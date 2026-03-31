using System;
namespace Lib_Reversi
{
    public class CoupPossible
    {
        public static bool EstUnCoupPossible(Coords pos, bool JoueurActuel)
        {
            if (Plateau.GetCase(pos) != Plateau.VIDE) return false;
            
            int i = 1;

            //En dessous
            //
            //  ·    X
            //  O -> X
            //  X	 X
            while (pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y + i)) == JoueurActuel)
            {
                return true;
            }
            
            i = 1;

            //En dessus
            //
            //  X    X
            //  O -> X
            //  ·	 X
            while (pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X, pos.Y - i)) == JoueurActuel)
            {
                return true;
            }
            
            i = 1;

            //A gauche
            //
            // XO· -> XXX
            while (pos.X - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.X - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y)) == JoueurActuel)
            {
                return true;
            }
            
            i = 1;

            //A droite
            //
            // ·OX -> XXX
            while (pos.X + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.X + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y)) == JoueurActuel)
            {
                return true;
            }
            
            i = 1;

            //Diagonale / vers le bas
            //
            //   ·      X
            //  O  ->  X
            // X      X
            while (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y + i)) == JoueurActuel)
            {
                return true;
            }
            
            i = 1;

            //Diagonale / vers le haut
            //
            //   X      X
            //  O  ->  X
            // ·      X
            while (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.X + i < Plateau.nbCases && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y - i)) == JoueurActuel)
            {
                return true;
            }
            
            i = 1;

            //Diagonale \ vers le bas
            //
            // ·      X
            //  O  ->  X
            //   X      X
            while (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.X + i < Plateau.nbCases && pos.Y + i < Plateau.nbCases && i > 1 && Plateau.GetCase(new Coords(pos.X + i, pos.Y + i)) == JoueurActuel)
            {
                return true;
            }
            
            i = 1;

            //Diagonale \ vers le haut
            //
            // X      X
            //  O  ->  X
            //  ·X      X
            //
            while (pos.X - i >= 0 && pos.Y - i >= 0 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == !JoueurActuel)
            {
                i++;
            }
            if (pos.X - i >= 0 && pos.Y - i >= 0 && i > 1 && Plateau.GetCase(new Coords(pos.X - i, pos.Y - i)) == JoueurActuel)
            {
                return true;
            }

            return false;
        }
    }
}