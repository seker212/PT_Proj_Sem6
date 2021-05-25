using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApplication
{
    public class ShowdownSchema
    {
        public int pot { get; set; }
        public Dictionary<string, PlayerHandSchema> players_hands { get; set; }
        public List<string> winners { get; set; }
    }
}
