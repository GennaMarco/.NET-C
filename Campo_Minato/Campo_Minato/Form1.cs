using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Campo_Minato
{
    public partial class Form1 : Form
    {
        private Button btnNuovaPartita;
        private Button btnStatistichePartite;
        private Button btnTornaMenu;
        private Label lblCampoMinato;
        private Label lblFlags;
        private Label lblTime;
        private CampoMinato CampoMinato;
        private System.Windows.Forms.Timer timer;
        private int seconds;
        private int NumeroRighe;
        private int NumeroColonne;
        private int NumeroMine;
        private int NumeroCelleLiberate;
        private int numberOfMoves;
        private Difficulty difficulty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.AutoSize = true;
            this.BackColor = Color.Black;

            lblCampoMinato = new Label();
            lblCampoMinato.Location = new Point(160, 10);
            lblCampoMinato.AutoSize = true;
            lblCampoMinato.Text = "Campo Minato";
            lblCampoMinato.BackColor = Color.Transparent;
            lblCampoMinato.ForeColor = Color.White;
            lblCampoMinato.Font = new Font(Font.FontFamily, 36, FontStyle.Italic);

            btnNuovaPartita = new Button();
            btnNuovaPartita.Location = new Point(210, 100);
            btnNuovaPartita.AutoSize = true;
            btnNuovaPartita.Width = 238;
            btnNuovaPartita.Text = "Nuova Partita";
            btnNuovaPartita.BackColor = Color.White;
            btnNuovaPartita.Font = new Font(Font.FontFamily, 20);
            btnNuovaPartita.Click += new EventHandler(btnNuovaPartita_Click);

            btnStatistichePartite = new Button();
            btnStatistichePartite.Location = new Point(210, 150);
            btnStatistichePartite.AutoSize = true;
            btnStatistichePartite.Text = "Statistiche Partite";
            btnStatistichePartite.BackColor = Color.White;
            btnStatistichePartite.Font = new Font(Font.FontFamily, 20);
            btnStatistichePartite.Click += new EventHandler(btnStatistichePartite_Click);

            this.Controls.Add(lblCampoMinato);
            this.Controls.Add(btnNuovaPartita);
            this.Controls.Add(btnStatistichePartite);
        }

        private void btnStatistichePartite_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            btnTornaMenu = new Button();
            btnTornaMenu.Location = new Point(405, 10);
            btnTornaMenu.AutoSize = true;
            btnTornaMenu.Width = 238;
            btnTornaMenu.Text = "Torna al menù";
            btnTornaMenu.BackColor = Color.White;
            btnTornaMenu.Font = new Font(Font.FontFamily, 20);
            btnTornaMenu.Click += new EventHandler(this.Form1_Load);

            DataGridView viewStatistiche = new DataGridView();
            viewStatistiche.Location = new Point(17, 100);
            viewStatistiche.AllowUserToAddRows = false;
            viewStatistiche.RowHeadersVisible = false;
            viewStatistiche.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            viewStatistiche.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            viewStatistiche.BackgroundColor = Color.Black;
            viewStatistiche.Font = new Font(viewStatistiche.Font.FontFamily, 8, FontStyle.Bold);
            viewStatistiche.AutoSize = true;
            viewStatistiche.Enabled = false;
            
            string json_string = MyLibrary.LoadJsonString();
            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(json_string);
            viewStatistiche.DataSource = dataTable;
            
            this.Controls.Add(btnTornaMenu);
            this.Controls.Add(viewStatistiche);
        }

        private void btnNuovaPartita_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            NumeroRighe = 9;
            NumeroColonne = 9;
            NumeroMine = 10;
            difficulty = Difficulty.easy;

            Label lblDifficolta = new Label();
            lblDifficolta.Location = new Point(150, 80);
            lblDifficolta.AutoSize = true;
            lblDifficolta.Text = "Scegli la difficolta:";
            lblDifficolta.BackColor = Color.Transparent;
            lblDifficolta.ForeColor = Color.White;
            lblDifficolta.Font = new Font(Font.FontFamily, 28);

            RadioButton rbtnPrincipiante = new RadioButton();
            rbtnPrincipiante.Location = new Point(160, 170);
            rbtnPrincipiante.Font = new Font(Font.FontFamily, 20);
            rbtnPrincipiante.AutoSize = true;
            rbtnPrincipiante.Name = "rbtnDifficolta";
            rbtnPrincipiante.Text = "Principiante (9x9 con 10 mine)";
            rbtnPrincipiante.ForeColor = Color.White;
            rbtnPrincipiante.Checked = true;
            rbtnPrincipiante.CheckedChanged += new EventHandler(rbtnPrincipiante_CheckedChanged);

            RadioButton rbtnIntermedio = new RadioButton();
            rbtnIntermedio.Location = new Point(160, 220);
            rbtnIntermedio.Font = new Font(Font.FontFamily, 20);
            rbtnIntermedio.AutoSize = true;
            rbtnIntermedio.Name = "rbtnDifficolta";
            rbtnIntermedio.Text = "Intermedio (16x16 con 40 mine)";
            rbtnIntermedio.ForeColor = Color.White;
            rbtnIntermedio.CheckedChanged += new EventHandler(rbtnIntermedio_CheckedChanged);

            RadioButton rbtnEsperto = new RadioButton();
            rbtnEsperto.Location = new Point(160, 270);
            rbtnEsperto.Font = new Font(Font.FontFamily, 20);
            rbtnEsperto.AutoSize = true;
            rbtnEsperto.Name = "rbtnDifficolta";
            rbtnEsperto.Text = "Esperto (30x16 con 99 mine)";
            rbtnEsperto.ForeColor = Color.White;
            rbtnEsperto.CheckedChanged += new EventHandler(rbtnEsperto_CheckedChanged);

            Button btnIniziaPartita = new Button();
            btnIniziaPartita.Location = new Point(210, 370);
            btnIniziaPartita.AutoSize = true;
            btnIniziaPartita.Width = 238;
            btnIniziaPartita.Text = "Inizia Partita";
            btnIniziaPartita.BackColor = Color.White;
            btnIniziaPartita.Font = new Font(Font.FontFamily, 20);
            btnIniziaPartita.Click += new EventHandler(btnIniziaPartita_Click);

            btnTornaMenu = new Button();
            btnTornaMenu.Location = new Point(400, 10);
            btnTornaMenu.AutoSize = true;
            btnTornaMenu.Width = 238;
            btnTornaMenu.Text = "Torna al menù";
            btnTornaMenu.BackColor = Color.White;
            btnTornaMenu.Font = new Font(Font.FontFamily, 20);
            btnTornaMenu.Click += new EventHandler(Form1_Load);

            this.Controls.Add(lblDifficolta);
            this.Controls.Add(rbtnPrincipiante);
            this.Controls.Add(rbtnIntermedio);
            this.Controls.Add(rbtnEsperto);
            this.Controls.Add(btnIniziaPartita);
            this.Controls.Add(btnTornaMenu);
        }

        private void rbtnPrincipiante_CheckedChanged(Object sender, EventArgs e)
        {
            NumeroRighe = 9;
            NumeroColonne = 9;
            NumeroMine = 10;
            difficulty = Difficulty.easy;
        }

        private void rbtnIntermedio_CheckedChanged(Object sender, EventArgs e)
        {
            NumeroRighe = 16;
            NumeroColonne = 16;
            NumeroMine = 40;
            difficulty = Difficulty.medium;
        }

        private void rbtnEsperto_CheckedChanged(Object sender, EventArgs e)
        {
            NumeroRighe = 16;
            NumeroColonne = 30;
            NumeroMine = 99;
            difficulty = Difficulty.hard;
        }

        private void btnIniziaPartita_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.BackColor = Color.Black;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = (1000); 
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            seconds = 0;
            NumeroCelleLiberate = 0;
            numberOfMoves = 0;

            CampoMinato = new CampoMinato(NumeroRighe, NumeroColonne, NumeroMine);
            CampoMinato.PosizionaTesto();
            ShowBoard(CampoMinato);

            btnTornaMenu = new Button();
            btnTornaMenu.Location = new Point(405, 10);
            btnTornaMenu.AutoSize = true;
            btnTornaMenu.Width = 238;
            btnTornaMenu.Text = "Torna al menù";
            btnTornaMenu.BackColor = Color.White;
            btnTornaMenu.Font = new Font(Font.FontFamily, 20);
            btnTornaMenu.Visible = true;
            btnTornaMenu.Click += new EventHandler(Form1_Load_Message_Box);

            Label lblNumeroMine = new Label();
            lblNumeroMine.Location = new Point(36, 35);
            lblNumeroMine.AutoSize = true;
            lblNumeroMine.Text = "Numero mine: " + CampoMinato.numero_mine;
            lblNumeroMine.BackColor = Color.Transparent;
            lblNumeroMine.ForeColor = Color.White;
            lblNumeroMine.Font = new Font(Font.FontFamily, 12);

            lblFlags = new Label();
            lblFlags.Location = new Point(36, 55);
            lblFlags.AutoSize = true;
            lblFlags.Text = "Bandiere: " + CampoMinato.flags;
            lblFlags.BackColor = Color.Transparent;
            lblFlags.ForeColor = Color.White;
            lblFlags.Font = new Font(Font.FontFamily, 12);

            lblTime = new Label();
            lblTime.Location = new Point(36, 75);
            lblTime.AutoSize = true;
            lblTime.Text = "Tempo: " + 0;
            lblTime.BackColor = Color.Transparent;
            lblTime.ForeColor = Color.White;
            lblTime.Font = new Font(Font.FontFamily, 12);

            this.Controls.Add(lblNumeroMine);
            this.Controls.Add(lblFlags);
            this.Controls.Add(btnTornaMenu);
            this.Controls.Add(lblTime);
        }

        private void Form1_Load_Message_Box(object sender, EventArgs e)
        {
            string message = "Sei sicuro di voler uscire? i dati attuali andranno persi";
            DialogResult dialogResult = MessageBox.Show(message, "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                btnTornaMenu.Click -= new EventHandler(this.Form1_Load_Message_Box);
                btnTornaMenu.Click += new EventHandler(this.Form1_Load);
                btnTornaMenu.PerformClick();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Tempo: " + ++seconds;
        }

        private void ShowBoard(CampoMinato campo_minato)
        {
            for (int j = 0; j < campo_minato.NumeroLista(); j++)
            {
                campo_minato.LeggiCella(j).Click += new EventHandler(btnCella_Click);
                campo_minato.LeggiCella(j).MouseUp += btnCella_MouseUp;
                this.Controls.Add(campo_minato.LeggiCella(j));
            }
        }

        public void btnCella_MouseUp(object sender, MouseEventArgs e)
        {
            Button CurrentButton = sender as Button;
            if (e.Button == MouseButtons.Right)
            {
                if (CurrentButton.Image == null && CampoMinato.flags > 0)
                {
                    CurrentButton.Font = new Font(Font.FontFamily, 1);
                    CurrentButton.ForeColor = Color.Red;
                    CurrentButton.Image = Image.FromFile("../flag.png");
                    lblFlags.Text = "Bandiere: " + --CampoMinato.flags;
                }
                else if (CurrentButton.Image != null)
                {
                    CurrentButton.Font = new Font(Font.FontFamily, 8);
                    CurrentButton.ForeColor = Color.Gray;
                    CurrentButton.Image = null;
                    lblFlags.Text = "Bandiere: " + ++CampoMinato.flags;
                }
            }
        }

        public void btnCella_Click(object sender, EventArgs e)
        {
            Cella CurrentButton = sender as Cella;
           
            if (!((e is EventArgs) && !(e is KeyEventArgs) && !(e is MouseEventArgs)))
                numberOfMoves++;
            
            if (CurrentButton.Image != null)
            {
                lblFlags.Text = "Bandiere: " + ++CampoMinato.flags;
                CurrentButton.Image = null;
                CurrentButton.Font = new Font(Font.FontFamily, 8);
            }
            CurrentButton.Click -= new EventHandler(btnCella_Click);
            CurrentButton.MouseUp -= btnCella_MouseUp;
            CurrentButton.ForeColor = Color.Black;
            CurrentButton.BackColor = Color.LightGray;
            int minesFound = 0;
            switch (CurrentButton.Text)
            {
                case "0":
                    CurrentButton.ForeColor = Color.LightGray;
                    NumeroCelleLiberate++;
                    string[] numeri = numeri = new string[2];
                    numeri = CurrentButton.Name.Split(':');
                    int RowCurrent = Int32.Parse(numeri[0]);
                    int ColCurrent = Int32.Parse(numeri[1]);

                    int NextRowCurrent;
                    int NextColCurrent;
                    int NextRowButton;
                    int NextColButton;
                    string[] numeriNext;

                    foreach (Cella NextButton in CampoMinato.ListBtnCelle)
                    {
                        numeriNext = new string[2];
                        for (int m = 0; m < 8; m++)
                        {
                            NextRowCurrent = RowCurrent + CampoMinato.PosizioniAdiacenti[m, 0];
                            NextColCurrent = ColCurrent + CampoMinato.PosizioniAdiacenti[m, 1];

                            numeriNext = NextButton.Name.Split(':');
                            NextRowButton = Int32.Parse(numeriNext[0]);
                            NextColButton = Int32.Parse(numeriNext[1]);

                            if (NextRowCurrent == NextRowButton && NextColCurrent == NextColButton)
                                NextButton.PerformClick();
                        }
                    }
                    break;

                case "99":
                    
                    foreach (Cella button in CampoMinato.ListBtnCelle)
                    {
                        if (button.Text == "99")
                        {
                            button.Click -= new EventHandler(btnCella_Click);
                            button.MouseUp -= btnCella_MouseUp;
                            button.Text = "";
                            if (button.Image == null)
                            {
                                button.Image = Image.FromFile("../mina.gif");
                                button.BackColor = Color.Red;
                            }
                            else
                            {
                                button.Image = Image.FromFile("../mina_scovata.gif");
                                button.BackColor = Color.Transparent;
                                minesFound++;
                            }
                            button.ForeColor = Color.Black;
                        }
                        if (button.BackColor == Color.Gray)
                        {
                            button.Text = "";
                            button.Enabled = false;
                        }
                    }
                    timer.Stop();
                    MyLibrary.WriteJson(difficulty, seconds, minesFound, CampoMinato.numero_mine, numberOfMoves, false);
                    btnTornaMenu.Click -= new EventHandler(this.Form1_Load_Message_Box);
                    btnTornaMenu.Click += new EventHandler(this.Form1_Load);
                    Label lblSconfittaGiocatore = new Label();
                    lblSconfittaGiocatore.Location = new Point(36, 0);
                    lblSconfittaGiocatore.Font = new Font(Font.FontFamily, 14);
                    lblSconfittaGiocatore.ForeColor = Color.White;
                    lblSconfittaGiocatore.AutoSize = true;
                    lblSconfittaGiocatore.Text = "Hai Perso! Mina trovata";
                    this.Controls.Add(lblSconfittaGiocatore);
                    break;

                default:
                    NumeroCelleLiberate++;
                    break;
            }
            if(MyLibrary.VerificaVittoria(CampoMinato.row, CampoMinato.col, CampoMinato.numero_mine, NumeroCelleLiberate))
            {
                timer.Stop();
                MyLibrary.WriteJson(difficulty, seconds, minesFound, CampoMinato.numero_mine, numberOfMoves, true);
                btnTornaMenu.Click -= new EventHandler(this.Form1_Load_Message_Box);
                btnTornaMenu.Click += new EventHandler(this.Form1_Load);
                Label lblVittoriaGiocatore = new Label();
                lblVittoriaGiocatore.Location = new Point(36, 0);
                lblVittoriaGiocatore.Font = new Font(Font.FontFamily, 14);
                lblVittoriaGiocatore.ForeColor = Color.White;
                lblVittoriaGiocatore.AutoSize = true;
                lblVittoriaGiocatore.Text = "Hai Vinto! Tutte le celle liberate!";
                foreach (Cella button in CampoMinato.ListBtnCelle)
                {
                    if (button.Text == "99")
                    {
                        button.Click -= new EventHandler(btnCella_Click);
                        button.MouseUp -= btnCella_MouseUp;
                        button.Text = "";
                        button.Image = Image.FromFile("../mina_bianca.gif");
                        button.ForeColor = Color.Black;
                        button.BackColor = Color.White;
                    }
                    if (button.BackColor == Color.Gray)
                    {
                        button.Text = "";
                        button.Enabled = false;
                    }
                }
                this.Controls.Add(lblVittoriaGiocatore);
            }

        }
    }
}
