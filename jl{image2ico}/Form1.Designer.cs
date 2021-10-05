namespace jl_image2ico
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPNG_inFile = new System.Windows.Forms.Button();
            this.pb256 = new System.Windows.Forms.PictureBox();
            this.btnICO_outFile = new System.Windows.Forms.Button();
            this.pb48 = new System.Windows.Forms.PictureBox();
            this.pb32 = new System.Windows.Forms.PictureBox();
            this.pb16 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb256)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb16)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPNG_inFile
            // 
            this.btnPNG_inFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPNG_inFile.Location = new System.Drawing.Point(305, 38);
            this.btnPNG_inFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnPNG_inFile.Name = "btnPNG_inFile";
            this.btnPNG_inFile.Size = new System.Drawing.Size(135, 24);
            this.btnPNG_inFile.TabIndex = 0;
            this.btnPNG_inFile.Text = "Select image file ...";
            this.btnPNG_inFile.UseVisualStyleBackColor = false;
            this.btnPNG_inFile.Click += new System.EventHandler(this.btnImage_inFile_Click);
            // 
            // pb256
            // 
            this.pb256.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pb256.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb256.Location = new System.Drawing.Point(14, 14);
            this.pb256.Margin = new System.Windows.Forms.Padding(4);
            this.pb256.Name = "pb256";
            this.pb256.Size = new System.Drawing.Size(256, 256);
            this.pb256.TabIndex = 5;
            this.pb256.TabStop = false;
            // 
            // btnICO_outFile
            // 
            this.btnICO_outFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnICO_outFile.Enabled = false;
            this.btnICO_outFile.Location = new System.Drawing.Point(303, 109);
            this.btnICO_outFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnICO_outFile.Name = "btnICO_outFile";
            this.btnICO_outFile.Size = new System.Drawing.Size(138, 24);
            this.btnICO_outFile.TabIndex = 6;
            this.btnICO_outFile.Text = "Save to ICO file ...";
            this.btnICO_outFile.UseVisualStyleBackColor = false;
            this.btnICO_outFile.Click += new System.EventHandler(this.btnICO_outFile_Click);
            // 
            // pb48
            // 
            this.pb48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pb48.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb48.Location = new System.Drawing.Point(296, 203);
            this.pb48.Margin = new System.Windows.Forms.Padding(4);
            this.pb48.Name = "pb48";
            this.pb48.Size = new System.Drawing.Size(48, 48);
            this.pb48.TabIndex = 7;
            this.pb48.TabStop = false;
            // 
            // pb32
            // 
            this.pb32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pb32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb32.Location = new System.Drawing.Point(370, 203);
            this.pb32.Margin = new System.Windows.Forms.Padding(4);
            this.pb32.Name = "pb32";
            this.pb32.Size = new System.Drawing.Size(32, 32);
            this.pb32.TabIndex = 7;
            this.pb32.TabStop = false;
            // 
            // pb16
            // 
            this.pb16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pb16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb16.Location = new System.Drawing.Point(428, 203);
            this.pb16.Margin = new System.Windows.Forms.Padding(4);
            this.pb16.Name = "pb16";
            this.pb16.Size = new System.Drawing.Size(16, 16);
            this.pb16.TabIndex = 7;
            this.pb16.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(361, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "↓";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 284);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "256×256";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "48×48";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 284);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "32×32";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 284);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "16×16";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 315);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb16);
            this.Controls.Add(this.pb32);
            this.Controls.Add(this.pb48);
            this.Controls.Add(this.btnICO_outFile);
            this.Controls.Add(this.btnPNG_inFile);
            this.Controls.Add(this.pb256);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "jl{image2ico}";
            ((System.ComponentModel.ISupportInitialize)(this.pb256)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPNG_inFile;
        private System.Windows.Forms.PictureBox pb256;
        private System.Windows.Forms.Button btnICO_outFile;
        private System.Windows.Forms.PictureBox pb48;
        private System.Windows.Forms.PictureBox pb32;
        private System.Windows.Forms.PictureBox pb16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

