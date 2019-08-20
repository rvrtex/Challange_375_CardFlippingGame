using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Challange_375_CardFlippingGame
{
    class Card
    {
        Queue<string> untestedSolutions = new Queue<string>();
        
        public bool checkIfCardsAreValid(string cards)
        {
            foreach (char c in cards)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        internal async Task<bool> CanGameBeWonAsync(string cards)
        {
            
            untestedSolutions.Enqueue(cards);
           
            List<string> nullCounter = new List<string>();
            Queue<string> tempQueue = new Queue<string>();
            bool validSolution = false;

            
            while ((untestedSolutions.Count > 0 || tempQueue.Count > 0) && !validSolution)
            {
                
                if (untestedSolutions.Count > 0)
                {
                    tempQueue = await drawCards(untestedSolutions.Dequeue());
                    validSolution = await AddCardsToCueAndSetWin(tempQueue);
                    if (tempQueue.Count == 1)
                    {
                        string peeking = tempQueue.Peek();
                        if (peeking.IndexOf('1') == -1)
                        {
                            tempQueue.Dequeue();
                        }
                    }
                    if (validSolution)
                    {
                        Console.WriteLine("Valid Solution Found");
                    }

                }


            }

            return validSolution;

        }

        private async Task<bool> AddCardsToCueAndSetWin(Queue<string> tempQueue)
        {
            
                foreach (string row in tempQueue)
                {
                    if(row.IndexOf('1') != -1)
                    {
                        untestedSolutions.Enqueue(row);
                    }else if (row.IndexOf('0') == -1 && row.IndexOf('1') == -1)
                    {
                        return true;
                    }   
                }
            return false;
        }

        private async Task<Queue<string>> drawCards(string cards)
        {
                         
            List<int> indexes = new List<int>();

            Queue<string> newRows = new Queue<string>();
            Char[] charCards = cards.ToCharArray();
            for (int index = 0; index < charCards.Length; index++)
            {
                if(charCards[index] == '1')
                {
                    indexes.Add(index);
                }
            }

            if (indexes.Count > 0)
            {
                foreach(int index in indexes)
                {
                    StringBuilder newCardLayout = new StringBuilder (cards);
                    if (index-1 >= 0 && newCardLayout[index-1] != '.')
                    {
                        if(newCardLayout[index - 1] == '0')
                        {
                            newCardLayout[index - 1] = '1';
                        }
                        else
                        {
                            newCardLayout[index - 1] = '0';
                        }


                    }
                    if ((index+1) < cards.Length && newCardLayout[index + 1] != '.')
                    {
                        if (newCardLayout[index + 1] == '0')
                        {
                            newCardLayout[index + 1] = '1';
                        }
                        else
                        {
                            newCardLayout[index + 1] = '0';
                        }


                    }
                    newCardLayout[index] = '.';

                    newRows.Enqueue(newCardLayout.ToString());
                }

                return newRows;

            }
            
            
                newRows.Enqueue(cards);
                return newRows;
            
            
              
           
        }

       
    }
}
