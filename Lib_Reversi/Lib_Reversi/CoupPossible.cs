using System;
namespace Lib_Reversi
{
    public class CoupPossible
    {
        public static bool EstUnCoupPossible(Coords pos, bool? JoueurActif, bool? JoueurPassif)
        {
            if (Plateau.GetCase(pos) != Plateau.VIDE) return false;

            //En dessous
            int i = 1;
            while (pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurActif)
            {
                return true;
            }

            //En dessus
            i = 1;
            while (pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurActif)
            {
                return true;
            }

            //A gauche
            i = 1;
            while (pos.X - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurActif)
            {
                return true;
            }

            //A droite
            i = 1;
            while (pos.X + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurActif)
            {
                return true;
            }

            //Diagonale / vers le bas
            i = 1;
            while (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurActif)
            {
                return true;
            }

            //Diagonale / vers le haut
            i = 1;
            while (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurActif)
            {
                return true;
            }

            //Diagonale \ vers le bas
            i = 1;
            while (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurActif)
            {
                return true;
            }

            //Diagonale \ vers le haut
            i = 1;
            while (pos.X - i >= 0 && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurPassif)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurActif)
            {
                return true;
            }

            return false;
        }
    }
}