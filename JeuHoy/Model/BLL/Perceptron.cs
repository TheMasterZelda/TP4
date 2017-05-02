using Microsoft.Kinect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuHoy.Model.BLL
{
    /// <summary>
    /// Classe du perceptron. Permet de faire l'apprentissage automatique sur un échantillon d'apprentissage. 
    /// </summary>
    public class Perceptron
    {
        private double _cstApprentissage;
        private double[] _poidsSyn;
        private int _reponse = 0;

        public int Reponse
        {
            get { return _reponse; }
        }

        /// <summary>
        /// Constructeur de la classe. Crée un perceptron pour une réponse(caractère) qu'on veut identifier le pattern(modèle)
        /// </summary>
        /// <param name="reponse">La classe que défini le perceptron</param>
        public Perceptron(int reponse)
        {
            _cstApprentissage = CstApplication.CONSTANTEAPPRENTISSAGE;
            _reponse = reponse;
        }

        public string Entrainement(List<CoordSkel> lstSkel)
        {
            Random r = new Random();
            string resultat = "";
            int iNbIterration = 0;
            int iNbErreur = 0;
            int iTaillePoids = 21;
            _poidsSyn = new double[iTaillePoids];

            for (int i = 0; i < iTaillePoids; i++)
            {
                _poidsSyn[i] = r.NextDouble();
            }

            do
            {
                iNbErreur = 0;
                foreach (var s in lstSkel)
                {
                    int iValeurEstime = ValeurEstime(_poidsSyn, s.Skeleton);
                    int iVraieValeur = s.Reponse == _reponse ? 0 : 1;

                    if (iValeurEstime != iVraieValeur)
                    {
                        iNbErreur++;
                        _poidsSyn[0] += _cstApprentissage * (iVraieValeur - iValeurEstime);
                        for (int j = 1; j < _poidsSyn.Length; j++)
                        {
                            _poidsSyn[j] += _cstApprentissage * (iVraieValeur - iValeurEstime) * (s.Skeleton.Position.X + s.Skeleton.Position.Y * CstApplication.KINECT_DISPLAY_WIDTH);
                        }
                    }
                }

                iNbIterration++;

            } while (iNbErreur != 0 && iNbIterration < CstApplication.MAXITERATION && ((double)(lstSkel.Count - iNbErreur) / (double)(lstSkel.Count) * 100.0d) < CstApplication.POURCENTCONVERGENCE);

            resultat += $"Le pourcentage de réussite est de {((double)(lstSkel.Count - iNbErreur) / (double)(lstSkel.Count)) * 100.0d} pour {Reponse} avec {iNbIterration} iterration et {iNbErreur} erreur\r\n";

            return resultat;
        }

        private int ValeurEstime(double[] vecteurSyn, Skeleton skel)
        {
            double sum = vecteurSyn[0];

            for (int i = 1; i < vecteurSyn.Length; i++)
            {
                sum += _poidsSyn[i] * (skel.Position.X + skel.Position.Y * CstApplication.KINECT_DISPLAY_WIDTH);
            }
            return (sum >= 0) ? 1 : 0;
        }

        public bool TesterNeurone(Skeleton skel)
        {
            double sum = _poidsSyn[0];
            for (int i = 1; i < _poidsSyn.Length; i++)
            {
                sum += _poidsSyn[i] * (skel.Position.X + skel.Position.Y * CstApplication.KINECT_DISPLAY_WIDTH);
            }
            return (sum >= 0) ? false : true;
        }
    }
}
