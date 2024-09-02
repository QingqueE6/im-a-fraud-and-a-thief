using System;
namespace BonusMission
{
    enum Suit
    {
        Heart,
        Spade,
        Diamond,
        Club
    }

    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int i = 1; i < 14; i++)
            {
                DrawCard(Suit.Heart, i);
            }

        }

        static void DrawCard(Suit suit, int rank)
        {
            Cards cards = new Cards();
            string suitSymbol = "";
            switch (suit)
            {
                case Suit.Heart:
                    suitSymbol = "♥";
                    break;
                case Suit.Spade:
                    suitSymbol = "♠";
                    break;
                case Suit.Diamond:
                    suitSymbol = "♦";
                    break;
                case Suit.Club:
                    suitSymbol = "♣";
                    break;
            }

            switch (rank)
            {
                case 1:
                    cards.Draw1(suitSymbol);
                    break;
                case 2:
                    cards.Draw2(suitSymbol);
                    break;
                case 3:
                    cards.Draw3(suitSymbol);
                    break;
                case 4:
                    cards.Draw4(suitSymbol);
                    break;
                case 5:
                    cards.Draw5(suitSymbol);
                    break;
                case 6:
                    cards.Draw6(suitSymbol);
                    break;
                case 7:
                    cards.Draw7(suitSymbol);
                    break;
                case 8:
                    cards.Draw8(suitSymbol);
                    break;
                case 9:
                    cards.Draw9(suitSymbol);
                    break;
                case 10:
                    cards.Draw10(suitSymbol);
                    break;
                case 11:
                    cards.Draw11(suitSymbol);
                    break;
                case 12:
                    cards.Draw12(suitSymbol);
                    break;
                case 13:
                    cards.Draw13(suitSymbol);
                    break;
            }
        }

    }
}

