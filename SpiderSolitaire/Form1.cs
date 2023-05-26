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
        public Form1()
        {
            this.BackColor = Color.Green;
            this.WindowState = FormWindowState.Maximized;
            remainLabel = new Label();
            remainLabel.Width = 300;
            remainLabel.Height = 100;
            remainLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            Controls.Add(remainLabel);
            InitializeComponent();
        }

        public void update()
        {
            Controls.Clear();
            //check finished stack
            for(int i = 0; i < 10; i++)
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
                    Console.WriteLine($"{card.Location.X} {card.Location.Y}");
                    Controls.Add(card);
                    card.BringToFront();
                    if (card == Global.cols[i].Peek() && card.isHidden)
                    {
                        card.reveal();
                    }
                }
            }
            //printCards();

            //update card deck
            if(Global.cardsLeft > 0)
            {
                Controls.Add(Deck.deck);
            }

            remainLabel.Text = Global.cardsLeft.ToString() + " Cards left";

            remainLabel.Location = new Point(Deck.deck.Location.X-30, Deck.deck.Location.Y + 230);
            Controls.Add(remainLabel);
        }

        public void printCards()
        {
            for(int i = 0; i < 10; i++)
            {
                foreach(Card card in Global.cols[i])
                {
                    Console.Write(card.toString());
                }
                Console.WriteLine();
            }
        }
    }
}
