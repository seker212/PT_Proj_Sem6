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
        }


    }
}
