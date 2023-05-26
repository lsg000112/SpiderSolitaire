using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderSolitaire
{

    public class Game
    {
        static int totalCards = 104;

        //initialize new game
        public void initGame(int suitNum)
        {
            Global.cols = new CardStack[10];
            Global.deckLeft = 0;
            Global.clickedCards = new CardStack();
            Global.clickedCol = 0;
            for(int i = 0; i < 10; i++)
            {
                Global.cols[i] = new CardStack();
                Global.cols[i].col = i;
            }

            //define total card number

            Card[] cardSet = new Card[totalCards];
            for (int k = 0; k < 8 / suitNum; k++)
            {
                for (int i = 0; i < suitNum; i++)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        Card newCard = new Card(i, j);
                        cardSet[Global.deckLeft++] = newCard;
                        
                    }
                }
            }

            //shuffle numbers from 0 to 103
            int[] shuffledCards = Enumerable.Range(0, totalCards).ToArray();
            Random random = new Random();
            for (int i = totalCards-1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int tmp = shuffledCards[i];
                shuffledCards[i] = shuffledCards[j];
                shuffledCards[j] = tmp;
            }

            //push shuffled cards into hidden stack
            Global.hiddenCardStack = new CardStack();
            Global.hiddenCardStack.col = 0;
            for (int i = 0; i < totalCards; i++)
            {
                Global.hiddenCardStack.Push(cardSet[shuffledCards[i]]);
            }

            
        }



        public static bool checkFinish(CardStack stack)
        {
            CardStack tempStack = new CardStack();
            if (stack.Count >= 13)
            {
                int shape = (int)stack.Peek().shape;
                for (int i = 1; i <= 13; i++)
                {
                    Card card = stack.Pop();
                    tempStack.Push(card);
                    if (!((int)card.shape == shape && card.number == i))
                    {
                        while (tempStack.Count > 0)
                        {
                            stack.Push(tempStack.Pop());
                        }

                        return false;
                    }
                }
                Console.Write(stack.col);
                Console.WriteLine(" is Finished");
                Global.setLeft -= 1;
                return true;
            }
            return false;
        }

        

    }
}