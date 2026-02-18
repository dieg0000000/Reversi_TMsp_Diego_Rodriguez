namespace Lib_Reversi
{
    public class tableau
    {
        //Créer une grille de 8 par 8
        public static char[,] grille = new char[8, 8];

        public static void InitialiserGrille()
        {
            //Mettre des espaces vides dasn chaque case
            int longu = 8;
            for (int ligne = 0; ligne < longu; ligne++)
            {
                for (int col = 0; col < longu; col++)
                {
                    grille[ligne, col] = ' ';
                }
            }

            //Pions au milieu de base (invisible)
            grille[3, 3] = 'X';
            grille[3, 4] = 'O';
            grille[4, 3] = 'O';
            grille[4, 4] = 'X';
        }

    }
}
