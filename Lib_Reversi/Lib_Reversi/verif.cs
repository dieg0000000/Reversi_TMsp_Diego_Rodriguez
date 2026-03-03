using System;

namespace Lib_Reversi
{
    public class verif
    {
        //Vérifications
        public static bool Verifcoup(char[,] grille, Coords pos, string sym, string symop)
        {
            bool valable = false;

            //En dessous
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.Y + i < 8 && grille[pos.Y + i, pos.X] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.Y + i < 8 && i > 1 && grille[pos.Y + i, pos.X] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y + j, pos.X] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //En dessus
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.Y - i >= 0 && grille[pos.Y - i, pos.X] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.Y - i >= 0 && i > 1 && grille[pos.Y - i, pos.X] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y - j, pos.X] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //A gauche
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.X - i >= 0 && grille[pos.Y, pos.X - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.X - i >= 0 && i > 1 && grille[pos.Y, pos.X - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y, pos.X - j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //A droite
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.X + i < 8 && grille[pos.Y, pos.X + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.X + i < 8 && i > 1 && grille[pos.Y, pos.X + i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y, pos.X + j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale / vers le bas
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y + i < 8 && grille[pos.Y + i, pos.X - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y + i < 8 && i > 1 && grille[pos.Y + i, pos.X - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y + j, pos.X - j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale / vers le haut
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.X + i < 8 && pos.Y - i >= 0 && grille[pos.Y - i, pos.X + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.X + i < 8 && pos.Y - i >= 0 && i > 1 && grille[pos.Y - i, pos.X + i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y - j, pos.X + j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale \ vers le bas
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.X + i < 8 && pos.Y + i < 8 && grille[pos.Y + i, pos.X + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.X + i < 8 && pos.Y + i < 8 && i > 1 && grille[pos.Y + i, pos.X + i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y + j, pos.X + j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale \ vers le haut
            if (grille[pos.Y, pos.X] == ' ')
            {
                int i = 1;

                while (pos.X - i >= 0 && pos.Y - i >= 0 && grille[pos.Y - i, pos.X - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && grille[pos.Y - i, pos.X - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[pos.Y - j, pos.X - j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            return valable;
        }
    }
}