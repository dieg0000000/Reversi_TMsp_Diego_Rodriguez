using System;
namespace Lib_Reversi
{
    public class coupposs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="JoueurActif"></param>
        /// <param name="JoueurPassif"></param>
        /// <returns></returns>
        public static bool Couppossible(Coords pos, bool? JoueurActif, bool? JoueurPassif)
        {
            if (tableau.GetCase(pos) != tableau.VIDE) return false;

            //En dessous
            int i = 1;
            while (pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurActif)
            {
                return true;
            }

            //En dessus
            i = 1;
            while (pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurActif)
            {
                return true;
            }

            //A gauche
            i = 1;
            while (pos.X - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurActif)
            {
                return true;
            }

            //A droite
            i = 1;
            while (pos.X + i < 8 && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurActif)
            {
                return true;
            }

            //Diagonale / vers le bas
            i = 1;
            while (pos.X - i >= 0 && pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurActif)
            {
                return true;
            }

            //Diagonale / vers le haut
            i = 1;
            while (pos.X + i < 8 && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X + i < 8 && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurActif)
            {
                return true;
            }

            //Diagonale \ vers le bas
            i = 1;
            while (pos.X + i < 8 && pos.Y + i < 8 && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X + i < 8 && pos.Y + i < 8 && i > 1 && tableau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurActif)
            {
                return true;
            }

            //Diagonale \ vers le haut
            i = 1;
            while (pos.X - i >= 0 && pos.Y - i >= 0 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && tableau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurActif)
            {
                return true;
            }

            return false;
        }
    }
}