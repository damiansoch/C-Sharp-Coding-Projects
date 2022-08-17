using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public abstract class Game
    {
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public string Dealer { get; set; }


        //methods specific to all card games

        public abstract void Play(); // (abstract) - classes that enharites from this superclass, must have the play() method


        public virtual void ListPlayers() // (virtual) - this method gets inherited, but you can overwrite it
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);

            }
            Console.ReadLine();
        }

    }
}
