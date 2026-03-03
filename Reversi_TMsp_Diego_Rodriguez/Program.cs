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

                //Affichage des colonnes
                Console.WriteLine();
                Console.WriteLine("ABCDEFGH");

                ///Déclaration des variables
                int aff = 0;
                bool valable = false;
                bool partie = true;
                bool menu = false;

                //Affichage du compteur à 2 pour chaque valablen, avant qu'il commence à compter 
                Console.SetCursorPosition(14, 3);
                Console.Write("X = 2");
                Console.SetCursorPosition(14, 4);
                Console.Write("O = 2");

                //Valables au milieu de base (affiché)
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
                                if (coupposs.Couppossible(tableau.grille, ligne, col, joueur.sym, joueur.symop))
                                {
                                    Console.SetCursorPosition(col, ligne);   
                                    Console.Write("+");
                                    comptPossible++;
                                }
                                else
                                {
                                    Console.SetCursorPosition(col, ligne);   
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
                        Coords position = new Coords(0, 0);

                        //Prendre la lettre
                        position.X = x[0];                                  //position.X = A (LETTRE)

                        //Prendre le numéro
                        string x11 = x.Substring(1);

                        //Convertir le numéro
                        position.Y = Convert.ToInt32(x11);                  //x1 = 1 (NUMERO)

                        //Passer en valeur tableau
                        position.Y = position.Y - 1; 
                        
                        //Lettre en numero (A = 0)
                        if (position.X == 'A' || position.X == 'a') position.X = 0;
                        else if (position.X == 'B' || position.X == 'b') position.X = 1;
                        else if (position.X == 'C' || position.X == 'c') position.X = 2;
                        else if (position.X == 'D' || position.X == 'd') position.X = 3;
                        else if (position.X == 'E' || position.X == 'e') position.X = 4;
                        else if (position.X == 'F' || position.X == 'f') position.X = 5;
                        else if (position.X == 'G' || position.X == 'g') position.X = 6;
                        else if (position.X == 'H' || position.X == 'h') position.X = 7;
                        else
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.WriteLine("Entrée invalide !!");
                        }
                        Console.WriteLine();
                        
                        //Si la case est vide
                        if (tableau.grille[position.Y, position.X] == ' ')
                        {
                            valable = verif.Verifcoup(tableau.grille, new Coords(position.X, position.Y), joueur.sym, joueur.symop);

                            //valable = verif.Verifcoup(tableau.grille, coordonnee, joueur.sym, joueur.symop);
                            //Si oui place le pion
                            if (valable == true)
                            {
                                tableau.grille[ position.Y, position.X] = Convert.ToChar(joueur.sym);

                                Console.SetCursorPosition(position.X,  position.Y);
                                Console.Write(joueur.sym);

                                for (int ligne = 0; ligne < 8; ligne++)
                                {
                                    for (int col = 0; col < 8; col++)
                                    {
                                        if (tableau.grille[ligne, col] == Convert.ToChar(joueur.sym))
                                        {
                                            Console.SetCursorPosition(col, ligne);
                                            Console.Write(joueur.sym);
                                        }
                                        else
                                        {
                                            if (tableau.grille[ligne, col] == Convert.ToChar(joueur.symop))
                                            {
                                                Console.SetCursorPosition(col, ligne);
                                                Console.Write(joueur.symop);
                                            }
                                        }
                                    }
                                }

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