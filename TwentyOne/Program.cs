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
            Game game = new TwentyOneGame();
            game.Players = new List<Player>();
            Player player = new Player();
            player.Name = "damian";
            game += player;
            game -= player;


            Deck deck = new Deck();
            int timesShuffled;

            deck.Shuffle(out timesShuffled, 3);


            //// print shuffled cards
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine(deck.Cards.Count);
            Console.WriteLine("Shuffled {0} ", timesShuffled + " times!");
            Console.ReadLine();
        }



    }
}
