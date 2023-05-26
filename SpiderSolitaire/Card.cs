using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderSolitaire
{
    public class Card : PictureBox
    {
        public enum Shape
        {
            spade,
            diamond,
            heart,
            club
        }

        public Shape shape;
        public int number, col;
        public bool isHidden, isClicked;

        public Card(int shape, int number)
        {
            this.shape = (Shape)shape;
            this.number = number;
            this.isHidden = true;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Properties.Resources.back;
            this.Width = 100;
            this.Height = 180;
            this.Click += CardClick;
            this.col = 0;
            this.isClicked = false;
            
        }
        public string toString()
        {
            return $"_{this.number}_of_{this.shape}s";
        }
        private void CardClick(object sender, EventArgs e)
        {
            if (this.isHidden == false) 
            {
                int cnt = Global.clickedCards.Count;
                //another col clicked
                if (Global.clickedCards.Count > 0 && Global.clickedCards.Peek().col != ((Card)sender).col && Global.clickedCol != ((Card)sender).col)
                {
                    move(Global.clickedCards, Global.cols[((Card)sender).col]);
                }
                //Click
                else if (isClicked == false)
                {
                    //check if clicked stack is descending or in same shape
                    int prev = 0;
                    var shape = Global.cols[((Card)sender).col].Peek().shape;
                    foreach (Card card in Global.cols[((Card)sender).col])
                    {
                        if (prev == 0)
                        {
                            prev = Global.cols[((Card)sender).col].Peek().number;
                        }
                        else if (prev != card.number - 1 || card.shape != shape)
                        {
                            return;
                        }
                        if (sender == card)
                            break;
                        prev = card.number;
                    }


                    //click
                    Global.clickedCol = ((Card)sender).col;
                    foreach (Card card in Global.cols[((Card)sender).col])
                    {
                        Global.clickedCards.Push(card);
                        card.BorderStyle = BorderStyle.Fixed3D;
                        card.isClicked = true;
                        if (card == (Card)sender)
                        {
                            break;
                        }
                    }


                }
                //unClick
                else if (this.isClicked == true)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        Card card = Global.clickedCards.Pop();
                        card.isClicked = false;
                        card.BorderStyle = BorderStyle.None;
                    }
                }
            }
        }

        public static bool move(CardStack from, CardStack to)
        {
            int cnt = Global.clickedCards.Count;
            //if descending or empty
            if (to.Count == 0 || from.Peek().number + 1 == to.Peek().number) 
            {
                while (from.Count > 0)
                {
                    Card card = from.Pop();
                    card.col = to.col;
                    card.isClicked = false;
                    card.BorderStyle = BorderStyle.None;
                    to.Push(card);
                }
                
                for (int i = 0; i < cnt; i++)
                {
                    Global.cols[Global.clickedCol].Pop();
                }
                Game.checkFinish(Global.cols[Global.clickedCol]);
                Game.checkFinish(to);
                Global.score--;
                Global.form.update();
                return true;
            }
            //move failed
            for (int i = 0; i < cnt; i++)
            {
                Card card = Global.clickedCards.Pop();
                card.isClicked = false;
                card.BorderStyle = BorderStyle.None;
            }
            return false;

        }

        public void reveal()
        {
            this.isHidden = false;
            string imageName = this.toString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
        }

        public void setLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}