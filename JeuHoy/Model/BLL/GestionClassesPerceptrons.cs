using JeuHoy.Model.DAL;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuHoy.Model.BLL
{
    /// <summary>
    /// Gère les fonctionnalités de l'application. Entre autre, permet de :
    /// - Charger les échantillons d'apprentissage,
    /// - Sauvegarder les échantillons d'apprentissage,
    /// - Tester le perceptron
    /// - Entrainer le perceptron
    /// </summary>
    public class GestionClassesPerceptrons
    {
        private Dictionary<int, Perceptron> _lstPerceptrons;
        private GestionFichiersSorties _gestionSortie;

        /// <summary>
        /// Constructeur
        /// </summary>
        public GestionClassesPerceptrons()
        {
            _lstPerceptrons = new Dictionary<int, Perceptron>();
            _gestionSortie = new GestionFichiersSorties();

            ChargerCoordonnees();
        }

        /// <summary>
        /// Charge les échantillons d'apprentissage sauvegardé sur le disque.
        /// </summary>
        public void ChargerCoordonnees()
        {
            _gestionSortie.ChargerCoordonnees();
            List<CoordSkel> lstCoord = ObtenirCoordonnees() as List<CoordSkel>;
            foreach (CoordSkel cd in lstCoord)
            {
                if (!_lstPerceptrons.ContainsKey(cd.Reponse))
                {
                    _lstPerceptrons.Add(cd.Reponse, new Perceptron(cd.Reponse));
                }
            }
        }

        /// <summary>
        /// Sauvegarde les échantillons d'apprentissage sauvegardé sur le disque.
        /// </summary>
        /// <returns>En cas d'erreur retourne le code d'erreur</returns>
        public int SauvegarderCoordonnees()
        {
            List<CoordSkel> lstCoord = _gestionSortie.ObtenirCoordonnees() as List<CoordSkel>;
            int erreur = _gestionSortie.SauvegarderCoordonnees(lstCoord);
            return erreur;
        }

        /// <summary>
        /// Entraine les perceptrons avec un nouveau caractère
        /// </summary>
        /// <param name="coordo">Les nouvelles coordonnées</param>
        /// <param name="reponse">La réponse associé(caractère) aux coordonnées</param>
        /// <returns>Le résultat de la console</returns>
        public string Entrainement(Skeleton skel, int reponse)
        {
            string sConsole = "";
            if (!_lstPerceptrons.ContainsKey(reponse))
            {
                _lstPerceptrons.Add(reponse, new Perceptron(reponse));
            }
            CoordSkel coordo = new CoordSkel(skel);
            coordo.Reponse = reponse;
            List<CoordSkel> lstCoord = ObtenirCoordonnees() as List<CoordSkel>;
            lstCoord.Add(coordo);
            foreach (var c in _lstPerceptrons)
            {
                sConsole += c.Value.Entrainement(lstCoord);
            }
            _gestionSortie.SauvegarderCoordonnees(lstCoord);
            return sConsole;
        }

        /// <summary>
        /// Test le perceptron avec de nouvelles coordonnées.
        /// </summary>
        /// <param name="coord">Les nouvelles coordonnées</param>
        /// <returns>Retourne la liste des valeurs possibles du perceptron</returns>
        public string TesterPerceptron(Skeleton skel)
        {
            string resultat = "";

            foreach (var p in _lstPerceptrons)
            {
                if (p.Value.TesterNeurone(skel))
                    resultat += "Figure courrante : " + p.Key + "\r\n";
            }

            if (resultat == "")
                resultat = "Aucune position correspondante.";

            return resultat;
        }

        /// <summary>
        /// Obtient une liste des coordonées.
        /// </summary>
        /// <returns>Une liste des coordonées.</returns>
        public IList<CoordSkel> ObtenirCoordonnees()
        {
            return _gestionSortie.ObtenirCoordonnees();
        }
    }
}
