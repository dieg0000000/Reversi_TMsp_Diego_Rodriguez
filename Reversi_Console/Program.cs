using Lib_Reversi;
using System;
using System.Linq;


namespace Reversi_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Debug = args.Contains("--debug");

            Console.Clear();

            Console.WriteLine("Bienvenue au Reversi !");
            Console.WriteLine("Placez vos pions pour encadrer ceux de l'adversaire et les retourner.");
            Console.WriteLine("Les cases marquées d'un · indiquent les coups jouables.");
            Console.WriteLine("   ");
            Console.WriteLine("[ENTER] pour commencer la partie");
            Console.ReadLine();

            Console.Clear();

            bool jeu = true;

            //Lancement de la partie
            do
            {
                Console.WriteLine("  A B C D E F G H");

                Plateau.InitialiserGrille();

                //Afficher la plateau
                for (int ligne = 0; ligne < Plateau.nbCases; ligne++)
                {
                    for (int col = 0; col < Plateau.nbCases; col++)
                    {
                        Console.SetCursorPosition(col * 2 + 1, ligne + 1);
                        Console.Write("   ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("  A B C D E F G H");

                //Afficher le numro des lignes 
                for (int l = 1; l < 9; l++)
                {
                    Console.SetCursorPosition(0, l);
                    Console.Write(l);
                }

                //Afficher le numro des lignes 
                for (int l = 1; l < 9; l++)
                {
                    Console.SetCursorPosition(18, l);
                    Console.Write(l);
                }

                //Déclaration des variables
                bool valable = false;
                bool partie = true;
                bool menu = false;

                //Affichage du compteur à 2 pour chaque valablen, avant qu'il commence à compter 
                Console.SetCursorPosition(21, 3);
                Console.Write("X = 2");
                Console.SetCursorPosition(21, 4);
                Console.Write("O = 2");

                if (Debug == true)
                {
                    Console.SetCursorPosition(21, 5);
                    Console.Write("' ' = 60");
                    Console.SetCursorPosition(21, 6);
                    Console.Write("· = 4");
                }


                //Valables au milieu de base (affiché)
                Console.SetCursorPosition(8, 4);
                Console.Write("X");
                Console.SetCursorPosition(10, 5);
                Console.Write("X");
                Console.SetCursorPosition(10, 4);
                Console.Write("O");
                Console.SetCursorPosition(8, 5);
                Console.Write("O");

                //Instructions
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Au tour du joueur " + (Joueur.JoueurActuel == true ? "X" : "O"));
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Veuillez entrer un coup (ex. A1) :");
                Console.SetCursorPosition(34, 12);

                //Boucle principale
                while (partie == true)
                {
                    int comptNoir = 0;
                    int comptBlanc = 0; 
                    int comptVide = 0;
                    int comptPossible = 0;

                    //Affichage des coups possibles
                    for (int ligne = 0; ligne < Plateau.nbCases; ligne++)
                    {
                        for (int col = 0; col < Plateau.nbCases; col++)
                        {
                            if (Plateau.GetCase(new Coords(col, ligne)) == Plateau.VIDE)
                            {
                                //Si un coup est possible, on afifhe le coup dans la console
                                if (CoupPossible.EstUnCoupPossible(new Coords(col, ligne), Joueur.JoueurActuel))
                                {
                                    Console.SetCursorPosition(col * 2 + 2, ligne + 1);
                                    Console.Write("·");                                   
                                }

                                //Si la case est vide, on affiche rien 
                                else
                                {
                                    Console.SetCursorPosition(col * 2 + 2, ligne + 1);
                                    Console.Write(' ');
                                }
                            }
                        }
                    }

                    //Instruction
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("Au tour du joueur " + (Joueur.JoueurActuel == true ? "X" : "O"));

                    //Clear la donnée entrée
                    Console.SetCursorPosition(34, 12);
                    Console.Write("                                                                                   ");
                    Console.SetCursorPosition(34, 12);

                    //Valeur de base
                    string x = Console.ReadLine();

                    //Clear du message d'erreur
                    Console.SetCursorPosition(0, 13);
                    Console.WriteLine("                                                                               ");
                    
                    //Vérification de l'entrée de l'utilisateur
                    bool estValide = VerifCoords.VerifEntree(x);

                    //Si l'entrée suit le bon format on décapsule les valeurs
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
                        if (Plateau.GetCase(new Coords(position.X, position.Y)) == Plateau.VIDE)
                        {
                            valable = Verification.VerificationRegleEtRetourne(new Coords(position.X, position.Y), Joueur.JoueurActuel);

                            //Si oui place le pion
                            if (valable == true)
                            {
                                //Ajouter le coup dans le tableau
                                Plateau.SetCase(new Coords(position.X, position.Y), Joueur.JoueurActuel);

                                //Afficher le joueur actuel
                                Console.SetCursorPosition(position.X * 2 + 2, position.Y + 1);
                                Console.Write(Joueur.JoueurActuel == true ? "X" : "O");

                                //Réaffichage de tout le tableau dans la console en fonction des valeurs du plateau invisible
                                for (int ligne = 0; ligne < Plateau.nbCases; ligne++)
                                {
                                    for (int col = 0; col < Plateau.nbCases; col++)
                                    {
                                        //Si la case est noire, on place un pion noir (X) dans la case visuelle
                                        if (Plateau.GetCase(new Coords(col, ligne)) == Plateau.NOIR)
                                        {
                                            Console.SetCursorPosition(col * 2 + 2, ligne + 1);
                                            Console.Write("X");
                                        }

                                        //Si la case est blanche, on place un pion blanc (O) dans la case visuelle
                                        else if (Plateau.GetCase(new Coords(col, ligne)) == Plateau.BLANC)
                                        {
                                            Console.SetCursorPosition(col * 2 + 2, ligne + 1);
                                            Console.Write("O");
                                        }
                                    }
                                }

                                Joueur.tour++;
                                Joueur.ChangerJoueur();

                                valable = false;
                                    
                                //Clear du message d'erreur
                                Console.SetCursorPosition(0, 13);
                                Console.WriteLine("                     ");

                                // Comptage des pions
                                (comptNoir, comptBlanc, comptVide) = Plateau.CompterPions();
                                comptPossible = Plateau.CompterCoupsPossibles(Joueur.JoueurActuel);

                                Console.SetCursorPosition(21, 3);
                                Console.Write("X = " + comptNoir);
                                Console.SetCursorPosition(21, 4);
                                Console.Write("O = " + comptBlanc);
                                if (Debug)
                                {
                                    Console.SetCursorPosition(21, 5);
                                    Console.Write("' ' = " + comptVide);
                                    Console.SetCursorPosition(21, 6);
                                    Console.Write("· = " + comptPossible);
                                }

                                if (comptVide == 0)
                                {
                                    menu = true;
                                }
                                else if (comptPossible == 0)
                                {
                                    Console.SetCursorPosition(0, 13);
                                    Console.WriteLine("Aucun coup possible, tour passé !");
                                    Joueur.tour++;
                                    Joueur.ChangerJoueur();

                                    bool autreCoupPossible = false;
                                    for (int l = 0; l < Plateau.nbCases; l++)
                                    {
                                        for (int c = 0; c < Plateau.nbCases; c++)
                                        {
                                            if (CoupPossible.EstUnCoupPossible(new Coords(c, l), Joueur.JoueurActuel))
                                            {
                                                autreCoupPossible = true;
                                                break;
                                            }
                                        }
                                        if (autreCoupPossible) break;
                                    }
                                    if (!autreCoupPossible) menu = true;
                                }

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

                    }
                    else
                    {
                        Console.SetCursorPosition(0, 13);
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
                        Console.WriteLine("     X = " + comptNoir);
                        Console.WriteLine("     O = " + comptBlanc);
                        Console.WriteLine("                ");
                        Console.WriteLine("                ");

                        //Definition du vainqueur
                        if (comptNoir > comptBlanc)
                        {
                            Console.WriteLine("Victoire des X !!");
                        }
                        else if (comptBlanc > comptNoir)
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
