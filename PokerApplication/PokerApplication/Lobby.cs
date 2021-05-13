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
        }
    }
}
