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
    public partial class frmJeu : Form
    {
        private JouerSon _son = new JouerSon();
        private bool _finished = false;

        /// <summary>
        /// Constructeur
        /// </summary>
        public frmJeu()
        {
            InitializeComponent();
            tmrTemps.Tick += new EventHandler(timer_tick);
        }

        private void timer_tick(object sender, EventArgs e)
        {
            int temps = Int32.Parse(lblTemps.Text);
            if (temps > 0)
            {
                lblTemps.Text = (--temps).ToString();
                _son.JouerSonAsync(@"./HoyContent/YES.wav");
            }
            else if (temps == 0 && !_finished)
            {
                picPositionAFaire.Image = Image.FromFile(@"./Resources/kim.png");
                _son.JouerSonAsync(@"./HoyContent/riphugo.wav");
                _finished = true;
            }
        }

        /// <summary>
        /// Ferme la fenêtre lorsqu'on appuie sur le bouton retour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Change le curseur lorsque le curseur est sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Change le curseur lorsque le curseur nest plus sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

    }
}
