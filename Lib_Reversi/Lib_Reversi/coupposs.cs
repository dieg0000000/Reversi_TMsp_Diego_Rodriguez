using System;
namespace Lib_Reversi
{
    public class coupposs
    {
        public static bool Couppossible(Coords pos, bool? sym, bool? symop)
        {
            if (tableau.GetCase(pos) != tableau.VIDE) return false;

            //En dessous
            int i = 1;
            while (pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == symop)
            {
                i++;
            }
            if (pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == sym)
            {
                return true;
            }

            //En dessus
            i = 1;
            while (pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == symop)
            {
                i++;
            }
            if (pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == sym)
            {
                return true;
            }

            //A gauche
            i = 1;
            while (pos.X - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == symop)
            {
                i++;
            }
            if (pos.X - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == sym)
            {
                return true;
            }

            //A droite
            i = 1;
            while (pos.X + i < 8 && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == symop)
            {
                i++;
            }
            if (pos.X + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == sym)
            {
                return true;
            }

            //Diagonale / vers le bas
            i = 1;
            while (pos.X - i >= 0 && pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == symop)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == sym)
            {
                return true;
            }

            //Diagonale / vers le haut
            i = 1;
            while (pos.X + i < 8 && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == symop)
            {
                i++;
            }
            if (pos.X + i < 8 && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == sym)
            {
                return true;
            }

            //Diagonale \ vers le bas
            i = 1;
            while (pos.X + i < 8 && pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == symop)
            {
                i++;
            }
            if (pos.X + i < 8 && pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == sym)
            {
                return true;
            }

            //Diagonale \ vers le haut
            i = 1;
            while (pos.X - i >= 0 && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == symop)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == sym)
            {
                return true;
            }

            return false;
        }
    }
}