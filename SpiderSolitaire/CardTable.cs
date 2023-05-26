using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderSolitaire
{
    internal class CardTable : Panel
    {
        private int col;
        public CardTable(int index)
        {
            col = index;
            Size = new Size(100, 200);
            Location = new Point(150 * index + 50, 50);
            BackColor = Color.DarkGreen;
            Click += new EventHandler(tableClick);
        }

        private void tableClick(object sender, EventArgs e)
        {
            if(Global.clickedCards.Count > 0)
            {
                Card.move(Global.clickedCards, Global.cols[(sender as CardTable).col]);
            }
        }
    }
}

