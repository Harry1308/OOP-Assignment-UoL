using System;
using System.Collections.Generic;
namespace CMP1903M_A01_2223
{
    internal class Testing
    {

        private static Pack testPack; 
        public void RunTests()
        {
            Console.WriteLine("Creating a new pack of cards...");
            testPack = new Pack();


            Console.WriteLine("Shuffling the pack with the Fisher-Yates Shuffle...");
            Pack.shuffleCardPack(1);
            List<Card> hand = Pack.dealCard(7);
            Console.WriteLine("Your hand:");
            foreach (Card c in hand)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine("Shuffling the pack with the Riffle Shuffle...");
            Pack.shuffleCardPack(2);
            hand = Pack.dealCard(7);
            Console.WriteLine("Your hand:");
            foreach (Card c in hand)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine("Not shuffling the pack...");
            Pack.shuffleCardPack(3);
            hand = Pack.dealCard(7);
            Console.WriteLine("Your hand:");
            foreach (Card c in hand)
            {
                Console.WriteLine(c.ToString());
            }

            Console.ReadLine();
        }

    }
}
