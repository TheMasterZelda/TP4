using System;
using System.Configuration;
using System.Windows.Forms;

namespace JeuHoy.Vue
{
    /// <summary>
    /// Auteur: Hugo St-Louis
    /// Description: Fenêtre princiaple de l'application. Montre les choix à l'utilisateur
    /// Date: 26/04/2014
    /// </summary>
    public partial class frmEntree : Form
    {
        private JouerMp3 _wmpIntro = new JouerMp3();

        /// <summary>
        /// Constructeur
        /// </summary>
        public frmEntree()
        {
            InitializeComponent();
            string fichierEntrainement = ConfigurationManager.AppSettings["FichierApp"];

            _wmpIntro.Open(@"./HoyContent/intro.mp3");
            _wmpIntro.Play(true);
        }

        /// <summary>
        /// Fermeture de la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEntree_FormClosing(object sender, FormClosingEventArgs e)
        {
            _wmpIntro.Close();
        }

        /// <summary>
        /// Ouverture de la fenêtre de jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picJouer_Click(object sender, EventArgs e)
        {
            _wmpIntro.Close();

            frmJeu f = new frmJeu();
            f.ShowDialog();
            f.Dispose();
            _wmpIntro.Open(@"./HoyContent/intro.mp3");
            _wmpIntro.Play(true);
        }

        /// <summary>
        /// Comportement lorsque curseur est au dessus d'une image(modifier le curseur)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_MouseHover(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntree));

            this.Cursor = Cursors.Hand;
            PictureBox p = (PictureBox)sender;
            if (p.Name == "picJouer")
                this.picJouer.Image = global::JeuHoy.Properties.Resources.JouerDessus;
            else if (p.Name == "picEntrainement")
                this.picEntrainement.Image = global::JeuHoy.Properties.Resources.EntrainementDessus;
            else if (p.Name == "picAide")
                this.picAide.Image = global::JeuHoy.Properties.Resources.AideDessus1234;
        }

        /// <summary>
        /// Comportement lorsque curseur quitte l'image(modifier le curseur)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_MouseLeave(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntree));
            this.Cursor = Cursors.Arrow;
            PictureBox p = (PictureBox)sender;
            if (p.Name == "picJouer")
                this.picJouer.Image = global::JeuHoy.Properties.Resources.JouerHoy;
            else if(p.Name == "picEntrainement")
                this.picEntrainement.Image = global::JeuHoy.Properties.Resources.Entrainement;
            else if (p.Name == "picAide")
                this.picAide.Image = global::JeuHoy.Properties.Resources.Aide;
        }

        /// <summary>
        /// Fermeture de la form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
            _wmpIntro.Close();
        }

        /// <summary>
        /// Ouverture de la fenêtre d'entrainement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picEntrainement_Click(object sender, EventArgs e)
        {
            _wmpIntro.Close();
            
            frmEntrainement f = new frmEntrainement();
            f.ShowDialog();
            f.Dispose();
            _wmpIntro.Open(@"./HoyContent/intro.mp3");
            _wmpIntro.Play(true);
        }

        /// <summary>
        /// Ouverture de la fenêtre d'aide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picAide_Click(object sender, EventArgs e)
        {
            frmAide f = new frmAide();
            f.ShowDialog();
            f.Dispose();

        }
    }
}
