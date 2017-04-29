using JeuHoy.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace JeuHoy.Presenter
{
    public class Entrainement
    {
        private IVue _vue;

        public Entrainement(IVue vue)
        {
            _vue = vue;
            _vue.ChangerFigure += btnClickChangerFigure_Click;
            _vue.Apprendre += btnApprendre_Click;
            _vue.iPosition = 1;
            _vue.DicImgFigure = new Dictionary<string, Image>();
        }



        /// <summary>
        /// Charger la figure de danse en cours.
        /// </summary>
        private void ChargerFigure()
        {
            Image imgValue;
            bool bResultat;

            if (_vue.iPosition > CstApplication.NBFIGURE)
                _vue.iPosition = 1;

            if (_vue.iPosition < 1)
                _vue.iPosition = CstApplication.NBFIGURE;

            _vue.sPosition = _vue.iPosition.ToString();

            bResultat = _vue.DicImgFigure.TryGetValue("fig" + _vue.iPosition, out imgValue);
            if (bResultat == true)
                _vue.PositionAFaire = imgValue;

        }

        /// <summary>
        /// Lorsqu'on appuie sur le bouton suivant ou précédent, modifier la figure en conséquence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClickChangerFigure_Click(object sender, EventArgs e)
        {
            Control bouton = (Control)sender;

            if (bouton.Name == "btnSuivant")
                _vue.iPosition++;
            else if (bouton.Name == "btnPrecedent")
                _vue.iPosition--;

            ChargerFigure();
        }

        private void btnApprendre_Click(object sender, EventArgs e)
        {

        }

    }
}
