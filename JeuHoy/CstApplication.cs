
namespace JeuHoy
{
    /// <summary>
    /// Classe de constantes de l'application.
    /// </summary>
    public static class CstApplication
    {
        //Nombre de figure de danse dans l'application.
        public const int NBFIGURE = 10;
        //Constante pour la Kinect
        public const int SKELETONCOUNT = 6;
        public const int KINECT_DISPLAY_WIDTH = 320;
        public const int KINECT_DISPLAY_HEIGHT = 240;

         //Constante d'apprentissage pour le perceptron
        public const double CONSTANTEAPPRENTISSAGE = 0.01;
        //Critère de convergence pour le perceptron.
        public const int MAXITERATION = 200;
        public const int POURCENTCONVERGENCE = 99;

        //Valeur vrai ou fausse pour le perceptron
        public const int VRAI = 1;
        public const int FAUX = -1;

        //Code d'erreur (pas nécessaire).
        public const int ERREUR = -1;
        public const int OK = 0;

        //Nombre maximale de permutation pour répartir les échantillons(pas nécessaire).
        public const int MAXPERMUTATION = 6000;
    }
}
