using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApplicationClassLibrary
{
    public class Game
    {
        String turn, pool;
        List<String> cards;
        List<Player> players;
        List<Pool> pools;
        public Game()
        {
            cards = new List<String>();
            players = new List<Player>();
            pools = new List<Pool>();
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
            get => cards;
        }
        public Game GetGame
        {
            get => this;
        }
        public List<Pool> Pools
        {
            get => pools;
        }




        public void Load(string[] table)
        {
            cards.Clear();
            players.Clear();
            pools.Clear();
            turn = "";
            
            Player player = new Player();
            Pool pool = new Pool();
            for (int i = 0; i < table.Length; i++)
            {

                if (table[i].Contains("rank"))
                {
                    var rank = table[i + 1];
                    if (rank.Contains("]"))
                    {
                        rank = rank.Replace("]", "");
                    }

                    var card = table[i + 3];
                    if (card.Contains("]"))
                    {
                        card = card.Replace("]", "");
                    }
                    card = card.Replace("hearts", "H");
                    card = card.Replace("diamonds", "D");
                    card = card.Replace("spades", "S");
                    card = card.Replace("clubs", "C");
                    card = rank + card;
                    cards.Add(card);
                    // Console.WriteLine("Kolej:" + table[i + 1]);
                }
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
                    if (player.name.Contains("]"))
                    {
                        player.name = player.name.Replace("]", "");
                    }
                    //Console.WriteLine("Gracz:" + table[i + 1]);
                    players.Add(player);
                    player = new Player();
                }
                else if (table[i].Contains("ammount") || table[i].Contains("amount"))
                {

                    pool.amount = table[i + 1];

                    //Console.WriteLine("Pula:" + table[i + 1]);
                }
                else if (table[i].Contains("members"))
                {
                    i++;
                    while (i < table.Length)
                    {

                        if (table[i].Contains("["))
                        {
                            var temp = table[i];
                            temp = temp.Replace("[", "");
                            if (table[i].Contains("]"))
                            {
                                temp = temp.Replace("]", "");
                                pool.members.Add(temp);
                                pools.Add(pool);
                                break;
                            }
                            pool.members.Add(temp);

                        }
                        else if (table[i].Contains("]"))
                        {
                            var temp = table[i];
                            temp = temp.Replace("]", "");
                            pool.members.Add(temp);
                            pools.Add(pool);
                            pool = new Pool();
                            break;
                        }
                        else
                        {
                            pool.members.Add(table[i]);
                        }

                        i++;
                    }
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
        public void PrintCards()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine("Karta " + i + 1 + ":" + cards[i]);
            }
        }


    }
}
