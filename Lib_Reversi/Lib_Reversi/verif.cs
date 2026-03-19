using System;

namespace Lib_Reversi
{
    public class verif
    {
        public static bool Verifcoup(Coords pos, bool? JoueurActif, bool? JoueurPassif)
        {
            bool valable = false;

            //En dessous
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.Y + i < tableau.nbCases && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.Y + i < tableau.nbCases && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X, pos.Y + j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //En dessus
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X, pos.Y - j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //A gauche
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X - j, pos.Y), JoueurActif);
                    }
                    valable = true;
                }
            }

            //A droite
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X + i < tableau.nbCases && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X + i < tableau.nbCases && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X + j, pos.Y), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le bas
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y + i < tableau.nbCases && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y + i < tableau.nbCases && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X - j, pos.Y + j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le haut
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X + i < tableau.nbCases && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X + i < tableau.nbCases && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X + j, pos.Y - j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le bas
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X + i < tableau.nbCases && pos.Y + i < tableau.nbCases && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X + i < tableau.nbCases && pos.Y + i < tableau.nbCases && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X + j, pos.Y + j), JoueurActif);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le haut
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurPassif)
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurActif)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X - j, pos.Y - j), JoueurActif);
                    }
                    valable = true;
                }
            }

            return valable;
        }
    }
}