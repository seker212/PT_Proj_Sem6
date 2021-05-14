
namespace PokerApplication
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.movieLabel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sourceButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.return_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // movieLabel1
            // 
            this.movieLabel1.AutoSize = true;
            this.movieLabel1.BackColor = System.Drawing.Color.Transparent;
            this.movieLabel1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.movieLabel1.Location = new System.Drawing.Point(6, 41);
            this.movieLabel1.Name = "movieLabel1";
            this.movieLabel1.Size = new System.Drawing.Size(569, 38);
            this.movieLabel1.TabIndex = 3;
            this.movieLabel1.Text = "Poniższy film ma na celu zaznajomienie z ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(69, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "zasadami Poker Texas Hold\'em";
            // 
            // sourceButton
            // 
            this.sourceButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sourceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sourceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sourceButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sourceButton.Location = new System.Drawing.Point(6, 522);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(571, 40);
            this.sourceButton.TabIndex = 5;
            this.sourceButton.Text = "Naciśnij, aby wyświetlić źródło";
            this.sourceButton.UseVisualStyleBackColor = false;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.return_Button);
            this.groupBox1.Controls.Add(this.axWindowsMediaPlayer2);
            this.groupBox1.Controls.Add(this.movieLabel1);
            this.groupBox1.Controls.Add(this.sourceButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 632);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zasady Pokera";
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(7, 120);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(568, 383);
            this.axWindowsMediaPlayer2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Location = new System.Drawing.Point(605, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 632);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // return_Button
            // 
            this.return_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.return_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.return_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.return_Button.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.return_Button.Location = new System.Drawing.Point(7, 586);
            this.return_Button.Name = "return_Button";
            this.return_Button.Size = new System.Drawing.Size(139, 37);
            this.return_Button.TabIndex = 7;
            this.return_Button.Text = "Powrót";
            this.return_Button.UseVisualStyleBackColor = false;
            this.return_Button.Click += new System.EventHandler(this.return_Button_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HelpForm";
            this.Text = "Texas Hold\'em Pomoc";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label movieLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button return_Button;
    }
}