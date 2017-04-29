using Microsoft.Kinect;
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuHoy.Vue
{
    public interface IVue
    {
        string Console { get; set; }
        string sPosition { get; set; }
        string NbPosition { get; set; }
        Image PositionAFaire { get; set; }
        PictureBox PicKinect { get; set; }
        Panel DessinSquelette { get; set; }
        ShapeContainer ShapeContainer { get; set; }
        Form FormEntrainement { get; }
        event EventHandler Fermeture;
        event EventHandler ChangerFigure;
        event EventHandler Apprendre;
        event PaintEventHandler DessinSquelettePaint;
        event EventHandler Retour;
        event EventHandler RetourMouseHover;
        event EventHandler RetourMouseLeave;



    }
}
