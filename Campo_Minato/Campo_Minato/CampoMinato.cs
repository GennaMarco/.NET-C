using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Campo_Minato
{
    public class CampoMinato
    {
        public List<Cella> ListBtnCelle { get; set; }
        public int[,] PosizioniAdiacenti { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public int numero_mine { get; set; }
        public int flags { get; set; }
        private int[,] CampoConMine;

        public CampoMinato(int row, int col, int numero_mine)
        {
            PosizioniAdiacenti = new int[8, 2] { { +0, +1 }, { -1, +1 }, { -1, +0 }, { -1, -1 }, { +0, -1 }, { +1, -1 }, { +1, +0 }, { +1, +1 } };
            ListBtnCelle = new List<Cella>();
            this.row = row;
            this.col = col;
            this.numero_mine = numero_mine;
            this.flags = numero_mine;
            PosizionaMine();
            int locY = 60;
            int locX = 0;
            int btnCellaSize = 40;
            Cella btnCella;
            for (int i = 0; i < row; i++)
            {
                locY += btnCellaSize;
                locX = 0;

                for (int j = 0; j < col; j++)
                {
                    locX += btnCellaSize;
                    btnCella = new Cella(i + ":" + j, CampoConMine[i, j].ToString(), btnCellaSize, btnCellaSize, Color.Gray, Color.Gray);
                    btnCella.Location = new Point(locX, locY);
                    ListBtnCelle.Add(btnCella);
                }
            }
        }

        private void PosizionaMine()
        {
            Random random;
            int randomRow;
            int randomCol;
            CampoConMine = new int[row, col];
            for (int i = 0; i < numero_mine; i++)
            {
                random = new Random();
                do
                {
                    randomRow = random.Next(row);
                    randomCol = random.Next(col);
                } while (CampoConMine[randomRow, randomCol] == 99);
                CampoConMine[randomRow, randomCol] = 99;
            }
        }

        public Cella LeggiCella(int index)
        {
            Cella cella = ListBtnCelle[index];
            return cella;
        }

        public int NumeroLista()
        {
            return ListBtnCelle.Count;
        }

        public void PosizionaTesto()
        {
            int RowCurrent;
            int ColCurrent;
            int NextRow;
            int NextCol;
            int FoundMines;
            string[] numeri;

            foreach (Cella CurrentButton in ListBtnCelle)
            {
                FoundMines = 0;
                if (CurrentButton.Text != "99")
                {
                    numeri = new string[2];
                    numeri = CurrentButton.Name.Split(':');
                    RowCurrent = Int32.Parse(numeri[0]);
                    ColCurrent = Int32.Parse(numeri[1]);
                    for (int m = 0; m < 8; m++)
                    {
                        NextRow = RowCurrent + PosizioniAdiacenti[m, 0];
                        NextCol = ColCurrent + PosizioniAdiacenti[m, 1];
                        if (AvailablePositions(NextRow, NextCol) && CampoConMine[NextRow, NextCol] == 99)
                        {
                            FoundMines++;
                            CurrentButton.Text = "" + FoundMines;
                        }
                    }
                }
            }
        }

        private bool AvailablePositions(int row, int col)
        {
            if (row < 0 || row > this.row - 1)
                return false;
            if (col < 0 || col > this.col - 1)
                return false;
            return true;
        }
    }
}
