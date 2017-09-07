using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3
{
    public partial class Form1 : Form
    {
        private OpenFileDialog selectFile = new OpenFileDialog();
        private SaveFileDialog saveFile = new SaveFileDialog();
        private Bitmap bmp;
        private Bitmap originalBmp;
        private BitmapData bmpData = null;
        private Rectangle area;
        IntPtr dataBegin;
        int numberOfBytes;
        byte[] RGBvalues;
        bool erosionEnabled = false;
        [DllImport("asm.DLL")]
        public static extern unsafe void binar(IntPtr Rval, IntPtr Gval, IntPtr Bval, int treshold, int lenght);
        //[DllImport("asm.DLL")]
        //public static extern unsafe void eros(IntPtr matrices, IntPtr RGBvalues, int lenght, int mLenght);

        public Form1()
        {
            InitializeComponent();
            selectFile.Title = "Select image to open";
            selectFile.Filter = "Image File (*.jpg, *.gif, *.png, *.bmp) |";
            saveFile.Title = "Save picture";
            saveFile.Filter = "JPEG File|*.jpg|GIF File|*.gif|PNG File|*.png|BMP File|*.bmp";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectFile.ShowDialog() == DialogResult.OK && selectFile.OpenFile() != null)
            {
                bmp = Bitmap.FromFile(selectFile.FileName) as Bitmap;
                originalBmp = new Bitmap(bmp);
                pictureBox.Image = bmp;
                pictureBox.Width = bmp.Width;
                pictureBox.Height = bmp.Height;
                area = new Rectangle(0, 0, bmp.Width, bmp.Height);
                numberOfBytes = bmp.Width * bmp.Height * 3;
                RGBvalues = new byte[numberOfBytes];
                binarization.Value = 0;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void binarization_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                int treshold = binarization.Value;

                bmpData = bmp.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);
                bmp.UnlockBits(bmpData);

                // Separation of RGB channels
                byte[] Rvalues = new byte[numberOfBytes / 3];
                byte[] Gvalues = new byte[numberOfBytes / 3];
                byte[] Bvalues = new byte[numberOfBytes / 3];
                for (int i = 0; i < numberOfBytes; i = i + 3)
                {
                    Rvalues[i / 3] = RGBvalues[i];
                    Gvalues[i / 3] = RGBvalues[i + 1];
                    Bvalues[i / 3] = RGBvalues[i + 2];
                }

                // Declaration of an unmanaged data segment
                IntPtr Rvalues_ = Marshal.AllocHGlobal(Rvalues.Length * sizeof(byte));
                IntPtr Gvalues_ = Marshal.AllocHGlobal(Gvalues.Length * sizeof(byte));
                IntPtr Bvalues_ = Marshal.AllocHGlobal(Bvalues.Length * sizeof(byte));
                Marshal.Copy(Rvalues, 0, Rvalues_, numberOfBytes / 3);
                Marshal.Copy(Gvalues, 0, Gvalues_, numberOfBytes / 3);
                Marshal.Copy(Bvalues, 0, Bvalues_, numberOfBytes / 3);


                // DLL support (binarization)
                binar(Rvalues_, Gvalues_, Bvalues_, treshold, numberOfBytes / 3);

                // Restore data from an unmanaged data segment
                Marshal.Copy(Rvalues_, Rvalues, 0, numberOfBytes / 3);
                Marshal.Copy(Gvalues_, Gvalues, 0, numberOfBytes / 3);
                Marshal.Copy(Bvalues_, Bvalues, 0, numberOfBytes / 3);
                Marshal.FreeHGlobal(Rvalues_);
                Marshal.FreeHGlobal(Gvalues_);
                Marshal.FreeHGlobal(Bvalues_);

                // Connecting RGB channels
                for (int i = 0; i < numberOfBytes; i = i + 3)
                {
                    RGBvalues[i] = Rvalues[i / 3];
                    RGBvalues[i + 1] = Gvalues[i / 3];
                    RGBvalues[i + 2] = Bvalues[i / 3];
                }


                bmpData = bmp.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;
                erosionEnabled = true;
            }
            else
                binarization.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bmp != null)
            {
                pictureBox.Image = originalBmp;
                bmp = new Bitmap(originalBmp);
                binarization.Value = 0;
                erosionEnabled = false;
                erosionValue.Value = 1;
            }
        }

        private void erosion_Click(object sender, EventArgs e)
        {
            if (erosionEnabled)
            {
                bmpData = bmp.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                byte[] RGBValuesCopy = new byte[numberOfBytes];



                int RGBWidth = bmp.Width * 3;

                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);
                for (int j = 1; j <= erosionValue.Value; j++)
                {
                    for (int i = 0; i < RGBvalues.Length; i++)
                    {
                        RGBValuesCopy[i] = RGBvalues[i];
                    }

                    //middle
                    for (int i = RGBWidth + 3; i < RGBvalues.Length - RGBWidth - 3; i += 3)
                    {
                        if (((i + 3) % RGBWidth) == 0)
                        {
                            i += 3;
                            continue;
                        }
                        if (RGBvalues[i + 3] == 255 || RGBvalues[i - 3] == 255 || RGBvalues[i - RGBWidth] == 255 || RGBvalues[i - RGBWidth - 3] == 255 || RGBvalues[i - RGBWidth + 3] == 255 || RGBvalues[i + RGBWidth] == 255 || RGBvalues[i + RGBWidth - 3] == 255 || RGBvalues[i + RGBWidth + 3] == 255)
                        {
                            RGBValuesCopy[i] = 255;
                            RGBValuesCopy[i + 1] = 255;
                            RGBValuesCopy[i + 2] = 255;
                        }

                    }
                    //upper edge
                    for (int i = 4; i < RGBWidth - 3; i += 3)
                    {
                        if (RGBvalues[i + 3] == 255 || RGBvalues[i - 3] == 255 || RGBvalues[i + RGBWidth] == 255 || RGBvalues[i + RGBWidth - 3] == 255 || RGBvalues[i + RGBWidth + 3] == 255)
                        {
                            RGBValuesCopy[i] = 255;
                            RGBValuesCopy[i + 1] = 255;
                            RGBValuesCopy[i + 2] = 255;
                        }
                    }
                    //bottom edge
                    for (int i = RGBvalues.Length - RGBWidth + 3; i < RGBvalues.Length - 3; i += 3)
                    {
                        if (RGBvalues[i + 3] == 255 || RGBvalues[i - 3] == 255 || RGBvalues[i - RGBWidth] == 255 || RGBvalues[i - RGBWidth - 3] == 255 || RGBvalues[i - RGBWidth + 3] == 255)
                        {
                            RGBValuesCopy[i] = 255;
                            RGBValuesCopy[i + 1] = 255;
                            RGBValuesCopy[i + 2] = 255;
                        }
                    }
                    //left edge
                    for (int i = RGBWidth; i < RGBvalues.Length - RGBWidth; i += RGBWidth)
                    {
                        if (RGBvalues[i + 3] == 255 || RGBvalues[i - RGBWidth] == 255 || RGBvalues[i - RGBWidth + 3] == 255 || RGBvalues[i + RGBWidth] == 255 || RGBvalues[i + RGBWidth + 3] == 255)
                        {
                            RGBValuesCopy[i] = 255;
                            RGBValuesCopy[i + 1] = 255;
                            RGBValuesCopy[i + 2] = 255;
                        }
                    }
                    //right edge
                    for (int i = 2*RGBWidth - 3; i < RGBvalues.Length - RGBWidth; i += RGBWidth)
                    {
                        if (RGBvalues[i - 3] == 255 || RGBvalues[i - RGBWidth] == 255 || RGBvalues[i - RGBWidth - 3] == 255 || RGBvalues[i + RGBWidth] == 255 || RGBvalues[i + RGBWidth - 3] == 255)
                        {
                            RGBValuesCopy[i] = 255;
                            RGBValuesCopy[i + 1] = 255;
                            RGBValuesCopy[i + 2] = 255;
                        }
                    }
                    int s = 0;
                    //upper left corner
                    if (RGBvalues[s + 3] == 255|| RGBvalues[s + RGBWidth] == 255 || RGBvalues[s + RGBWidth + 3] == 255)
                    {
                        RGBValuesCopy[s] = 255;
                        RGBValuesCopy[s + 1] = 255;
                        RGBValuesCopy[s + 2] = 255;
                    }
                    s = RGBWidth - 3;
                    //uper right corner
                    if (RGBvalues[s - 3] == 255 || RGBvalues[s + RGBWidth - 3] == 255 || RGBvalues[s + RGBWidth] == 255)
                    {
                        RGBValuesCopy[s] = 255;
                        RGBValuesCopy[s + 1] = 255;
                        RGBValuesCopy[s + 2] = 255;
                    }
                    //bottom left corner
                    s = RGBvalues.Length - RGBWidth;
                    if (RGBvalues[s + 3] == 255 || RGBvalues[s - RGBWidth] == 255 || RGBvalues[s - RGBWidth + 3] == 255)
                    {
                        RGBValuesCopy[s] = 255;
                        RGBValuesCopy[s + 1] = 255;
                        RGBValuesCopy[s + 2] = 255;
                    }
                    //bottom right corner
                    s = RGBvalues.Length - 3;
                    if (RGBvalues[s - 3] == 255 || RGBvalues[s - RGBWidth] == 255 || RGBvalues[s - RGBWidth - 3] == 255)
                    {
                        RGBValuesCopy[s] = 255;
                        RGBValuesCopy[s + 1] = 255;
                        RGBValuesCopy[s + 2] = 255;
                    }


                    for (int i = 0; i < RGBvalues.Length; i++)
                    {
                        RGBvalues[i] = RGBValuesCopy[i];
                    }
                }
                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;

            }
            else
                erosionValue.Value = 1;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                DialogResult result = saveFile.ShowDialog();
                if (result == DialogResult.OK && saveFile.FileName != "")
                {
                    // Saving image
                    pictureBox.Image.Save(saveFile.FileName);
                }
            }
        }
    }
}
