using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace JeuHoy.Vue
{
    /// <summary>
    /// Auteur: Hugo St-Louis
    /// Description: Permet de faire l'entrainement des différentes figures de danse.
    /// Date: 26/04/2014
    /// </summary>
    public partial class frmEntrainement : Form
    {
        private Bitmap _bmapSquelette;
        private Dictionary<string, Image> _dicImgFigure = new Dictionary<string, Image>();
        private bool _isClosing = false;
        private JouerSon _son = new JouerSon();
        private int _positionEnCours = 1;
        private KinectSensor _sensor;

        /// <summary>
        /// Constructeur
        /// </summary>
        public frmEntrainement()
        {
            InitializeComponent();
            if (KinectSensor.KinectSensors.Count > 0)
            {
                _sensor = KinectSensor.KinectSensors[0];
                if (_sensor.Status == KinectStatus.Connected)
                {
                    _sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                    _sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    _sensor.SkeletonStream.Enable();
                    _sensor.AllFramesReady += kinect_ImagePretes;
                    try
                    {
                        _sensor.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur de connexion \r\n " + ex.Message);
                    }
                }
            }

            picKinect.Width = CstApplication.KINECT_DISPLAY_WIDTH;
            picKinect.Height = CstApplication.KINECT_DISPLAY_HEIGHT;
            shapeContainer1.BringToFront();
            for (int i = 1; i <= CstApplication.NBFIGURE; i++)
                _dicImgFigure.Add("fig" + i, Image.FromFile(@"./HoyContent/fig" + i + ".png"));

            _bmapSquelette = new Bitmap(pDessinSquelette.Width, pDessinSquelette.Height);

            lblNbPosition.Text = CstApplication.NBFIGURE.ToString();
            ChargerFigure();
            _son.JouerSonAsync(@"./HoyContent/hoy.wav");

        }

        private void kinect_ImagePretes(object sender, AllFramesReadyEventArgs e)
        {
            byte[] pixels;
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame != null)
                {
                    pixels = new byte[colorFrame.PixelDataLength];
                    colorFrame.CopyPixelDataTo(pixels);
                    Bitmap b = CreerBitMapAPartirPixels(pixels, colorFrame.Height, colorFrame.Width);
                    picKinect.Image = b;
                }
            }

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    Skeleton[] skeletons = new Skeleton[6];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                    Skeleton skel = skeletons.FirstOrDefault(s => s.TrackingState == SkeletonTrackingState.Tracked);
                    if (skel != null)
                    {
                        DessinerSquelette(skel, _sensor);
                    }

                }
            }
        }

        private Bitmap CreerBitMapAPartirPixels(byte[] pixels, int hauteur, int largeur)
        {
            //Crée un bitmap vide du bon type pour la bonne dimension
            Bitmap bitmapFrame = new Bitmap(largeur, hauteur, PixelFormat.Format32bppRgb);

            //Réserve un espace mémoire de type bitmapData pour les pixels
            BitmapData bitmapData = bitmapFrame.LockBits(new Rectangle(0, 0, largeur, hauteur), ImageLockMode.WriteOnly, bitmapFrame.PixelFormat);

            //Transfert les pixels dans l'espace mémoire réservé.
            IntPtr intPointer = bitmapData.Scan0;
            Marshal.Copy(pixels, 0, intPointer, pixels.Length);
            //Active l'espace mémoire réservé de pixels pour remplir le Bitmap
            bitmapFrame.UnlockBits(bitmapData);

            return bitmapFrame;
        }

        /// <summary>
        /// Dessine un ellipse pour chacune des jointure du squelette détecté.
        /// </summary>
        /// <param name="joueur">Le joueur détecté</param>
        /// <param name="sensor">Le sensor Kinect</param>
        private void DessinerSquelette(Skeleton joueur, KinectSensor sensor)
        {
            SolidBrush brush;
            Pen pen;
            int iCoordY;
            int iCoordX;

            try
            {
                if (_isClosing || joueur == null)
                    return;

                using (Graphics g = Graphics.FromImage(_bmapSquelette))
                {
                    g.Clear(Color.Black);
                }

                for (int i = 1; i < joueur.Joints.Count; i++)
                {

                    brush = new SolidBrush(Color.White);
                    pen = new Pen(Color.White);
                    iCoordY = (int)(this.Height - this.ClientSize.Height);
                    iCoordX = (int)(this.Width - this.ClientSize.Width) / 2;
                    DepthImagePoint point = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(joueur.Joints[(JointType)i].Position,
                                            DepthImageFormat.Resolution640x480Fps30);

                    float y = (point.Y + iCoordY) / 2;
                    float x = (point.X - iCoordX) / 2;

                    using (Graphics g = Graphics.FromImage(_bmapSquelette))
                    {
                        g.FillEllipse(Brushes.White, x, y, 10, 10);
                    }
                    pDessinSquelette.Invalidate();

                }
            }
            catch (Exception ex)
            {
                txtConsole.Text = ex.Message;
            }
        }

        /// <summary>
        /// Ferme la fenêtre lorsqu'on appuie sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            _isClosing = true;
            this.Close();
        }

        /// <summary>
        /// Charger la figure de danse en cours.
        /// </summary>
        private void ChargerFigure()
        {
            Image imgValue;
            bool bResultat;

            if (_positionEnCours > CstApplication.NBFIGURE)
                _positionEnCours = 1;

            if (_positionEnCours < 1)
                _positionEnCours = CstApplication.NBFIGURE;

            lblFigureEnCours.Text = _positionEnCours.ToString();

            bResultat = _dicImgFigure.TryGetValue("fig" + _positionEnCours, out imgValue);
            if (bResultat == true)
                picPositionAFaire.Image = imgValue;

        }

        /// <summary>
        /// Lorsqu'on appuie sur le bouton suivant ou précédent, modifier la figure en conséquence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClickChangerFigure_Click(object sender, EventArgs e)
        {
            Control bouton = (Control)sender;

            if(bouton.Name == "btnSuivant")
                _positionEnCours++;
            else if(bouton.Name == "btnPrecedent")
                _positionEnCours--;

            ChargerFigure();
        }

        private void btnApprendre_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Dessiner les points de jointure sur le panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pDessinSquelette_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_bmapSquelette, Point.Empty);
        }

        /// <summary>
        /// Fermeture de la fenêtre.
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
        /// Change le curseur lorsque le curseur est sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
