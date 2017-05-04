using JeuHoy.Model.BLL;
using JeuHoy.Vue;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuHoy.Presenter
{
    public class Jeu
    {
        private int _cstPointage = 10;
        private int _points;
        private int _position;
        private int _nbPosition;
        private int _temps;
        private int _dernierTemps;
        private IVueJeu _vue;
        private Dictionary<string, Image> _dicImgFigure = new Dictionary<string, Image>();
        private KinectSensor _sensor;
        private GestionClassesPerceptrons _gcpAnalyseEcriture;
        private Skeleton _skeleton;
        private JouerSon _son = new JouerSon();
        private bool _finished;
        private Random _rnd = new Random();
        private SpeechRecognitionEngine _speechEngine;
        private JouerMp3 _wmpIntro = new JouerMp3();



        public Jeu(IVueJeu vue)
        {
            _vue = vue;
            _vue.TimerTick += timer_tick;
            _vue.RetourClick += picRetour_Click;
            _vue.RetourMouseHover += picRetour_MouseHover;
            _vue.RetourMouseLeave += picRetour_MouseLeave;
            _gcpAnalyseEcriture = new GestionClassesPerceptrons();


            _gcpAnalyseEcriture = new GestionClassesPerceptrons();

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
                // Voix
                RecognizerInfo ri = GetKinectRecognizer();

                if (null != ri)
                {
                    this._speechEngine = new SpeechRecognitionEngine(ri.Id);
                }

                var directions = new Choices();
                directions.Add(new SemanticResultValue("hoy", "HOY!"));
                directions.Add(new SemanticResultValue("hoooy", "HOY!"));



                var gb = new GrammarBuilder { Culture = ri.Culture };
                gb.Append(directions);
                var g = new Grammar(gb);
                _speechEngine.LoadGrammar(g);
                _speechEngine.SpeechRecognized += SpeechRecognized;
                _speechEngine.SpeechRecognitionRejected += SpeechRejected;
                _speechEngine.SetInputToAudioStream(_sensor.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));

                _speechEngine.RecognizeAsync(RecognizeMode.Multiple);
                // Fin voix
            }

            for (int i = 1; i <= CstApplication.NBFIGURE; i++)
                _dicImgFigure.Add("fig" + i, Image.FromFile(@"./HoyContent/fig" + i + ".png"));

            ChangerPosition();
            ChargerFigure();
            _temps = Convert.ToInt32(_vue.sTemps);
            _dernierTemps = _temps;
            _son.JouerSonAsync(@"./HoyContent/hoooy.wav");

            _wmpIntro.Open(@"./HoyContent/soundtrack.mp3");
            _wmpIntro.Play(true);
        }

        #region Kinect

        private RecognizerInfo GetKinectRecognizer()
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                return recognizer;
            }

            return null;
        }

        private void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            const double ConfidenceThreshold = 0.3;
            if (e.Result.Confidence >= ConfidenceThreshold)
            {
                _son.JouerSonAsync(@"./HoyContent/hoooy.wav");
            }
        }


        private void kinect_ImagePretes(object sender, AllFramesReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    Skeleton[] skeletons = new Skeleton[6];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                    Skeleton skel = skeletons.FirstOrDefault(s => s.TrackingState == SkeletonTrackingState.Tracked);
                    _skeleton = skel;
                    if (_temps > 0)
                    {
                        string result = _gcpAnalyseEcriture.TesterPerceptronJeu(skel);
                        if (result == null)
                            return;
                        string[] sTabElement;
                        sTabElement = result.Split('\t');
                        foreach (string position in sTabElement)
                        {
                            if (position != "")
                            {
                                if (Convert.ToInt32(position) == _position)
                                {
                                    LogiqueReussite();
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    _skeleton = null;
                }
            }
        }

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

            bResultat = _dicImgFigure.TryGetValue("fig" + _position, out imgValue);
            if (bResultat == true)
                _vue.PositionAFaire = imgValue;

        }

        #endregion Kinect

        private void LogiqueReussite()
        {
            int position = _position;
            while (position == _position)
            {
                ChangerPosition();
            }
            ChargerFigure();
            CalculerPointage(_dernierTemps - _temps);
            _dernierTemps = _temps;
            _nbPosition++;
            // Partie préféré a reno
            _vue.sPoints = _points.ToString();
            _vue.sPosition = _nbPosition.ToString();
            // Fin de la partie préféré a reno
            _son.JouerSonAsync(@"./HoyContent/YES.wav");
        }

        private void CalculerPointage(int temps)
        {
            _points += (_cstPointage - temps) >= 0 ? (_cstPointage - temps) : 0;
        }

        private void ChangerPosition()
        {
            _position = _rnd.Next() % CstApplication.NBFIGURE;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            _temps = Int32.Parse(_vue.sTemps);
            if (_temps > 0)
            {
                _vue.sTemps = (--_temps).ToString();
            }
            else if (_temps == 0 && !_finished)
            {
                _vue.PositionAFaire = Image.FromFile(@"./Resources/kim.png");
                _son.JouerSonAsync(@"./HoyContent/riphugo.wav");
                _finished = true;
            }
        }

        /// <summary>
        /// Ferme la fenêtre lorsqu'on appuie sur le bouton retour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_Click(object sender, EventArgs e)
        {
            if (_sensor != null && _sensor.IsRunning)
            {
                _sensor.AudioSource.Stop();
                _sensor.Stop();
                _sensor = null;
            }
            if (null != _speechEngine)
            {
                _speechEngine.SpeechRecognized -= SpeechRecognized;
                _speechEngine.SpeechRecognitionRejected -= SpeechRejected;
                _speechEngine.RecognizeAsyncStop();
            }
            
            _vue.form.Close();
        }

        /// <summary>
        /// Change le curseur lorsque le curseur est sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseHover(object sender, EventArgs e)
        {
            _vue.form.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Change le curseur lorsque le curseur nest plus sur l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRetour_MouseLeave(object sender, EventArgs e)
        {
            _vue.form.Cursor = Cursors.Arrow;
        }
    }
}
