namespace Lib_Reversi
{
    public class tableau
    {
        
        //
        private static bool?[,] plateau = new bool?[8, 8];

        public static readonly bool? NOIR = true;
        public static readonly bool? BLANC = false;
        public static readonly bool? VIDE = null;

        // Lire une case
        public static bool? GetCase(Coords pos)
        {
            return plateau[pos.Y, pos.X];
        }

        // Ecrire une case
        public static void SetCase(Coords pos, bool? valeur)
        {
            plateau[pos.Y, pos.X] = valeur;
        }

        public static void InitialiserGrille()
        {
            for (int ligne = 0; ligne < 8; ligne++)
                for (int col = 0; col < 8; col++)
                    plateau[ligne, col] = VIDE;

            plateau[3, 3] = NOIR;
            plateau[3, 4] = BLANC;
            plateau[4, 3] = BLANC;
            plateau[4, 4] = NOIR;
        }
    }
}


