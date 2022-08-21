using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyOne
{
    public class TwentyOneGame : Game, IWalkAway //game twentyone inherits form game
    {

        public TwentyOneDealer Dealer { get; set; }

        // methods specific only to TwentyOne game
        public override void Play()
        {
            //create the dealer object
            Dealer = new TwentyOneDealer();
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle(out int timesShuffled);
            Console.WriteLine("Place your bet!");

            foreach (Player player in Players)
            {
                string betStr = Console.ReadLine();

                while (betStr == "" || Convert.ToInt32(betStr) <= 0)
                {
                    Console.WriteLine("You have to bet if you want to play!");
                    Console.WriteLine("Place your bet!");
                    betStr = Console.ReadLine();
                }

                int bet = Convert.ToInt32(betStr);
                bool succesfullyBet = player.Bet(bet);

                if (!succesfullyBet)
                {
                    return;
                }
                //using dictionary prop from the Game class
                Bets[player] = bet;
            }

            // deal cards now (two cards at the beginning) 
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.Write("{0}:", player.Name);
                    Dealer.Deal(player.Hand);
                    //checking if you gao a black jack
                    if (i == 1)
                    {
                        bool BlackJack = TwentyOneRules.CheckForBlackJack(player.Hand);
                        if (BlackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);
                            return;
                        }
                    }
                }
                Console.Write("Dealer: ");
                Dealer.Deal(Dealer.Hand);
                if (i == 1)
                {
                    bool BlackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                    if (BlackJack)
                    {
                        Console.WriteLine("Dealer hac blackJack! Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets) // iterating over a dictionary
                        {
                            Dealer.Balance += entry.Value;
                        }
                        return;
                    }
                }
            }
            //asking each player if he wants to stay in the game
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("Your cards are: ");
                    foreach (Card card in player.Hand)
                    {
                        Console.Write("{0} ", card.ToString());//using public customized method from card class 
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("Dealers cards are: ");
                    foreach (Card card in Dealer.Hand)
                    {
                        Console.Write("{0} ", card.ToString());
                    }
                    Console.WriteLine("\n\nHit or stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);
                    }


                    bool busted = TwentyOneRules.IsBoosted(player.Hand);
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine("{0} Busted! You loose your bet of {1} . Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                        Console.WriteLine("Do you want to play again?");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "yep" || answer == "ye" || answer == "Yeah" || answer == "y")
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                            return;
                        }

                    }
                }
            }

            Dealer.isBusted = TwentyOneRules.IsBoosted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = TwentyOneRules.IsBoosted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staing.");
            }
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer Busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}! ", entry.Key.Name, entry.Value);
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
                    //Players where the name is equal the name form the dictionary at the moment (there is only one but we need to use First(){where produces a list, even if there is only one result} gets the winning) 
                    Dealer.Balance -= entry.Value;

                }

                return;
            }

            foreach (Player player in Players)
            {
                //bool?playerWon - turns boolean data type in to nullable data type (means that bool can have the null value now!)
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);

                if (playerWon == null)
                {
                    Console.WriteLine("Push! (TIE) No one wins.");
                    player.Balance += Bets[player];
                }
                else if (playerWon == true)
                {
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];
                    Console.WriteLine("{0} won {1}! Your Balance is {2}", player.Name, Bets[player], player.Balance);

                }
                else
                {
                    Console.WriteLine("Dealer wins {0}!", Bets[player]);
                    Dealer.Balance += Bets[player];
                }
                Console.WriteLine("Play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "yep" || answer == "ye" || answer == "Yeah" || answer == "y")
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
                }
            }


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
