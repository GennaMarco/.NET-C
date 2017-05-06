using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Carta
    {
        public Seme seme { get; set; }
        public Valore valore { get; set; }

        public Carta(Seme seme, Valore valore)
        {
            this.seme = seme;
            this.valore = valore;
        }

        public int CalcolaValoreCarta()
        {
            int valueInt = 0;
            switch(valore)
            {
                case Valore.DUE: valueInt = 2; break;
                case Valore.TRE: valueInt = 3; break;
                case Valore.QUATTRO: valueInt = 4; break;
                case Valore.CINQUE: valueInt = 5; break;
                case Valore.SEI: valueInt = 6; break;
                case Valore.SETTE: valueInt = 7; break;
                case Valore.OTTO: valueInt = 8; break;
                case Valore.NOVE: valueInt = 9; break;
                case Valore.DIECI: valueInt = 10; break;
                case Valore.JACK: valueInt = 10; break;
                case Valore.QUEEN: valueInt = 10; break;
                case Valore.KING: valueInt = 10; break;
                case Valore.ASSO: valueInt = 11; break;
            }

            return valueInt;
        }

        public override string ToString()
        {
           return "" + valore + seme;
        }
    }
}
