using JeuHoy.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JeuHoy.Vue
{
    /// <summary>
    /// Auteur: Hugo St-Louis
    /// Description: Fenêtre du jeu.
    /// Date: 26/04/2014
    /// </summary>
    public partial class frmJeu : Form, IVueJeu
    {
        private Jeu _jeu;

        public event EventHandler TimerTick;
        public event EventHandler RetourClick;
        public event EventHandler RetourMouseHover;
        public event EventHandler RetourMouseLeave;


        public string sPosition
        {
            get
            {
                return lblPosition.Text;
            }

            set
            {
                lblPosition.Text = value;
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

        public Form form
        {
            get
            {
                return this;
            }
        }

        public string sPoints
        {
            get
            {
                return lblPoint.Text;
            }

            set
            {
                lblPoint.Text = value;
            }
        }

        public string sTemps
        {
            get
            {
                return lblTemps.Text;
            }

            set
            {
                lblTemps.Text = value;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public frmJeu()
        {
            InitializeComponent();
            _jeu = new Jeu(this);
        }

        private void tmrTemps_Tick(object sender, EventArgs e)
        {
            TimerTick(sender, e);
        }

        /// <summary>
        /// Ferme la fenêtre lorsqu'on appuie sur le bouton retour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_Click(object sender, EventArgs e)
        {
            RetourClick(sender, e);
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
        /// Change le curseur lorsque le curseur nest plus sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseLeave(object sender, EventArgs e)
        {
            RetourMouseLeave(sender, e);
        }
    }
}
