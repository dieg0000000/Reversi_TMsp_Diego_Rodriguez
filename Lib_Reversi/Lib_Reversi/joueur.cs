// ===============================================================================================
// AUTHOR     :         Diego Rodriguez
// CREATE DATE     :    27 janvier 2026
// PURPOSE     :        Moteur de jeu : Gère l'état du joueur actuel et l'alternance des tours
//                      entre les deux joueurs.
// SPECIAL NOTES    :   Oubliez pas de générer la solution (Ctrl+Maj+B)après chaque modification
//                      pour retouver les modifications dans votre code
// ===============================================================================================
// CHANGE HISTORY   :   31-03-2026 - Changement du système des joueurs -> JoueurActuelX
// ===============================================================================================

namespace Lib_Reversi
{
    public class Joueur
    {
        //Initialisation des variables joeurs
        public static int tour = 0;
        public static bool JoueurActuelX = true; //true = noir et X / false = blanc et O
        

        public static void ChangerJoueur()
        {
            JoueurActuelX = !JoueurActuelX;
        }
    }
}
