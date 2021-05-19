using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApplication
{
    public class Game
    {
        String turn, pool;
        List<String> cards;
        List<Player> players;
        public Game()
        {
            cards = new List<String>();
            players = new List<Player>();
            pool = "";
            turn = "";
        }
        public string Turn
        {
            get => turn;
        }
        public string Pool
        {
            get => pool;
        }
        public List<Player> Players
        {
            get => players;
        }
        public List<String> Cards
        {
            get => Cards;
        }
        public void Load(string[] table)
        {
            cards = new List<String>();
            players = new List<Player>();
            Player player = new Player();
            for (int i = 0; i < table.Length; i++)
            {

                if (table[i].Contains("player_turn"))
                {
                    turn = table[i + 1];
                    // Console.WriteLine("Kolej:" + table[i + 1]);
                }
                else if (table[i].Contains("money"))
                {
                    player.cash = table[i + 1];
                    // Console.WriteLine("Money:"+table[i + 1]);
                }
                else if (table[i].Contains("player_name"))
                {
                    player.name = table[i + 1];
                    //Console.WriteLine("Gracz:" + table[i + 1]);
                    players.Add(player);
                    player = new Player();
                }
                else if (table[i].Contains("ammount") || table[i].Contains("amount"))
                {
                    pool = table[i + 1];
                    //Console.WriteLine("Pula:" + table[i + 1]);
                }
            }
        }
        public void PrintPlayers()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("Gracz:" + players[i].name);
                Console.WriteLine("Kwota:" + players[i].cash);
            }
        }
        public void PrintPool()
        {
            Console.WriteLine("Pula:" + pool);
        }
        public void PrintTurn()
        {
            Console.WriteLine("Kolej:" + pool);
        }


    }
}
