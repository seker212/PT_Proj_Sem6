using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApplicationClassLibrary
{
    public class PlayerHandSchema
    {
        public string hand_type { get; set; }
        public List<CardSchema> hand { get; set; }
    }
}
