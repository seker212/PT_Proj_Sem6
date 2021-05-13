
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(12, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Anuluj rozgrywkę";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(281, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Udostępnij kod znajomym";
            // 
            // codeBox
            // 
            this.codeBox.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.codeBox.Location = new System.Drawing.Point(254, 50);
            this.codeBox.Name = "codeBox";
            this.codeBox.ReadOnly = true;
            this.codeBox.Size = new System.Drawing.Size(294, 45);
            this.codeBox.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(558, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Rozpocznij rozgrywkę";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(364, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lobby";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(326, 404);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = "Odśwież";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}