using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public class TwentyOneGame : Game, IWalkAway //game twentyone inherits form game
    {
        // methods specific only to TwentyOne game
        public override void Play()
        {
            throw new NotImplementedException();
        }

        public override void ListPlayers()
        {
            Console.WriteLine("21 PLayers: ");
            base.ListPlayers();
        }

        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
