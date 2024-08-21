using System;

namespace Mission2
{
    class MainClass
    {
        static void CallToAction(string[] activeParty)
        {
            string partyMembers = string.Join(", ", activeParty); 
            Console.WriteLine($"Fighters {partyMembers} descend into the dungeon.");
        }

        static int SpawnEnemy(int AmountDice, int ValueDice) 
        {
            var Rng = new Random();
            int TotalHp = 16; 

            for(int i = 0; i < AmountDice; i++)
            {
                TotalHp += Rng.Next(1, ValueDice + 1);
            }
            Console.WriteLine($"A Foe with { TotalHp } Healthpoints appears.");
            return TotalHp;
        }

        static int GreatswordAttack(int AmountDice, int ValueDice)
        {
            var Rng = new Random();
            int TotalDmg = 0;

            for (int i = 0; i < AmountDice; i++)
            {
                TotalDmg += Rng.Next(1, ValueDice + 1);
            }
            return TotalDmg;
        }

        static void InitiateCombat(string[] activeParty, int EnemyHp) 
        {
            var Rng = new Random();

            while (EnemyHp > 0)
                                                {
                for(int i = 0; i < activeParty.Length; i++)
                {
                    int CurrentAttack = GreatswordAttack(2, 6);
                    // Ternary if-else, if HP goes below 0, turn it to 0. Else just keep attacking
                    EnemyHp = (EnemyHp - CurrentAttack < 0) ? 0 : EnemyHp - CurrentAttack;

                    Console.WriteLine($"{ activeParty[i] } hits for {CurrentAttack} Damage! The Foe has {EnemyHp} Healthpoints left.");

                    if(EnemyHp == 0) 
                    {
                        Console.WriteLine("Thy foe has been vanquished.");
                        break; 
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            string[] activeParty = { "Himmel", "Guts", "Musashi", "Himura Kenshin" };

            CallToAction(activeParty);
            int EnemyHp = SpawnEnemy(8, 8);
            InitiateCombat(activeParty, EnemyHp);
        }
    }
}