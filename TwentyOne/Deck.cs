using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public class Deck
    {
        //constructor method
        public Deck()
        {
            //Cards is a property of the Deck so we dont need to create if here
            Cards = new List<Card>();

            List<string> Suits = new List<string>() { "Hearts", "Diamonds", "Clubs", "Spades" };
            List<string> Faces = new List<string>() { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };

            foreach (string face in Faces)
            {
                foreach (string suit in Suits)
                {
                    Card card = new Card();
                    card.Suit = suit;
                    card.Face = face;

                    Cards.Add(card);
                }
            }
        }
        public List<Card> Cards { get; set; }
    }
}
