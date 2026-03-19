using System;

namespace Lib_Reversi
{
    public class Verification
    {
        public static bool VerificationRegle(Coords pos, bool? JoueurActif, bool? JoueurPassif)
        {
            bool valable = false;

            //En dessous
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X, pos.Y + j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //En dessus
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X, pos.Y - j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //A gauche
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y), JoueurActif);
                    }
                    valable = true;
                }
            }

            //A droite
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.X + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le bas
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y + j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le haut
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y - j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le bas
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X + j, pos.Y + j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le haut
            if (Plateau.GetCase(pos) == Plateau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Plateau.SetCase(new Coords(pos.X - j, pos.Y - j), JoueurActif);
                    }
                    valable = true;
                }
            }

            return valable;
        }
    }
}