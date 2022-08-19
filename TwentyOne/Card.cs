using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public class Card
    {
        ////constructor method
        ////if we won't assign any values later, those will be the default values
        //public Card()
        //{
        //    Suit = "Spades";
        //    Face = "Two";
        //}
        public Suit Suit { get; set; } //spades, clubs, hearts, and diamonds.

        //The card class has a property of data type string, called Suit.
        // and you can get this property or set this property
        //Making this property pubic means it is accessible by other parts on the program

        public Face Face { get; set; }//ace, king...

    }

    //creating enum
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    public enum Face
    {
        Two,
        Three,
        Four,
        Fife,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
