using System;
using System.Linq;

namespace Mission1
{
    class MainClass
    {

        static int CreateAbilityScore()
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
            int AbilityScore1 = CreateAbilityScore();
            int AbilityScore2 = CreateAbilityScore();
            int AbilityScore3 = CreateAbilityScore();
            int AbilityScore4 = CreateAbilityScore();
            int AbilityScore5 = CreateAbilityScore();
            int AbilityScore6 = CreateAbilityScore();
        }
    }
}
