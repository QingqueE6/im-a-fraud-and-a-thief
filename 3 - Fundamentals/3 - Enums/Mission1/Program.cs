using System;

namespace Mission1
{
    class MainClass
    {
        enum Suit
        {
            Heart,
            Spade,
            Diamond,
            Club
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DrawAce(Suit.Heart);
            DrawAce(Suit.Spade);
            DrawAce(Suit.Diamond);
            DrawAce(Suit.Club);
        }

        static void DrawAce(Suit suit)
        {
            string CardSymbol = "";
            switch(suit)
            {
                case Suit.Heart:
                    CardSymbol = "♥";
                    break;
                case Suit.Spade:
                    CardSymbol = "♠";
                    break;
                case Suit.Diamond:
                    CardSymbol = "♦";
                    break;
                case Suit.Club:
                    CardSymbol = "♣";
                    break;
            }
            Console.WriteLine("╭───────╮");
            Console.WriteLine("│A      │");
            Console.WriteLine($"│{CardSymbol}      │");
            Console.WriteLine($"│   {CardSymbol}   │");
            Console.WriteLine($"│      {CardSymbol}│");
            Console.WriteLine("│      A│");
            Console.WriteLine("╰───────╯");

        }
    }
}
