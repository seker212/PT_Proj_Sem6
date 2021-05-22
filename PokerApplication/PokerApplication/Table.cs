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

namespace PokerApplication
{
    public partial class Table : Form
    {
        List<System.Windows.Forms.Label> labels;
        List<System.Windows.Forms.PictureBox> cards;
        List<System.Windows.Forms.Label> money;
        List<System.Windows.Forms.PictureBox> sharedCards;
        Client client;
        public delegate void delUpdateUILabel(List<Player> players,int i);
        public delegate void delUpdateUIPoints(List<Player> players,int i);
        public delegate void delUpdateUIPool(string pool);
        public delegate void delUpdateUITurn(string turn);
        public delegate void delUpdatePlayerCards();
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
            /*
            
            Image img=player_card1.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            player_card1.Image = img;
            img = player_card2.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            player_card2.Image = img;
            img = player_card7.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            player_card7.Image = img;
            img = player_card8.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            player_card8.Image = img;
            */
            LoadObjects();
            FormatList();
            Task t = Task.Run(CheckGameStatus);

        }
        private void LoadObjects()
        {
            labels.Add(player_1);
            labels.Add(player_2);
            labels.Add(player_3);
            labels.Add(player_4);
            labels.Add(player_5);
            labels.Add(player_6);

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

            money.Add(points_1);
            money.Add(points_2);
            money.Add(points_3);
            money.Add(points_4);
            money.Add(points_5);
            money.Add(points_6);

            sharedCards.Add(sharedCard1);
            sharedCards.Add(sharedCard2);
            sharedCards.Add(sharedCard3);
            sharedCards.Add(sharedCard4);
            sharedCards.Add(sharedCard5);

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
        private void CheckGameStatus()
        {
            while(true)
            {
                var message = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode;
                string table = client.makeRequest(message, 0)[0];
                //table = table.Replace()
                table = Regex.Replace(table, @"[^0-9a-zA-Z:_,]+", "");
                var MyTable = table.Split(':', ',');
                client.game.Load(MyTable);
                //UPDATE puli, posiadanej kasy, zaznaczenie aktywnego użytkownika
                var pool = client.game.Pool;
                var players = client.game.Players;
                var turn = client.game.Turn;
                while(players[0].name!=client.userName)
                {
                    var player = players[0];
                    players.RemoveAt(0);
                    players.Add(player);
                }
                delUpdateUILabel delUpdateUILabel = new delUpdateUILabel(UpdateUILabel);
                delUpdateUIPoints delUpdateUIPoints = new delUpdateUIPoints(UpdateUIPoints);
                delUpdateUIPool delUpdateUIPool = new delUpdateUIPool(UpdateUIPool);
                delUpdateUITurn delUpdateUITurn = new delUpdateUITurn(UpdateUITurn);
                this.turnLabel.BeginInvoke(delUpdateUITurn, turn);
                this.poolLabel.BeginInvoke(delUpdateUIPool, pool);

                for (int i=0;i<players.Count;i++)
                {
                    this.labels[i].BeginInvoke(delUpdateUILabel,players, i);
                }
                for (int i = 0; i < players.Count; i++)
                {
                    this.money[i].BeginInvoke(delUpdateUIPoints,players, i);
                }


                //this.labels.BeginInvoke()
                Thread.Sleep(1000);
            }            

        }
        public void UpdateUILabel(List<Player> players, int i)
        {
            
                labels[i].Text = players[i].name;
           
        }
        public void UpdateUIPoints(List<Player> players,int i)
        {
                money[i].Text = players[i].cash;
        }
        public void UpdateUIPool(string pool)
        {
            poolLabel.Text = pool;
        }
        public void UpdateUITurn(string turn)
        {
            turnLabel.Text = turn;
        }

    }
}
