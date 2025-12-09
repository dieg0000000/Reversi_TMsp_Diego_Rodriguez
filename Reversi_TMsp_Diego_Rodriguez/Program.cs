using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            grille[5, 4] = Convert.ToChar("X");
            Console.SetCursorPosition(5 * 2, 4);
            Console.Write("O");
            grille[5, 5] = Convert.ToChar("O");
            Console.SetCursorPosition(5 * 2, 5);
            Console.Write("X");




            //Système de tours 
            int tour = 0;
            string sym = "X";


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
                int xA = x[0];

                //Prendre le numéro
                string x11 = x.Substring(1);

                //Convertir le numéro                 //xA = A (LETTRE)
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

                Console.ReadLine();
                //placement de x dans la grille
                for (int ligne = 5; ligne >= 0; ligne--)
                {
                    if (grille[xA, x1] == ' ')
                    {
                        grille[xA, x1] = Convert.ToChar(sym);
                        Console.SetCursorPosition(xA * 2, x1);
                        Console.Write(sym);
                    }


                }
            }
        }
    }
}
