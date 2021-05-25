using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApplication
{
    public class PlayerHandSchema
    {
        public string hand_type { get; set; }
        public List<CardSchema> hand { get; set; }
    }
}
