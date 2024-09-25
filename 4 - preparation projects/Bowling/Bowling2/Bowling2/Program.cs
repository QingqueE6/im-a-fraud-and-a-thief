namespace Bowling2;

class Program
{
    static int TotalRounds = 10;
    static int[][] JechtShotMark3 = new int[TotalRounds][];
    
    static void Main(string[] args)
    {
        PlayBowling();
    }

    static void PlayBowling()
    {
        // Play first 9 games (normal)
        // play last round (seperate method to avoid if)
        // TODO: make last round method
        PlayNormal();
        Console.WriteLine("Bowling Results:");
        for (int i = 0; i < TotalRounds; i++)
        {
            if (JechtShotMark3[i] != null)
            {
                Console.Write($"Round {i + 1}: ");
                foreach (var number in JechtShotMark3[i])
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Round {i + 1}: No shots taken.");
            }
        }
    }

    static void PlayNormal()
    {
        Random Randowiz = new Random();
        int StandingPins = 10;
        
        for (int i = 0; i < TotalRounds; i++)
        {
            int Shot1 = Randowiz.Next(0, StandingPins + 1);
            
            if (Shot1 <= 9)
            {
                StandingPins -= Shot1;
                int Shot2 = Randowiz.Next(0, StandingPins + 1);
                JechtShotMark3[i] = new int[2]{Shot1, Shot2};
                StandingPins = 10;
            }
            else
            {
                JechtShotMark3[i] = new int[1]{Shot1};
                StandingPins = 10;
            }
            
        }
    }
}