using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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


            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card); // and printing it to the console

            //loging card dealt to the file
            string path = @"C:\Users\damia\Desktop\Basic_C#_Programs\LogsFrom21.txt";
            // when using "using statement" after the method reaces the closing bracket, it will dispose of the data, and freeup the memmory
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(DateTime.Now);
                file.WriteLine(card);
            }

            Deck.Cards.RemoveAt(0);
        }
    }
}
