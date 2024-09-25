﻿namespace Bowling2;

class Program
{
    static int TotalRounds = 10;
    static int[][] JechtShotMark3 = new int[TotalRounds][];
    static Random Randowiz = new Random();
    
    static void Main(string[] args)
    {
        PlayBowling();
    }

    static void PlayBowling()
    {
        PlayNormal();
        LastRound();
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
        
        for (int i = 0; i < TotalRounds - 1; i++)
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

    static void LastRound()
    {
        int FinalShot1 = Randowiz.Next(0, TotalRounds);
        
        int FinalShot2 = (FinalShot1 == 10) 
            ? Randowiz.Next(0, TotalRounds) 
            : Randowiz.Next(0, TotalRounds - FinalShot1);
        
        int FinalShot3 = (FinalShot2 == 10) 
            ? Randowiz.Next(0, TotalRounds) 
            : Randowiz.Next(0, TotalRounds - FinalShot1);
        
        JechtShotMark3[9] = new int[3]{FinalShot1, FinalShot2, FinalShot3};
    }
}