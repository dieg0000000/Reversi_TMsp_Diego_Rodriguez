using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Reversi
{
    public class Joueur
    {
        //Initialisation des variables joeurs
        public static int tour = 0;
        public static bool JoueurActif = true; //noir et X
        public static bool JoueurPassif = false; //blanc et O

        public static void ChangerJoueur()
        {
            bool swap = JoueurActif;
            JoueurActif = JoueurPassif;
            JoueurPassif = swap;
        }
    }
}
