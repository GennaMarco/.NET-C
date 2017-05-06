using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minato
{
    class MyLibrary
    {
        static string path = "../mines_sweeper_stats.json";

        public static bool VerificaVittoria(int row, int col, int numero_mine, int numero_celle_libere)
        {
            if (numero_celle_libere == ((row * col) - numero_mine))
                return true;
            else
                return false;
        }

        public static void WriteJson(Difficulty g_l, int t_t, int m_f, int t_n_o_m, int n_o_m, bool w)
        {
            List<Partita> ListMatches;
            
            if (File.Exists(path))
                ListMatches = LoadJson();
            else
                ListMatches = new List<Partita>();

            ListMatches.Add(new Partita()
            {
                game_level = g_l,
                time_taken = t_t,
                mines_found = m_f,
                total_number_of_mines = t_n_o_m,
                number_of_moves = n_o_m,
                win = w
            });
            string json = JsonConvert.SerializeObject(ListMatches, Formatting.Indented);

            System.IO.File.WriteAllText(path, json);
        }

        private static List<Partita> LoadJson()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Partita> ListMatches = JsonConvert.DeserializeObject<List<Partita>>(json);
                return ListMatches;
            }
        }

        public static string LoadJsonString()
        {
            using (StreamReader r = new StreamReader("../mines_sweeper_stats.json"))
            {
               return r.ReadToEnd();
            }
        }

    }
}
