namespace Lib_Reversi
{

    public struct Coords
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct VerifCoords
    {
        //eVerifie le format de l'entrée
        public static bool VerifEntree(string x)
        {
            //Verifie si sa respecte la longueur
            if (x.Length == 2)
            {
                //Prendre la lettre
                char lettre = x[0];

                //Prendre le numéro
                char numero = x[1];

                //Verifie si la lettre est entre A et H
                if ((lettre >= 'A' && lettre <= 'H') || (lettre >= 'a' && lettre <= 'h'))
                {
                    //verifie si le nombre est entre 1 et 8
                    if (numero >= '1' && numero <= '8')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
} 

