using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderSolitaire
{
    internal class PopupForm : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;

        public void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Easy (1 Suit)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Normal (2 Suit)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(226, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "Hard (4 Suit)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(80, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Game Level";
            // 
            // popupForm
            // 
            this.ClientSize = new System.Drawing.Size(610, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "popupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

            button1.Click += new EventHandler(setLevelEasy);
            button2.Click += new EventHandler(setLevelNorm);
            button3.Click += new EventHandler(setLevelHard);
        }

        private void setLevelHard(object sender, EventArgs e)
        {
            Level = 4;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void setLevelNorm(object sender, EventArgs e)
        {
            Level = 2;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void setLevelEasy(object sender, EventArgs e)
        {
            Level = 1;
            DialogResult = DialogResult.OK;
            Close();
        }

        public int Level;
    }
}
