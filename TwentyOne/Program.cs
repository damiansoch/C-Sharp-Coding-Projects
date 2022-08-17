using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {

        static void Main(string[] args)
        {

            Deck deck = new Deck();
            int timesShuffled;

            deck.Shuffle(out timesShuffled, 3);



            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine(deck.Cards.Count);
            Console.WriteLine("Shuffled {0} ", timesShuffled + " times!");
            Console.ReadLine();
        }


        //public static Deck Shuffle(Deck deck,int times)
        //{
        //    for(int i =0; i < times; i++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    }
}
