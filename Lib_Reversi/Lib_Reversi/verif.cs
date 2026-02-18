using System;

namespace Lib_Reversi
{
    public class verif
    {
        //Vérifications
        public static bool Verifcoup(char[,] grille, int x1, int xA, string sym, string symop)
        {
            bool valable = false;

            //En dessous
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (x1 + i < 8 && grille[x1 + i, xA] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (x1 + i < 8 && i > 1 && grille[x1 + i, xA] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1 + j, xA] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //En dessus
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (x1 - i >= 0 && grille[x1 - i, xA] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (x1 - i >= 0 && i > 1 && grille[x1 - i, xA] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1 - j, xA] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //A gauche
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && grille[x1, xA - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && i > 1 && grille[x1, xA - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1, xA - j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //A droite
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && grille[x1, xA + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && i > 1 && grille[x1, xA + i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1, xA + j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale / vers le bas
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && x1 + i < 8 && grille[x1 + i, xA - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && x1 + i < 8 && i > 1 && grille[x1 + i, xA - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1 + j, xA - j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale / vers le haut
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && x1 - i >= 0 && grille[x1 - i, xA + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && x1 - i >= 0 && i > 1 && grille[x1 - i, xA + i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1 - j, xA + j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale \ vers le bas
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && x1 + i < 8 && grille[x1 + i, xA + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && x1 + i < 8 && i > 1 && grille[x1 + i, xA + i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1 + j, xA + j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale \ vers le haut
            if (grille[x1, xA] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && x1 - i >= 0 && grille[x1 - i, xA - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && x1 - i >= 0 && i > 1 && grille[x1 - i, xA - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[x1 - j, xA - j] = Convert.ToChar(sym);
                    }

                    valable = true;
                }
            }

            return valable;
        }
    }
}