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
                List<Card> half1 = pack.GetRange(0, pack.Count / 2);
                List<Card> half2 = pack.GetRange(pack.Count / 2, pack.Count - (pack.Count / 2));
                pack.Clear();
                Random random = new Random();
                while (half1.Count > 0 && half2.Count > 0)
                {
                    int n1 = random.Next(1, 4);
                    int n2 = random.Next(1, 4);
                    n1 = Math.Min(n1, half1.Count);
                    n2 = Math.Min(n2, half2.Count);
                    pack.AddRange(half1.GetRange(0, n1));
                    half1.RemoveRange(0, n1);
                    pack.AddRange(half2.GetRange(0, n2));
                    half2.RemoveRange(0, n2);
                }
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
