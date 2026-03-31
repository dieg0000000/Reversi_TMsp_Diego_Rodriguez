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
        public static bool JoueurActuel = true; //true = noir et X / false = blanc et O
        

        public static void ChangerJoueur()
        {
            JoueurActuel = !JoueurActuel;
        }
    }
}
