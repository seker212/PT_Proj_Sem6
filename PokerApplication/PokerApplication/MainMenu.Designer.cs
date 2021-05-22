﻿
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
            this.leftArrow = new System.Windows.Forms.PictureBox();
            this.rightArrow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(451, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 680);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mainLabel
            // 
            this.mainLabel.BackColor = System.Drawing.Color.White;
            this.mainLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold);
            this.mainLabel.Location = new System.Drawing.Point(481, 33);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(297, 27);
            this.mainLabel.TabIndex = 1;
            this.mainLabel.Text = "Dzień dobry";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Crimson;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Comic Sans MS", 14.75F, System.Drawing.FontStyle.Bold);
            this.startButton.ForeColor = System.Drawing.Color.Black;
            this.startButton.Location = new System.Drawing.Point(512, 109);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(229, 49);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Utwórz rozgrywkę";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.startButton_Enter);
            this.startButton.MouseLeave += new System.EventHandler(this.startButton_Leave);
            // 
            // joinButton
            // 
            this.joinButton.BackColor = System.Drawing.Color.Crimson;
            this.joinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.joinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.joinButton.ForeColor = System.Drawing.Color.Black;
            this.joinButton.Location = new System.Drawing.Point(512, 179);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(229, 49);
            this.joinButton.TabIndex = 3;
            this.joinButton.Text = "Dołącz do rozgrywki";
            this.joinButton.UseVisualStyleBackColor = false;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            this.joinButton.MouseEnter += new System.EventHandler(this.joinButton_Enter);
            this.joinButton.MouseLeave += new System.EventHandler(this.joinButton_Leave);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.Crimson;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.helpButton.ForeColor = System.Drawing.Color.Black;
            this.helpButton.Location = new System.Drawing.Point(512, 249);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(229, 49);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "Pomocy!";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            this.helpButton.MouseEnter += new System.EventHandler(this.helpButton_Enter);
            this.helpButton.MouseLeave += new System.EventHandler(this.helpButton_Leave);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Crimson;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.settingsButton.ForeColor = System.Drawing.Color.Black;
            this.settingsButton.Location = new System.Drawing.Point(512, 319);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(229, 49);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.Text = "Ustawienia";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.MouseEnter += new System.EventHandler(this.settingsButton_Enter);
            this.settingsButton.MouseLeave += new System.EventHandler(this.settingsButton_Leave);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Crimson;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(512, 459);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(229, 49);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Wyjście";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_Enter);
            this.exitButton.MouseLeave += new System.EventHandler(this.settingsButton_Leave);
            // 
            // leftArrow
            // 
            this.leftArrow.BackColor = System.Drawing.Color.White;
            this.leftArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftArrow.BackgroundImage")));
            this.leftArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftArrow.Location = new System.Drawing.Point(475, 109);
            this.leftArrow.Name = "leftArrow";
            this.leftArrow.Size = new System.Drawing.Size(31, 30);
            this.leftArrow.TabIndex = 7;
            this.leftArrow.TabStop = false;
            // 
            // rightArrow
            // 
            this.rightArrow.BackColor = System.Drawing.Color.White;
            this.rightArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightArrow.BackgroundImage")));
            this.rightArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightArrow.Location = new System.Drawing.Point(747, 109);
            this.rightArrow.Name = "rightArrow";
            this.rightArrow.Size = new System.Drawing.Size(31, 30);
            this.rightArrow.TabIndex = 8;
            this.rightArrow.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.rightArrow);
            this.Controls.Add(this.leftArrow);
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
            ((System.ComponentModel.ISupportInitialize)(this.leftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrow)).EndInit();
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
        private System.Windows.Forms.PictureBox leftArrow;
        private System.Windows.Forms.PictureBox rightArrow;
    }
}