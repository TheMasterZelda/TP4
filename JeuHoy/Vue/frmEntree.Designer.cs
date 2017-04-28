namespace JeuHoy.Vue
{
    partial class frmEntree
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntree));
            this.picQuitter = new System.Windows.Forms.PictureBox();
            this.picJouer = new System.Windows.Forms.PictureBox();
            this.picEntrainement = new System.Windows.Forms.PictureBox();
            this.picAide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJouer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEntrainement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAide)).BeginInit();
            this.SuspendLayout();
            // 
            // picQuitter
            // 
            this.picQuitter.BackColor = System.Drawing.Color.Transparent;
            this.picQuitter.Image = ((System.Drawing.Image)(resources.GetObject("picQuitter.Image")));
            this.picQuitter.Location = new System.Drawing.Point(1215, 678);
            this.picQuitter.Name = "picQuitter";
            this.picQuitter.Size = new System.Drawing.Size(50, 50);
            this.picQuitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuitter.TabIndex = 2;
            this.picQuitter.TabStop = false;
            this.picQuitter.Click += new System.EventHandler(this.picQuitter_Click);
            this.picQuitter.MouseLeave += new System.EventHandler(this.pic_MouseLeave);
            this.picQuitter.MouseHover += new System.EventHandler(this.pic_MouseHover);
            // 
            // picJouer
            // 
            this.picJouer.BackColor = System.Drawing.Color.Transparent;
            this.picJouer.Image = ((System.Drawing.Image)(resources.GetObject("picJouer.Image")));
            this.picJouer.Location = new System.Drawing.Point(168, 624);
            this.picJouer.Name = "picJouer";
            this.picJouer.Size = new System.Drawing.Size(261, 135);
            this.picJouer.TabIndex = 4;
            this.picJouer.TabStop = false;
            this.picJouer.Click += new System.EventHandler(this.picJouer_Click);
            this.picJouer.MouseLeave += new System.EventHandler(this.pic_MouseLeave);
            this.picJouer.MouseHover += new System.EventHandler(this.pic_MouseHover);
            // 
            // picEntrainement
            // 
            this.picEntrainement.BackColor = System.Drawing.Color.Transparent;
            this.picEntrainement.Image = ((System.Drawing.Image)(resources.GetObject("picEntrainement.Image")));
            this.picEntrainement.Location = new System.Drawing.Point(455, 639);
            this.picEntrainement.Name = "picEntrainement";
            this.picEntrainement.Size = new System.Drawing.Size(443, 104);
            this.picEntrainement.TabIndex = 5;
            this.picEntrainement.TabStop = false;
            this.picEntrainement.Click += new System.EventHandler(this.picEntrainement_Click);
            this.picEntrainement.MouseLeave += new System.EventHandler(this.pic_MouseLeave);
            this.picEntrainement.MouseHover += new System.EventHandler(this.pic_MouseHover);
            // 
            // picAide
            // 
            this.picAide.BackColor = System.Drawing.Color.Transparent;
            this.picAide.Image = global::JeuHoy.Properties.Resources.Aide;
            this.picAide.Location = new System.Drawing.Point(947, 644);
            this.picAide.Name = "picAide";
            this.picAide.Size = new System.Drawing.Size(192, 83);
            this.picAide.TabIndex = 6;
            this.picAide.TabStop = false;
            this.picAide.Click += new System.EventHandler(this.picAide_Click);
            this.picAide.MouseLeave += new System.EventHandler(this.pic_MouseLeave);
            this.picAide.MouseHover += new System.EventHandler(this.pic_MouseHover);
            // 
            // frmEntree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1305, 780);
            this.Controls.Add(this.picAide);
            this.Controls.Add(this.picEntrainement);
            this.Controls.Add(this.picJouer);
            this.Controls.Add(this.picQuitter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEntree";
            this.Text = "Hoy !";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntree_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picQuitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJouer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEntrainement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picQuitter;
        private System.Windows.Forms.PictureBox picJouer;
        private System.Windows.Forms.PictureBox picEntrainement;
        private System.Windows.Forms.PictureBox picAide;
    }
}

