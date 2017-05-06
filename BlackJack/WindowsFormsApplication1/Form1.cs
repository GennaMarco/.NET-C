using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Mazzo mazzo;
        private List<Carta> ManoGiocatore;
        private List<Carta> ManoDealer;
        private List<Label> ManoLabelsGiocatore;
        private List<Label> ManoLabelsDealer;
        private Label lblSoldi;
        private Label lblPuntata;
        private Label lblCartaCoperta;
        private Label lblImgMazzo;
        private Label lblGiocatore;
        private Label lblDealer;
        private Button btnPesca;
        private Button btnMantieni;
        private Button btnRaddoppia;
        private Button btnGiocaAgain;
        private Button btnTornaMenu;
        private Button btnScommetti;
        private Button btnReset;
        private Button ViewPuntata;
        private int puntata;
        private int soldi = 1000;
        private static DateTime DateStart;
        private static DateTime DateEnd;
        private static int TotaleGiocatore;
        private static int TotaleDealer;
        private static string vincitore;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.AutoSize = true;

            Image sfondo = new Bitmap("../blackjacksfondo.jpg");
            this.BackgroundImage = sfondo;

            lblBlackJack.Location = new Point(235, 9);
            lblBlackJack.Font = new Font(lblBlackJack.Font.FontFamily, 36);
            lblBlackJack.Name = "lblBlackJack";
            lblBlackJack.Text = "BlackJack";
            lblBlackJack.AutoSize = true;
            lblBlackJack.Visible = true;
            lblBlackJack.BackColor = Color.Transparent;
            lblBlackJack.ForeColor = Color.White;

            btnGioca.Location = new Point(269, 109);
            btnGioca.AutoSize = true;
            btnGioca.Width = 160;
            btnGioca.TextAlign = ContentAlignment.MiddleCenter;
            btnGioca.Font = new Font(btnGioca.Font.FontFamily, 14);
            btnGioca.Text = "Nuova Partita";
            btnGioca.Name = "btnGioca";
            btnGioca.Click += new EventHandler(this.btnIniziaScommessa_Click);

            btnStatistichePartite.Location = new Point(269, 159);
            btnStatistichePartite.AutoSize = true;
            btnStatistichePartite.TextAlign = ContentAlignment.MiddleCenter;
            btnStatistichePartite.Font = new Font(btnStatistichePartite.Font.FontFamily, 14);
            btnStatistichePartite.Text = "Statistiche Partite";
            btnStatistichePartite.Name = "btnStatistichePartite";
            btnStatistichePartite.Click += new EventHandler(this.btnStatistichePartite_Click);

            this.Controls.Add(lblBlackJack);
            this.Controls.Add(btnGioca);
            this.Controls.Add(btnStatistichePartite);
        }

        private void btnIniziaScommessa_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.BackgroundImage = null;
            this.BackColor = Color.ForestGreen;

            string pathfish = "../fish.bmp";

            Button btnFish1 = new Button();
            btnFish1.Image = Image.FromFile(pathfish);
            btnFish1.AutoSize = true;
            btnFish1.Location = new Point(100, 250);
            btnFish1.ForeColor = Color.White;
            btnFish1.Font = new Font(btnFish1.Font.FontFamily, 18);
            btnFish1.Text = "5";
            btnFish1.Click += new EventHandler(this.btnFish1_Click);
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath1.AddEllipse(5, 5, 70, 70);
            btnFish1.Region = new Region(myGraphicsPath1);

            Button btnFish2 = new Button();
            btnFish2.Image = Image.FromFile(pathfish);
            btnFish2.AutoSize = true;
            btnFish2.Location = new Point(190, 250);
            btnFish2.ForeColor = Color.White;
            btnFish2.Font = new Font(btnFish2.Font.FontFamily, 18);
            btnFish2.Text = "10";
            btnFish2.Click += new EventHandler(this.btnFish2_Click);
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath2.AddEllipse(5, 5, 70, 70);
            btnFish2.Region = new Region(myGraphicsPath2);

            Button btnFish3 = new Button();
            btnFish3.Image = Image.FromFile(pathfish);
            btnFish3.AutoSize = true;
            btnFish3.Location = new Point(280, 250);
            btnFish3.ForeColor = Color.White;
            btnFish3.Font = new Font(btnFish3.Font.FontFamily, 18);
            btnFish3.Text = "20";
            btnFish3.Click += new EventHandler(this.btnFish3_Click);
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath3 = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath3.AddEllipse(5, 5, 70, 70);
            btnFish3.Region = new Region(myGraphicsPath3);

            Button btnFish4 = new Button();
            btnFish4.Image = Image.FromFile(pathfish);
            btnFish4.AutoSize = true;
            btnFish4.Location = new Point(370, 250);
            btnFish4.ForeColor = Color.White;
            btnFish4.Font = new Font(btnFish4.Font.FontFamily, 18);
            btnFish4.Text = "50";
            btnFish4.Click += new EventHandler(this.btnFish4_Click);
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath4 = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath4.AddEllipse(5, 5, 70, 70);
            btnFish4.Region = new Region(myGraphicsPath4);

            Button btnFish5 = new Button();
            btnFish5.Image = Image.FromFile(pathfish);
            btnFish5.AutoSize = true;
            btnFish5.Location = new Point(465, 250);
            btnFish5.ForeColor = Color.White;
            btnFish5.Font = new Font(btnFish5.Font.FontFamily, 18);
            btnFish5.Text = "100";
            btnFish5.Click += new EventHandler(this.btnFish5_Click);
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath5 = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath5.AddEllipse(5, 5, 70, 70);
            btnFish5.Region = new Region(myGraphicsPath5);

            btnTornaMenu = new Button();
            btnTornaMenu.Location = new Point(528, 5);
            btnTornaMenu.AutoSize = true;
            btnTornaMenu.Font = new Font(btnTornaMenu.Font.FontFamily, 20);
            btnTornaMenu.Text = "Torna al Menù";
            btnTornaMenu.Name = "btnTornaMenu";
            btnTornaMenu.BackColor = Color.White;
            btnTornaMenu.Click += new EventHandler(this.btnTornaMenu_Click);

            btnReset = new Button();
            btnReset.Location = new Point(445, 180);
            btnReset.AutoSize = true;
            btnReset.Font = new Font(btnReset.Font.FontFamily, 20);
            btnReset.Text = "Reset";
            btnReset.Name = "btnReset";
            btnReset.BackColor = Color.White;
            btnReset.Click += new EventHandler(this.btnReset_Click);

            btnScommetti = new Button();
            btnScommetti.Location = new Point(265, 342);
            btnScommetti.BackColor = Color.White;
            btnScommetti.AutoSize = true;
            btnScommetti.Font = new Font(btnScommetti.Font.FontFamily, 18);
            btnScommetti.Text = "Inizia Partita";
            btnScommetti.Click += new EventHandler(this.btnGioca_Click);

            puntata = 0;

            lblPuntata = new Label();
            lblPuntata.Location = new Point(100, 180);
            lblPuntata.Font = new Font(lblPuntata.Font.FontFamily, 30, FontStyle.Bold);
            lblPuntata.AutoSize = true;
            lblPuntata.BackColor = Color.Transparent;
            lblPuntata.ForeColor = Color.White;
            lblPuntata.Text = "PUNTATA: " + puntata;

            lblSoldi = new Label();
            lblSoldi.Location = new Point(1, 1);
            lblSoldi.Font = new Font(lblSoldi.Font.FontFamily, 30);
            lblSoldi.AutoSize = true;
            lblSoldi.BackColor = Color.Transparent;
            lblSoldi.ForeColor = Color.White;
            lblSoldi.Text = "Soldi disponibili: " + soldi;

            this.Controls.Add(btnFish1);
            this.Controls.Add(btnFish2);
            this.Controls.Add(btnFish3);
            this.Controls.Add(btnFish4);
            this.Controls.Add(btnFish5);
            this.Controls.Add(btnTornaMenu);
            this.Controls.Add(lblPuntata);
            this.Controls.Add(lblSoldi);
            this.Controls.Add(btnReset);
        }

        private void btnTornaMenu_Click(object sender, EventArgs e)
        {
            btnReset.PerformClick();
            btnTornaMenu.Click -= new EventHandler(this.btnTornaMenu_Click);
            btnTornaMenu.Click += new EventHandler(this.Form1_Load);
            btnTornaMenu.PerformClick();
        }

        private void btnGioca_Click(object sender, EventArgs e) 
        {
            DateStart = new DateTime();
            DateStart = DateTime.Now;
            this.Controls.Clear();

            this.BackgroundImage = null;
            this.BackColor = Color.ForestGreen;

            lblSoldi.Location = new Point(545, 13);
            lblSoldi.Font = new Font(lblBlackJack.Font.FontFamily, 14);

            Label lblVincitaMax = new Label();
            lblVincitaMax.Location = new Point(545, 43);
            lblVincitaMax.Font = new Font(lblVincitaMax.Font.FontFamily, 14);
            lblVincitaMax.AutoSize = true;
            lblVincitaMax.BackColor = Color.Transparent;
            lblVincitaMax.ForeColor = Color.White;
            lblVincitaMax.Text = "Vincita potenziale: " + puntata * 2;

            ViewPuntata = new Button();
            ViewPuntata.Image = Image.FromFile("../fish.bmp");
            ViewPuntata.AutoSize = true;
            ViewPuntata.Location = new Point(55, 140);
            ViewPuntata.ForeColor = Color.White;
            ViewPuntata.Font = new Font(ViewPuntata.Font.FontFamily, 18);
            ViewPuntata.Text = "" + puntata;
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPathPuntata = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPathPuntata.AddEllipse(5, 5, 70, 70);
            ViewPuntata.Region = new Region(myGraphicsPathPuntata);

            ManoGiocatore = new List<Carta>();
            ManoDealer = new List<Carta>();

            ManoLabelsGiocatore = new List<Label>();
            ManoLabelsDealer = new List<Label>();

            mazzo = new Mazzo();
            mazzo.MescolaMazzo();

            Carta carta1 = mazzo.PescaCarta();
            Carta carta2 = mazzo.PescaCarta();
            ManoGiocatore.Add(carta1);
            ManoGiocatore.Add(carta2);

            Label lblcarta1 = new Label();
            lblcarta1.Location = new Point(12, 250);
            string nomeimg = "../" + carta1.ToString() + ".bmp";
            Image imgcarta1 = Image.FromFile(nomeimg);
            lblcarta1.Size = new Size(imgcarta1.Width, imgcarta1.Height);
            lblcarta1.Image = imgcarta1;

            Label lblcarta2 = new Label();
            lblcarta2.Location = new Point(90, 250);
            string nomeimg2 = "../" + carta2.ToString() + ".bmp";
            Image imgcarta2 = Image.FromFile(nomeimg2);
            lblcarta2.Size = new Size(imgcarta2.Width, imgcarta2.Height);
            lblcarta2.Image = imgcarta2;

            ManoLabelsGiocatore.Add(lblcarta1);
            ManoLabelsGiocatore.Add(lblcarta2);

            int valCarta1 = carta1.CalcolaValoreCarta();
            int valCarta2 = carta2.CalcolaValoreCarta();

            if (carta1.CalcolaValoreCarta() == 11 && carta2.CalcolaValoreCarta() == 11)
                valCarta1 = 1;

            TotaleGiocatore = valCarta1 + valCarta2;

            lblGiocatore = new Label();
            lblGiocatore.Location = new Point(8, 230);
            lblGiocatore.Font = new Font(lblGiocatore.Font.FontFamily, 12);
            lblGiocatore.AutoSize = true;
            lblGiocatore.BackColor = Color.Transparent;
            lblGiocatore.ForeColor = Color.White;
            lblGiocatore.Text = "GIOCATORE: " + TotaleGiocatore;

            Carta carta3 = mazzo.PescaCarta();
            Carta carta4 = mazzo.PescaCarta();
            ManoDealer.Add(carta3);
            ManoDealer.Add(carta4);

            Label lblcarta3 = new Label();
            lblcarta3.Location = new Point(12, 33);
            string nomeimg3 = "../" + carta3.ToString() + ".bmp";
            Image imgcarta3 = Image.FromFile(nomeimg3);
            lblcarta3.Size = new Size(imgcarta3.Width, imgcarta3.Height);
            lblcarta3.Image = imgcarta3;

            lblCartaCoperta = new Label();
            lblCartaCoperta.Location = new Point(90, 33);
            string nomeimgcoperta = "../cartaCoperta.bmp";
            Image imgcartacoperta = Image.FromFile(nomeimgcoperta);
            lblCartaCoperta.Size = new Size(imgcartacoperta.Width, imgcartacoperta.Height);
            lblCartaCoperta.Image = imgcartacoperta;

            lblImgMazzo = new Label();
            lblImgMazzo.Location = new Point(650, 250);
            Image imgMazzo = Image.FromFile("../mazzoCarte.bmp");
            lblImgMazzo.Size = new Size(imgMazzo.Width, imgMazzo.Height);
            lblImgMazzo.Image = imgMazzo;
            lblImgMazzo.TextAlign = ContentAlignment.MiddleCenter;
            lblImgMazzo.ForeColor = Color.White;
            lblImgMazzo.Font = new Font(lblGiocatore.Font.FontFamily, 28, FontStyle.Bold);
            lblImgMazzo.Text = "" + mazzo.NumeroCarteMazzo();

            ManoLabelsDealer.Add(lblcarta3);
            ManoLabelsDealer.Add(lblCartaCoperta);

            int valCarta3 = carta3.CalcolaValoreCarta();
            int valCarta4 = carta4.CalcolaValoreCarta();

            if (carta3.CalcolaValoreCarta() == 11 && carta4.CalcolaValoreCarta() == 11)
                valCarta3 = 11;

            TotaleDealer = valCarta3;
            int TotaleDealerVero = valCarta3 + valCarta4;

            lblDealer = new Label();
            lblDealer.Location = new Point(8, 13);
            lblDealer.Font = new Font(lblDealer.Font.FontFamily, 12);
            lblDealer.AutoSize = true;
            lblDealer.BackColor = Color.Transparent;
            lblDealer.ForeColor = Color.White;
            lblDealer.Text = "DEALER: " + TotaleDealer;

            btnPesca = new Button();
            btnPesca.Location = new Point(12, 370);
            btnPesca.AutoSize = true;
            btnPesca.Font = new Font(btnPesca.Font.FontFamily, 26);
            btnPesca.Visible = true;
            btnPesca.Text = "Pesca";
            btnPesca.Name = "btnPesca";
            btnPesca.BackColor = Color.White;
            btnPesca.Click += new EventHandler(this.btnPesca_Click);

            btnMantieni = new Button();
            btnMantieni.Location = new Point(140, 370);
            btnMantieni.AutoSize = true;
            btnMantieni.Font = new Font(btnPesca.Font.FontFamily, 26);
            btnMantieni.Visible = true;
            btnMantieni.Text = "Mantieni";
            btnMantieni.Name = "btnMantieni";
            btnMantieni.BackColor = Color.White;
            btnMantieni.Click += new EventHandler(this.btnMantieni_Click);

            btnRaddoppia = new Button();
            btnRaddoppia.Location = new Point(302, 370);
            btnRaddoppia.AutoSize = true;
            btnRaddoppia.Font = new Font(btnPesca.Font.FontFamily, 26);
            btnRaddoppia.Visible = true;
            btnRaddoppia.Text = "Raddoppia";
            btnRaddoppia.Name = "btnRaddoppia";
            btnRaddoppia.BackColor = Color.White;
            btnRaddoppia.Click += new EventHandler(this.btnRaddoppia_Click);

            this.Controls.Add(lblGiocatore);
            this.Controls.Add(lblDealer);
            this.Controls.Add(btnPesca);
            this.Controls.Add(btnMantieni);
            this.Controls.Add(btnRaddoppia);
            this.Controls.Add(lblImgMazzo);
            this.Controls.Add(lblcarta1);
            this.Controls.Add(lblcarta2);
            this.Controls.Add(lblcarta3);
            this.Controls.Add(lblCartaCoperta);
            this.Controls.Add(lblSoldi);
            this.Controls.Add(ViewPuntata);
            this.Controls.Add(lblVincitaMax);
            this.AutoSize = true;

            if (TotaleGiocatore == 21 && TotaleDealerVero != 21) 
            {
                DateEnd = new DateTime();
                DateEnd = DateTime.Now;
                soldi += puntata * 2;
                lblSoldi.Text = "Soldi disponibili: " + soldi;
                vincitore = "player";
                Label lblSconfittaDealer = new Label();
                lblSconfittaDealer.Location = new Point(130, 164);
                lblSconfittaDealer.Font = new Font(lblSconfittaDealer.Font.FontFamily, 26);
                lblSconfittaDealer.BackColor = Color.Transparent;
                lblSconfittaDealer.ForeColor = Color.White;
                lblSconfittaDealer.Name = "lblSconfittaDealer";
                lblSconfittaDealer.Text = "BLACKJACK! Il Giocatore Ha vinto!";
                lblSconfittaDealer.AutoSize = true;
                lblSconfittaDealer.Visible = true;

                btnGiocaAgain = new Button();
                btnGiocaAgain.Location = new Point(12, 370);
                btnGiocaAgain.AutoSize = true;
                btnGiocaAgain.Width = 197;
                btnGiocaAgain.Font = new Font(btnGiocaAgain.Font.FontFamily, 20);
                btnGiocaAgain.Text = "Nuova Partita";
                btnGiocaAgain.Name = "btnGiocaAgain";
                btnGiocaAgain.BackColor = Color.White;
                btnGiocaAgain.Click += new EventHandler(this.btnGiocaAgain_Click);

                btnTornaMenu.Location = new Point(525, 370);
                btnTornaMenu.AutoSize = true;
                btnTornaMenu.Font = new Font(btnTornaMenu.Font.FontFamily, 20);
                btnTornaMenu.Text = "Torna al Menù";
                btnTornaMenu.Name = "btnTornaMenu";
                btnTornaMenu.BackColor = Color.White;
                btnTornaMenu.Click += new EventHandler(this.Form1_Load);

                this.Controls.Remove(lblCartaCoperta);
                ManoLabelsDealer.Remove(lblCartaCoperta);

                Label lblCartaScoperta = new Label();
                lblCartaScoperta.Location = new Point((ManoLabelsDealer[ManoLabelsDealer.Count - 1].Location.X + 78), 33);
                string nomeimgscoperta = "../" + carta4.ToString() + ".bmp";
                Image imgcartascoperta = Image.FromFile(nomeimgscoperta);
                lblCartaScoperta.Size = new Size(imgcartascoperta.Width, imgcartascoperta.Height);
                lblCartaScoperta.Image = imgcartascoperta;

                ManoLabelsDealer.Add(lblCartaScoperta);

                lblDealer.Text = "DEALER: " + TotaleDealerVero;

                this.Controls.Remove(btnPesca);
                this.Controls.Remove(btnMantieni);
                this.Controls.Remove(btnRaddoppia);
                this.Controls.Add(lblSconfittaDealer);
                this.Controls.Add(btnGiocaAgain);
                this.Controls.Add(btnTornaMenu);
                this.Controls.Add(lblCartaScoperta);

                SaveXml();

                MessageBox.Show("Complimenti! Hai vinto " + puntata*2, "Vittoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
            if (TotaleDealerVero == 21 && TotaleGiocatore != 21) 
            {
                DateEnd = new DateTime();
                DateEnd = DateTime.Now;
                vincitore = "dealer";
                Label lblSconfittaGiocatore = new Label();
                lblSconfittaGiocatore.Location = new Point(130, 164);
                lblSconfittaGiocatore.Font = new Font(lblSconfittaGiocatore.Font.FontFamily, 26);
                lblSconfittaGiocatore.BackColor = Color.Transparent;
                lblSconfittaGiocatore.ForeColor = Color.White;
                lblSconfittaGiocatore.Name = "lblSconfittaGiocatore";
                lblSconfittaGiocatore.Text = "BLACKJACK! Il Dealer Ha vinto!";
                lblSconfittaGiocatore.AutoSize = true;
                lblSconfittaGiocatore.Visible = true;

                btnGiocaAgain = new Button();
                btnGiocaAgain.Location = new Point(12, 370);
                btnGiocaAgain.AutoSize = true;
                btnGiocaAgain.Width = 197;
                btnGiocaAgain.Font = new Font(btnGiocaAgain.Font.FontFamily, 20);
                btnGiocaAgain.Text = "Nuova Partita";
                btnGiocaAgain.Name = "btnGiocaAgain";
                btnGiocaAgain.BackColor = Color.White;
                btnGiocaAgain.Click += new EventHandler(this.btnGiocaAgain_Click);

                btnTornaMenu.Location = new Point(525, 370);
                btnTornaMenu.AutoSize = true;
                btnTornaMenu.Font = new Font(btnTornaMenu.Font.FontFamily, 20);
                btnTornaMenu.Text = "Torna al Menù";
                btnTornaMenu.Name = "btnTornaMenu";
                btnTornaMenu.BackColor = Color.White;
                btnTornaMenu.Click += new EventHandler(this.Form1_Load);

                this.Controls.Remove(lblCartaCoperta);
                ManoLabelsDealer.Remove(lblCartaCoperta);

                Label lblCartaScoperta = new Label();
                lblCartaScoperta.Location = new Point((ManoLabelsDealer[ManoLabelsDealer.Count - 1].Location.X + 78), 33);
                string nomeimgscoperta = "../" + carta4.ToString() + ".bmp";
                Image imgcartascoperta = Image.FromFile(nomeimgscoperta);
                lblCartaScoperta.Size = new Size(imgcartascoperta.Width, imgcartascoperta.Height);
                lblCartaScoperta.Image = imgcartascoperta;

                ManoLabelsDealer.Add(lblCartaScoperta);

                lblDealer.Text = "DEALER: " + TotaleDealerVero;

                this.Controls.Remove(btnPesca);
                this.Controls.Remove(btnMantieni);
                this.Controls.Remove(btnRaddoppia);
                this.Controls.Add(lblSconfittaGiocatore);
                this.Controls.Add(btnGiocaAgain);
                this.Controls.Add(btnTornaMenu);
                this.Controls.Add(lblCartaScoperta);

                SaveXml();

                MessageBox.Show("Peccato! Hai perso " + puntata, "Sconfitta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
        }

        private void btnFish1_Click(object sender, EventArgs e)
        {
            if (soldi >= 5)
            {
                puntata += 5;
                soldi -= 5;
                lblPuntata.Text = "PUNTATA: " + puntata;
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
            if (!this.Controls.Contains(btnScommetti))
                this.Controls.Add(btnScommetti);
        }

        private void btnFish2_Click(object sender, EventArgs e)
        {
            if (soldi >= 10)
            {
                puntata += 10;
                soldi -= 10;
                lblPuntata.Text = "PUNTATA: " + puntata;
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
            if (!this.Controls.Contains(btnScommetti))
                this.Controls.Add(btnScommetti);
        }

        private void btnFish3_Click(object sender, EventArgs e)
        {
            if (soldi >= 20)
            {
                puntata += 20;
                soldi -= 20;
                lblPuntata.Text = "PUNTATA: " + puntata;
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
            if (!this.Controls.Contains(btnScommetti))
                this.Controls.Add(btnScommetti);
        }

        private void btnFish4_Click(object sender, EventArgs e)
        {
            if (soldi >= 50)
            {
                puntata += 50;
                soldi -= 50;
                lblPuntata.Text = "PUNTATA: " + puntata;
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
            if (!this.Controls.Contains(btnScommetti))
                this.Controls.Add(btnScommetti);
        }

        private void btnFish5_Click(object sender, EventArgs e)
        {
            if (soldi >= 100)
            {
                puntata += 100;
                soldi -= 100;
                lblPuntata.Text = "PUNTATA: " + puntata;
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
            if (!this.Controls.Contains(btnScommetti))
                this.Controls.Add(btnScommetti);
        }

        private void btnReset_Click(object sender, EventArgs e) 
        {
            soldi += puntata;
            puntata = 0;
            lblSoldi.Text = "Soldi disponibili: " + soldi;
            lblPuntata.Text = "PUNTATA: " + puntata;
            if (this.Controls.Contains(btnScommetti))
                this.Controls.Remove(btnScommetti);
        }

        private void btnStatistichePartite_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.BackgroundImage = null;
            this.BackColor = Color.ForestGreen;

            btnTornaMenu = new Button();
            btnTornaMenu.Location = new Point(446, 5);
            btnTornaMenu.AutoSize = true;
            btnTornaMenu.Font = new Font(btnTornaMenu.Font.FontFamily, 20);
            btnTornaMenu.Text = "Torna al Menù";
            btnTornaMenu.Name = "btnTornaMenu";
            btnTornaMenu.BackColor = Color.White;
            btnTornaMenu.Click += new EventHandler(this.Form1_Load);

            DataGridView viewStatistiche = new DataGridView();
            viewStatistiche.Location = new Point(100, 100);
            viewStatistiche.AllowUserToResizeColumns = false;
            viewStatistiche.AllowUserToAddRows = false;
            viewStatistiche.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            viewStatistiche.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            viewStatistiche.ReadOnly = true;
            viewStatistiche.BackgroundColor = Color.ForestGreen;
            viewStatistiche.Visible = true;
            viewStatistiche.BorderStyle = BorderStyle.None;
            viewStatistiche.Font = new Font(viewStatistiche.Font.FontFamily, 8,FontStyle.Bold);
            viewStatistiche.AutoSize = true;
            try
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create("games_history.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                viewStatistiche.DataSource = ds.Tables[0];
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Controls.Add(viewStatistiche);
            this.Controls.Add(btnTornaMenu);
        }

        private void btnPesca_Click(object sender, EventArgs e)
        {
            Carta carta = mazzo.PescaCarta();
            ManoGiocatore.Add(carta);

            Label lblcarta = new Label();
            lblcarta.Location = new Point((ManoLabelsGiocatore[ManoLabelsGiocatore.Count - 1].Location.X + 78), 250);
            string nomeimg = "../" + carta.ToString() + ".bmp";
            Image imgcarta = Image.FromFile(nomeimg);
            lblcarta.Size = new Size(imgcarta.Width, imgcarta.Height);
            lblcarta.Image = imgcarta;

            ManoLabelsGiocatore.Add(lblcarta);

            TotaleGiocatore += carta.CalcolaValoreCarta();
            
            if(TotaleGiocatore > 21) 
            {
                int TotConAsso1 = 0;
                int piudiunasso = 0;
                foreach (Carta c in ManoGiocatore) 
                {
                    if(c.CalcolaValoreCarta() == 11)
                        TotConAsso1 += 1;
                }
                if (TotConAsso1 > 1) 
                {
                    piudiunasso = 1;
                }
                foreach (Carta c in ManoGiocatore) 
                {
                    if(c.CalcolaValoreCarta() != 11)
                        TotConAsso1 += c.CalcolaValoreCarta();
                }
                if (TotConAsso1 <= 11 && piudiunasso == 1) 
                {
                    TotConAsso1 += 10;
                }
                TotaleGiocatore = TotConAsso1;
            }
            
            lblGiocatore.Text = "GIOCATORE: " + TotaleGiocatore;
            lblImgMazzo.Text = "" + mazzo.NumeroCarteMazzo();

            this.Controls.Add(lblcarta);

            if (TotaleGiocatore>21)
            {
                DateEnd = new DateTime();
                DateEnd = DateTime.Now;
                vincitore = "dealer";
                Label lblSconfittaGiocatore = new Label();
                lblSconfittaGiocatore.Location = new Point(130, 164);
                lblSconfittaGiocatore.Font = new Font(lblSconfittaGiocatore.Font.FontFamily, 26);
                lblSconfittaGiocatore.BackColor = Color.Transparent;
                lblSconfittaGiocatore.ForeColor = Color.White;
                lblSconfittaGiocatore.Name = "lblSconfittaGiocatore";
                lblSconfittaGiocatore.Text = "Il Dealer Ha vinto!";
                lblSconfittaGiocatore.AutoSize = true;
                lblSconfittaGiocatore.Visible = true;

                btnGiocaAgain = new Button();
                btnGiocaAgain.Location = new Point(12, 370); 
                btnGiocaAgain.AutoSize = true;
                btnGiocaAgain.Width = 197;
                btnGiocaAgain.Font = new Font(btnGiocaAgain.Font.FontFamily, 20);
                btnGiocaAgain.Text = "Nuova Partita";
                btnGiocaAgain.Name = "btnGiocaAgain";
                btnGiocaAgain.BackColor = Color.White;
                btnGiocaAgain.Click += new EventHandler(this.btnGiocaAgain_Click);

                btnTornaMenu = new Button();
                btnTornaMenu.Location = new Point(525, 370);
                btnTornaMenu.AutoSize = true;
                btnTornaMenu.Font = new Font(btnTornaMenu.Font.FontFamily, 20);
                btnTornaMenu.Text = "Torna al Menù";
                btnTornaMenu.Name = "btnTornaMenu";
                btnTornaMenu.BackColor = Color.White;
                btnTornaMenu.Click += new EventHandler(this.Form1_Load);

                this.Controls.Remove(btnPesca);
                this.Controls.Remove(btnMantieni);
                this.Controls.Remove(btnRaddoppia);
                this.Controls.Add(lblSconfittaGiocatore);
                this.Controls.Add(btnTornaMenu);
                this.Controls.Add(btnGiocaAgain);

                SaveXml();

                MessageBox.Show("Peccato! Hai perso " + puntata, "Sconfitta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSoldi.Text = "Soldi disponibili: " + soldi;
                
            }
            else if(TotaleGiocatore == 21)
            {
                btnMantieni.PerformClick();
                this.Controls.Remove(btnPesca);
                this.Controls.Remove(btnMantieni);
                this.Controls.Remove(btnRaddoppia);
            }
        }

        private void btnMantieni_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(lblCartaCoperta);
            ManoLabelsDealer.Remove(lblCartaCoperta);

            Label lblCartaScoperta = new Label();
            lblCartaScoperta.Location = new Point((ManoLabelsDealer[ManoLabelsDealer.Count - 1].Location.X + 78), 33);
            string nomeimgscoperta = "../" + ManoDealer[ManoDealer.Count-1].ToString() + ".bmp";
            Image imgcartascoperta = Image.FromFile(nomeimgscoperta);
            lblCartaScoperta.Size = new Size(imgcartascoperta.Width, imgcartascoperta.Height);
            lblCartaScoperta.Image = imgcartascoperta;

            int valCartaScoperta = ManoDealer[ManoDealer.Count - 1].CalcolaValoreCarta();
            int valCarta3 = ManoDealer[0].CalcolaValoreCarta();

            if (valCartaScoperta == 11 && valCarta3 == 11)
                valCartaScoperta = 1;

            ManoLabelsDealer.Add(lblCartaScoperta);
            TotaleDealer = valCartaScoperta + valCarta3;

            lblDealer.Text = "DEALER: " + TotaleDealer;

            this.Controls.Add(lblCartaScoperta);

            while (TotaleDealer <= 16 && TotaleDealer<=TotaleGiocatore)
            {
                Carta carta = mazzo.PescaCarta();
                ManoDealer.Add(carta);
                    
                Label lblcarta = new Label();
                lblcarta.Location = new Point((ManoLabelsDealer[ManoLabelsDealer.Count - 1].Location.X + 78), 33);
                string nomeimg = "../" + carta.ToString() + ".bmp";
                Image imgcarta = Image.FromFile(nomeimg);
                lblcarta.Size = new Size(imgcarta.Width, imgcarta.Height);
                lblcarta.Image = imgcarta;

                ManoLabelsDealer.Add(lblcarta);

                TotaleDealer += carta.CalcolaValoreCarta();

                if (TotaleDealer > 21) 
                {
                    int TotConAsso1 = 0;
                    int piudiunasso = 0;

                    foreach (Carta c in ManoDealer) 
                    {
                        if (c.CalcolaValoreCarta() == 11)
                            TotConAsso1 += 1;
                    }
                    if (TotConAsso1 > 1)
                    {
                        piudiunasso = 1;
                    }
                    foreach (Carta c in ManoDealer) 
                    {
                        if (c.CalcolaValoreCarta() != 11)
                            TotConAsso1 += c.CalcolaValoreCarta();
                    }
                    if (TotConAsso1 <= 11 && piudiunasso == 1) 
                    {
                        TotConAsso1 += 10;
                    }
                    TotaleDealer = TotConAsso1;
                }

                lblDealer.Text = "DEALER: " + TotaleDealer;
                lblImgMazzo.Text = "" + mazzo.NumeroCarteMazzo();

                this.Controls.Add(lblcarta);
            }
            
            if(TotaleDealer < TotaleGiocatore || TotaleDealer>21)
            {
                DateEnd = new DateTime();
                DateEnd = DateTime.Now;
                vincitore = "player";
                soldi += puntata*2;
                Label lblSconfittaDealer = new Label();
                lblSconfittaDealer.Location = new Point(130, 164);
                lblSconfittaDealer.Font = new Font(lblSconfittaDealer.Font.FontFamily, 26);
                lblSconfittaDealer.BackColor = Color.Transparent;
                lblSconfittaDealer.ForeColor = Color.White;
                lblSconfittaDealer.Name = "lblSconfittaDealer";
                lblSconfittaDealer.Text = "Il Giocatore Ha vinto!";
                lblSconfittaDealer.AutoSize = true;
                lblSconfittaDealer.Visible = true;

                this.Controls.Add(lblSconfittaDealer);

                MessageBox.Show("Complimenti! Hai vinto " + puntata*2, "Vittoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }
            else if(TotaleGiocatore == TotaleDealer)
            {
                DateEnd = new DateTime();
                DateEnd = DateTime.Now;
                vincitore = "tie";
                soldi += puntata;
                Label lblPareggio = new Label();
                lblPareggio.Location = new Point(130, 164);
                lblPareggio.Font = new Font(lblPareggio.Font.FontFamily, 26);
                lblPareggio.BackColor = Color.Transparent;
                lblPareggio.ForeColor = Color.White;
                lblPareggio.Name = "lblPareggio";
                lblPareggio.Text = "Pareggio!";
                lblPareggio.AutoSize = true;
                lblPareggio.Visible = true;
                this.Controls.Add(lblPareggio);
            }
            else 
            {
                DateEnd = new DateTime();
                DateEnd = DateTime.Now;
                vincitore = "dealer";
                Label lblSconfittaGiocatore = new Label();
                lblSconfittaGiocatore.Location = new Point(130, 164);
                lblSconfittaGiocatore.Font = new Font(lblSconfittaGiocatore.Font.FontFamily, 26);
                lblSconfittaGiocatore.BackColor = Color.Transparent;
                lblSconfittaGiocatore.ForeColor = Color.White;
                lblSconfittaGiocatore.Name = "lblSconfittaGiocatore";
                lblSconfittaGiocatore.Text = "Il Dealer Ha vinto!";
                lblSconfittaGiocatore.AutoSize = true;
                lblSconfittaGiocatore.Visible = true;

                this.Controls.Add(lblSconfittaGiocatore);

                MessageBox.Show("Peccato! Hai perso " + puntata, "Sconfitta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSoldi.Text = "Soldi disponibili: " + soldi;
            }

            SaveXml();

            btnGiocaAgain = new Button();
            btnGiocaAgain.Location = new Point(12, 370);
            btnGiocaAgain.AutoSize = true;
            btnGiocaAgain.Width = 197;
            btnGiocaAgain.Font = new Font(btnGiocaAgain.Font.FontFamily, 20);
            btnGiocaAgain.Text = "Nuova Partita";
            btnGiocaAgain.Name = "btnGiocaAgain";
            btnGiocaAgain.BackColor = Color.White;
            btnGiocaAgain.Click += new EventHandler(this.btnGiocaAgain_Click);

            btnTornaMenu = new Button();
            btnTornaMenu.Location = new Point(525, 370);
            btnTornaMenu.AutoSize = true;
            btnTornaMenu.Font = new Font(btnTornaMenu.Font.FontFamily, 20);
            btnTornaMenu.Text = "Torna al Menù";
            btnTornaMenu.Name = "btnTornaMenu";
            btnTornaMenu.BackColor = Color.White;
            btnTornaMenu.Click += new EventHandler(this.Form1_Load);

            this.Controls.Remove(btnPesca);
            this.Controls.Remove(btnMantieni);
            this.Controls.Remove(btnRaddoppia);
            this.Controls.Add(btnTornaMenu);
            this.Controls.Add(btnGiocaAgain);
        }

        private void btnRaddoppia_Click(object sender, EventArgs e) 
        {
            soldi -= puntata;
            puntata *= 2;
            lblSoldi.Text = "Soldi disponibili: " + soldi;

            Label lbl2x = new Label();
            lbl2x.Location = new Point(5, 155);
            lbl2x.Font = new Font(lbl2x.Font.FontFamily, 28);
            lbl2x.Name = "lbl2x";
            lbl2x.Text = "2x";
            lbl2x.AutoSize = true;
            lbl2x.Visible = true;
            lbl2x.BackColor = Color.Transparent;
            lbl2x.ForeColor = Color.White;

            this.Controls.Add(lbl2x);

            btnPesca.PerformClick();
            if(TotaleGiocatore<21)
              btnMantieni.PerformClick();
        }

        private void btnGiocaAgain_Click(object sender, EventArgs e)
        {
            btnGioca.PerformClick();
        }

        public static void SaveXml()
        {
            // Create the XmlDocument.
            XmlDocument doc = new XmlDocument();

            string pathfilexml = "games_history.xml";

            if (File.Exists(pathfilexml))
                doc.Load(pathfilexml);
            else
                doc.LoadXml("<games></games>");

            // Add the "big" element
            XmlElement data = doc.CreateElement("game");
            data.SetAttribute("DateStarted", DateStart.ToString());
            data.SetAttribute("DateEnd", DateEnd.ToString());
            
            // add single element of a "big" element
            XmlElement playerPoints = doc.CreateElement("PlayerPoints");
            playerPoints.InnerText = TotaleGiocatore.ToString();
            data.AppendChild(playerPoints);

            // add single element of a "big" element
            XmlElement dealerPoints = doc.CreateElement("DealerPoints");
            dealerPoints.InnerText = TotaleDealer.ToString();
            data.AppendChild(dealerPoints);

            // add single element of a "big" element
            XmlElement winner = doc.CreateElement("Winner");
            winner.InnerText = vincitore;
            data.AppendChild(winner);

            doc.DocumentElement.AppendChild(data);

            doc.PreserveWhitespace = true;
            doc.Save("games_history.xml");
        }
    }
}
