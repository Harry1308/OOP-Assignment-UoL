namespace CMP1903M_A01_2223
{
    public enum Suit
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds
    };

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    };

    public class Card
    {
        public Suit suit { get; }
        public Rank rank { get; }

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        // repr for class 
        public override string ToString()
        {
            return rank + " of " + suit;
        }
    }
}
