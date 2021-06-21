
namespace PokerApplication
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(101)))), ((int)(((byte)(77)))));
            this.pictureBox1.Location = new System.Drawing.Point(451, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 680);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mainLabel
            // 
            this.mainLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(101)))), ((int)(((byte)(77)))));
            this.mainLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold);
            this.mainLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.mainLabel.Location = new System.Drawing.Point(486, 32);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(297, 27);
            this.mainLabel.TabIndex = 1;
            this.mainLabel.Text = "Dzień dobry";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Gainsboro;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Comic Sans MS", 14.75F, System.Drawing.FontStyle.Bold);
            this.startButton.ForeColor = System.Drawing.Color.Black;
            this.startButton.Location = new System.Drawing.Point(517, 109);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(229, 49);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Utwórz rozgrywkę";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.BackColor = System.Drawing.Color.Gainsboro;
            this.joinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.joinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.joinButton.ForeColor = System.Drawing.Color.Black;
            this.joinButton.Location = new System.Drawing.Point(517, 179);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(229, 49);
            this.joinButton.TabIndex = 3;
            this.joinButton.Text = "Dołącz do rozgrywki";
            this.joinButton.UseVisualStyleBackColor = false;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.Gainsboro;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.helpButton.ForeColor = System.Drawing.Color.Black;
            this.helpButton.Location = new System.Drawing.Point(517, 249);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(229, 49);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "Pomocy!";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Gainsboro;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.settingsButton.ForeColor = System.Drawing.Color.Black;
            this.settingsButton.Location = new System.Drawing.Point(517, 319);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(229, 49);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.Text = "Ustawienia";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Visible = false;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Gainsboro;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(517, 459);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(229, 49);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Wyjście";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainMenu";
            this.Text = "Texas Hold\'em";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button exitButton;
    }
}