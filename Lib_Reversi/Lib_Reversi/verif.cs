using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Reversi
{
    public class verif
    {
        //Vérifications
       public static bool Verifcoup(char[,] grille, int x1, int xA, string sym, string symop, bool valable)
        {
            //En dessous
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (x1 + i < 8 && grille[xA, x1 + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (x1 + i < 8 && i > 1 && grille[xA, x1 + i] == Convert.ToChar(sym))
                {
                    //Retourner les valablens intermédiaires
                    for (int j = 1; j < i; j++)
                    {
                        grille[xA, x1 + j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA, x1 + j);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            //En dessus
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (x1 - i >= 0 && grille[xA, x1 - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (x1 - i >= 0 && i > 1 && grille[xA, x1 - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[xA, x1 - j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA, x1 - j);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            //A gauche
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && grille[xA - i, x1] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && i > 1 && grille[xA - i, x1] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA - j, x1] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA - j, x1);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            //A droite
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && grille[xA + i, x1] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && i > 1 && grille[xA + i, x1] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA + j, x1] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA + j, x1);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale / vers le bas
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && x1 + i < 8 && grille[xA - i, x1 + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && x1 + i < 8 && i > 1 && grille[xA - i, x1 + i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA - j, x1 + j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA - j, x1 + j);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale / vers le haut
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && x1 - i >= 0 && grille[xA + i, x1 - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && x1 - i >= 0 && i > 1 && grille[xA + i, x1 - i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA + j, x1 - j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA + j, x1 - j);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale \ vers le bas
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && x1 + i < 8 && grille[xA + i, x1 + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && x1 + i < 8 && i > 1 && grille[xA + i, x1 + i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA + j, x1 + j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA + j, x1 + j);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            //Diagonale \ vers le haut
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && x1 - i >= 0 && grille[xA - i, x1 - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && x1 - i >= 0 && i > 1 && grille[xA - i, x1 - i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA - j, x1 - j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA - j, x1 - j);
                        Console.Write(sym);
                    }

                    valable = true;
                }
            }

            return valable;
        }
    }
}
