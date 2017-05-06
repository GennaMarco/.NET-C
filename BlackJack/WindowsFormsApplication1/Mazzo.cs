using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Mazzo
    {
        public List<Carta> mazzo = new List<Carta>();

        public Mazzo()
        {
           foreach(Seme seme in Enum.GetValues(typeof(Seme)))
             foreach(Valore valore in Enum.GetValues(typeof(Valore)))
                mazzo.Add(new Carta(seme, valore));
        }

        public void MescolaMazzo()
        {
            Random r = new Random();
            int numeroMescolamenti = r.Next(50, 100);
            int posizione1;
            int posizione2;
            for(int i = 0; i<numeroMescolamenti; i++)
            {
                posizione1 = r.Next(mazzo.Count);
                do
                {
                    posizione2 = r.Next(mazzo.Count);
                }while(posizione1 == posizione2);

                Carta cartaTemp = mazzo[posizione1];
                mazzo[posizione1] = mazzo[posizione2];
                mazzo[posizione2] = cartaTemp;

            }
        }

        public Carta PescaCarta()
        {
            Carta carta = mazzo[mazzo.Count-1];
            mazzo.RemoveAt(mazzo.Count-1);
            return carta;
        }

        public int NumeroCarteMazzo()
        {
            return mazzo.Count;
        }
    }
}
