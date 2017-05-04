using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuHoy.Vue
{
    public interface IVueJeu
    {
        string sPosition { get; set; }
        string sNbPosition { get; set; }
        string sPoints { get; set; }
        string sTemps { get; set; }
        Image PositionAFaire { get; set; }
        Form form { get; }
        event EventHandler Fermeture;
        event EventHandler TimerTick;
        event EventHandler RetourClick;
        event EventHandler RetourMouseHover;
        event EventHandler RetourMouseLeave;
    }
}
