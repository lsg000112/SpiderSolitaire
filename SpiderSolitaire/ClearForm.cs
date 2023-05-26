using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderSolitaire
{
    internal class ClearForm : Form
    {
        private Label label1;
        private Label label2;
        private Button button1;

        public void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(241, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "You Win!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(248, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "You Win!";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ClearForm
            // 
            this.ClientSize = new System.Drawing.Size(724, 644);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClearForm";
            this.ResumeLayout(false);
            this.PerformLayout();

            label2.Text = "Score : " + Global.score.ToString();
            button1.Click += new EventHandler(Exit);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
