using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public abstract class Game
    {
        private List<Player> _players = new List<Player>();
        public List<Player> Players { get { return _players; } set { _players = value; } }

        //the above two lines are exactly the same what below, the diverence is that we do have instantiated the empty list at the beggining, below returns a null at the beggiging and this will throws an error in the program
        //public List<Player> Players { get; set; }

        //doing the same for a dictionary list

        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }

        //instad ot this public Dictionary<Player, int> Bets { get; set; }

        public string Name { get; set; }


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
