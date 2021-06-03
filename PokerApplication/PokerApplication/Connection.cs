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
    public partial class Connection : Form
    {
        
        Client client;
        public Connection()
        {
            InitializeComponent();
        }
        public Connection(Client myClient)
        {
            this.client = myClient;
            InitializeComponent();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.tableCode = textBox1.Text;
            if (client.Started())
            {
                MessageBox.Show("Za późno. Gra już się zaczęła.");
            }
            else if(!refresh())
            {
                MessageBox.Show("Za późno. Lobby jest pełne.");
            }
            else
            {
                if (client.JoinGame(textBox1.Text))
                {
                    UserLobby userLobby = new UserLobby(client, client.tableCode);
                    userLobby.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd. Upewnij się, że podany kod jest poprawny");
                }
            }
           
        }


        private void returnButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(client);
            mainMenu.Show();
            this.Close();
        }
        private bool refresh()
        {
            var message = "http://" + client.apiAddress + ":" + client.apiPort + "/newtable/players/" + textBox1.Text;
            var data = client.MakeRequest(message, 0)[0];
            if (splitToLabels(data).Length >= 6)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private string[] splitToLabels(string data)
        {
            data = data.Replace("[", "");
            data = data.Replace("]", "");
            data = data.Replace("\"", "");
            data = data.Replace("\'", "");
            data = data.Replace(" ", "");
            var users = data.Split(',');
            return users;
        }
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
                "Czy na pewno chcesz opuścić program?";
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

            }
        }
    }
}
