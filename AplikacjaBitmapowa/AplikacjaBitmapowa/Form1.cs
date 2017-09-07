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

namespace AplikacjaBitmapowa
{
    public partial class MainForm : Form
    {
        private OpenFileDialog selectFile = new OpenFileDialog();
        private Bitmap bmp;
        private Bitmap originalBmp;
        private BitmapData bmpData = null;
        private Rectangle obszar;
        IntPtr dataBegin;
        int numberOfBytes;
        byte[] RGBvalues;
        double saturationValue = 0;
        int brightnessValue = 0;
        int colorValue = 0;
        int contrastValue = 0;


        public MainForm()
        {
            InitializeComponent();
            selectFile.Title = "Select image to open";
            selectFile.Filter = "Image File (*.jpg, *.gif, *.png, *.bmp) |";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(selectFile.ShowDialog()==DialogResult.OK && selectFile.OpenFile() != null)
            {
                bmp = Bitmap.FromFile(selectFile.FileName) as Bitmap;
                originalBmp = new Bitmap(bmp);
                pictureBox.Image = bmp;
                pictureBox.Width = bmp.Width;
                pictureBox.Height = bmp.Height;
                obszar = new Rectangle(0, 0, bmp.Width, bmp.Height);
                numberOfBytes = bmp.Width * bmp.Height * 3;
                RGBvalues = new byte[numberOfBytes];
                saturation.Value = 0;
                saturationValue = 0;
                brightness.Value = 0;
                brightnessValue = 0;
                color.Value = 0;
                colorValue = 0;
                contrast.Value = 0;
                contrastValue = 0;
                binarization.Value = 0;
            }
        }
        
        //Switch to original bitmap
        private void button1_Click(object sender, EventArgs e)
        {
            if(originalBmp!=null)
            {
                pictureBox.Image = originalBmp;
                pictureBox.Width = originalBmp.Width;
                pictureBox.Height = originalBmp.Height;
                bmp = new Bitmap(originalBmp);
                saturation.Value = 0;
                saturationValue = 0;
                brightness.Value = 0;
                brightnessValue = 0;
                color.Value = 0;
                colorValue = 0;
                contrast.Value = 0;
                contrastValue = 0;
                binarization.Value = 0;
            }
        }

        private void negative_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

