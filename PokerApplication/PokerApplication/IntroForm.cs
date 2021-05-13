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
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("BuRGfont TTF",48);
            Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Firebrick);
            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(180);
            e.Graphics.DrawString("A", font, brush, 0, 0);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
           Client client = new Client();
           if(client.CheckData(addressBox.Text, portBox.Text, userName.Text))
           {
                if (client.Initialize(addressBox.Text, portBox.Text, userName.Text))
                {
                    MainMenu mainMenu = new MainMenu(client);
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nie uzyskano odpowiedzi od serwera.");
                }
           }
           else
           {
                MessageBox.Show("Wprowadzone dane są niepoprawne.");
           }
           
            
        }
        private void playButton_Hover(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
        }
        private void playButton_Leave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

    }
}
