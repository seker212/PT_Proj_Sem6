
namespace PokerApplication
{
    partial class Lobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.start_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.refresh_button = new System.Windows.Forms.Button();
            this.userLabel1 = new System.Windows.Forms.Label();
            this.userLabel2 = new System.Windows.Forms.Label();
            this.userLabel3 = new System.Windows.Forms.Label();
            this.userLabel6 = new System.Windows.Forms.Label();
            this.userLabel5 = new System.Windows.Forms.Label();
            this.userLabel4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bet = new System.Windows.Forms.NumericUpDown();
            this.smalBlind = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smalBlind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(12, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Anuluj rozgrywkę";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(82, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Udostępnij kod znajomym";
            // 
            // codeBox
            // 
            this.codeBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.codeBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.codeBox.Location = new System.Drawing.Point(66, 64);
            this.codeBox.Name = "codeBox";
            this.codeBox.ReadOnly = true;
            this.codeBox.Size = new System.Drawing.Size(274, 43);
            this.codeBox.TabIndex = 2;
            // 
            // start_Button
            // 
            this.start_Button.Enabled = false;
            this.start_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start_Button.Location = new System.Drawing.Point(558, 404);
            this.start_Button.Name = "start_Button";
            this.start_Button.Size = new System.Drawing.Size(230, 34);
            this.start_Button.TabIndex = 3;
            this.start_Button.Text = "Rozpocznij rozgrywkę";
            this.start_Button.UseVisualStyleBackColor = true;
            this.start_Button.Click += new System.EventHandler(this.start_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(355, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lobby";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // refresh_button
            // 
            this.refresh_button.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.refresh_button.Location = new System.Drawing.Point(326, 404);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(133, 34);
            this.refresh_button.TabIndex = 5;
            this.refresh_button.Text = "Odśwież";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_Click);
            // 
            // userLabel1
            // 
            this.userLabel1.AutoSize = true;
            this.userLabel1.BackColor = System.Drawing.Color.Transparent;
            this.userLabel1.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.userLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userLabel1.Location = new System.Drawing.Point(70, 217);
            this.userLabel1.Name = "userLabel1";
            this.userLabel1.Size = new System.Drawing.Size(33, 37);
            this.userLabel1.TabIndex = 6;
            this.userLabel1.Text = "1:";
            // 
            // userLabel2
            // 
            this.userLabel2.AutoSize = true;
            this.userLabel2.BackColor = System.Drawing.Color.Transparent;
            this.userLabel2.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.userLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userLabel2.Location = new System.Drawing.Point(70, 254);
            this.userLabel2.Name = "userLabel2";
            this.userLabel2.Size = new System.Drawing.Size(37, 37);
            this.userLabel2.TabIndex = 7;
            this.userLabel2.Text = "2:";
            // 
            // userLabel3
            // 
            this.userLabel3.AutoSize = true;
            this.userLabel3.BackColor = System.Drawing.Color.Transparent;
            this.userLabel3.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.userLabel3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userLabel3.Location = new System.Drawing.Point(70, 291);
            this.userLabel3.Name = "userLabel3";
            this.userLabel3.Size = new System.Drawing.Size(37, 37);
            this.userLabel3.TabIndex = 8;
            this.userLabel3.Text = "3:";
            // 
            // userLabel6
            // 
            this.userLabel6.AutoSize = true;
            this.userLabel6.BackColor = System.Drawing.Color.Transparent;
            this.userLabel6.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.userLabel6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userLabel6.Location = new System.Drawing.Point(440, 291);
            this.userLabel6.Name = "userLabel6";
            this.userLabel6.Size = new System.Drawing.Size(37, 37);
            this.userLabel6.TabIndex = 11;
            this.userLabel6.Text = "6:";
            // 
            // userLabel5
            // 
            this.userLabel5.AutoSize = true;
            this.userLabel5.BackColor = System.Drawing.Color.Transparent;
            this.userLabel5.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.userLabel5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userLabel5.Location = new System.Drawing.Point(441, 254);
            this.userLabel5.Name = "userLabel5";
            this.userLabel5.Size = new System.Drawing.Size(37, 37);
            this.userLabel5.TabIndex = 10;
            this.userLabel5.Text = "5:";
            // 
            // userLabel4
            // 
            this.userLabel4.AutoSize = true;
            this.userLabel4.BackColor = System.Drawing.Color.Transparent;
            this.userLabel4.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.userLabel4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userLabel4.Location = new System.Drawing.Point(440, 217);
            this.userLabel4.Name = "userLabel4";
            this.userLabel4.Size = new System.Drawing.Size(38, 37);
            this.userLabel4.TabIndex = 9;
            this.userLabel4.Text = "4:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(572, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mała w ciemno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(356, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Początkowe Punkty";
            // 
            // bet
            // 
            this.bet.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bet.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.bet.Location = new System.Drawing.Point(346, 65);
            this.bet.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.bet.Name = "bet";
            this.bet.Size = new System.Drawing.Size(206, 43);
            this.bet.TabIndex = 14;
            // 
            // smalBlind
            // 
            this.smalBlind.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.smalBlind.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.smalBlind.Location = new System.Drawing.Point(558, 65);
            this.smalBlind.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.smalBlind.Name = "smalBlind";
            this.smalBlind.Size = new System.Drawing.Size(174, 43);
            this.smalBlind.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(91, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(615, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Do rozpoczęcia rozgrywki potrzeba 2 użytkowników";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(68, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(664, 10);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.smalBlind);
            this.Controls.Add(this.bet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userLabel6);
            this.Controls.Add(this.userLabel5);
            this.Controls.Add(this.userLabel4);
            this.Controls.Add(this.userLabel3);
            this.Controls.Add(this.userLabel2);
            this.Controls.Add(this.userLabel1);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start_Button);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.Load += new System.EventHandler(this.Lobby_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smalBlind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.Button start_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.Label userLabel1;
        private System.Windows.Forms.Label userLabel2;
        private System.Windows.Forms.Label userLabel3;
        private System.Windows.Forms.Label userLabel6;
        private System.Windows.Forms.Label userLabel5;
        private System.Windows.Forms.Label userLabel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown bet;
        private System.Windows.Forms.NumericUpDown smalBlind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}