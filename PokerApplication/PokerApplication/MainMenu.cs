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
            if(now.Hour<19 && now.Hour>5)
            {
                return "Dzień dobry " + name;
            }
            else 
            {
                return "Dobry wieczór "+name;
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
        private void startButton_Enter(object sender, EventArgs e)
        {
            leftArrow.Location = new Point(leftArrow.Location.X, startButton.Location.Y);
            rightArrow.Location = new Point(rightArrow.Location.X, startButton.Location.Y);
            leftArrow.Visible = true;
            rightArrow.Visible = true;
        }
        private void startButton_Leave(object sender, EventArgs e)
        {
            leftArrow.Visible = false;
            rightArrow.Visible = false;
        }
        private void joinButton_Enter(object sender, EventArgs e)
        {
            leftArrow.Location = new Point(leftArrow.Location.X, joinButton.Location.Y);
            rightArrow.Location = new Point(rightArrow.Location.X, joinButton.Location.Y);
            leftArrow.Visible = true;
            rightArrow.Visible = true;
        }
        private void joinButton_Leave(object sender, EventArgs e)
        {
            leftArrow.Visible = false;
            rightArrow.Visible = false;
        }
        private void helpButton_Enter(object sender, EventArgs e)
        {
            leftArrow.Location = new Point(leftArrow.Location.X, helpButton.Location.Y);
            rightArrow.Location = new Point(rightArrow.Location.X, helpButton.Location.Y);
            leftArrow.Visible = true;
            rightArrow.Visible = true;
        }
        private void helpButton_Leave(object sender, EventArgs e)
        {
            leftArrow.Visible = false;
            rightArrow.Visible = false;
        }
        private void settingsButton_Enter(object sender, EventArgs e)
        {
            leftArrow.Location = new Point(leftArrow.Location.X, settingsButton.Location.Y);
            rightArrow.Location = new Point(rightArrow.Location.X, settingsButton.Location.Y);
            leftArrow.Visible = true;
            rightArrow.Visible = true;
        }
        private void settingsButton_Leave(object sender, EventArgs e)
        {
            leftArrow.Visible = false;
            rightArrow.Visible = false;
        }
        private void exitButton_Enter(object sender, EventArgs e)
        {
            leftArrow.Location = new Point(leftArrow.Location.X, exitButton.Location.Y);
            rightArrow.Location = new Point(rightArrow.Location.X, exitButton.Location.Y);
            leftArrow.Visible = true;
            rightArrow.Visible = true;
        }
        private void exitButton_Leave(object sender, EventArgs e)
        {
            leftArrow.Visible = false;
            rightArrow.Visible = false;
        }
        #endregion

     
    }
}
