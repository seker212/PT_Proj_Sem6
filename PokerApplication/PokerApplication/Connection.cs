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
            else
            {
                if (client.joinGame(textBox1.Text))
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
    }
}
