using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderSolitaire
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PopupForm popup = new PopupForm();
            popup.InitializeComponent();
            DialogResult result = popup.ShowDialog();
            
            if(result == DialogResult.OK)
            {
                Global.score = 500;
                Global.setLeft = 8;
                Global.form = new Form1();
                Game game = new Game();
                game.initGame(popup.Level);
                Deck.deal(54);
                Application.Run(Global.form);
            }
        }
    }
}
