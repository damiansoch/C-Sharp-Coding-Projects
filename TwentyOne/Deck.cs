using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public class Deck
    {

        //------------------------------CONSTRUCTOR---------------------------------

        //constructor method
        public Deck()
        {
            //Cards is a property of the Deck so we dont need to create if here
            Cards = new List<Card>();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i; //casting j to Face data type
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }
        }


        //------------------------------PROPERTIES----------------------------------


        public List<Card> Cards { get; set; }



        //method that shuffles the deck of card
        //we will take the deck as an argument and than return shuffled deck

        //public - available everywhere - Access Modifier
        //static - we dont want to create Object Program before calling it ?
        //Deck - thats whats it's returning - ReturnType
        //Shuffle - name of the function
        //(Deck deck) - takes a parameter of type Deck and assigning it to the variable - deck - Parameters


        //------------------------------METHODS-----------------------------------

        public void Shuffle(out int timesShuffled, int times = 1)
        //times is an "optional parameter", if we wont provide it, it will be "1" in this case
        {
            timesShuffled = 0;
            for (int i = 0; i < times; i++)
            {
                timesShuffled++;
                // temp list for shuffled cards
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }
                Cards = TempList;
            }

        }

    }
}
