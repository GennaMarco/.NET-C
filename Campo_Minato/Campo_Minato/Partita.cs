using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minato
{
    public class Partita
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Difficulty game_level;

        public int time_taken;

        public int mines_found;

        public int total_number_of_mines;

        public int number_of_moves;

        public bool win;
    }
}
