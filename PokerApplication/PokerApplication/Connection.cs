﻿using System;
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
        string gamecode;
        Client client;
        public Connection()
        {
            InitializeComponent();
        }
        public Connection(Client myClient, string code)
        {
            this.client = myClient;
            InitializeComponent();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.joinGame(textBox1.Text);
        }
        
    }
}
