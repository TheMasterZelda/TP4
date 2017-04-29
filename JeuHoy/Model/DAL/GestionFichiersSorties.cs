using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuHoy.Model.BLL;

namespace JeuHoy.Model.DAL
{
    /// <summary>
    /// Cette classe gère l'accès aux disques pour le fichiers d'apprentissages. 
    /// Permet de charger ou décharger dans la matrice d'apprentissage.
    /// </summary>
    public class GestionFichiersSorties
    {
        private List<CoordSkel> _lstCoord;

        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        public List<CoordSkel> ChargerCoordonnees()
        {

            return _lstCoord;
        }

        /// <summary>
        /// Permet de sauvegarder dans fichier texte dans une matrice pour l'apprentissage automatique
        /// </summary>
        public int SauvegarderCoordonnees(List<CoordSkel> lstCoord)
        {

            return CstApplication.OK;
        }

        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        public IList<CoordSkel> ObtenirCoordonnees()
        {
            return _lstCoord;
        }
    }
}
