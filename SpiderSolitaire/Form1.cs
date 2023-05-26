using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderSolitaire
{
    public partial class Form1 : Form
    {
        private static Label remainLabel;
        private static Label scoreLabel;
        private static Label moveLabel;
        private static CardTable[] cardTable;
        public Form1()
        {
            this.BackColor = Color.Green;
            this.WindowState = FormWindowState.Maximized;

            remainLabel = new Label();
            remainLabel.Width = 300;
            remainLabel.Height = 100;
            remainLabel.Font = new Font("Arial", 15, FontStyle.Bold);

            scoreLabel = new Label();
            scoreLabel.Width = 300;
            scoreLabel.Height = 100;
            scoreLabel.Font = new Font("Arial", 15, FontStyle.Bold);

            moveLabel = new Label();
            moveLabel.Width = 300;
            moveLabel.Height = 100;
            moveLabel.Font = new Font("Arial", 15, FontStyle.Bold);

            cardTable = new CardTable[10];
            for (int i = 0; i < 10; i++)
            {
                cardTable[i] = new CardTable(i);
            }
        }


        public void update()
        {
            Controls.Clear();

            if(Global.setLeft == 0)
            {
                ClearForm popup = new ClearForm();
                popup.InitializeComponent();
                DialogResult result = popup.ShowDialog();
            }

            loadBase();
            //check finished stack
            for (int i = 0; i < 10; i++)
            {
                Game.checkFinish(Global.cols[i]);
            }
            //update columns
            for(int i = 0; i < 10; i++)
            { 
                List<Card> list = new List<Card>(Global.cols[i]);
                list.Reverse();
                int yPos = 50;
                foreach(Card card in list)
                {   
                    card.setLocation(150*i+50, yPos);
                    yPos += 30;
                    Controls.Add(card);
                    card.BringToFront();
                    if (card == Global.cols[i].Peek() && card.isHidden)
                    {
                        card.reveal();
                    }
                }
            }

            //update card deck
            if(Global.deckLeft > 0)
            {
                Controls.Add(Deck.deck);
            }
        }

        private void loadBase()
        {
            for (int i = 0; i < 10; i++)
            {
                Controls.Add(cardTable[i]);
            }
            
            remainLabel.Text = (Global.deckLeft/10).ToString() + " Draws left";
            remainLabel.Location = new Point(Deck.deck.Location.X - 30, Deck.deck.Location.Y + 230);
            Controls.Add(remainLabel);

            scoreLabel.Text = "Score : " + (Global.score).ToString();
            scoreLabel.Location = new Point(Deck.deck.Location.X - 30, Deck.deck.Location.Y + 330);
            Controls.Add(scoreLabel);
            
            moveLabel.Text = "Move : " + (500 - Global.score).ToString();
            moveLabel.Location = new Point(Deck.deck.Location.X - 30, Deck.deck.Location.Y + 430);
            Controls.Add(moveLabel);
        }
    }
}
