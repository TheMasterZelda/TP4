using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuHoy.Model.BLL
{
    public class CoordSkel
    {
        private Skeleton _skel = null;
        private int _reponse = 0;

        public Skeleton Skeleton
        {
            get { return _skel; }
        }

        public int Reponse
        {
            get { return _reponse; }
            set { _reponse = value; }
        }

        public CoordSkel(Skeleton skel)
        {
            _skel = skel;
        }
    }
}
