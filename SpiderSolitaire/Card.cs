using System;
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
            int cnt = Global.clickedCards.Count;
            //another col clicked
            if (Global.clickedCards.Count > 0 && Global.clickedCards.Peek().col != ((Card)sender).col)
            {
                //move succeed
                if (move(Global.clickedCards, Global.cols[((Card)sender).col]))
               
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        Global.cols[Global.clickedCol].Pop();
                    }
                    Global.form.update();
                }
                //move failed
                else
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        Card card = Global.clickedCards.Pop();
                        card.isClicked = false;
                        card.BorderStyle = BorderStyle.None;
                    }
                }
            }

            //Click
            else if (this.isHidden == false && isClicked == false)
            {
                //check if clicked stack is descending
                int prev = 0;
                foreach (Card card in Global.cols[((Card)sender).col])
                {
                    if(prev == 0)
                    {
                        prev = Global.cols[((Card)sender).col].Peek().number;
                    }
                    else if (prev != card.number-1)
                    {
                        return;
                    }
                    if (sender == card)
                        break;
                    prev = card.number;
                }
                  


                Global.clickedCol = ((Card)sender).col;
                foreach(Card card in Global.cols[((Card)sender).col])
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
            else if (this.isHidden == false && this.isClicked == true)
            {
                for (int i = 0; i < cnt; i++)
                {
                    Card card = Global.clickedCards.Pop();
                    card.isClicked = false;
                    card.BorderStyle = BorderStyle.None;
                }
            }
        }

        private bool move(CardStack from, CardStack to)
        {
            if(from.Peek().number + 1 == to.Peek().number) 
            {
                while(from.Count > 0)
                {
                    Card card = from.Pop();
                    card.col = to.col;
                    card.isClicked = false;
                    card.BorderStyle = BorderStyle.None;
                    to.Push(card);
                }
                return true;
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