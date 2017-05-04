using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuHoy.Model.BLL;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Microsoft.Kinect;
using System.Globalization;

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
                string sFichier = ConfigurationManager.AppSettings["DataPath"] + ConfigurationManager.AppSettings["FichierApp"];
                StreamReader sr = new StreamReader(new FileStream(sFichier, FileMode.Open, FileAccess.Read));
                string sLigne = "";
                string[] sTabElement;

                while (!sr.EndOfStream)
                {
                    sLigne = sr.ReadLine();
                    Skeleton skel = new Skeleton();
                    sTabElement = sLigne.Split('\t');
                    
                    SkeletonPoint position = new SkeletonPoint
                    {
                        X = 0,
                        Y = 0
                    };

                    for (int i = 0; i < 40; i++)
                    {
                        if (i % 2 == 0)
                        {
                            position.X = float.Parse(sTabElement[i]);
                        }
                        else
                        {
                            position.Y = float.Parse(sTabElement[i]);
                            Joint joint = skel.Joints[(JointType)(i / 2)];
                            joint.Position = position;
                            skel.Joints[(JointType)(i / 2)] = joint;
                            if (i == 39)
                            {
                                CoordSkel coordskel = new CoordSkel(skel);
                                coordskel.Reponse = Convert.ToInt32(sTabElement[sTabElement.Length - 1]);
                                _lstCoord.Add(coordskel);
                            }
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
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

                foreach (CoordSkel cd in lstCoord)
                {
                    string sLigne = "";

                    foreach (Joint join in cd.Skeleton.Joints)
                    {
                        sLigne += join.Position.X + "\t";
                        sLigne += join.Position.Y + "\t";
                    }
                    sLigne += cd.Reponse;
                    sw.WriteLine(sLigne);
                }

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