                for (int i = 0; i < RGBvalues.Length; i += 3)
                {
                    RGBvalues[i] = (byte)(255 - RGBvalues[i]);
                    RGBvalues[i + 1] = (byte)(255 - RGBvalues[i + 1]);
                    RGBvalues[i + 2] = (byte)(255 - RGBvalues[i + 2]);
                }

                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;
            }
        }


        private void brightness_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                int brightnessChangeValue = 0;
                if (brightness.Value != brightnessValue)
                {
                    brightnessChangeValue = brightness.Value - brightnessValue;
                }
                else
                    return;
                double R, G, B, H = 0, S, V;
                double min, max, r, f;
                int rr;
                double a, b, c;
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

                for (int i = 0; i < RGBvalues.Length; i += 3)
                {
                    R = (double)RGBvalues[i];
                    G = (double)RGBvalues[i + 1];
                    B = (double)RGBvalues[i + 2];

                    //convert RGB to HSV
                    min = Math.Min(R, Math.Min(G, B));
                    max = Math.Max(R, Math.Max(G, B));

                    V = max;
                    if (min == max)
                    {
                        S = 0;
                        H = 0;
                    }
                    else
                    {
                        r = max - min;
                        S = r / max;

                        if (R == max)
                            H = 60 * (G - B) / r;
                        if (G == max)
                            H = 60 * (B - R) / r + 120;
                        if (B == max)
                            H = 60 * (R - G) / r + 240;
                        if (H < 0)
                            H = H + 360;
                    }

                    //changing value (brightness)
                    V += brightnessChangeValue;
                    if (V < 0)
                        V = 0;
                    if (V > 255)
                        V = 255;


                    //convert HSV to RGB
                    rr = (int)H / 60;
                    f = H / 60 - rr;

                    a = V * (1 - S);
                    b = V * (1 - S * f);
                    c = V * (1 - S * (1 - f));

                    switch (rr)
                    {
                        case 0:
                            {
                                R = V;
                                G = c;
                                B = a;
                                break;
                            }
                        case 1:
                            {
                                R = b;
                                G = V;
                                B = a;
                                break;
                            }
                        case 2:
                            {
                                R = a;
                                G = V;
                                B = c;
                                break;
                            }
                        case 3:
                            {
                                R = a;
                                G = b;
                                B = V;
                                break;
                            }
                        case 4:
                            {
                                R = c;
                                G = a;
                                B = V;
                                break;
                            }
                        case 5:
                            {
                                R = V;
                                G = a;
                                B = b;
                                break;
                            }
                    }

                    RGBvalues[i] = (byte)R;
                    RGBvalues[i + 1] = (byte)G;
                    RGBvalues[i + 2] = (byte)B;
                }


                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;


                brightnessValue = brightness.Value;
            }
            else brightness.Value = 0;
        }

        private void saturation_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                double saturationChangeValue = 0;
                if (saturation.Value != saturationValue)
                {
                    saturationChangeValue = (saturation.Value - saturationValue) / 100;
                }
                else
                    return;
                double R, G, B, H = 0, S, V;
                double min, max, r, f;
                int rr;
                double a, b, c;
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

                for (int i = 0; i < RGBvalues.Length; i += 3)
                {
                    B = (double)RGBvalues[i];
                    G = (double)RGBvalues[i + 1];
                    R = (double)RGBvalues[i + 2];

                    //convert RGB to HSV
                    min = Math.Min(R, Math.Min(G, B));
                    max = Math.Max(R, Math.Max(G, B));

                    V = max;
                    if (min == max)
                    {
                        S = 0;
                        H = 0;
                    }
                    else
                    {
                        r = max - min;
                        S = r / max;

                        if (R == max)
                            H = 60 * (G - B) / r;
                        if (G == max)
                            H = 60 * (B - R) / r + 120;
                        if (B == max)
                            H = 60 * (R - G) / r + 240;
                        if (H < 0)
                            H = H + 360;
                    }

                    //changing saturation
                    S += saturationChangeValue;
                    if (S < 0)
                        S = 0;
                    if (S > 1)
                        S = 1;


                    //convert HSV to RGB
                    rr = (int)H / 60;
                    f = H / 60 - rr;

                    a = V * (1 - S);
                    b = V * (1 - S * f);
                    c = V * (1 - S * (1 - f));

                    switch (rr)
                    {
                        case 0:
                            {
                                R = V;
                                G = c;
                                B = a;
                                break;
                            }
                        case 1:
                            {
                                R = b;
                                G = V;
                                B = a;
                                break;
                            }
                        case 2:
                            {
                                R = a;
                                G = V;
                                B = c;
                                break;
                            }
                        case 3:
                            {
                                R = a;
                                G = b;
                                B = V;
                                break;
                            }
                        case 4:
                            {
                                R = c;
                                G = a;
                                B = V;
                                break;
                            }
                        case 5:
                            {
                                R = V;
                                G = a;
                                B = b;
                                break;
                            }
                    }

                    RGBvalues[i] = (byte)R;
                    RGBvalues[i + 1] = (byte)G;
                    RGBvalues[i + 2] = (byte)B;
                }


                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;

                saturationValue = saturation.Value;
            }
            else
                saturation.Value = 0;
        }

        private void color_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                int colorChangeValue = 0;
                if (color.Value != colorValue)
                {
                    colorChangeValue = color.Value - colorValue;
                }                
                else
                    return;

                double R, G, B, H = 0, S, V;
                double min, max, r, f;
                int rr;
                double a, b, c;
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

                for (int i = 0; i < RGBvalues.Length; i += 3)
                {
                    R = (double)RGBvalues[i];
                    G = (double)RGBvalues[i + 1];
                    B = (double)RGBvalues[i + 2];

                    //convert RGB to HSV
                    min = Math.Min(R, Math.Min(G, B));
                    max = Math.Max(R, Math.Max(G, B));

                    V = max;
                    if (min == max)
                    {
                        S = 0;
                        H = 0;
                    }
                    else
                    {
                        r = max - min;
                        S = r / max;

                        if (R == max)
                            H = 60 * (G - B) / r;
                        if (G == max)
                            H = 60 * (B - R) / r + 120;
                        if (B == max)
                            H = 60 * (R - G) / r + 240;
                        if (H < 0)
                            H = H + 360;
                    }

                    //changing Hue (color)
                    H += colorChangeValue;
                    if (H < 0)
                        H = 0;
                    if (H > 360)
                        H = 360;


                    //convert HSV to RGB
                    rr = (int)(H / 60);
                    f = H / 60 - rr;

                    a = V * (1 - S);
                    b = V * (1 - S * f);
                    c = V * (1 - S * (1 - f));

                    switch (rr)
                    {
                        case 0:
                            {
                                R = V;
                                G = c;
                                B = a;
                                break;
                            }
                        case 1:
                            {
                                R = b;
                                G = V;
                                B = a;
                                break;
                            }
                        case 2:
                            {
                                R = a;
                                G = V;
                                B = c;
                                break;
                            }
                        case 3:
                            {
                                R = a;
                                G = b;
                                B = V;
                                break;
                            }
                        case 4:
                            {
                                R = c;
                                G = a;
                                B = V;
                                break;
                            }
                        case 5:
                            {
                                R = V;
                                G = a;
                                B = b;
                                break;
                            }
                    }

                    RGBvalues[i] = (byte)R;
                    RGBvalues[i + 1] = (byte)G;
                    RGBvalues[i + 2] = (byte)B;
                }


                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;


                colorValue = color.Value;
            }
            else
                color.Value = 0;
        }

        private void contrast_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                int contrastValueChanged = 0;
                if(contrast.Value != contrastValue)
                {
                    contrastValueChanged = contrast.Value - contrastValue;
                }
                else
                {
                    return;
                }

                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

                double R = 0, G = 0, B = 0;
                double contrastLevel = Math.Pow((100.0 + contrastValueChanged) / 100.0, 2);

                for (int i = 0; i < RGBvalues.Length; i += 3)
                {
                    R = ((((RGBvalues[i] / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0;
                    G = ((((RGBvalues[i+1] / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0;
                    B = ((((RGBvalues[i+2] / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0;

                    if (R > 255)
                        R = 255;
                    else if (R < 0)
                        R = 0;

                    if (G > 255)
                        G = 255;
                    else if (G < 0)
                        G = 0;

                    if (B > 255)
                        B = 255;
                    else if (B < 0)
                        B = 0;

                    RGBvalues[i] = (byte)R;
                    RGBvalues[i + 1] = (byte)G;
                    RGBvalues[i + 2] = (byte)B;
                }

                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;        

                contrastValue = contrast.Value;
            }
            else contrast.Value = 0;
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            if(bmp != null)
            {
                int[] histogramTable = new int[256];

                double R, G, B, V;
                double min, max;
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

                for (int i = 0; i < RGBvalues.Length; i += 3)
                {
                    R = (double)RGBvalues[i];
                    G = (double)RGBvalues[i + 1];
                    B = (double)RGBvalues[i + 2];
                    
                   // min = Math.Min(R, Math.Min(G, B));
                    max = Math.Max(R, Math.Max(G, B));

                    V = max;

                    histogramTable[(int)V] += 1;                 
                }
                
                bmp.UnlockBits(bmpData);




                Form2 histForm = new Form2(histogramTable);
                histForm.Show();
            }            
        }

        private void blurring_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                byte[] RGBValuesCopy = new byte[numberOfBytes];

                int RGBWidth = bmp.Width * 3;
               // int j = RGBWidth - 3;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);
                for (int i = RGBWidth + 3; i < RGBvalues.Length - RGBWidth - 3; i++)
                {
                    if (((i+3) % RGBWidth) == 0)
                    {
                        i += 5;
                        continue;
                    }

                    RGBValuesCopy[i] = (byte)((RGBvalues[i] + RGBvalues[i - 3] + RGBvalues[i + 3] + RGBvalues[i - RGBWidth] + RGBvalues[i - RGBWidth - 3] + RGBvalues[i - RGBWidth + 3] + RGBvalues[i + RGBWidth] + RGBvalues[i + RGBWidth - 3] + RGBvalues[i + RGBWidth + 3]) / 9);
                }
                for (int i = 0; i < RGBvalues.Length; i++)
                {
                    RGBvalues[i] = RGBValuesCopy[i];
                }

                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;
            }
        }

        private void sharpen_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                byte[] RGBValuesCopy = new byte[numberOfBytes];
                int RGBWidth = bmp.Width * 3;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);
                double result = 0;
                
                for (int i = RGBWidth + 3; i < RGBvalues.Length - RGBWidth - 3; i++)
                {
                    if (((i + 3) % RGBWidth) == 0)
                    {
                        i += 5;
                        continue;
                    }
                    result = ((5*RGBvalues[i] + (-1)*RGBvalues[i - 3] + (-1)*RGBvalues[i + 3] + (-1)*RGBvalues[i - RGBWidth] + (-1)* RGBvalues[i + RGBWidth])*1);
                    if (result > 255)
                        result = 255;
                    if (result < 0)
                        result = 0;
                    RGBValuesCopy[i] = (byte)result;
                }
                for(int i = 0;i<RGBvalues.Length;i++)
                {
                    RGBvalues[i] = RGBValuesCopy[i];
                }


                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;
            }
        }

        private void edgeDetection_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                byte[] RGBValuesCopy = new byte[numberOfBytes];
                int RGBWidth = bmp.Width * 3;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);
                double result = 0;

                for (int i = RGBWidth + 3; i < RGBvalues.Length - RGBWidth - 3; i++)
                {
                    if (((i + 3) % RGBWidth) == 0)
                    {
                        i += 5;
                        continue;
                    }
                    result = ((4 * RGBvalues[i] + (-1) * RGBvalues[i - 3] + (-1) * RGBvalues[i + 3] + (-1) * RGBvalues[i - RGBWidth] + (-1) * RGBvalues[i + RGBWidth]) * 1);
                    if (result > 255)
                        result = 255;
                    if (result < 0)
                        result = 0;
                    RGBValuesCopy[i] = (byte)result;
                }
                for (int i = 0; i < RGBvalues.Length; i++)
                {
                    RGBvalues[i] = RGBValuesCopy[i];
                }


                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;
            }
        }

        private void binarization_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                int treshold = binarization.Value;
                double brightness = 0;

                bmpData = bmp.LockBits(obszar, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                dataBegin = bmpData.Scan0;
                Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

                for (int i = 0; i < RGBvalues.Length; i += 3)
                {
                    brightness = RGBvalues[i] * 0.299 + RGBvalues[i+1] * 0.587 + RGBvalues[i+2] * 0.114;

                    if(brightness < treshold)
                    {
                        RGBvalues[i] = 0;
                        RGBvalues[i+1] = 0;
                        RGBvalues[i+2] = 0;
                    }
                    else
                    {
                        RGBvalues[i] = 255;
                        RGBvalues[i + 1] = 255;
                        RGBvalues[i + 2] = 255;
                    }
                }

                Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
                bmp.UnlockBits(bmpData);

                pictureBox.Image = bmp;
            }
            else
                binarization.Value = 0;
        }
    }
}
