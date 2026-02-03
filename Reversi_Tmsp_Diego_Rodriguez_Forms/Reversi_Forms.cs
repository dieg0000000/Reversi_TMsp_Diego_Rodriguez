using Lib_Reversi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi_Tmsp_Diego_Rodriguez_Forms
{
    public partial class Reversi_Forms : Form
    {

        //classe du plateau
        tableau jeu = new tableau();

        //tableau des caractères et des bouttons
        private char[,] grille = new char[8, 8];
        private Button[,] boutons = new Button[8, 8];

        //initiation des valeurs
        private int tour = 0;
        private bool Partie_finie = false;

        //classe de la fenêtre
        private TableLayoutPanel plateauPanel;

        //initialisations (appel des méthodes)
        public Reversi_Forms()
        {
            InitializeComponent();
            tableau.InitialiserGrille();
            InitialiserPlateau();
            //AfficherPlateau();
        }

        // Création du plateau
        private void InitialiserPlateau()
        {
            //design du panel
            plateauPanel = new TableLayoutPanel();
            plateauPanel.Dock = DockStyle.Fill;
            plateauPanel.ColumnCount = 8;
            plateauPanel.RowCount = 8;

            //pourcentage des de la taille des bouttons en fonction de la fenêtre
            for (int i = 0; i < 8; i++)
                plateauPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 8f));
            for (int i = 0; i < 8; i++)
                plateauPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 8f));

            //image de fond qui s'étire
            plateauPanel.BackgroundImage = Image.FromFile(@"D:\TMsp\Code\Reversi_TMsp_Diego_Rodriguez\Reversi_Tmsp_Diego_Rodriguez_Forms\plateau.png");
            plateauPanel.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(plateauPanel);

            //création des boutons
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    Button bout = new Button();

                    //design des bouttons
                    bout.Dock = DockStyle.Fill;
                    bout.Margin = new Padding(0);
                    bout.FlatStyle = FlatStyle.Flat;
                    bout.FlatAppearance.BorderSize = 0;
                    bout.BackColor = Color.Transparent;
                    bout.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    bout.FlatAppearance.MouseOverBackColor = Color.Transparent;

                    if (ligne == 3 && colonne == 3 || ligne == 4 && colonne == 4)
                    {
                        bout.BackgroundImage = Image.FromFile(@"D:\TMsp\Code\Reversi_TMsp_Diego_Rodriguez\Reversi_Tmsp_Diego_Rodriguez_Forms\pion-noir.png");
                    }
                    else if (ligne == 3 && colonne == 4 || ligne == 4 && colonne == 3)
                    {
                        bout.BackgroundImage = Image.FromFile(@"D:\TMsp\Code\Reversi_TMsp_Diego_Rodriguez\Reversi_Tmsp_Diego_Rodriguez_Forms\pion-blanc.png");
                    }

                    //important pour que l'image du pion s'étire aussi
                    bout.BackgroundImageLayout = ImageLayout.Stretch;

                    bout.TabStop = false;
                    bout.Tag = new Point(ligne, colonne);
                    bout.Click += Bouton_Click;

                    //on ajoute le bouton dans la case précise
                    plateauPanel.Controls.Add(bout, colonne, ligne);
                    boutons[ligne, colonne] = bout;

                }
            }
        }

        //evenement click des bouttons
        private void Bouton_Click(object sender, EventArgs e)
        {
            bool valable = true;

            if (Partie_finie) return;

            Button b = sender as Button;

            if (b.Tag is Point p)
            {
                int x1 = p.X;   //coordonnée X
                int xA= p.Y; //coordonnée Y


                ///////////////////////////////////////////////////////////////
                //afficeher les lignes et la colonne du boutton pour debug   //
                Label monLabel = new Label();                                //
                b.Text = x1.ToString() + ", " + xA.ToString();       //
                b.ForeColor = Color.Red;                                     //
                ///////////////////////////////////////////////////////////////
                
                verif.Verifcoup(tableau.grille, x1, xA, joueur.sym, joueur.symop, valable);
            }

        }
    }
}
