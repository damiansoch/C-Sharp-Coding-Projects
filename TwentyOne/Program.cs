using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwentyOne
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Hotel Casino. Let's Start by telling me your name.");
            string playerName = Console.ReadLine();

            while (playerName == "")
            {
                Console.WriteLine("Tell me your name,please");
                playerName = Console.ReadLine();
            }

            Console.WriteLine("And how much money did you bring today?");


            string bankStr = Console.ReadLine();
            while (bankStr == "" || Convert.ToInt32(bankStr) <= 0)
            {
                Console.WriteLine("You have to bring some money to the table if you want to play! \n");
                Console.WriteLine("And how much money did you bring today?");
                bankStr = Console.ReadLine();
            }
            int bank = Convert.ToInt32(bankStr);


            Console.WriteLine("Hello, {0}. Would you like to join the game of \"Black Jack\" right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            while (answer == "")
            {
                Console.WriteLine("Would you like to join the game?");
                answer = Console.ReadLine().ToLower();
            }

            if (answer == "yes" || answer == "yep" || answer == "ye" || answer == "Yeah" || answer == "y")
            {
                //creating a player from constructor
                Player player = new Player(playerName, bank);
                //creating a game 
                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;

                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                //if player walks away
                game -= player;
                Console.WriteLine("Thank you for playing! Your end ballance is: {0}", player.Balance);
            }
            //if player doesnt want to play now, or when he exits the game
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.ReadLine();
        }
    }
}
