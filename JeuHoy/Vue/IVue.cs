using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuHoy.Vue
{
    public interface IVue
    {
        string Console { get; set; }
        string sPosition { get; set; }
        int iPosition { get; set; }

        Dictionary<string, Image> DicImgFigure { get; set; }
        Image PositionAFaire { get; set; }
        event EventHandler ChangerFigure;
        event EventHandler Apprendre;

    }
}
