namespace Bowling3;
class Program
{
    static int TotalRounds = 10;
    static int[][] JechtShotMark3 = new int[TotalRounds][];
    static int[] pointsGained = new int[TotalRounds];
    static int[] frameScores = new int[TotalRounds];
    static string Username = System.Environment.MachineName;
    static Random Randowiz = new Random();

    static void Main(string[] args)
    {
        PlayBowling();
    }
    static void PlayBowling()
    {
        PlayNormal();
        // LastRound();
        // CalculateFrameScores();
        // ShowResults();
        // ShowScoreBoard();
    }
    static void PlayNormal()
    {
        for (int i = 0; i < TotalRounds - 1; i++)
        {
            
            int StandingPins = 10;
            Console.WriteLine($"Round {i+1}: Press enter to roll, {Username}!");
            
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                int Shot1 = Randowiz.Next(0, StandingPins + 1);

                if (Shot1 <= 9)
                {
                    StandingPins -= Shot1;
                    Console.WriteLine($"Round {i+1}: Roll again!");
                    
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        int Shot2 = Randowiz.Next(0, StandingPins + 1);

                        JechtShotMark3[i] = new int[2] { Shot1, Shot2 };
                        pointsGained[i] = Shot1 + Shot2;
                    }
                }
                else
                {
                        JechtShotMark3[i] = new int[1] { Shot1 };
                        pointsGained[i] = Shot1;
                }
            }
            ShowScoreBoard(i);
        }
        LastRound();
    }
    static void LastRound()
    {
        
        int IndexLastRound = TotalRounds - 1;
        int FinalShot1 = 0;
        int FinalShot2 = 0;
        int FinalShot3 = 0;
        
        Console.WriteLine($"Last round: Press enter to roll, {Username}!");
        
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            FinalShot1 = Randowiz.Next(0, TotalRounds);
            Console.WriteLine($"You rolled {FinalShot1}!");
        }
        
        Console.WriteLine($"Last round: Second roll!");
        
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            FinalShot2 = (FinalShot1 == 10)
                ? Randowiz.Next(0, TotalRounds)
                : Randowiz.Next(0, TotalRounds - FinalShot1);
            Console.WriteLine($"You rolled {FinalShot2}!");
        }
        Console.WriteLine($"Last round: Last roll!");
        
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            FinalShot3 = (FinalShot2 == 10)
                ? Randowiz.Next(0, TotalRounds)
                : Randowiz.Next(0, TotalRounds - FinalShot1);
            
            Console.WriteLine($"You rolled {FinalShot3}!");
        }
        JechtShotMark3[IndexLastRound] = new int[3] { FinalShot1, FinalShot2, FinalShot3 };
        pointsGained[IndexLastRound] = FinalShot1 + FinalShot2 + FinalShot3;
        ShowScoreBoard(9);
    }
    
    static void CalculateFrameScores(int currentRound)
    {        
        for (int i = 0; i < currentRound - 1; i++)
        {
            if (JechtShotMark3[i].Length == 1 && JechtShotMark3[i][0] == 10) StrikeCalculation(i);
            else if (JechtShotMark3[i].Length == 2 && JechtShotMark3[i][0] + JechtShotMark3[i][1] == 10) SpareCalculation(i);
            for (int j = 0; j <= i; j++)
            {
                frameScores[i] += pointsGained[j];
            }
            frameScores[9] = pointsGained[9] + frameScores[8];
            
        }
    }
    static void StrikeCalculation(int i)
    {   
        pointsGained[i] += JechtShotMark3[i + 1][0];
        
        // is [i+1] [0] also a strike? If yes, is i+2 in bounds?
        if (JechtShotMark3[i + 1].Length == 1 && i + 2 < TotalRounds)
        {
            pointsGained[i] += JechtShotMark3[i + 2][0]; 
        }
        else
        {
            pointsGained[i] += JechtShotMark3[i + 1][1];
        }
    }
    static void SpareCalculation(int i)
    {
        pointsGained[i] += JechtShotMark3[i + 1][0];
    }

    static void PrintCurrentRound(int Throw1, int? Throw2 = null)
    {
        if (Throw1 == 10 ) Console.WriteLine($"Strike! That is 10 points.");
        else if (Throw1 + (Throw2 ?? 0) == 10) Console.WriteLine($"Spare!: That is 10 points.");
        else Console.WriteLine($"You rolled {Throw1} | {Throw2}");
    }

    static void ShowScoreBoard(int currentRound)
    {
        Console.WriteLine("┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐");
        Console.Write("│");
        
        for (int i = 0; i <= currentRound; i++)
        {
            if (i < TotalRounds - 1) // Normal frames (1 to 9)
            {
                // Strike
                if (JechtShotMark3[i].Length == 1)
                {
                    Console.Write(" │X│ │");
                }
                // Spare
                else if (JechtShotMark3[i].Length == 2 && JechtShotMark3[i][0] + JechtShotMark3[i][1] == 10)
                {
                    Console.Write($" │{JechtShotMark3[i][0]}│/│");
                }
                // Normal rolls
                else
                {
                    Console.Write($" │{JechtShotMark3[i][0]}│{JechtShotMark3[i][1]}│");
                }
            }
            else // 10th frame
            {
                string shot1 = JechtShotMark3[i][0].ToString();
                string shot2 = (JechtShotMark3[i][1] == 10) ? "X" : (JechtShotMark3[i][0] + JechtShotMark3[i][1] == 10) ? "/" : JechtShotMark3[i][1].ToString();
                string shot3 = (JechtShotMark3[i][2] == 10) ? "X" : JechtShotMark3[i][2].ToString();
                Console.Write($" │{shot1}│{shot2}│{shot3}│");
                CalculateFrameScores(currentRound);
            }
        }

        Console.WriteLine("\n└─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┤");
        Console.Write("│");
        for (int i = 0; i < currentRound - 1; i++)
        {
            Console.Write($" {frameScores[i],4}│");
        }
        Console.Write($" {frameScores[9],6}│");
        Console.WriteLine("\n└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
    }

    static void ShowResults()
    {
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
            Console.WriteLine("Points this frame: " + pointsGained[i]);
            Console.WriteLine("Total points: " + frameScores[i]);
            Console.WriteLine("===============");
        }
    }
}