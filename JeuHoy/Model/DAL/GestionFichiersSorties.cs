using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuHoy.Model.BLL;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

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
            _lstCoord = new List<CoordSkel>();

            try
            {
           //     string sFichier = ConfigurationManager.AppSettings["DataPath"] + ConfigurationManager.AppSettings["FichierApp"];
            //    StreamReader sr = new StreamReader(new FileStream(sFichier, FileMode.Open, FileAccess.Read));
                //string sLigne = "";
                //string[] sTabElement;
                //int iTailleArray = 0;
                //
                //if (!sr.EndOfStream)
                //{
                //    sLigne = sr.ReadLine();
                //    iTailleArray = Convert.ToInt32(sLigne);
                //}

               // if (iTailleArray != CstApplication.NOMBRE_BITS_X * CstApplication.NOMBRE_BITS_Y)
               // {
               //     return _lstCoord;
               // }
              //
              // while (!sr.EndOfStream)
              // {
              //     sLigne = sr.ReadLine();
              //     sTabElement = sLigne.Split('\t');
              //     CoordDessin cd = new CoordDessin(CstApplication.TAILLEDESSINY, CstApplication.TAILLEDESSINX);
              //
              //     for (int x = 0; x < CstApplication.NOMBRE_BITS_X; x++)
              //     {
              //         for (int y = 0; y < CstApplication.NOMBRE_BITS_Y; y++)
              //         {
              //             if (Convert.ToInt32(sTabElement[y + (CstApplication.NOMBRE_BITS_Y * x)]) == CstApplication.FAUX)
              //                 cd.AjouterCoordonnees(x * CstApplication.LARGEURTRAIT, y * CstApplication.HAUTEURTRAIT, CstApplication.LARGEURTRAIT, CstApplication.HAUTEURTRAIT);
              //         }
              //     }
              //     cd.Reponse = sTabElement[sTabElement.Length - 1];
              //     _lstCoord.Add(cd);
              // }
            //    sr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return _lstCoord;
        }

        /// <summary>
        /// Permet de sauvegarder dans fichier texte dans une matrice pour l'apprentissage automatique
        /// </summary>
        public int SauvegarderCoordonnees(List<CoordSkel> lstCoord)
        {
            try
            {
                string sFichier = ConfigurationManager.AppSettings["DataPath"] + ConfigurationManager.AppSettings["FichierApp"];
                StreamWriter sw = new StreamWriter(new FileStream(sFichier, FileMode.Open, FileAccess.Write));

                //sw.WriteLine(CstApplication.NOMBRE_BITS_X * CstApplication.NOMBRE_BITS_Y);

              //  foreach (CoordSkel cd in lstCoord)
              //  {
                   // string sLigne = "";

                   // foreach (bool bit in cd.Skeleton)
                   // {
                   //     sLigne += bit ? CstApplication.FAUX : CstApplication.VRAI;
                   //     sLigne += "\t";
                   // }
                   // sLigne += cd.Reponse;
                   // sw.WriteLine(sLigne);
              //  }

                sw.Close();

                return CstApplication.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return CstApplication.ERREUR;
            }
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
