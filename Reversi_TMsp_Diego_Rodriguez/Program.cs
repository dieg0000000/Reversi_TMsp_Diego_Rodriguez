using System;
using System.Text.RegularExpressions;

namespace Reversi_TMsp_Diego_Rodriguez
{
    internal class Program
    {

        //Vérifications
        static bool Verif(char[,] grille, int x1, int xA, string sym, string symop, bool pio)
        {
            //En dessous
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (x1 + i < 8 && grille[xA, x1 + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (x1 + i < 8 && i > 1 && grille[xA, x1 + i] == Convert.ToChar(sym))
                {
                    //Retourner les pions intermédiaires
                    for (int j = 1; j < i; j++)
                    {
                        grille[xA, x1 + j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA, x1 + j);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            //En dessus
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (x1 - i >= 0 && grille[xA, x1 - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (x1 - i >= 0 && i > 1 && grille[xA, x1 - i] == Convert.ToChar(sym))
                {
                    for (int j = 1; j < i; j++)
                    {
                        grille[xA, x1 - j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA, x1 - j);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            //A gauche
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && grille[xA - i, x1] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && i > 1 && grille[xA - i, x1] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA - j, x1] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA - j, x1);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            //A droite
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && grille[xA + i, x1] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && i > 1 && grille[xA + i, x1] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA + j, x1] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA + j, x1);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            //Diagonale / vers le bas
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && x1 + i < 8 && grille[xA - i, x1 + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && x1 + i < 8 && i > 1 && grille[xA - i, x1 + i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA - j, x1 + j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA - j, x1 + j);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            //Diagonale / vers le haut
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && x1 - i >= 0 && grille[xA + i, x1 - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && x1 - i >= 0 && i > 1 && grille[xA + i, x1 - i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA + j, x1 - j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA + j, x1 - j);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            //Diagonale \ vers le bas
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA + i < 8 && x1 + i < 8 && grille[xA + i, x1 + i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA + i < 8 && x1 + i < 8 && i > 1 && grille[xA + i, x1 + i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA + j, x1 + j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA + j, x1 + j);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            //Diagonale \ vers le haut
            if (grille[xA, x1] == ' ')
            {
                int i = 1;

                while (xA - i >= 0 && x1 - i >= 0 && grille[xA - i, x1 - i] == Convert.ToChar(symop))
                {
                    i++;
                }

                if (xA - i >= 0 && x1 - i >= 0 && i > 1 && grille[xA - i, x1 - i] == Convert.ToChar(sym))
                {

                    for (int j = 1; j < i; j++)
                    {
                        grille[xA - j, x1 - j] = Convert.ToChar(sym);

                        Console.SetCursorPosition(xA - j, x1 - j);
                        Console.Write(sym);
                    }

                    pio = true;
                }
            }

            return pio;
        }

        static void Main(string[] args)
        {
            bool jeu = true;
            do
            {
                //Créer une grille de 8 par 8
                char[,] grille = new char[8, 8];

                int longu = 8;
                for (int ligne = 0; ligne < longu; ligne++)
                {
                    for (int col = 0; col < longu; col++)
                    {
                        grille[ligne, col] = ' ';
                    }
                }

                //Afficher la grille
                for (int ligne = 0; ligne < 8; ligne++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        Console.Write("·");
                    }
                    Console.WriteLine();
                }

                //Affichage des lignes
                for (int l = 1; l < 9; l++)
                {
                    Console.SetCursorPosition(8, l - 1);
                    Console.Write(l);
                }

                //Affichage des colonnes
                Console.WriteLine();
                Console.WriteLine("ABCDEFGH");

                //Pions au milieu de base (invisible)



                grille[3, 3] = 'X';
                grille[3, 4] = 'O';
                grille[4, 3] = 'O';
                grille[4, 4] = 'X';


                //Affichage du compteur à 2 pour chaque pion, avant qu'il commence à compter 
                Console.SetCursorPosition(14, 3);
                Console.Write("X = 2");
                Console.SetCursorPosition(14, 4);
                Console.Write("O = 2");

                //Pions au milieu de base (affiché)
                Console.SetCursorPosition(3, 3);
                Console.Write("X");
                Console.SetCursorPosition(3, 4);
                Console.Write("O");
                Console.SetCursorPosition(4, 3);
                Console.Write("O");
                Console.SetCursorPosition(4, 4);
                Console.Write("X");


                ///Déclaration des variables
                int tour = 0;
                bool pio = false;
                bool partie = true;
                string sym = "X";
                string symop = "O";

                //Instructions
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Veuillez entrer un coup (ex. A1) :");
                Console.SetCursorPosition(34, 11);

                //Boucle principale
                while (partie == true)
                {
                    //Déclaration des compteurs de pions
                    int comptX = 0;
                    int comptO = 0;
                    int comptVide = 0;

                    //Clear la donnée entrée
                    Console.SetCursorPosition(34, 11);
                    Console.Write("               ");
                    Console.SetCursorPosition(34, 11);

                    //Valeur de base
                    string x = Console.ReadLine();

                    //Clear du message d'erreur
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("                                                                               ");

                    //Regex généré par l'IA
                    string pattern = @"^[A-Ha-h][1-8]$";

                    //Vérification de l'entrée de l'utilisateur
                    bool isValid = Regex.IsMatch(x, pattern);

                    if (isValid == true)
                    {
                        //Prendre la lettre
                        int xA = x[0];                                  //xA = A (LETTRE)

                        //Prendre le numéro
                        string x11 = x.Substring(1);

                        //Convertir le numéro
                        int x1 = Convert.ToInt32(x11);                  //x1 = 1 (NUMERO)

                        //Passer en valeur tableau
                        x1 = x1 - 1;

                        //Si tour pair ou impair O ou X
                        if (tour % 2 == 0)
                        {
                            sym = "X";
                            symop = "O";
                        }
                        else
                        {
                            sym = "O";
                            symop = "X";
                        }

                        //Lettre en numero (A = 0)
                        if (xA == 'A' || xA == 'a') xA = 0;
                        else if (xA == 'B' || xA == 'b') xA = 1;
                        else if (xA == 'C' || xA == 'c') xA = 2;
                        else if (xA == 'D' || xA == 'd') xA = 3;
                        else if (xA == 'E' || xA == 'e') xA = 4;
                        else if (xA == 'F' || xA == 'f') xA = 5;
                        else if (xA == 'G' || xA == 'g') xA = 6;
                        else if (xA == 'H' || xA == 'h') xA = 7;
                        else
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.WriteLine("Entrée invalide !!");
                        }
                        Console.WriteLine();

                        //Si la case est vide
                        if (grille[xA, x1] == ' ')
                        {
                            //Appel de la méthode qui vérifie si on peut jouer dans cette case
                            pio = Verif(grille, x1, xA, sym, symop, pio);

                            //Si oui place le pion
                            if (pio == true)
                            {
                                grille[xA, x1] = Convert.ToChar(sym);
                                Console.SetCursorPosition(xA, x1);
                                Console.Write(sym);
                                tour++;
                                pio = false;

                                //Clear du message d'erreur
                                Console.SetCursorPosition(0, 13);
                                Console.WriteLine("                     ");
                            }

                            //Si non, coup invalide
                            else
                            {
                                Console.SetCursorPosition(0, 13);
                                Console.Write("Coup invalide !!");
                            }
                        }

                        //Si la case est pas vide
                        else
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.Write("Case occupée !!");
                        }

                        //Comptage de chaque pion 
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (grille[i, j] == 'X')
                                {
                                    comptX++;
                                }

                                else if (grille[i, j] == 'O')
                                {
                                    comptO++;
                                }

                                else if (grille[i, j] == ' ')
                                {
                                    comptVide++;
                                    Console.SetCursorPosition(14, 5);
                                    Console.Write("' ' = " + comptVide);
                                }
                            }
                        }

                        //Affichage du nombre de pions de chaque joueur (Cases vide pour debug)
                        Console.SetCursorPosition(14, 3);
                        Console.Write("X = " + comptX);
                        Console.SetCursorPosition(14, 4);
                        Console.Write("O = " + comptO);

                        //Fin de partie
                        if (comptVide == 0)
                        {
                            //Clear du plateau
                            Console.Clear();

                            //Affichage des visuels de fin de partie
                            Console.WriteLine("                ");
                            Console.WriteLine("                ");
                            Console.WriteLine("Partie terminée !");
                            Console.WriteLine("                ");
                            Console.WriteLine("                ");
                            Console.WriteLine("     X = " + comptX);
                            Console.WriteLine("     O = " + comptO);
                            Console.WriteLine("                ");
                            Console.WriteLine("                ");

                            //Definition du vainqueur
                            if (comptX > comptO)
                            {
                                Console.WriteLine("Victoire des X !!");
                            }
                            else if (comptO > comptX)
                            {
                                Console.WriteLine("Victoire des O !!");
                            }
                            else
                            {
                                Console.WriteLine("Egalité");
                            }

                            //Affichage des visuels de fin de partie
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Que voulez-vous faire ?");
                            Console.WriteLine("                ");
                            Console.WriteLine("                ");
                            Console.WriteLine("[1] Nouvelle partie");
                            Console.WriteLine("[2] Quitter");

                            while (partie == true)
                            {
                                Console.SetCursorPosition(23, 12);
                                string mov1 = Console.ReadLine();
                                int mov;

                                if (int.TryParse(mov1, out mov) && (mov == 1 || mov == 2))
                                {
                                    partie = false;

                                    if (mov == 1)
                                    {
                                        Console.Clear();
                                        jeu = true;
                                    }
                                    else
                                    {
                                        jeu = false;
                                    }
                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 13);
                                    Console.WriteLine("Entrée invalide. Veuillez taper 1 ou 2.");
                                    Console.SetCursorPosition(24, 12);
                                    Console.Write("                                               ");

                                }
                            }
                        }

                    }
                    else
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.WriteLine("Entrée invalide. Veuillez suivre l'exemple.");
                    }
                }
            }
            while (jeu == true);
        }
    }
}


