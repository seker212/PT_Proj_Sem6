using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using PokerApplicationClassLib;

namespace PokerApplication
{
    public partial class Table : Form
    {
        List<System.Windows.Forms.Label> labels;
        List<System.Windows.Forms.PictureBox> cards;
        List<System.Windows.Forms.Label> money;
        List<System.Windows.Forms.PictureBox> sharedCards;
        List<System.Windows.Forms.Label> pools;
        List<System.Windows.Forms.Label> poolAmounts;
        Client client;
        bool showdown=false;
        public delegate void delUpdateUILabel(List<Player> players,int i);
        public delegate void delUpdateUIPoints(List<Player> players,int i);
        public delegate void delUpdateUIPoints2(string text, int i);
        public delegate void delUpdateUISharedCards(List<string> cards, int i);

        public delegate void delUpadateUIPools( int i,string text,int type);
        public delegate void delUpdateUIPoolNames(int i,int type);
        public delegate void delUpdateUIPool(string pool);
        public delegate void delUpdateUITurn(string turn);
        public delegate void delUpdatePlayerCards();
        public delegate void delUpdateCards(int i,string directory);

        public Table()
        {
            InitializeComponent();
        }
        public Table(Client myClient)
        {
            InitializeComponent();
            this.client = myClient;
            labels = new List<System.Windows.Forms.Label>();
            cards= new List<System.Windows.Forms.PictureBox>();
            money = new List<System.Windows.Forms.Label>();
            sharedCards= new List<System.Windows.Forms.PictureBox>();
            pools = new List<System.Windows.Forms.Label>();
            poolAmounts = new List<System.Windows.Forms.Label>();
            client.GetCards();
        
            LoadObjects();
            FormatList();
            Task t = Task.Run(CheckGameStatus);
            client.GetCards();

        }
        #region Initialization
        private void LoadObjects()
        {
            labels.Clear();
            labels.Add(player_1);
            labels.Add(player_2);
            labels.Add(player_3);
            labels.Add(player_4);
            labels.Add(player_5);
            labels.Add(player_6);

            cards.Clear();
            cards.Add(userCard1);
            cards.Add(userCard2);
            cards.Add(player_card1);
            cards.Add(player_card2);
            cards.Add(player_card3);
            cards.Add(player_card4);
            cards.Add(player_card5);
            cards.Add(player_card6);
            cards.Add(player_card7);
            cards.Add(player_card8);
            cards.Add(player_card9);
            cards.Add(player_card10);

            try
            {
                var directory = client.path + "crimson_back.png";
                for (int i = 2; i < cards.Count; i++)
                {
                    cards[i].BackgroundImage = Image.FromFile(directory);
                }
                userCard1.BackgroundImage = Image.FromFile(directory);
                userCard2.BackgroundImage = Image.FromFile(directory);
            }
            catch (Exception e)
            {
                MessageBox.Show("Bład wczytywania kart");
            }

            money.Clear();
            money.Add(points_1);
            money.Add(points_2);
            money.Add(points_3);
            money.Add(points_4);
            money.Add(points_5);
            money.Add(points_6);

            sharedCards.Clear();
            sharedCards.Add(sharedCard1);
            sharedCards.Add(sharedCard2);
            sharedCards.Add(sharedCard3);
            sharedCards.Add(sharedCard4);
            sharedCards.Add(sharedCard5);
            try
            {
                var directory = client.path +  "crimson_back.png";
                for(int i=0; i<sharedCards.Count;i++)
                {
                    sharedCards[i].BackgroundImage= Image.FromFile(directory);
                }
                userCard1.BackgroundImage = Image.FromFile(directory);
                userCard2.BackgroundImage = Image.FromFile(directory);
            }
            catch (Exception e)
            {
                MessageBox.Show("Bład wczytywania kart");
            }

            pools.Clear();
            pools.Add(pool1);
            pools.Add(pool2);
            pools.Add(pool3);
            pools.Add(pool4);
            pools.Add(pool5);

            poolAmounts.Clear();
            poolAmounts.Add(poolLabel1);
            poolAmounts.Add(poolLabel2);
            poolAmounts.Add(poolLabel3);
            poolAmounts.Add(poolLabel4);
            poolAmounts.Add(poolLabel5);
            for (int i=1;i<5;i++)
            {
                pools[i].Visible = false;
                poolAmounts[i].Visible = false;
            }

            
            try
            {
                var directory = client.path + client.card1 + ".png";
                userCard1.BackgroundImage = Image.FromFile(directory);
                directory = client.path + client.card2 + ".png";
                userCard2.BackgroundImage = Image.FromFile(directory);
                
            }
            catch(Exception e )
            {
                MessageBox.Show("Bład wczytywania kart");
            }

           

        }
        private void FormatList()
        {  
           
            int offset;
            for (offset = 0; offset < client.users.Count; offset++)
            {
                if(client.users[offset]==client.userName)
                {
                    break;
                } 
            }
            for (;0<offset; offset--)
            {
                var temp= client.users[0];
                client.users.RemoveAt(0);
                client.users.Add(temp);
            }
            for (int i = 0; i < client.users.Count;i++)
            {
                labels[i].Text = client.users[i];
            }
            for (int i=client.users.Count;i<6;i++)
            {
                labels[i].Text = "";
                money[i].Text = "";
                cards[i * 2].Visible = false;
                cards[(i * 2) + 1].Visible = false;
            }
        }
        #endregion
        private void CheckGameStatus()
        {
            while(true)
            {
                var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode;
                string table = client.MakeRequest(message, 0)[0];
                //table = table.Replace()
                table = Regex.Replace(table, @"[^0-9a-zA-Z:,_[+\]]", "");

                var MyTable = table.Split(':', ',');
                client.game.Load(MyTable);
                //UPDATE puli, posiadanej kasy, zaznaczenie aktywnego użytkownika
                var cards = client.game.Cards;
                //var pool = client.game.Pool;
                var players = client.game.Players;
                if(players.Count()<2)
                {   
                        MessageBox.Show("Wszyscy gracze wyszli. Opuść rozgrywkę.");
                }
                

                //jeśli playerów jest 1 to wtedy zamknij 
                var turn = client.game.Turn;
                var gamePools = client.game.Pools;
                if(players!=null&&players.Count>0)
                {
                    while(players[0].name!=client.userName)
                    {
                        var player = players[0];
                        players.RemoveAt(0);
                        players.Add(player);
                    }
                    if (!showdown)
                    {
                        delUpdateUILabel delUpdateUILabel = new delUpdateUILabel(UpdateUILabel);
                        delUpdateUIPoints delUpdateUIPoints = new delUpdateUIPoints(UpdateUIPoints);
                        delUpdateUIPool delUpdateUIPool = new delUpdateUIPool(UpdateUIPool);
                        delUpdateUITurn delUpdateUITurn = new delUpdateUITurn(UpdateUITurn);
                        delUpdateUISharedCards delUpdateUISharedCards = new delUpdateUISharedCards(UpdateUISharedCards);
                        delUpadateUIPools delUpadateUIPools = new delUpadateUIPools(UpdateUIPool);
                        delUpdateUIPoolNames delUpdateUIPoolNames = new delUpdateUIPoolNames(UpdateUIPoolNames);
                        this.turnLabel.BeginInvoke(delUpdateUITurn, turn);
                        // this.poolLabel1.BeginInvoke(delUpdateUIPool, pool);
                        for (int i = 0; i < gamePools.Count; i++)
                        {
                            this.pools[i].BeginInvoke(delUpdateUIPoolNames, i, 0);
                            this.poolAmounts[i].BeginInvoke(delUpadateUIPools, i, gamePools[i].amount, 0);
                            if (gamePools[i].members.Contains(client.userName))
                            {
                                this.pools[i].BeginInvoke(delUpdateUIPoolNames, i, 1);
                                this.poolAmounts[i].BeginInvoke(delUpadateUIPools, i, gamePools[i].amount, 1);
                            }
                            else
                            {
                                this.pools[i].BeginInvoke(delUpdateUIPoolNames, i, 3);
                                this.poolAmounts[i].BeginInvoke(delUpadateUIPools, i, gamePools[i].amount, 3);
                            }

                            // this.poolAmounts[i].
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            this.labels[i].BeginInvoke(delUpdateUILabel, players, i);
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            this.money[i].BeginInvoke(delUpdateUIPoints, players, i); 
                        }
                        for (int i = 0; i < cards.Count; i++)
                        {
                            this.sharedCards[i].BeginInvoke(delUpdateUISharedCards, cards, i);
                        }

                    }
                }

                //this.labels.BeginInvoke()
                Thread.Sleep(1000);
            }            

        }
        public void Showdown()
        {
            delUpdateUITurn delUpdateUITurn = new delUpdateUITurn(UpdateUITurn);
            
            var  message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/showdown";
            var response = client.MakeRequest(message, 0)[0];
            List<ShowdownSchema> showdownresp = new List<ShowdownSchema>();
            showdownresp = JsonConvert.DeserializeObject<List<ShowdownSchema>>(response);
            if(showdownresp!=null)
            {
                for (int i = 0; i < showdownresp.Count; i++)
                {
                    this.turnLabel.BeginInvoke(delUpdateUITurn, "Koniec Rundy");
                    var schema = showdownresp[i];
                    int pot = schema.pot + 1;
                    var prefix = "";
                    //if (schema.winners.Count > 1)
                    //{
                    //    prefix = "Wygrali:";
                    //}
                    //else
                    //{
                    //     prefix = "Wygrał: ";
                    //}
                    var winners = string.Join(", ", schema.winners);
                    winners = prefix + winners;
                    delUpadateUIPools delUpadateUIPools = new delUpadateUIPools(UpdateUIPool);
                    poolAmounts[schema.pot].BeginInvoke(delUpadateUIPools, new object[] { i, winners, 0 });
                    if(schema.players_hands!=null)
                    {
                        for (int j = 0; j < schema.players_hands.Count; j++)//RĘCE GRACZY
                        {
                            var cards = schema.players_hands;
                            foreach (var item in cards)//GRACZE
                            {
                                int k = 0;
                                for (k = 0; k < labels.Count; k++)//SZUKANIE GRACZA
                                {
                                    if (labels[k].Text == item.Key)//PRZYPISYWANIE WARTOŚCI RĘKI DO TEKSTU
                                    {
                                        delUpdateUIPoints2 delUpdateUIPoints = new delUpdateUIPoints2(UpdateUIPoints2);

                                        string type = GetHand(item.Value.hand_type);
                                        this.money[k].BeginInvoke(delUpdateUIPoints, new object[] { type, k });
                                        var rank = item.Value.hand[0].rank;
                                        var suit = item.Value.hand[0].suit;
                                        suit = suit.Replace("hearts", "H");
                                        suit = suit.Replace("diamonds", "D");
                                        suit = suit.Replace("spades", "S");
                                        suit = suit.Replace("clubs", "C");
                                        var card = rank + suit;
                                        var directory = "";
                                        delUpdateCards delUpdateCards = new delUpdateCards(UpdateCards);
                                        if (card != "null")
                                        {
                                            directory = client.path + card + ".png";

                                            this.cards[k * 2].BeginInvoke(delUpdateCards, new object[] { k * 2, directory });

                                        }
                                        rank = item.Value.hand[1].rank;
                                        suit = item.Value.hand[1].suit;
                                        suit = suit.Replace("hearts", "H");
                                        suit = suit.Replace("diamonds", "D");
                                        suit = suit.Replace("spades", "S");
                                        suit = suit.Replace("clubs", "C");
                                        card = rank + suit;
                                        if (card != "null")
                                        {
                                            directory = client.path + card + ".png";
                                            this.cards[k * 2 + 1].BeginInvoke(delUpdateCards, new object[] { k * 2 + 1, directory });
                                        }
                                        break;
                                    }
                                }
                            }

                            // cards[j].
                        }
                    }
                    
                    //schema.players_hands
                }
            }
            else
            {
                showdown = false;
            }
           
            
        }
        public string GetHand(string rawHand)
        {
            if(rawHand== "royal_flash")
            {
                return "Poker Królewski";
            }
            if (rawHand == "straight_flash")
            {
                return "Poker";
            }
            if (rawHand == "four_of_a_kind")
            {
                return "Kareta";
            }
            if (rawHand == "full_house")
            {
                return "Full";
            }
            if (rawHand == "flush")
            {
                return "Kolor";
            }
            if (rawHand == "straight")
            {
                return "Strit";
            }
            if (rawHand == "three_of_a_kind")
            {
                return "Trójka";
            }
            if (rawHand == "two_pair")
            {
                return "Dwie Pary";
            }
            if (rawHand == "pair")
            {
                return "Para";
            }
            if (rawHand == "high_hand")
            {
                return "Wysoka Karta";
            }


            //royal_flash = 1
            //straight_flash = 2
            //four_of_a_kind = 3
            //full_house = 4
            //flush = 5
            //straight = 6
            //three_of_a_kind = 7
            //two_pair = 8
            //pair = 9
            //high_hand = 10
            return "";
        }
        #region UI handling
        public void UpdateUILabel(List<Player> players, int i)
        {
                if (i < 0)
                    return;
                if(i>=players.Count())
                {
                    labels[i].Text = "";
                }
                else
                {
                     labels[i].Text = players[i].name;
                }
                
           
        }
        public void UpdateUIPoints(List<Player> players,int i)
        {
            if (i >= players.Count())
            {
                money[i].Text = "";
            }
            else
            {
                money[i].Text = players[i].cash;
            }
            
        }
        public void UpdateUIPoints2(string text, int i)
        {
            money[i].Text = text;
        }
        public void UpdateUIPool(string pool)
        {
            poolLabel1.Text = pool;
        }
        public void UpdateUITurn(string turn)
        {
            turnLabel.Text = turn;
        }
        public void UpdateUISharedCards(List<string> cards, int i)
        {
            try
            {
                var directory = client.path + cards[i] + ".png";
                sharedCards[i].BackgroundImage = Image.FromFile(directory);
            }
            catch(Exception e)
            {
                MessageBox.Show("Bład wczytywania wspólnych kart");
            }
        }
        public void UpdateUIPoolNames(int i,int type)
        {
            if(type ==0)
            {
                pools[i].Visible = true;
            }
            else if (type == 1)
            {
                pools[i].ForeColor = Color.Red;
            }
            else
            {
                pools[i].ForeColor = DefaultForeColor;
            }
        }
        public void UpdateUIPool( int i, string text,int type)
        {
            if (type == 0)
            {
                poolAmounts[i].Visible = true;
                poolAmounts[i].Text = text;
            }
            else if(type ==1)
            {
                poolAmounts[i].ForeColor = Color.Red;
            }
            else
            {
                poolAmounts[i].ForeColor = DefaultForeColor;
            }
        }
        public void UpdateCards(int i, string directory)
        {
            cards[i].BackgroundImage = Image.FromFile(directory);
        }
        #endregion
        #region Button Handling
        private void CheckButtons(object sender, EventArgs e)
        {
          
            if (turnLabel.Text==client.userName)
            {
                var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/actions?playerID=" + client.userCode;
                var cards = client.MakeRequest(message, 0)[0];
                cards = cards.Replace("{", "");
                cards = cards.Replace("}", "");
                var myCards = cards.Split(',');

                var bet_raise = false;
                var call = false;
                var check=false;
                for (int i = 0; i < myCards.Length; i++)
                {
                    //Console.WriteLine(myCards[i]);
                    var line = myCards[i].Split(':');
                    if (line[0].Contains("bet_raise"))
                    {
                        if (line[1].Contains("true"))
                        {
                            bet_raise = true;
                        }
                        else
                        {
                            bet_raise = false;
                        }
                    }
                    else if (line[0].Contains("call"))
                    {
                        if (line[1].Contains("true"))
                        {
                            call = true;
                        }
                        else
                        {
                            call = false;
                        }
                    }
                    if (line[0].Contains("check"))
                    {
                        if (line[1].Contains("true"))
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                        }
                    }

                }

                checkButton.Visible = true;
                betButton.Visible = true;
                allinButton.Visible = true;
                foldButton.Visible = true;
                callButton.Visible = true;
                cashUpDown.Visible = true;

                foldButton.Enabled = true;
                allinButton.Enabled = true;
                if(!bet_raise)
                {
                    betButton.Enabled = false;
                    cashUpDown.Enabled = false;
                }
                else
                {
                    betButton.Enabled = true;
                    cashUpDown.Enabled = true;
                }
                if(!call)
                {
                    callButton.Enabled = false;
                }
                else
                {
                    callButton.Enabled = true;
                }
                if (!check)
                {
                    checkButton.Enabled = false;
                }
                else
                {
                    checkButton.Enabled = true;
                }
            }
            else if(turnLabel.Text == "null")
            {
                showdown = true;
                Showdown();
                nextRound.Visible = true;
            }
            else
            {
                checkButton.Visible = false;
                betButton.Visible = false;
                allinButton.Visible = false;
                foldButton.Visible = false;
                callButton.Visible = false;
                cashUpDown.Visible = false;

                checkButton.Enabled = false;
                betButton.Enabled = false;
                allinButton.Enabled = false;
                foldButton.Enabled = false;
                callButton.Enabled = false;
                cashUpDown.Enabled = false;

            }
        }
        private void callButton_Click(object sender, EventArgs e)
        {
            //var message = 
            //http://127.0.0.1:29345/table/HsbtJO8RtdWbV9p2/actions/call?playerID=Pq8qG7nuSKl1Efoq
            var message = "http://"+client.apiAddress+":"+client.apiPort+"/table/"+client.tableCode+"/actions/call?playerID="+client.userCode;
            client.MakeRequest(message, 0);
        }
        private void checkButton_Click(object sender, EventArgs e)
        {
            var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/actions/check?playerID=" + client.userCode;
            client.MakeRequest(message, 0);
        }
        private void betButton_Click(object sender, EventArgs e)
        {
            //http://127.0.0.1:29345/table/HsbtJO8RtdWbV9p2/actions/bet?playerID=SqTwlUuJhgE0Fl6h&ammount=23
            var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/actions/bet?playerID=" + client.userCode+ "&ammount="+cashUpDown.Value.ToString();
            client.MakeRequest(message, 0);
        }
        private void foldButton_Click(object sender, EventArgs e)
        {
            //http://127.0.0.1:29345/table/HsbtJO8RtdWbV9p2/actions/fold?playerID=ufCHsPZyP71GvBT7
            var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/actions/fold?playerID=" + client.userCode;
            client.MakeRequest(message, 0);
        }
        private void allinButton_Click(object sender, EventArgs e)
        {
            //http://127.0.0.1:29345/table/HsbtJO8RtdWbV9p2/actions/allin?playerID=1mrkelFBCVJbaY3G
            var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/actions/allin?playerID=" + client.userCode;
            client.MakeRequest(message, 0);
        }

