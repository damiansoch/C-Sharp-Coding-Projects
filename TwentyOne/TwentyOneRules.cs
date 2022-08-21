using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//business logic class - only the methods needed, no props

namespace TwentyOne
{
    public class TwentyOneRules
    {
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Fife] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1, //ace can be eithe 1 or 11, deppends what player wants it to be
        };

        private static int[] GeaAllPosibbleHandValues(List<Card> Hand)
        {
            int aceCount = Hand.Count(x => x.Face == Face.Ace);
            int[] result = new int[aceCount + 1];
            //ace==1(default)
            int value = Hand.Sum(x => _cardValues[x.Face]); //taking each card and check for the value and Sum it
            result[0] = value;
            if (result.Length == 1) return result;
            for (int i = 1; i < result.Length; i++)
            {
                value += (i * 10);
                result[i] = value;
            }
            return result;
        }

        public static bool CheckForBlackJack(List<Card> Hand)
        {
            int[] posibleValues = GeaAllPosibbleHandValues(Hand);
            int value = posibleValues.Max();
            if (value == 21) return true;
            else return false;
        }

        public static bool IsBoosted(List<Card> Hand)
        {
            int value = GeaAllPosibbleHandValues(Hand).Min();
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = GeaAllPosibbleHandValues(Hand);
            foreach (int value in possibleHandValues)
            {
                // if dealer value above 16 and below 22 dealer has to stay
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }
            return false;

        }

        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            int[] playerResults = GeaAllPosibbleHandValues(PlayerHand);
            int[] dealerResults = GeaAllPosibbleHandValues(DealerHand);

            int playerScore = playerResults.Where(x => x < 22).Max();//filter the values for values larger than 22 and give me the Largest of those
            int dealerScore = dealerResults.Where(x => x < 22).Max();

            if (playerScore > dealerScore) return true;
            else if (dealerScore > playerScore) return false;
            else return null;
        }
    }
}
