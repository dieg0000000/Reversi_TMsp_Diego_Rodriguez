using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Reversi
{
    public class joueur
    {
        public static int tour = 0;
        public static string sym = "X";
        public static string symop = "O";

        public static void ChangerJoueur() //tableau.CompterPions();
        {
            //Si tour pair ou impair O ou X
            if (tour % 2 == 0)
            {
                sym = "X";
                symop = "O";
            }
            else
            {
                sym = "O";
                symop = "X";
            }
        }
    }
}
