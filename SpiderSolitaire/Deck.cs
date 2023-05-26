using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderSolitaire
{
    internal static class Deck
    {
        public static PictureBox deck;
        static Deck()
        {
            deck = new PictureBox();
            deck.Width = 100;
            deck.Height = 180;
            deck.SizeMode = PictureBoxSizeMode.StretchImage;
            deck.Image = Properties.Resources.back;
            deck.Location = new Point(150 * 11 + 50, 50);
            deck.Click += onClick;
        }

        private static void onClick(object sender, EventArgs e)
        {
            deal(10);
        }

        public static void draw(CardStack from, CardStack to)
        {
            if (from.Count > 0)
            {
                Card card = from.Pop();
                card.col = to.col;
                to.Push(card);
            }
        }
        public static void deal(int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                draw(Global.hiddenCardStack, Global.cols[i % 10]);
            }
            Global.cardsLeft -= cnt;
            Global.form.update();
        }
    }
}
