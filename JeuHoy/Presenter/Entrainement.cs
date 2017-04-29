﻿using JeuHoy.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Kinect;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace JeuHoy.Presenter
{
    public class Entrainement
    {
        private IVue _vue;
        private Bitmap _bmapSquelette;
        private JouerSon _son = new JouerSon();
        private int _position = 1;
        private Dictionary<string, Image> _dicImgFigure = new Dictionary<string, Image>();
        private KinectSensor _sensor;
        private bool _isClosing = false;




        public Entrainement(IVue vue)
        {
            _vue = vue;
            _vue.Fermeture += btnFermer_Click;
            _vue.ChangerFigure += btnClickChangerFigure_Click;
            _vue.Apprendre += btnApprendre_Click;
            _vue.DessinSquelettePaint += pDessinSquelette_Paint;
            _vue.Retour += picRetour_Click;
            _vue.RetourMouseHover += picRetour_MouseHover;
            _vue.RetourMouseLeave += picRetour_MouseLeave;

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

            _vue.PicKinect.Width = CstApplication.KINECT_DISPLAY_WIDTH;
            _vue.PicKinect.Height = CstApplication.KINECT_DISPLAY_HEIGHT;
            _vue.ShapeContainer.BringToFront();
            for (int i = 1; i <= CstApplication.NBFIGURE; i++)
                _dicImgFigure.Add("fig" + i, Image.FromFile(@"./HoyContent/fig" + i + ".png"));

            _bmapSquelette = new Bitmap(_vue.DessinSquelette.Width, _vue.DessinSquelette.Height);

            _vue.NbPosition = CstApplication.NBFIGURE.ToString();
            ChargerFigure();
            _son.JouerSonAsync(@"./HoyContent/hoy.wav");
        }

        #region Kinect

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
                    _vue.PicKinect.Image = b;
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

                   // _vue.ShapeContainer.Container.;
                   // brush = new SolidBrush(Color.White);
                   // pen = new Pen(Color.White);
                    iCoordY = (int)(_vue.FormEntrainement.Height - _vue.FormEntrainement.ClientSize.Height);
                    iCoordX = (int)(_vue.FormEntrainement.Width - _vue.FormEntrainement.ClientSize.Width) / 2;
                    DepthImagePoint point = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(joueur.Joints[(JointType)i].Position,
                                            DepthImageFormat.Resolution640x480Fps30);

                    float y = (point.Y + iCoordY) / 2;
                    float x = (point.X - iCoordX) / 2;

                    _vue.ShapeContainer.Controls[i].Location = new Point(iCoordX, iCoordY);

                   // using (Graphics g = Graphics.FromImage(_bmapSquelette))
                   // {
                   //     g.FillEllipse(_vue.ShapeContainer.Controls[i], x, y, 10, 10);//Brushes.White, x, y, 10, 10);
                   // }
                    _vue.DessinSquelette.Invalidate();

                }
            }
            catch (Exception ex)
            {
                _vue.Console = ex.Message;
            }
        }

        #endregion Kinect

        /// <summary>
        /// Charger la figure de danse en cours.
        /// </summary>
        private void ChargerFigure()
        {
            Image imgValue;
            bool bResultat;

            if (_position > CstApplication.NBFIGURE)
                _position = 1;

            if (_position < 1)
                _position = CstApplication.NBFIGURE;

            _vue.sPosition = _position.ToString();

            bResultat = _dicImgFigure.TryGetValue("fig" + _position, out imgValue);
            if (bResultat == true)
                _vue.PositionAFaire = imgValue;

        }

        /// <summary>
        /// Ferme la fenêtre lorsqu'on appuie sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            _isClosing = true;
            _vue.FormEntrainement.Close();
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
                _position++;
            else if (bouton.Name == "btnPrecedent")
                _position--;

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
            _vue.FormEntrainement.Close();
        }

        /// <summary>
        /// Change le curseur lorsque le curseur est sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseHover(object sender, EventArgs e)
        {
            _vue.FormEntrainement.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Change le curseur lorsque le curseur est sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseLeave(object sender, EventArgs e)
        {
            _vue.FormEntrainement.Cursor = Cursors.Arrow;
        }
    }
}
