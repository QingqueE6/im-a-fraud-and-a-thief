using System;
using System.Linq;

namespace Mission1
{
    class MainClass
    {

        static int ProcessStringList()
        {
            Random Rng = new Random();
            int Random1 = Rng.Next(1,7);
            int Random2 = Rng.Next(1,7);
            int Random3 = Rng.Next(1,7);
            int Random4 = Rng.Next(1,7);
            int[] DiceRolls = { Random1, Random2, Random3, Random4 };
            int Min = DiceRolls.Min();
            int AbilityScore = DiceRolls.Sum() - Min;
            Console.WriteLine($"You roll {Random1}, {Random2}, {Random3} and {Random4}. Your ability score is {AbilityScore}.");
            return AbilityScore;
        }
        public static void Main(string[] args)
        {
            int AbilityScore1 = ProcessStringList();
            int AbilityScore2 = ProcessStringList();
            int AbilityScore3 = ProcessStringList();
            int AbilityScore4 = ProcessStringList();
            int AbilityScore5 = ProcessStringList();
            int AbilityScore6 = ProcessStringList();
        }
    }
}
