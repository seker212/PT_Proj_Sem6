using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerApplication
{
    public partial class UserLobby : Form
    {
        string gamecode;
        Client client;
        public UserLobby()
        {
            InitializeComponent();
        }
        public UserLobby(Client myClient, string code)
        {
            this.client = myClient;
            this.gamecode = code;
            InitializeComponent();
            codeBox.Text = gamecode;
            refresh();
           // userLabel1.Text = "1:"+client.userName;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refresh();
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
                mainMenu.Show();
                this.Close();
                //USUWANIE STOŁU 
            }
            
        }
        private void splitToLabels(string data)
        {
           data= data.Replace("[", "");
           data= data.Replace("]", "");
           data=data.Replace("\"", "");
           data = data.Replace("\'", "");
           data = data.Replace(" ", "");
           var users = data.Split(',');

            //MessageBox.Show(data);
           if (users.Length == 1)
           {
                userLabel1.Text = "1:" + users[0];
           }
           if (users.Length == 2)
           {
                userLabel1.Text = "1:" + users[0];
                userLabel2.Text = "2:" + users[1];

           }
           if (users.Length == 3)
           {
                userLabel1.Text = "1:" + users[0];
                userLabel2.Text = "2:" + users[1];
                userLabel3.Text = "3:" + users[2];
           }
           if (users.Length == 4)
           {
                userLabel1.Text = "1:" + users[0];
                userLabel2.Text = "2:" + users[1];
                userLabel3.Text = "3:" + users[2];
                userLabel4.Text = "4:" + users[3];
           }
           if (users.Length == 5)
           {
                userLabel1.Text = "1:" + users[0];
                userLabel2.Text = "2:" + users[1];
                userLabel3.Text = "3:" + users[2];
                userLabel4.Text = "4:" + users[3];
                userLabel5.Text = "5:" + users[4];
           }
           if (users.Length == 6)
           {
                userLabel1.Text = "1:" + users[0];
                userLabel2.Text = "2:" + users[1];
                userLabel3.Text = "3:" + users[2];
                userLabel4.Text = "4:" + users[3];
                userLabel5.Text = "5:" + users[4];
                userLabel6.Text = "6:" + users[5];
           }
        }

        
    }
}