        private void nextRound_Click(object sender, EventArgs e)
        {
            nextRound.Visible = false;
            var request = "http://"+client.apiAddress+":"+client.apiPort+"/table/"+client.tableCode+"/nextround?playerID="+client.userCode;
            client.MakeRequest(request, 3);
            while(true)
            {
                var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode;
                string table = client.MakeRequest(message, 0)[0];
                //table = table.Replace()
                table = Regex.Replace(table, @"[^0-9a-zA-Z:,_[+\]]", "");

                var MyTable = table.Split(':', ',');
                client.game.Load(MyTable);
                //UPDATE puli, posiadanej kasy, zaznaczenie aktywnego użytkownika
               
                //var pool = client.game.Pool;
                
                var turn = client.game.Turn;
                if (turn != "null")
                {
                    break;
                }
                Thread.Sleep(500);

            }
            showdown = false;
            client.GetCards();
            LoadObjects();

        }
        private void Table_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
                "Czy na pewno chcesz opuścić rozgrywkę?\nUwaga, jeżeli opuścisz rozgrywkę już do niej nie wrócisz!";
            const string caption = "Wyście";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                e.Cancel = true;
            }
            else
            {
                var request = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/disconnect?playerID=" + client.userCode;
                client.MakeRequest(request, 2);
            }
        }
    }

    #endregion
}
