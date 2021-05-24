using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApplication
{
    public class Pool
    {
        public List<string> members;
        public string amount;
        public Pool()
        {
            members = new List<string>();
            amount = "";
        }
        public void printPool()
        {
            Console.WriteLine("Stawka:" + amount);
            Console.WriteLine("Czlonkowie:");
            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine(members[i]);
            }
        }
    }
}
