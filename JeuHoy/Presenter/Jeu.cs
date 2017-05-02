using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuHoy.Presenter
{
    public class Jeu
    {
        private int _cstPointage = 10;
        private int _points;
        private int _position;
        private int _temps;
        private int _derniertemps;

        public int CalculerPointage(int temps)
        {
            return (_cstPointage - temps) >= 0 ? (_cstPointage - temps) : 0;
        }

        public int ChangerPosition()
        {
            Random rnd = new Random();
            return rnd.Next() % 10;
        }
    }
}
