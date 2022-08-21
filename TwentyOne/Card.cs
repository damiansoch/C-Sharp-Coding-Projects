using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public struct Card
    {

        public Suit Suit { get; set; } //spades, clubs, hearts, and diamonds.

        //The card class has a property of data type string, called Suit.
        // and you can get this property or set this property
        //Making this property pubic means it is accessible by other parts on the program

        public Face Face { get; set; }//ace, king...

        //custo ToString method - 
        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }

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
