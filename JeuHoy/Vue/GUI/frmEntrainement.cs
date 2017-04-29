using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using JeuHoy.Presenter;
using Microsoft.VisualBasic.PowerPacks;

namespace JeuHoy.Vue
{
    /// <summary>
    /// Auteur: Hugo St-Louis
    /// Description: Permet de faire l'entrainement des différentes figures de danse.
    /// Date: 26/04/2014
    /// </summary>
    public partial class frmEntrainement : Form, IVue
    {
        private Entrainement _entrainement;

        public event EventHandler Fermeture;
        public event EventHandler ChangerFigure;
        public event EventHandler Apprendre;
        public event PaintEventHandler DessinSquelettePaint;
        public event EventHandler Retour;
        public event EventHandler RetourMouseHover;
        public event EventHandler RetourMouseLeave;

        public string Console
        {
            get
            {
                return txtConsole.Text;
            }

            set
            {
                txtConsole.Text += "\r\n" + value;
            }
        }

        public string sPosition
        {
            get
            {
                return lblFigureEnCours.Text;
            }

            set
            {
                lblFigureEnCours.Text = value;
            }
        }

        public string NbPosition
        {
            get
            {
                return lblNbPosition.Text;
            }

            set
            {
                lblNbPosition.Text = value;
            }
        }

        public Image PositionAFaire
        {
            get
            {
                return picPositionAFaire.Image;
            }

            set
            {
                picPositionAFaire.Image = value;
            }
        }

        public PictureBox PicKinect
        {
            get
            {
                return picKinect;
            }

            set
            {
                picKinect = value;
            }
        }

        public Panel DessinSquelette
        {
            get
            {
                return pDessinSquelette;
            }

            set
            {
                pDessinSquelette = value;
            }
        }

        public ShapeContainer ShapeContainer
        {
            get
            {
                return shapeContainer1;
            }

            set
            {
                shapeContainer1 = value;
            }
        }

        public Form FormEntrainement
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public frmEntrainement()
        {
            InitializeComponent();
            _entrainement = new Entrainement(this);
        }

        /// <summary>
        /// Ferme la fenêtre lorsqu'on appuie sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            Fermeture(sender, e);
        }

        /// <summary>
        /// Lorsqu'on appuie sur le bouton suivant ou précédent, modifier la figure en conséquence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClickChangerFigure_Click(object sender, EventArgs e)
        {
            ChangerFigure(sender, e);
        }

        private void btnApprendre_Click(object sender, EventArgs e)
        {
            Apprendre(sender, e);
        }

        /// <summary>
        /// Dessiner les points de jointure sur le panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pDessinSquelette_Paint(object sender, PaintEventArgs e)
        {
            DessinSquelettePaint(sender, e);
        }

        /// <summary>
        /// Fermeture de la fenêtre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_Click(object sender, EventArgs e)
        {
            Retour(sender, e);
        }

        /// <summary>
        /// Change le curseur lorsque le curseur est sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseHover(object sender, EventArgs e)
        {
            RetourMouseHover(sender, e);
        }

        /// <summary>
        /// Change le curseur lorsque le curseur est sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseLeave(object sender, EventArgs e)
        {
            RetourMouseLeave(sender, e);
        }
    }
}