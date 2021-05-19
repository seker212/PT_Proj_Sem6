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
    public partial class HelpForm : Form
    {
        Client client;
        public HelpForm()
        {
            InitializeComponent();
        }
        public HelpForm(Client myClient)
        {
            InitializeComponent();
            this.client = myClient;
            //webBrowser1.Navigate("https://www.youtube.com/watch?v=-QXdRX6OE3E");
            //movieLabel1.Text= System.IO.Directory.GetCurrentDirectory();
        }

        private void sourceButton_Click(object sender, EventArgs e)
        {
            // System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=-QXdRX6OE3E");
            //https://www.youtube.com/watch?v=6kRRdgKVB1o
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=6kRRdgKVB1o");
        }
        private void return_Button_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(client);
            mainMenu.Show();
            this.Close();
        }
    }
}
