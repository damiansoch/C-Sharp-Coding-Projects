using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwentyOne
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First()); //addind firs card from the deck to the hand
            Console.WriteLine(Deck.Cards.First().ToString() + "\n"); // and printing it to the console
            Deck.Cards.RemoveAt(0);
        }
    }
}
