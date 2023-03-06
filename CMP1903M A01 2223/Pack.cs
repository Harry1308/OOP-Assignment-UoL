using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private static List<Card> pack;

        public Pack()
        {
            pack = new List<Card>();
            // populate the cards
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    pack.Add(new Card(suit, rank));
                }
            }
        }


        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            if (typeOfShuffle == 1)
            {
                // Fisher-Yates Shuffle
                Random random = new Random();
                int n = pack.Count;
                // randomly exchange cards
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    Card card = pack[k];
                    pack[k] = pack[n];
                    pack[n] = card;
                }
                return true;
            }
            else if (typeOfShuffle == 2)
            {
                // Riffle Shuffle

                // split the cards into two halves
                List<Card> half1 = pack.GetRange(0, pack.Count / 2);
                List<Card> half2 = pack.GetRange(pack.Count / 2, pack.Count - (pack.Count / 2));

                // clear the pack so we can readd the shuffled
                pack.Clear();
                Random random = new Random();

                // while both halves have cards
                while (half1.Count > 0 && half2.Count > 0)
                {
                    // pick cards at random and add to pack 
                    int n1 = random.Next(1, 4);
                    int n2 = random.Next(1, 4);
                    // take the lower bounds so we don't get anout of range error 
                    n1 = Math.Min(n1, half1.Count);
                    n2 = Math.Min(n2, half2.Count);
                    // add the first n2 cards in the pack
                    pack.AddRange(half1.GetRange(0, n1));
                    // take those out of the half
                    half1.RemoveRange(0, n1);
                    pack.AddRange(half2.GetRange(0, n2));
                    half2.RemoveRange(0, n2);
                }
                // merge it all togther
                pack.AddRange(half1);
                pack.AddRange(half2);
                return true;
            }
            else
            {
                // No Shuffle
                return true;
            }

        }
        public static Card deal()
        {
            //Deals one card
            // Return a random card from the pack
            Random random = new Random();
            if (pack.Count == 0)
            {
                return null;
            }
            else
            {
                // deal a random card
                int index = random.Next(0, pack.Count);
                Card card = pack[index];
                pack.RemoveAt(index);
                return card;
            }

        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            // Return a list of random cards from the pack
            List<Card> hand = new List<Card>();
            // loop and add cards to hand
            for (int i = 0; i < amount; i++)
            {
                Card card = deal();
                if (card == null)
                {
                    return null;
                }
                else
                {
                    hand.Add(card);
                }
            }
            return hand;
        }
    }
}
