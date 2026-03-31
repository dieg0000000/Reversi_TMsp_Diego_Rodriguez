// ===============================================================================================
// AUTHOR     :         Diego Rodriguez
// CREATE DATE     :    27 janvier 2026
// PURPOSE     :        Moteur de jeu : Représente le plateau de jeu Reversi. Gère
//                      l'initialisation, la lecture/écriture des cases et le comptage des pions.
// SPECIAL NOTES    :   Oubliez pas de générer la solution (Ctrl+Maj+B)après chaque modification
//                      pour retouver les modifications dans votre code
// ===============================================================================================
// CHANGE HISTORY   :   31-03-2026 - Regroupement méthode de comptage de pions / espaces vides /
//                      coups possibles
// ===============================================================================================

namespace Lib_Reversi
{
    public class Plateau
    {
        //Inistialisation des constantes
        public const int nbCases = 8;
        public const int pionBaseX = 3;
        public const int pionBaseY = 4;

        //Initialisation du plateau invisible qui gardera les valeurs de la partie pour chaque case (Null, True et False)
        private static bool?[,] plateau = new bool?[nbCases, nbCases];

        public static readonly bool? NOIR = true;
        public static readonly bool? BLANC = false;
        public static readonly bool? VIDE = null;

        //Lire une case
        public static bool? GetCase(Coords pos)
        {
            return plateau[pos.Y, pos.X];
        }

        //Ecrire une case
        public static void SetCase(Coords pos, bool? valeur)
        {
            plateau[pos.Y, pos.X] = valeur;
        }

        public static void InitialiserGrille()
        {
            for (int ligne = 0; ligne < nbCases; ligne++)
            {
                for (int col = 0; col < nbCases; col++)
                {
                    plateau[ligne, col] = VIDE;
                }
            }
            
            //Ajouter les 4 pions de base dans le tableau
            plateau[pionBaseX, pionBaseX] = NOIR;
            plateau[pionBaseX, pionBaseY] = BLANC;
            plateau[pionBaseY, pionBaseX] = BLANC;
            plateau[pionBaseY, pionBaseY] = NOIR;
        }

        public static (int comptNoir, int comptBlanc, int comptVide) CompterPions()
        {
            int comptNoir = 0;
            int comptBlanc = 0;
            int comptVide = 0;

            for (int l = 0; l < nbCases; l++)
            {
                for (int c = 0; c < nbCases; c++)
                {
                    if (plateau[l, c] == NOIR)
                    {
                        comptNoir++;
                    }
                    else if (plateau[l, c] == BLANC)
                    {
                        comptBlanc++;
                    }
                    else if (plateau[l, c] == VIDE)
                    {
                        comptVide++;
                    }
                }
            }
            return (comptNoir, comptBlanc, comptVide);
        }

        public static int CompterCoupsPossibles(bool JoueurActuelX)
        {
            int comptCP = 0;
            for (int l = 0; l < Plateau.nbCases; l++)
            {
                for (int c = 0; c < Plateau.nbCases; c++)
                {
                    if (CoupPossible.EstUnCoupPossible(new Coords(c, l), JoueurActuelX))
                    {
                        comptCP++;
                    }
                }
            }
            return comptCP;
        }
    }
}


