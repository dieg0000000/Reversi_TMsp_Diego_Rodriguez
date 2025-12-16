using System;

namespace Reversi_TMsp_Diego_Rodriguez
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("  A B C D E F G H");


            const int longu = 8;

            //Créer une grille de 8 par 8
            char[,] grille = new char[longu, longu];

            for (int ligne = 0; ligne < longu; ligne++)
            {
                for (int col = 0; col < longu; col++)
                {
                    grille[ligne, col] = ' ';
                }
            }

            //afficher la grille
            for (int ligne = 0; ligne < 8; ligne++)
            {
                Console.Write(ligne + 1);
                for (int col = 0; col < 8; col++)
                {
                    Console.Write(grille[ligne, col] + ("·"));
                }
                Console.WriteLine();
            }

            //Les 4 pions au milieu de base
            grille[4, 4] = Convert.ToChar("X");
            Console.SetCursorPosition(4 * 2, 4);
            Console.Write("X");
            grille[4, 5] = Convert.ToChar("O");
            Console.SetCursorPosition(4 * 2, 5);
            Console.Write("O");
            grille[5, 4] = Convert.ToChar("O");
            Console.SetCursorPosition(5 * 2, 4);
            Console.Write("O");
            grille[5, 5] = Convert.ToChar("X");
            Console.SetCursorPosition(5 * 2, 5);
            Console.Write("X");




            //Système de tours 
            int tour = 0;
            bool pio = false;
            string sym = "X";
            String symop = "O";
            


            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Veuillez entrer un coup (ex. A1) :");
            Console.SetCursorPosition(34, 11);



            while (true)
            {

                //Clear la donnée 
                Console.SetCursorPosition(34, 11);
                Console.Write("        ");
                Console.SetCursorPosition(34, 11);

                //Valeur de base
                string x = Console.ReadLine();

                //Prendre la lettre
                int xA = x[0];                        //xA = A (LETTRE)

                //Prendre le numéro~~
                string x11 = x.Substring(1);

                //Convertir le numéro
                int x1 = Convert.ToInt32(x11);        //x1 = 1 (NUMERO)




                //Clear le "Entrée invalide !!"
                Console.SetCursorPosition(0, 12);
                Console.Write("                               ");
                Console.SetCursorPosition(0, 12);


                //Si tour pair ou impair O ou X
                if (tour % 2 == 0)
                {
                    sym = "X";
                }
                else
                {
                    sym = "O";
                }

                //Tour opposés
                if (tour % 2 == 0)
                {
                    symop = "O";
                }
                else
                {
                    symop = "X";
                }

                //Pas jouer en dehors du tableau
                if (Convert.ToInt32(x1) > 8)
                {
                    Console.WriteLine("Entrée invalide !!");
                }


                //Lettre en numero (A = 1)
                else if (xA == 'A' || xA == 'a')
                {
                    xA = 1;
                }

                else if (xA == 'B' || xA == 'b')
                {
                    xA = 2;
                }

                else if (xA == 'C' || xA == 'c')
                {
                    xA = 3;
                }

                else if (xA == 'D' || xA == 'd')
                {
                    xA = 4;
                }

                else if (xA == 'E' || xA == 'e')
                {
                    xA = 5;
                }

                else if (xA == 'F' || xA == 'f')
                {
                    xA = 6;
                }

                else if (xA == 'G' || xA == 'g')
                {
                    xA = 7;
                }

                else if (xA == 'H' || xA == 'h')
                {
                    xA = 8;
                }


                //Pas pouvoir jouer une autre case
                else
                {
                    Console.WriteLine("Entrée invalide !!");
                }



                //Temporaire
                Console.WriteLine("lettre = " + xA);
                Console.WriteLine("numero = " + x1);

                //Effacer le message d'erreur
                Console.SetCursorPosition(0, 16);
                Console.Write("                       ");

                if (x1 < 7)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!");
                }

                ////placement de x dans la grille
                //Si case vide 1
                if (grille[xA, x1] == ' ')
                {
                    if (grille[xA, x1 + 1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("1!");
                        pio = true;
                    }
                    else if (grille[xA - 1, x1 + 1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("2!");
                        pio = true;
                    }
                    else if (grille[xA - 1, x1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("3!");
                        pio = true;
                    }
                    else if (grille[xA - 1, x1 - 1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("4!");
                        pio = true;
                    }
                    else if (grille[xA, x1 - 1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("5!"); 
                        pio = true;
                    }
                    else if (grille[xA + 1, x1 - 1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("6!");
                        pio = true;
                    }
                    else if (grille[xA + 1, x1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("7!");
                        pio = true;
                    }
                    else if (grille[xA + 1, x1 + 1] == Convert.ToChar(symop))
                    {
                        Console.WriteLine("8!"); 
                        pio = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.WriteLine("Entrée invalide !!");
                        pio = true;
                    }


                    if (pio == true)
                    {
                        grille[xA, x1] = Convert.ToChar(sym);
                        Console.SetCursorPosition(xA * 2, x1);
                        Console.Write(sym);
                        tour++;
                        pio = false;
                    }
                    

                }
                //Case occupée
                else
                {
                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("Case occupée !!");
                }
                


            }
        }
    }
}
