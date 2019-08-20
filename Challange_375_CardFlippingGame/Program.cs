using System;
using System.Threading.Tasks;

namespace Challange_375_CardFlippingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Card Card = new Card();
            string cards;
            Console.WriteLine("please enter your cards");
            cards = Console.ReadLine();
            if (Card.checkIfCardsAreValid(cards))
            {
                Task<bool> canGameBeWon = Card.CanGameBeWonAsync(cards);
                canGameBeWon.Wait();
                if (canGameBeWon.Result)
                {
                    Console.WriteLine("Game has a Solution");
                }
                else
                {
                    Console.WriteLine("Game has no Solution");
                }

            }
            else
            {
                Console.WriteLine("bad Data");
            }
            
           
            

           
        }

        
    }
}
