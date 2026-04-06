// ===============================================================================================
// AUTHOR     :         Diego Rodriguez
// CREATE DATE     :    27 janvier 2026
// PURPOSE     :        Moteur de jeu : Représente le plateau de jeu Reversi. Gère
//                      l'initialisation, la lecture/écriture des cases et le comptage des pions.
// SPECIAL NOTES    :   Oubliez pas de générer la solution (Ctrl+Maj+B)après chaque modification
//                      pour retouver les modifications dans votre code
// ===============================================================================================
// CHANGE HISTORY   :   06-04-2026 - Ajout Undo
//                      31-03-2026 - Regroupement méthode de comptage de pions / espaces vides /
//                      coups possibles
// ===============================================================================================

using System.Collections.Generic;

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

        //Liste des plateaux pour le Undo
        private static List<bool?[,]> HistoriquePlateau = new List<bool?[,]>();

        //Curseur Undo / Redo
        private static int CurseurUndo = -1;

        //Sauvegarde l'état actuel
        public static void SauvegarderEtat()
        {
            if (CurseurUndo < HistoriquePlateau.Count - 1)
            {
                HistoriquePlateau.RemoveRange(CurseurUndo + 1, HistoriquePlateau.Count - CurseurUndo - 1);
            }

            HistoriquePlateau.Add((bool?[,])plateau.Clone());
            CurseurUndo++;
        }

        //Afficher le coup d'avant
        public static bool Undo()
        {
            if (CurseurUndo <= 0)
            {
                return false;
            }

            CurseurUndo--;         
            plateau = (bool?[,])HistoriquePlateau[CurseurUndo].Clone();
            return true;
        }

        //Afficher le coup d'après
        public static bool Redo()
        {
            if (CurseurUndo >= HistoriquePlateau.Count - 1)
            {
                return false;
            }

            CurseurUndo++;
            plateau = (bool?[,])HistoriquePlateau[CurseurUndo].Clone();
            return true;
        }


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

            //Remet les infos du Undo à 0
            CurseurUndo = -1;
            HistoriquePlateau.Clear();
            
            //Sauvegarder le plateau de base
            SauvegarderEtat();
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
