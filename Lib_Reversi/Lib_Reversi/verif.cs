using System;

namespace Lib_Reversi
{
    public class verif
    {
        public static bool Verifcoup(Coords pos, bool? sym, bool? symop)
        {
            bool valable = false;

            //En dessous
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == symop)
                {
                    i++;
                }

                if (pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X, pos.Y + j), sym);
                    }
                    valable = true;
                }
            }

            //En dessus
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == symop)
                {
                    i++;
                }

                if (pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X, pos.Y - j), sym);
                    }
                    valable = true;
                }
            }

            //A gauche
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == symop)
                {
                    i++;
                }

                if (pos.X - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X - j, pos.Y), sym);
                    }
                    valable = true;
                }
            }

            //A droite
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X + i < 8 && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == symop)
                {
                    i++;
                }

                if (pos.X + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X + j, pos.Y), sym);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le bas
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == symop)
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X - j, pos.Y + j), sym);
                    }
                    valable = true;
                }
            }

            //Diagonale / vers le haut
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X + i < 8 && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == symop)
                {
                    i++;
                }

                if (pos.X + i < 8 && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X + j, pos.Y - j), sym);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le bas
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X + i < 8 && pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == symop)
                {
                    i++;
                }

                if (pos.X + i < 8 && pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X + j, pos.Y + j), sym);
                    }
                    valable = true;
                }
            }

            //Diagonale \ vers le haut
            if (tableau.GetCase(pos) == tableau.VIDE)
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == symop)
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == sym)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tableau.SetCase(new Coords(pos.X - j, pos.Y - j), sym);
                    }
                    valable = true;
                }
            }

            return valable;
        }
    }
}