using Lib_Reversi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi_Tmsp_Diego_Rodriguez_Forms
{
    public partial class Reversi_Forms : Form
    {
        //Images du jeu
        private Image imgJ1;
        private Image imgJ2;
        private Image imgPlateau;
        private Image imgCoupPoss;

        //Tableau des caractères et des bouttons
        private Button[,] boutons = new Button[8, 8];

        //Initiation de la valeur de la partie
        private bool Partie_finie = false;

        //Controle pour la fenêtre
        private TableLayoutPanel plateauPanel;

        //Informations de la barre d'info
        private Panel barreInfo;
        private PictureBox JoueurActuel;
        private Label lblJoueurActuel;
        private PictureBox picNoir;
        private Label lblNoir;
        private PictureBox picBlanc;
        private Label lblBlanc;


        //Initialisations (appel des méthodes)
        public Reversi_Forms()
        {
            InitializeComponent();

            this.MinimumSize = new Size(350, 410);

            imgJ1 = Image.FromFile(@"D:\TMsp\Code\Reversi_TMsp_Diego_Rodriguez\Reversi_Tmsp_Diego_Rodriguez_Forms\Assets\Joueur_1.png");
            imgJ2 = Image.FromFile(@"D:\TMsp\Code\Reversi_TMsp_Diego_Rodriguez\Reversi_Tmsp_Diego_Rodriguez_Forms\Assets\Joueur_2.png");
            imgCoupPoss = Image.FromFile(@"D:\TMsp\Code\Reversi_TMsp_Diego_Rodriguez\Reversi_Tmsp_Diego_Rodriguez_Forms\Assets\Coup_possible.png");
            imgPlateau = Image.FromFile(@"D:\TMsp\Code\Reversi_TMsp_Diego_Rodriguez\Reversi_Tmsp_Diego_Rodriguez_Forms\Assets\Plateau.png");

            tableau.InitialiserGrille();
            InitialiserPlateau();
            InitialiserBarreInfo();
            affichagePossible();
            MAJBarreInfo();
        }

        //Affichage des coups possible en gris
        private void affichagePossible()
        {
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (tableau.GetCase(new Coords(col, ligne)) == tableau.VIDE)
                    {
                        if (coupposs.Couppossible(new Coords(col, ligne), joueur.JoueurActif, joueur.JoueurPassif))
                        {
                            boutons[ligne, col].BackgroundImage = imgCoupPoss;
                        }
                        else
                        {
                            boutons[ligne, col].BackgroundImage = null;
                        }
                    }
                }
            }
        }

        //Affichage de la barre d'informations en haut de la fenêtre
        private void InitialiserBarreInfo()
        {
            barreInfo = new Panel();
            barreInfo.Dock = DockStyle.Top;
            barreInfo.Height = 50;
            barreInfo.BackColor = Color.FromArgb(51, 170, 68);
            barreInfo.Padding = new Padding(8, 4, 8, 4);

            //Image pion joueur actuel
            JoueurActuel = new PictureBox();
            JoueurActuel.Size = new Size(36, 36);
            JoueurActuel.Location = new Point(52, 7);
            JoueurActuel.SizeMode = PictureBoxSizeMode.StretchImage;
            barreInfo.Controls.Add(JoueurActuel);

            //Label joueur actuel
            lblJoueurActuel = new Label();
            lblJoueurActuel.AutoSize = false;
            lblJoueurActuel.Size = new Size(130, 36);
            lblJoueurActuel.Location = new Point(10, 7);
            lblJoueurActuel.ForeColor = Color.White;
            lblJoueurActuel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblJoueurActuel.TextAlign = ContentAlignment.MiddleLeft;
            barreInfo.Controls.Add(lblJoueurActuel);

            //Image pion noir
            picNoir = new PictureBox();
            picNoir.Size = new Size(30, 30);
            picNoir.Location = new Point(200, 10);
            picNoir.SizeMode = PictureBoxSizeMode.StretchImage;
            picNoir.Image = imgJ1;
            barreInfo.Controls.Add(picNoir);

            //Label score noir
            lblNoir = new Label();
            lblNoir.AutoSize = false;
            lblNoir.Size = new Size(40, 36);
            lblNoir.Location = new Point(234, 7);
            lblNoir.ForeColor = Color.White;
            lblNoir.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblNoir.TextAlign = ContentAlignment.MiddleLeft;
            barreInfo.Controls.Add(lblNoir);

            //Image pion blanc
            picBlanc = new PictureBox();
            picBlanc.Size = new Size(30, 30);
            picBlanc.Location = new Point(278, 10);
            picBlanc.SizeMode = PictureBoxSizeMode.StretchImage;
            picBlanc.Image = imgJ2;
            barreInfo.Controls.Add(picBlanc);

            //Label score blanc
            lblBlanc = new Label();
            lblBlanc.AutoSize = false;
            lblBlanc.Size = new Size(40, 36);
            lblBlanc.Location = new Point(312, 7);
            lblBlanc.ForeColor = Color.White;
            lblBlanc.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblBlanc.TextAlign = ContentAlignment.MiddleLeft;
            barreInfo.Controls.Add(lblBlanc);

            this.Controls.Add(barreInfo);
        }

        //Mise à jour de la barre d'information a chaque click
        private void MAJBarreInfo()
        {
            if (joueur.JoueurActif == true)
            {
                JoueurActuel.Image = imgJ1;
                lblJoueurActuel.Text = "Tour";
            }
            else
            {
                JoueurActuel.Image = imgJ2;
                lblJoueurActuel.Text = "Tour";
            }

            //Compter les pions pour la barre
            int nbNoir = 0;
            int nbBlanc = 0;

            //Boucle qui compte le nombre de pions Noirs et Blancs dans le tableau
            for (int l = 0; l < 8; l++)
                for (int c = 0; c < 8; c++)
                {
                    if (tableau.GetCase(new Coords(c, l)) == tableau.NOIR)
                    { 
                        nbNoir++; 
                    }
                    else if (tableau.GetCase(new Coords(c, l)) == tableau.BLANC)
                    {
                        nbBlanc++;
                    }
                }

            //Afficher les valeurs dans la barre d'info
            lblNoir.Text = nbNoir.ToString();
            lblBlanc.Text = nbBlanc.ToString();
        }

        //Initialisation du plateau visuel 
        private void InitialiserPlateau()
        {
            plateauPanel = new TableLayoutPanel();
            plateauPanel.Dock = DockStyle.Fill;
            plateauPanel.ColumnCount = 8;
            plateauPanel.RowCount = 8;

            //Configurer 8 colonnes de taille égale
            for (int i = 0; i < 8; i++)
            {
                plateauPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 8f));
            }

            //Configurer 8 lignes de taille égale
            for (int i = 0; i < 8; i++)
            {
                plateauPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 8f));
            }
            
            plateauPanel.BackgroundImage = imgPlateau;
            plateauPanel.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(plateauPanel);


            //Boucle qui insert des bouttons dans chaque cases du tableau
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    Button bout = new Button();
                    bout.Dock = DockStyle.Fill;
                    bout.Margin = new Padding(0);
                    bout.FlatStyle = FlatStyle.Flat;
                    bout.FlatAppearance.BorderSize = 0;
                    bout.BackColor = Color.Transparent;
                    bout.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    bout.FlatAppearance.MouseOverBackColor = Color.Transparent;

                    //Affichage des 4 pions au centre au début de la partie
                    if (ligne == 3 && colonne == 3 || ligne == 4 && colonne == 4)
                    {
                        bout.BackgroundImage = imgJ1;
                    }

                    else if (ligne == 3 && colonne == 4 || ligne == 4 && colonne == 3)
                    {
                        bout.BackgroundImage = imgJ2;
                    }

                    bout.BackgroundImageLayout = ImageLayout.Stretch;
                    bout.TabStop = false;
                    bout.Tag = new Point(ligne, colonne);
                    bout.Click += Bouton_Click;

                    plateauPanel.Controls.Add(bout, colonne, ligne);
                    boutons[ligne, colonne] = bout;
                }
            }
        }

        //Gestion de la fin de partie
        private void finDePartie()
        {
            Partie_finie = true;

            int nbNoir = 0;
            int nbBlanc = 0;

            //Comptage des pions pour les afficher dans le messageBox
            for (int l = 0; l < 8; l++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (tableau.GetCase(new Coords(c, l)) == tableau.NOIR)
                    {
                        nbNoir++;
                    }
                    else
                    {
                        if (tableau.GetCase(new Coords(c, l)) == tableau.BLANC)
                        {
                            nbBlanc++;
                        }
                    }
                }
            }

            //Messages en fonction du gagnant
            string message;

            if (nbNoir > nbBlanc)
            {
                message = "Le joueur Noir a gagné ! (" + nbNoir + " contre " + nbBlanc + ")";
            }
            else
            {
                if (nbBlanc > nbNoir)
                {
                    message = "Le joueur Blanc gagne ! (" + nbBlanc + " contre " + nbNoir + ")";
                }
                else
                {
                    message = "Égalité ! (" + nbNoir + " - " + nbBlanc + ")";
                }
            }

            //Affichage du messageBox
            DialogResult result = MessageBox.Show(message + "\n\nRejouer ?", "Fin de partie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                this.Close();
            }

            return;

        }

        //Passer le tour si un joueur n'a pas de possibilité de coup
        private bool passerLeTour()
        {
            bool coupPossible = false;

            //Si pas de coups possibles, passer son tour
            for (int l = 0; l < 8; l++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (coupposs.Couppossible(new Coords(c, l), joueur.JoueurActif, joueur.JoueurPassif))
                    {
                        coupPossible = true;
                        break;
                    }
                }

                if (coupPossible == true)
                {
                    break;
                }
            }

            //Si aucun coup possible
            if (coupPossible == false)
            {
                MessageBox.Show("Aucun coup possible pour ce joueur");

                joueur.tour++;
                joueur.ChangerJoueur();
                MAJBarreInfo();
                affichagePossible();

                //Vérifier si l'autre joueur peut jouer
                bool autreCoupPossible = false;

                for (int l = 0; l < 8; l++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        if (coupposs.Couppossible(new Coords(c, l), joueur.JoueurActif, joueur.JoueurPassif))
                        {
                            autreCoupPossible = true;
                            break;
                        }
                    }

                    if (autreCoupPossible == true)
                    {
                        break;
                    }
                }

                //Si l'autre joueur ne peut pas jouer non plus
                if (autreCoupPossible == false)
                {
                    return true;
                }
            }

            return false;

        }

        //Gestion des coups à afficher dans les différents tableaux
        private void jouerCoup(Coords posCoup)
        {

            tableau.SetCase(posCoup, joueur.JoueurActif);

            //Mise à jour du tableau en fonction de chaque casesw
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (tableau.GetCase(new Coords(col, ligne)) == tableau.NOIR)
                    {
                        boutons[ligne, col].BackgroundImage = imgJ1;
                    }
                    else if (tableau.GetCase(new Coords(col, ligne)) == tableau.BLANC)
                    {
                        boutons[ligne, col].BackgroundImage = imgJ2;
                    }
                    else
                    {
                        boutons[ligne, col].BackgroundImage = null;
                    }

                    boutons[ligne, col].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        //Comptage des cases vides pour la fin de partie
        private int compterVide()
        {
            //Compter les cases vides
            int nbVide = 0;

            for (int l = 0; l < 8; l++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (tableau.GetCase(new Coords(c, l)) == tableau.VIDE)
                    {
                        nbVide++;
                    }
                }
            }
            return nbVide;
        }

        //Click des bouttons
        private void Bouton_Click(object sender, EventArgs e)
        {
            bool valable = false;
            if (Partie_finie) return;

            Button b = sender as Button;
            if (b.Tag is Point p)
            {
                Coords position = new Coords(0, 0);

                position.Y = p.X;  //ligne
                position.X = p.Y;  //colonne

                //Vérifie si le coup est valable même si les coups valables sont automatiquement proposés
                valable = verif.Verifcoup(new Coords(position.X, position.Y), joueur.JoueurActif, joueur.JoueurPassif);

                if (valable == true)
                {
                    jouerCoup(new Coords (position.X, position.Y));

                    joueur.tour++;
                    joueur.ChangerJoueur();

                    MAJBarreInfo();

                    affichagePossible();

                    int nbVide = compterVide();

                    bool finPartie = false;

                    //Fin si plateau plein
                    if (nbVide == 0)
                    {
                        finPartie = true;
                    }
                    else
                    {
                        finPartie = passerLeTour();
                    }

                    if (finPartie == true)
                    {
                        finDePartie();
                    }
                }
            }
        }

        //Empecher la fermeture de la fenêtre par accident
        private void Reversi_Forms_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Etes-vous sûr de vouloir quitter ?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}