namespace Lib_Reversi
{
    public class tableau
    {
        //Initialisation du plateau invisible qui gardera les valeurs de la partie pour chaque case (Null, True et False)


        public const int nbCases = 8;
        public const int pionBaseX = 3;
        public const int pionBaseY = 4;
        private static bool?[,] plateau = new bool?[nbCases, nbCases];

        public static readonly bool? NOIR = true;
        public static readonly bool? BLANC = false;
        public static readonly bool? VIDE = null;

        //Lire une case
        public static bool? GetCase(Coords pos)
        {
            return plateau[pos.Y, pos.X];
        }

        //Ecrire une case
        public static void SetCase(Coords pos, bool? valeur)
        {
            plateau[pos.Y, pos.X] = valeur;
        }

        public static void InitialiserGrille()
        {
            for (int ligne = 0; ligne < nbCases; ligne++)
            {
                for (int col = 0; col < nbCases; col++)
                {
                    plateau[ligne, col] = VIDE;
                }
            }
            
            //Ajouter les 4 pions de base dans le tableau
            plateau[pionBaseX, pionBaseX] = NOIR;
            plateau[pionBaseX, pionBaseY] = BLANC;
            plateau[pionBaseY, pionBaseX] = BLANC;
            plateau[pionBaseY, pionBaseY] = NOIR;
        }
    }
}


