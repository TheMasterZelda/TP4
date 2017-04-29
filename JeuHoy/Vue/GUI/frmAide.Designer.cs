namespace JeuHoy.Vue
{
    partial class frmAide
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
            this.picRetour = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRetour)).BeginInit();
            this.SuspendLayout();
            // 
            // picRetour
            // 
            this.picRetour.BackColor = System.Drawing.Color.Transparent;
            this.picRetour.Image = global::JeuHoy.Properties.Resources.edit_undo;
            this.picRetour.Location = new System.Drawing.Point(34, 705);
            this.picRetour.Name = "picRetour";
            this.picRetour.Size = new System.Drawing.Size(50, 50);
            this.picRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRetour.TabIndex = 2;
            this.picRetour.TabStop = false;
            this.picRetour.Click += new System.EventHandler(this.picRetour_Click);
            this.picRetour.MouseLeave += new System.EventHandler(this.picRetour_MouseLeave);
            this.picRetour.MouseHover += new System.EventHandler(this.picRetour_MouseHover);
            // 
            // frmAide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JeuHoy.Properties.Resources.AideTuto;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1310, 780);
            this.Controls.Add(this.picRetour);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAide";
            this.Text = "frmAide";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picRetour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRetour;

    }
}