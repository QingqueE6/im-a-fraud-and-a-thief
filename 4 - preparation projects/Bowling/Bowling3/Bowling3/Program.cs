namespace Bowling3
{
    class Program
    {
        static int TotalRounds = 10;
        static int[][] JechtShotMark3 = new int[TotalRounds][];
        static int[] pointsGained = new int[TotalRounds];
        static int[] frameScores = new int[TotalRounds];
        static bool[] calculationPending = new bool[TotalRounds];
        static string Username = System.Environment.MachineName;
        static Random Randowiz = new Random();
        private int carryOver = 0;

        static void Main(string[] args)
        {
            PlayBowling();
        }

        static void PlayBowling()
        {
            PlayNormal();
            LastRound();
        }

        static void PlayNormal()
        {
            for (int i = 0; i < TotalRounds - 1; i++)
            {
                int StandingPins = 10;
                Console.WriteLine($"Round {i + 1}: Press enter to roll, {Username}!");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    int Shot1 = Randowiz.Next(0, StandingPins + 1);

                    if (Shot1 < StandingPins)
                    {
                        StandingPins -= Shot1;
                        ShowScoreBoard(i, Shot1);
                        Console.WriteLine($"Round {i + 1}: Roll again!");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            int Shot2 = Randowiz.Next(0, StandingPins + 1);
                            JechtShotMark3[i] = new int[2] { Shot1, Shot2 };
                            pointsGained[i] = Shot1 + Shot2;
                            if (Shot1 + Shot2 == 10) calculationPending[i] = true;
                        }
                    }
                    else
                    {
                        JechtShotMark3[i] = new int[1] { Shot1 };
                        pointsGained[i] = Shot1;
                        calculationPending[i] = true;
                    }
                    frameScores[i] += pointsGained[i];
                }
                ShowScoreBoard(i);
            }
        }

        static void LastRound()
        {
            int IndexLastRound = TotalRounds - 1;
            int FinalShot1 = 0, FinalShot2 = 0, FinalShot3 = 0;

            Console.WriteLine($"Final round: Press enter to roll, {Username}!");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                FinalShot1 = Randowiz.Next(0, 11);
                Console.WriteLine($"You rolled {FinalShot1}!");
            }

            Console.WriteLine($"Final round: Second roll!");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                FinalShot2 = (FinalShot1 == 10)
                    ? Randowiz.Next(0, 11)
                    : Randowiz.Next(0, 11 - FinalShot1);
                Console.WriteLine($"You rolled {FinalShot2}!");
            }
            
            if(FinalShot1 + FinalShot2 >= 10){
                Console.WriteLine($"Final round: Last roll!");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    FinalShot3 = (FinalShot2 == 10)
                        ? Randowiz.Next(0, 11)
                        : Randowiz.Next(0, 11 - FinalShot2);
                    Console.WriteLine($"You rolled {FinalShot3}!");
                }
            }
            JechtShotMark3[IndexLastRound] = new int[3] { FinalShot1, FinalShot2, FinalShot3 };
            pointsGained[IndexLastRound] = FinalShot1 + FinalShot2 + FinalShot3;
            frameScores[IndexLastRound] = pointsGained[IndexLastRound];
            ShowScoreBoard(9);
        }

        static void CalculateFrameScores(int currentRound)
        {
            for (int i = 0; i <= currentRound; i++)
            {
                if (calculationPending[i] && JechtShotMark3[i].Length == 2)
                {
                    SpareCalculation(i);
                }
                else if (calculationPending[i] && JechtShotMark3[i].Length == 1)
                {
                    StrikeCalculation(i);
                }
            }
        }

        static void StrikeCalculation(int i)
        {
            if (JechtShotMark3[i + 1] != null && JechtShotMark3[i + 1].Length == 2)
            {
                frameScores[i] += JechtShotMark3[i + 1][0];
                frameScores[i] += JechtShotMark3[i + 1][1];
                calculationPending[i] = false;
            }
            else if (JechtShotMark3[i + 2] != null && JechtShotMark3[i + 1].Length == 1 && JechtShotMark3[i + 2].Length >= 1)
            {
                frameScores[i] += JechtShotMark3[i + 1][0];
                frameScores[i] += JechtShotMark3[i + 2][0];
                calculationPending[i] = false;
            }
        }
        static void SpareCalculation(int i)
        {
            if (JechtShotMark3[i + 1] != null && JechtShotMark3[i + 1].Length >= 1)
            {
                frameScores[i] += JechtShotMark3[i + 1][0];
                calculationPending[i] = false;
            }
        }
        static void ShowScoreBoard(int currentRound, int? currentShot = null)
        {
            Console.Clear();
            CalculateFrameScores(currentRound);
            WithSpace(currentRound * 6, $"FRAME {currentRound + 1}");
            Console.WriteLine("┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐");
            Console.Write("│");
            
            for (int i = 0; i <= currentRound; i++)
            {

                if (JechtShotMark3[i] == null)
                {
                    Console.Write($" │{currentShot}│ │");
                }
                else if (i < TotalRounds - 1) // Normal frames (1 to 9)
                {
                    if (JechtShotMark3[i][0] == 10) Console.Write(" │X│ │"); // Strike
                    else if (JechtShotMark3[i].Length == 2 && JechtShotMark3[i][0] + JechtShotMark3[i][1] == 10)
                        Console.Write($" │{JechtShotMark3[i][0]}│/│"); // Spare
                    else Console.Write($" │{JechtShotMark3[i][0]}│{JechtShotMark3[i][1]}│"); // Normal rolls
                }
                else // 10th frame
                {
                    string shot1 = (JechtShotMark3[i][0] == 10) ? "X" : JechtShotMark3[i][0].ToString();
                    string shot2 = (JechtShotMark3[i][1] == 10) ? "X" : (JechtShotMark3[i][0] + JechtShotMark3[i][1] == 10) ? "/" : JechtShotMark3[i][1].ToString();
                    string shot3 = (JechtShotMark3[i][2] == 10) ? "X" : JechtShotMark3[i][2].ToString();
                    Console.Write($" │{shot1}│{shot2}│{shot3}│");
                }
            }

            Console.WriteLine("\n└─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┤");
            Console.Write("│");
            for (int i = 0; i <= currentRound; i++)
            {
                if(i == 9) Console.Write($" {frameScores[i],6}│");
                else{Console.Write($" {frameScores[i],4}│");}
            }
            Console.WriteLine("\n└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
            ShowPins(currentRound);
        }

        static void ShowPins(int i)
        {
            int remainingPins = TotalRounds - pointsGained[i];
            string[] Pin = new string[TotalRounds];

            for (int j = 0; j < remainingPins; j++) Pin[j] = "o";
            
            string CenterLine(string line, int width)
            {
                int padding = (width - line.Length) / 2;
                return line.PadLeft(padding + line.Length).PadRight(width);
            }
            
            int width = 7;

            Console.WriteLine(CenterLine($"{Pin[6]} {Pin[7]} {Pin[8]} {Pin[9]}", width));
            Console.WriteLine(CenterLine($"{Pin[3]} {Pin[4]} {Pin[5]}", width));
            Console.WriteLine(CenterLine($"{Pin[1]} {Pin[2]}", width));
            Console.WriteLine(CenterLine($"{Pin[0]}", width));
        }
        
        static void WithSpace(int spacesCount, string content)
        {
            string spaces = new string(' ', spacesCount);
            Console.WriteLine($"{spaces}{content}");
        }
    }
}
