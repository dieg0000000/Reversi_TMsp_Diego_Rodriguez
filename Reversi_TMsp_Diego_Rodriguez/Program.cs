using System;

namespace Reversi_TMsp_Diego_Rodriguez
{
	internal class Program
	{
		static void Main(string[] args)
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
			for (int o = 1; o < 9; o++)
			{
				Console.SetCursorPosition(8, o - 1);
				Console.Write(o);
			}

			//Affichage des colonnes
			Console.WriteLine();
			Console.WriteLine("ABCDEFGH");

			//Pions au milieu de base (invisible)
			grille[3, 3] = 'X';
			grille[4, 3] = 'O';
			grille[3, 4] = 'O';
			grille[4, 4] = 'X';

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
			string sym = "X";
			string symop = "O";

			//Instructions
			Console.SetCursorPosition(0, 11);
			Console.WriteLine("Veuillez entrer un coup (ex. A1) :");
			Console.SetCursorPosition(34, 11);

			//Boucle principale
			while (true)
			{
				//Clear la donnée 
				Console.SetCursorPosition(34, 11);
				Console.Write("        ");
				Console.SetCursorPosition(34, 11);

				//Valeur de base
				string x = Console.ReadLine();

				//Prendre la lettre
				int xA = x[0];                                  //xA = A (LETTRE)

				//Prendre le numéro
				string x11 = x.Substring(1);

				//Convertir le numéro
				int x1 = Convert.ToInt32(x11);                  //x1 = 1 (NUMERO)

				// FIX → passer en indices tableau (0-7)
				x1 = x1 - 1;

				//Clear le "Entrée invalide !!"
				Console.SetCursorPosition(0, 12);
				Console.Write("                               ");


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
					Console.WriteLine("Entrée invalide !!");
					continue;
				}
				Console.WriteLine();

				//Temporaire
				Console.WriteLine("lettre = " + xA);
				Console.WriteLine("numero = " + x1);

				//Effacer le message d'erreur
				Console.SetCursorPosition(0, 16);
				Console.Write("                       ");

				//Vérifie si la case est vide
				if (grille[xA, x1] == ' ')
				{
					//Regarde autour si y a un pion adverse
					if (x1 + 1 < 8 && grille[xA, x1 + 1] == symop[0]) pio = true;
					else if (xA - 1 >= 0 && x1 + 1 < 8 && grille[xA - 1, x1 + 1] == symop[0]) pio = true;
					else if (xA - 1 >= 0 && grille[xA - 1, x1] == symop[0]) pio = true;
					else if (xA - 1 >= 0 && x1 - 1 >= 0 && grille[xA - 1, x1 - 1] == symop[0]) pio = true;
					else if (x1 - 1 >= 0 && grille[xA, x1 - 1] == symop[0]) pio = true;
					else if (xA + 1 < 8 && x1 - 1 >= 0 && grille[xA + 1, x1 - 1] == symop[0]) pio = true;
					else if (xA + 1 < 8 && grille[xA + 1, x1] == symop[0]) pio = true;
					else if (xA + 1 < 8 && x1 + 1 < 8 && grille[xA + 1, x1 + 1] == symop[0]) pio = true;
					else Console.WriteLine("Entrée invalide !!");

					//Si oui place le pion
					if (pio == true)
					{
						grille[xA, x1] = sym[0];
						Console.SetCursorPosition(xA, x1);
						Console.Write(sym);
						tour++;
						pio = false;
					}
				}
				else
				{
					Console.WriteLine("Case occupée !!");
				}
			}
		}
	}
}
