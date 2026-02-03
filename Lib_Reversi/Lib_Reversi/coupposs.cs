using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Reversi
{
    public class coupposs
    {
        //Coups possibles
        public static bool Couppossible(char[,] grille, int x1, int xA, string sym, string symop)
        {

            if (grille[xA, x1] != ' ') return false;

            //En dessous
            int i = 1;
            while (x1 + i < 8 && grille[xA, x1 + i] == Convert.ToChar(symop))
            {
                i++;
            }
            if (x1 + i < 8 && i > 1 && grille[xA, x1 + i] == Convert.ToChar(sym))
            {
                return true;
            }

            //En dessus
            i = 1;
            while (x1 - i >= 0 && grille[xA, x1 - i] == Convert.ToChar(symop))
            {
                i++;
            }
            if (x1 - i >= 0 && i > 1 && grille[xA, x1 - i] == Convert.ToChar(sym))
            {
                return true;
            }

            //Gauche
            i = 1;
            while (xA - i >= 0 && grille[xA - i, x1] == Convert.ToChar(symop))
            {
                i++;
            }
            if (xA - i >= 0 && i > 1 && grille[xA - i, x1] == Convert.ToChar(sym))
            {
                return true;
            }

            //A droite
            i = 1;
            while (xA + i < 8 && grille[xA + i, x1] == Convert.ToChar(symop))
            {
                i++;
            }
            if (xA + i < 8 && i > 1 && grille[xA + i, x1] == Convert.ToChar(sym))
            {
                return true;
            }

            //Diagonale / vers le bas
            i = 1;
            while (xA - i >= 0 && x1 + i < 8 && grille[xA - i, x1 + i] == Convert.ToChar(symop))
            {
                i++;
            }
            if (xA - i >= 0 && x1 + i < 8 && i > 1 && grille[xA - i, x1 + i] == Convert.ToChar(sym))
            {
                return true;
            }

            //Diagonale / vers le haut
            i = 1;
            while (xA + i < 8 && x1 - i >= 0 && grille[xA + i, x1 - i] == Convert.ToChar(symop))
            {
                i++;
            }
            if (xA + i < 8 && x1 - i >= 0 && i > 1 && grille[xA + i, x1 - i] == Convert.ToChar(sym))
            {
                return true;
            }

            //Diagonale \ vers le bas
            i = 1;
            while (xA + i < 8 && x1 + i < 8 && grille[xA + i, x1 + i] == Convert.ToChar(symop))
            {
                i++;
            }
            if (xA + i < 8 && x1 + i < 8 && i > 1 && grille[xA + i, x1 + i] == Convert.ToChar(sym))
            {
                return true;
            }

            //Diagonale \ vers le haut
            i = 1;
            while (xA - i >= 0 && x1 - i >= 0 && grille[xA - i, x1 - i] == Convert.ToChar(symop))
            {
                i++;
            }

            if (xA - i >= 0 && x1 - i >= 0 && i > 1 && grille[xA - i, x1 - i] == Convert.ToChar(sym))
            {
                return true;
            }

            return false;
        }
    }
}
