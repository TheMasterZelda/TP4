using JeuHoy.Model.BLL;
using JeuHoy.Vue;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuHoy.Presenter
{
    public class Jeu
    {
        private int _cstPointage = 10;
        private int _points;
        private int _position;
        private int _dernierePosition;
        private int _temps;
        private int _dernierTemps;
        private bool _isClosing = false;
        private IVueJeu _vue;
        private Dictionary<string, Image> _dicImgFigure = new Dictionary<string, Image>();
        private KinectSensor _sensor;
        private GestionClassesPerceptrons _gcpAnalyseEcriture;
        private Skeleton _skeleton;


        public Jeu(IVueJeu vue)
        {
            _vue = vue;
            _vue.Fermeture += btnFermer_Click;
            _vue.TimerTick += timer_tick;
            _vue.RetourClick += picRetour_Click;
            _vue.RetourMouseHover += picRetour_MouseHover;
            _vue.RetourMouseLeave += picRetour_MouseLeave;
        }

        public int CalculerPointage(int temps)
        {
            return (_cstPointage - temps) >= 0 ? (_cstPointage - temps) : 0;
        }

        public int ChangerPosition()
        {
            Random rnd = new Random();
            return rnd.Next() % 10;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            int temps = Int32.Parse(lblTemps.Text);
            if (temps > 0)
                lblTemps.Text = (--temps).ToString();
            else if (temps == 0)
            {
                picPositionAFaire.Image = Image.FromFile(@"./Resources/kim.png");
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

        /// <summary>
        /// Ferme la fenêtre lorsqu'on appuie sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            _isClosing = true;
            _vue.form.Close();
        }

    }
}
