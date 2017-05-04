namespace JeuHoy.Vue
{
    partial class frmJeu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJeu));
            this.lblNbPosition = new System.Windows.Forms.Label();
            this.lblSep = new System.Windows.Forms.Label();
            this.lblFigureEnCours = new System.Windows.Forms.Label();
            this.picPositionAFaire = new System.Windows.Forms.PictureBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.tmrTemps = new System.Windows.Forms.Timer(this.components);
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.picRetour = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTemps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPositionAFaire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetour)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNbPosition
            // 
            this.lblNbPosition.AutoSize = true;
            this.lblNbPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblNbPosition.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbPosition.Location = new System.Drawing.Point(642, -92);
            this.lblNbPosition.Name = "lblNbPosition";
            this.lblNbPosition.Size = new System.Drawing.Size(69, 57);
            this.lblNbPosition.TabIndex = 13;
            this.lblNbPosition.Text = "10";
            // 
            // lblSep
            // 
            this.lblSep.AutoSize = true;
            this.lblSep.BackColor = System.Drawing.Color.Transparent;
            this.lblSep.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSep.Location = new System.Drawing.Point(582, -92);
            this.lblSep.Name = "lblSep";
            this.lblSep.Size = new System.Drawing.Size(36, 57);
            this.lblSep.TabIndex = 12;
            this.lblSep.Text = "/";
            // 
            // lblFigureEnCours
            // 
            this.lblFigureEnCours.AutoSize = true;
            this.lblFigureEnCours.BackColor = System.Drawing.Color.Transparent;
            this.lblFigureEnCours.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureEnCours.Location = new System.Drawing.Point(535, -92);
            this.lblFigureEnCours.Name = "lblFigureEnCours";
            this.lblFigureEnCours.Size = new System.Drawing.Size(41, 57);
            this.lblFigureEnCours.TabIndex = 11;
            this.lblFigureEnCours.Text = "1";
            // 
            // picPositionAFaire
            // 
            this.picPositionAFaire.BackColor = System.Drawing.Color.Transparent;
            this.picPositionAFaire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPositionAFaire.Location = new System.Drawing.Point(129, 0);
            this.picPositionAFaire.Name = "picPositionAFaire";
            this.picPositionAFaire.Size = new System.Drawing.Size(768, 777);
            this.picPositionAFaire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPositionAFaire.TabIndex = 10;
            this.picPositionAFaire.TabStop = false;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblPosition.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblPosition.Location = new System.Drawing.Point(1282, 120);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(53, 57);
            this.lblPosition.TabIndex = 16;
            this.lblPosition.Text = "0";
            // 
            // tmrTemps
            // 
            this.tmrTemps.Enabled = true;
            this.tmrTemps.Interval = 1000;
            this.tmrTemps.Tick += new System.EventHandler(this.tmrTemps_Tick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1361, 764);
            this.shapeContainer1.TabIndex = 17;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.White;
            this.lineShape4.BorderWidth = 5;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 596;
            this.lineShape4.X2 = 892;
            this.lineShape4.Y1 = 404;
            this.lineShape4.Y2 = 404;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.White;
            this.lineShape3.BorderWidth = 5;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 540;
            this.lineShape3.X2 = 836;
            this.lineShape3.Y1 = 390;
            this.lineShape3.Y2 = 390;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.White;
            this.lineShape2.BorderWidth = 5;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 1050;
            this.lineShape2.X2 = 1347;
            this.lineShape2.Y1 = 256;
            this.lineShape2.Y2 = 256;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.BorderWidth = 5;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 1050;
            this.lineShape1.X2 = 1346;
            this.lineShape1.Y1 = 96;
            this.lineShape1.Y2 = 96;
            // 
            // picRetour
            // 
            this.picRetour.BackColor = System.Drawing.Color.Transparent;
            this.picRetour.Image = global::JeuHoy.Properties.Resources.edit_undo;
            this.picRetour.Location = new System.Drawing.Point(1290, 702);
            this.picRetour.Name = "picRetour";
            this.picRetour.Size = new System.Drawing.Size(50, 50);
            this.picRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRetour.TabIndex = 18;
            this.picRetour.TabStop = false;
            this.picRetour.Click += new System.EventHandler(this.picRetour_Click);
            this.picRetour.MouseLeave += new System.EventHandler(this.picRetour_MouseLeave);
            this.picRetour.MouseHover += new System.EventHandler(this.picRetour_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(1023, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 57);
            this.label4.TabIndex = 19;
            this.label4.Text = "Position(s) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(1023, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 57);
            this.label2.TabIndex = 21;
            this.label2.Text = "Point(s) :";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.BackColor = System.Drawing.Color.Transparent;
            this.lblPoint.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblPoint.Location = new System.Drawing.Point(1282, 177);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(53, 57);
            this.lblPoint.TabIndex = 20;
            this.lblPoint.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(1023, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 57);
            this.label5.TabIndex = 23;
            this.label5.Text = "Temps :";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.BackColor = System.Drawing.Color.Transparent;
            this.lblTemps.Font = new System.Drawing.Font("Matura MT Script Capitals", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemps.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblTemps.Location = new System.Drawing.Point(1233, 9);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(73, 57);
            this.lblTemps.TabIndex = 22;
            this.lblTemps.Text = "20";
            // 
            // frmJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1361, 764);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTemps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picRetour);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblNbPosition);
            this.Controls.Add(this.lblSep);
            this.Controls.Add(this.lblFigureEnCours);
            this.Controls.Add(this.picPositionAFaire);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmJeu";
            this.Text = "frmJeu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picPositionAFaire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNbPosition;
        private System.Windows.Forms.Label lblSep;
        private System.Windows.Forms.Label lblFigureEnCours;
        private System.Windows.Forms.PictureBox picPositionAFaire;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Timer tmrTemps;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.PictureBox picRetour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTemps;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
    }
}