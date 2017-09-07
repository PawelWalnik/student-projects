namespace AplikacjaBitmapowa
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.edgeDetection = new System.Windows.Forms.Button();
            this.sharpen = new System.Windows.Forms.Button();
            this.blurring = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.binarization = new System.Windows.Forms.TrackBar();
            this.histogram = new System.Windows.Forms.Button();
            this.negative = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contrast = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.saturation = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.color = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.brightness = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binarization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1591F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1878, 989);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.edgeDetection);
            this.groupBox.Controls.Add(this.sharpen);
            this.groupBox.Controls.Add(this.blurring);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.binarization);
            this.groupBox.Controls.Add(this.histogram);
            this.groupBox.Controls.Add(this.negative);
            this.groupBox.Controls.Add(this.button1);
            this.groupBox.Controls.Add(this.contrast);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.saturation);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.color);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.brightness);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(281, 983);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Settings";
            // 
            // edgeDetection
            // 
            this.edgeDetection.Location = new System.Drawing.Point(7, 595);
            this.edgeDetection.Name = "edgeDetection";
            this.edgeDetection.Size = new System.Drawing.Size(268, 26);
            this.edgeDetection.TabIndex = 15;
            this.edgeDetection.Text = "Edge detection";
            this.edgeDetection.UseVisualStyleBackColor = true;
            this.edgeDetection.Click += new System.EventHandler(this.edgeDetection_Click);
            // 
            // sharpen
            // 
            this.sharpen.Location = new System.Drawing.Point(6, 549);
            this.sharpen.Name = "sharpen";
            this.sharpen.Size = new System.Drawing.Size(268, 26);
            this.sharpen.TabIndex = 14;
            this.sharpen.Text = "Sharpen";
            this.sharpen.UseVisualStyleBackColor = true;
            this.sharpen.Click += new System.EventHandler(this.sharpen_Click);
            // 
            // blurring
            // 
            this.blurring.Location = new System.Drawing.Point(6, 505);
            this.blurring.Name = "blurring";
            this.blurring.Size = new System.Drawing.Size(268, 26);
            this.blurring.TabIndex = 13;
            this.blurring.Text = "Blurring";
            this.blurring.UseVisualStyleBackColor = true;
            this.blurring.Click += new System.EventHandler(this.blurring_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Binarization:";
            // 
            // binarization
            // 
            this.binarization.Location = new System.Drawing.Point(15, 458);
            this.binarization.Maximum = 255;
            this.binarization.Name = "binarization";
            this.binarization.Size = new System.Drawing.Size(260, 56);
            this.binarization.TabIndex = 11;
            this.binarization.MouseCaptureChanged += new System.EventHandler(this.binarization_MouseCaptureChanged);
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(7, 394);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(268, 26);
            this.histogram.TabIndex = 10;
            this.histogram.Text = "Histogram";
            this.histogram.UseVisualStyleBackColor = true;
            this.histogram.Click += new System.EventHandler(this.histogram_Click);
            // 
            // negative
            // 
            this.negative.Location = new System.Drawing.Point(7, 350);
            this.negative.Name = "negative";
            this.negative.Size = new System.Drawing.Size(268, 26);
            this.negative.TabIndex = 9;
            this.negative.Text = "Negative";
            this.negative.UseVisualStyleBackColor = true;
            this.negative.Click += new System.EventHandler(this.negative_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Undo any changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contrast
            // 
            this.contrast.Location = new System.Drawing.Point(6, 287);
            this.contrast.Maximum = 100;
            this.contrast.Minimum = -100;
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(269, 56);
            this.contrast.TabIndex = 7;
            this.contrast.MouseCaptureChanged += new System.EventHandler(this.contrast_MouseCaptureChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contrast:";
            // 
            // saturation
            // 
            this.saturation.Location = new System.Drawing.Point(6, 225);
            this.saturation.Maximum = 100;
            this.saturation.Minimum = -100;
            this.saturation.Name = "saturation";
            this.saturation.Size = new System.Drawing.Size(269, 56);
            this.saturation.TabIndex = 5;
            this.saturation.MouseCaptureChanged += new System.EventHandler(this.saturation_MouseCaptureChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saturation:";
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(6, 156);
            this.color.Maximum = 360;
            this.color.Minimum = -360;
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(269, 56);
            this.color.TabIndex = 3;
            this.color.MouseCaptureChanged += new System.EventHandler(this.color_MouseCaptureChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color:";
            // 
            // brightness
            // 
            this.brightness.Location = new System.Drawing.Point(6, 97);
            this.brightness.Maximum = 255;
            this.brightness.Minimum = -255;
            this.brightness.Name = "brightness";
            this.brightness.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.brightness.Size = new System.Drawing.Size(269, 56);
            this.brightness.TabIndex = 1;
            this.brightness.MouseCaptureChanged += new System.EventHandler(this.brightness_MouseCaptureChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brightness:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(290, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1585, 983);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(519, 494);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Aplikacja Bitmapowa";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binarization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TrackBar brightness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar color;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar saturation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar contrast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button negative;
        private System.Windows.Forms.Button histogram;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar binarization;
        private System.Windows.Forms.Button edgeDetection;
        private System.Windows.Forms.Button sharpen;
        private System.Windows.Forms.Button blurring;
    }
}

