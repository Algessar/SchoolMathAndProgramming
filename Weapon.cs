using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming
{
    public class PawnController
    {
        [System.Serializable]
        public class Weapon
        {
            public int AmmoCurrent;
            public int AmmoTotal;
            public int ClipSize;

        }
        public Weapon weapon;

    }
}
