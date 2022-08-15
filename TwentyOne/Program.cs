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

            deck = Shuffle(deck);



            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();
        }

        //method that shuffles the deck of card
        //we will take the deck as an argument and than return shuffled deck

        //public - available everywhere - Access Modifier
        //static - we dont want to create Object Program before calling it ?
        //Deck - thats whats it's returning - ReturnType
        //Shuffle - name of the function
        //(Deck deck) - takes a parameter of type Deck and assigning it to the variable - deck - Parameters
        public static Deck Shuffle(Deck deck)
        {
            // temp list for shuffled cards
            List<Card> TempList = new List<Card>();
            Random random = new Random();

            while (deck.Cards.Count > 0)
            {
                int randomIndex = random.Next(0, deck.Cards.Count);
                TempList.Add(deck.Cards[randomIndex]);
                deck.Cards.RemoveAt(randomIndex);
            }
            deck.Cards = TempList;
            return deck;
        }
    }
}
