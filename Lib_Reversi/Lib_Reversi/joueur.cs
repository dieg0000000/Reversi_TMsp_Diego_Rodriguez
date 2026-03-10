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
        public static bool? sym = true; //noir et X
        public static bool? symop = false; //blanc et O

        public static void ChangerJoueur()
        {
            bool? temp = sym;
            sym = symop;
            symop = temp;
        }
    }
}
