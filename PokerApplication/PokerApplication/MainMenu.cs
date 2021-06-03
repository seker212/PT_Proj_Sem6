using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokerApplication;
using PokerApplicationClassLib;

namespace PokerApplication
{
    public partial class MainMenu : Form
    {
        Client client;
        private MainMenu()
        {
            InitializeComponent();

        }
        public MainMenu(Client client1)
        {
            this.client = client1;
            InitializeComponent();
            mainLabel.Text = getTime(client.userName);
        }

        string getTime(string name)
        {

            var now = DateTime.Now;
            if (now.Hour < 19 && now.Hour > 5)
            {
                return "Dzień dobry " + name;
            }
            else
            {
                return "Dobry wieczór " + name;
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
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

            }
            else
            {
                Application.Exit();
            }
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
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseCancel(e);
        }
        public static void CloseCancel(FormClosingEventArgs e)
        {
            const string message = "Czy na pewno chcesz opuścić program?";
            const string caption = "Wyście";
            var result = MessageBox.Show(message, caption,
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(client);
            helpForm.Show();
            this.Hide();
        }
        #region Button Hovering 
       

        #endregion

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var code =client.CreateGame();
            if(client.JoinGame(code))
            {
                Lobby lobby = new Lobby(client, code);
                lobby.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wystąpił błąd");
            }
            

        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection(client);
            connection.Show();
            this.Hide();
        }
    }
}
