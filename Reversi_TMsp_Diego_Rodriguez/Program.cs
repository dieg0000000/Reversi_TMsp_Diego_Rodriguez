using System;
using System.Text.RegularExpressions;
using Lib_Reversi;

namespace Reversi_TMsp_Diego_Rodriguez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            bool jeu = true;
            do
            {
                tableau.InitialiserGrille();

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

                ///Déclaration des variables
                int aff = 0;
                bool valable = false;
                bool partie = true;
                bool menu = false;
                
                //Affichage des colonnes
                Console.WriteLine();
                Console.WriteLine("ABCDEFGH");

                //Affichage du compteur à 2 pour chaque valablen, avant qu'il commence à compter 
                Console.SetCursorPosition(14, 3);
                Console.Write("X = 2");
                Console.SetCursorPosition(14, 4);
                Console.Write("O = 2");

                //valablens au milieu de base (affiché)
                Console.SetCursorPosition(3, 3);
                Console.Write("X");
                Console.SetCursorPosition(3, 4);
                Console.Write("O");
                Console.SetCursorPosition(4, 3);
                Console.Write("O");
                Console.SetCursorPosition(4, 4);
                Console.Write("X");

                //Instructions
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Au tour du joueur " + joueur.sym);
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Veuillez entrer un coup (ex. A1) :");
                Console.SetCursorPosition(34, 11);

                //Boucle principale
                while (partie == true)
                {
                    //Déclaration des compteurs de valablens
                    int comptX = 0;
                    int comptO = 0;
                    int comptVide = 0;
                    int comptPossible = 0;

                    //Affichage des coups possibles
                    for (int ligne = 0; ligne < 8; ligne++)
                    {
                        for (int col = 0; col < 8; col++)
                        {
                            if (tableau.grille[ligne, col] == ' ')
                            {
                                if (coupposs.Couppossible(tableau.grille, col, ligne, joueur.sym, joueur.symop))
                                {
                                    Console.SetCursorPosition(ligne, col);
                                    Console.Write("+");
                                    comptPossible++;
                                }
                                else
                                {
                                    //Remet un point si ancien indice
                                    Console.SetCursorPosition(ligne, col);
                                    Console.Write("·");
                                }
                            }
                        }
                    }

                    //Instruction
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("Au tour du joueur " + joueur.sym);

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
                    bool estValide = Regex.IsMatch(x, pattern);

                    if (estValide == true)
                    {
                        //Prendre la lettre
                        int xA = x[0];                                  //xA = A (LETTRE)

                        //Prendre le numéro
                        string x11 = x.Substring(1);

                        //Convertir le numéro
                        int x1 = Convert.ToInt32(x11);                  //x1 = 1 (NUMERO)

                        //Passer en valeur tableau
                        x1 = x1 - 1;


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
                        if (tableau.grille[xA, x1] == ' ')
                        {
                            //Appel de la méthode qui vérifie si on peut jouer dans cette case
                            valable = verif.Verifcoup(tableau.grille, x1, xA, joueur.sym, joueur.symop, valable);

                            //Si oui place le pion
                            if (valable == true)
                            {
                                tableau.grille[xA, x1] = Convert.ToChar(joueur.sym);
                                Console.SetCursorPosition(xA, x1);
                                Console.Write(joueur.sym);
                                joueur.tour++;
                                joueur.ChangerJoueur();

                                valable = false;
                                aff = 0;

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

                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (tableau.grille[i, j] == 'X')
                                {
                                    comptX++;
                                }
                                else if (tableau.grille[i, j] == 'O')
                                {
                                    comptO++;
                                }
                                else
                                {
                                    comptVide++;
                                }
                            }
                        }

                        //Affichage du nombre de valablens de chaque joueur (Cases vide pour debug)
                        Console.SetCursorPosition(14, 3);
                        Console.Write("X = " + comptX);
                        Console.SetCursorPosition(14, 4);
                        Console.Write("O = " + comptO);
                        Console.SetCursorPosition(14, 5);
                        Console.Write("' ' = " + comptVide);
                        Console.SetCursorPosition(14, 6);
                        Console.Write("+ = " + comptPossible);

                        //Fin de partie
                        if (comptVide == 0)
                        {
                            menu = true;
                        }
                        else if (comptPossible == 0)
                        {
                            joueur.tour++;
                            aff++;
                        }
                        else if (aff > 1)
                        {
                            menu |= true;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.WriteLine("Entrée invalide. Veuillez suivre l'exemple.");
                    }

                    //Affichge du menua la fin de la partie
                    if (menu == true)
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
            }
            while (jeu == true);
        }
    }
}


