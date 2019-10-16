namespace SayisalGoruntuOdev1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rsmAc = new System.Windows.Forms.Button();
            this.ilr = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(320, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(468, 368);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rsmAc
            // 
            this.rsmAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rsmAc.Location = new System.Drawing.Point(92, 169);
            this.rsmAc.Name = "rsmAc";
            this.rsmAc.Size = new System.Drawing.Size(155, 33);
            this.rsmAc.TabIndex = 1;
            this.rsmAc.Text = "RESİM AÇ";
            this.rsmAc.UseVisualStyleBackColor = true;
            this.rsmAc.Click += new System.EventHandler(this.rsmAc_Click);
            // 
            // ilr
            // 
            this.ilr.BackColor = System.Drawing.Color.White;
            this.ilr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ilr.ForeColor = System.Drawing.Color.Red;
            this.ilr.Location = new System.Drawing.Point(666, 399);
            this.ilr.Name = "ilr";
            this.ilr.Size = new System.Drawing.Size(122, 39);
            this.ilr.TabIndex = 2;
            this.ilr.Text = "İLERİ";
            this.ilr.UseVisualStyleBackColor = false;
            this.ilr.Click += new System.EventHandler(this.ilr_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ilr);
            this.Controls.Add(this.rsmAc);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button rsmAc;
        private System.Windows.Forms.Button ilr;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

