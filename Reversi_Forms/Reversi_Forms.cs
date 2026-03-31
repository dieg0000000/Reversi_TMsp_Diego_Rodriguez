using Lib_Reversi;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Reversi_Forms
{
    public partial class ReversiForm : Form
    {
        //Images du jeu
        private Image imgJNoir;
        private Image imgJBlanc;
        private Image imgPlateau;
        private Image imgCoupPoss;

        //Tableau des caractères et des bouttons
        private Button[,] boutons = new Button[Plateau.nbCases, Plateau.nbCases];

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
        private Label lblVide;
        private Label lblPossible;

        //Récupération du --Debug
        private bool Debug = Environment.GetCommandLineArgs().Contains("--debug");
        
        //Initialisations (appel des méthodes)
        public ReversiForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(350, 410);

            imgJNoir = Resource1.Joueur_X_True;
            imgJBlanc = Resource1.Joueur_O_False;
            imgCoupPoss = Resource1.Coup_possible;
            imgPlateau = Resource1.Plateau;

            Plateau.InitialiserGrille();
            InitialiserPlateau();
            InitialiserBarreInfo();
            affichagePossible();
            MAJBarreInfo();
            this.Show();
            debutPartie();
        }

        //Affichage des coups possible en gris
        private void affichagePossible()
        {
            for (int ligne = 0; ligne < Plateau.nbCases; ligne++)
            {
                for (int col = 0; col < Plateau.nbCases; col++)
                {
                    if (Plateau.GetCase(new Coords(col, ligne)) == Plateau.VIDE)
                    {
                        if (CoupPossible.EstUnCoupPossible(new Coords(col, ligne), Joueur.JoueurActuel))
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
            picNoir.Image = imgJNoir;
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
            picBlanc.Image = imgJBlanc;
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

            lblVide = new Label();
            lblVide.AutoSize = false;
            lblVide.Size = new Size(80, 36);
            lblVide.Location = new Point(360, 7);
            lblVide.ForeColor = Color.White;
            lblVide.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblVide.TextAlign = ContentAlignment.MiddleLeft;
            lblVide.Visible = Debug;
            barreInfo.Controls.Add(lblVide);

            lblPossible = new Label();
            lblPossible.AutoSize = false;
            lblPossible.Size = new Size(80, 36);
            lblPossible.Location = new Point(440, 7);
            lblPossible.ForeColor = Color.White;
            lblPossible.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblPossible.TextAlign = ContentAlignment.MiddleLeft;
            lblPossible.Visible = Debug;
            barreInfo.Controls.Add(lblPossible);

            this.Controls.Add(barreInfo);
            this.Icon = Resource1.Icone_reversi;
        }

        //Mise à jour de la barre d'information a chaque click
        private void MAJBarreInfo()
        {
            int comptNoir = 0;
            int comptBlanc = 0;
            int comptVide = 0;
            int comptPossible = 0;

            //Comptage des cases  
            (comptNoir, comptBlanc, comptVide) = Plateau.CompterPions();
            comptPossible = Plateau.CompterCoupsPossibles(Joueur.JoueurActuel);

            if (Joueur.JoueurActuel == true)
            {
                JoueurActuel.Image = imgJNoir;
                lblJoueurActuel.Text = "Tour";
            }
            else
            {
                JoueurActuel.Image = imgJBlanc;
                lblJoueurActuel.Text = "Tour";
            }

            //Afficher les valeurs dans la barre d'info
            lblNoir.Text = comptNoir.ToString();
            lblBlanc.Text = comptBlanc.ToString();

            if (Debug)
            {
                //Afficher les valeurs dans la barre d'info
                lblVide.Text = "' ' = " + comptVide;
                lblPossible.Text = "· = " + comptPossible;
            }
        }

        //Initialisation du plateau visuel 
        private void InitialiserPlateau()
        {
            plateauPanel = new TableLayoutPanel();
            plateauPanel.Dock = DockStyle.Fill;
            plateauPanel.ColumnCount = Plateau.nbCases;
            plateauPanel.RowCount = Plateau.nbCases;

            //Configurer 8 colonnes de taille égale
            for (int i = 0; i < Plateau.nbCases; i++)
            {
                plateauPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 8f));
            }

            //Configurer 8 lignes de taille égale
            for (int i = 0; i < Plateau.nbCases; i++)
            {
                plateauPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 8f));
            }
            
            plateauPanel.BackgroundImage = imgPlateau;
            plateauPanel.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(plateauPanel);


            //Boucle qui insert des bouttons dans chaque cases du Plateau
            for (int ligne = 0; ligne < Plateau.nbCases; ligne++)
            {
                for (int colonne = 0; colonne < Plateau.nbCases; colonne++)
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
                        bout.BackgroundImage = imgJNoir;
                    }

                    else if (ligne == 3 && colonne == 4 || ligne == 4 && colonne == 3)
                    {
                        bout.BackgroundImage = imgJBlanc;
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

        private void debutPartie()
        {
            MessageBox.Show("Placez vos pions pour encadrer ceux de l'adversaire et les retourner. \nLes cases marquées d'un cercle gris indiquent les coups jouables.", "Bienvenue au Reversi !");
        }

        //Gestion de la fin de partie
        private void finDePartie()
        {
            Partie_finie = true;

            int comptNoir = 0;
            int comptBlanc = 0;
            int comptVide = 0;

            //Comptage des cases
            (comptNoir, comptBlanc, comptVide) = Plateau.CompterPions();

            //Messages en fonction du gagnant
            string message;

            if (comptNoir > comptBlanc)
            {
                message = "Le joueur Noir a gagné ! (" + comptNoir + " contre " + comptBlanc + ")";
            }
            else
            {
                if (comptBlanc > comptNoir)
                {
                    message = "Le joueur Blanc gagne ! (" + comptBlanc + " contre " + comptNoir + ")";
                }
                else
                {
                    message = "Égalité ! (" + comptNoir + " - " + comptBlanc + ")";
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
            for (int l = 0; l < Plateau.nbCases; l++)
            {
                for (int c = 0; c < Plateau.nbCases; c++)
                {
                    if (CoupPossible.EstUnCoupPossible(new Coords(c, l), Joueur.JoueurActuel))
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

                Joueur.tour++;
                Joueur.ChangerJoueur();
                MAJBarreInfo();
                affichagePossible();

                //Vérifier si l'autre joueur peut jouer
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

        //Gestion des coups à afficher dans les différents Plateaux
        private void jouerCoup(Coords posCoup)
        {

            Plateau.SetCase(posCoup, Joueur.JoueurActuel);

            //Mise à jour du Plateau en fonction de chaque casesw
            for (int ligne = 0; ligne < Plateau.nbCases; ligne++)
            {
                for (int col = 0; col < Plateau.nbCases; col++)
                {
                    if (Plateau.GetCase(new Coords(col, ligne)) == Plateau.NOIR)
                    {
                        boutons[ligne, col].BackgroundImage = imgJNoir;
                    }
                    else if (Plateau.GetCase(new Coords(col, ligne)) == Plateau.BLANC)
                    {
                        boutons[ligne, col].BackgroundImage = imgJBlanc;
                    }
                    else
                    {
                        boutons[ligne, col].BackgroundImage = null;
                    }

                    boutons[ligne, col].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
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
                valable = Verification.VerificationRegleEtRetourne(new Coords(position.X, position.Y), Joueur.JoueurActuel);

                if (valable == true)
                {
                    jouerCoup(new Coords (position.X, position.Y));

                    Joueur.tour++;
                    Joueur.ChangerJoueur();

                    MAJBarreInfo();

                    affichagePossible();

                    int comptNoir = 0;
                    int comptBlanc = 0;
                    int comptVide = 0;

                    //Comptage des cases 
                    (comptNoir, comptBlanc, comptVide) = Plateau.CompterPions();

                    bool finPartie = false;

                    //Fin si plateau plein
                    if (comptVide == 0)
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
        private void ReversiForm_FormClosing(object sender, FormClosingEventArgs e)
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