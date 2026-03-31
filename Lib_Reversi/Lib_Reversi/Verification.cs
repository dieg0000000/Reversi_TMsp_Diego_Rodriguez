using System;

namespace Lib_Reversi
{
    public class Verification
    {
        public static bool VerificationRegleEtRetourne(Coords pos, bool JoueurActuel)
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
                while (pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X, pos.Y + j), JoueurActuel);
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
                while (pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X, pos.Y - j), JoueurActuel);
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
                while (pos.X - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y), JoueurActuel);
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
                while (pos.X + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y), JoueurActuel);
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
                while (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y + j), JoueurActuel);
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
                while (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y - j), JoueurActuel);
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
                while (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y + j), JoueurActuel);
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
                while (pos.X - i >= 0 && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == !JoueurActuel)
                {
                    i++;
                }

                //Si apres il y a un pion au joueur actuel
                if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurActuel)
                {
                    //Pour ceux qu'on a parcourru, on les retourne
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y - j), JoueurActuel);
                    }
                    valable = true;
                }
            }

            return valable;
        }
    }
}