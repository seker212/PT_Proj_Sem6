using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokerApplicationClassLib;

namespace PokerApplication
{
    public partial class Lobby : Form
    {
        string gamecode;
        Client client;
        public Lobby()
        {
            InitializeComponent();
        }
        public Lobby(Client myClient, string code)
        {
            this.client = myClient;
            this.gamecode = code;
            InitializeComponent();
            codeBox.Text = gamecode;
            refresh();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refresh();
            if (label2.Text.Length > 2)
            {
                start_Button.Enabled = true;
            }
            else
            {
                start_Button.Enabled = false;
            }
        }
        private void refresh()
        {
            var message = "http://" + client.apiAddress + ":" + client.apiPort + "/newtable/players/" + gamecode;
            var data = client.makeRequest(message, 0)[0];
            splitToLabels(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string message =
               "Czy na pewno chcesz anulować rozgrywkę?";
            const string caption = "Wyjście";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.

            }
            else
            {
                MainMenu mainMenu = new MainMenu(client);
                var request = "http://" + client.apiAddress + ":" + client.apiPort + "/table/" + client.tableCode + "/disconnect?playerID=" + client.userCode;
                client.makeRequest(request, 2);
                //http://127.0.0.1:29345/table/T2IGi5DgI1yvx3DL/disconnect?playerID=ScgfM4DitNP3op5I
                mainMenu.Show();
                this.Close();
                
            }
            
        }
        private void splitToLabels(string data)
        {
           data= data.Replace("[", "");
           data= data.Replace("]", "");
           data=data.Replace("\"", "");
           data = data.Replace("\'", "");
           data = data.Replace(" ", "");
           var Users = data.Split(',');

            if (Users.Length == 1)
            {
                userLabel1.Text = "1:" + Users[0];
                userLabel2.Text = "2:";
                userLabel3.Text = "3:";
                userLabel4.Text = "4:";
                userLabel5.Text = "5:";
                userLabel6.Text = "6:";
            }
            if (Users.Length == 2)
            {
                userLabel1.Text = "1:" + Users[0];
                userLabel2.Text = "2:" + Users[1];
                userLabel3.Text = "3:";
                userLabel4.Text = "4:";
                userLabel5.Text = "5:";
                userLabel6.Text = "6:";

            }
            if (Users.Length == 3)
            {
                userLabel1.Text = "1:" + Users[0];
                userLabel2.Text = "2:" + Users[1];
                userLabel3.Text = "3:" + Users[2];
                userLabel4.Text = "4:";
                userLabel5.Text = "5:";
                userLabel6.Text = "6:";
            }
            if (Users.Length == 4)
            {
                userLabel1.Text = "1:" + Users[0];
                userLabel2.Text = "2:" + Users[1];
                userLabel3.Text = "3:" + Users[2];
                userLabel4.Text = "4:" + Users[3];
                userLabel5.Text = "5:";
                userLabel6.Text = "6:";
            }
            if (Users.Length == 5)
            {
                userLabel1.Text = "1:" + Users[0];
                userLabel2.Text = "2:" + Users[1];
                userLabel3.Text = "3:" + Users[2];
                userLabel4.Text = "4:" + Users[3];
                userLabel5.Text = "5:" + Users[4];
                userLabel6.Text = "6:";
            }
            if (Users.Length == 6)
            {
                userLabel1.Text = "1:" + Users[0];
                userLabel2.Text = "2:" + Users[1];
                userLabel3.Text = "3:" + Users[2];
                userLabel4.Text = "4:" + Users[3];
                userLabel5.Text = "5:" + Users[4];
                userLabel6.Text = "6:" + Users[5];
            }
            if (Users.Length != 1)
            {
                client.users.Clear();
                for (int i = 0; i < Users.Length; i++)
                {
                    client.users.Add(Users[i]);
                }
            }
        }

        private void start_Button_Click(object sender, EventArgs e)
        {
            
            //http://127.0.0.1:29345/newtable/start/mjjzZEMSOtbIJ1bf?startingMoney=1000&smallBlind=20
            var message = "http://"+client.apiAddress+":"+client.apiPort+"/newtable/start/"+client.tableCode+"?startingMoney="+bet.Value.ToString()+"&smallBlind="+smalBlind.Value.ToString();
            client.makeRequest(message,0);
            if(client.Started())
            {
                Table table = new Table(client);
                table.Show();
                this.Hide();
            }
            

        }

        private void Lobby_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
