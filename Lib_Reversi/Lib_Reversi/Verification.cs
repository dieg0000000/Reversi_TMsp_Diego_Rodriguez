// ===============================================================================================
// AUTHOR     :         Diego Rodriguez                                                           
// CREATE DATE     :    27 janvier 2026                                                           
// PURPOSE     :        Moteur de jeu : Vérifie si un coup est valide et retourne les pions       
//                      adverses capturés dans les 8 directions.                                  
// SPECIAL NOTES    :   Oubliez pas de générer la solution (Ctrl+Maj+B) après chaque modification 
//                      pour retouver les modifications dans votre code                           
// ===============================================================================================
// CHANGE HISTORY   :   31-03-2026 - Amélioration des commentaires
// ===============================================================================================

namespace Lib_Reversi
{
    public class Verification
    {
        public static bool VerificationRegleEtRetourne(Coords pos, bool JoueurActuelX)
        {
            bool valable = false;

            //En dessous
            //
            //  ·    X
            //  O -> X
            //  X	 X
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'en dessous il y a un pion adverse, on continue
                while (pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X, pos.Y + j), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            //En dessus
            //
            //  X    X
            //  O -> X
            //  ·	 X
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'en dessus il y a un pion adverse, on continue
                while (pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X, pos.Y - j), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            //A gauche
            //
            // XO· -> XXX 
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'à gauche il y a un pion adverse, on continue
                while (pos.X - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            //A droite
            //
            // ·OX -> XXX   
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'à droite il y a un pion adverse, on continue
                while (pos.X + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le bas
            //
            //   ·      X
            //  O  ->  X
            // X      X
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'en dessous à gauche il y a un pion adverse, on continue
                while (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y + j), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le haut
            //
            //   X      X
            //  O  ->  X
            // ·      X
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'en dessus à droite il y a un pion adverse, on continue
                while (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y - j), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le bas
            //
            // ·      X
            //  O  ->  X
            //   X      X
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'en dessous à droite il y a un pion adverse, on continue
                while (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y + j), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le haut
            //
            // X      X
            //  O  ->  X
            //  ·X      X
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                //Tan qu'en dessus à gauche il y a un pion adverse, on continue
                while (pos.X - i >= 0 && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == !JoueurActuelX)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurActuelX)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y - j), JoueurActuelX);
                    }
                    valable = true;
                }
            }

            return valable;
        }
    }
}