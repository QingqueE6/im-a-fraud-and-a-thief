using System;
using System.Collections.Generic;
namespace Mission2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> activeParty = new List<string> { "Himmel", "Guts", "Musashi", "Himura Kenshin" };

            CallToAction(activeParty);
            int EnemyHp = SpawnEnemy(8, 8);
            InitiateCombat(activeParty, EnemyHp);
        }

        // ================= Method List =================

        static void CallToAction(List<string> activeParty)
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

        static List<string> PetrifyBasilisk(List<string> activeParty)
        {
            if (activeParty.Count == 0)
            {
                return activeParty;
            }
            var Rng = new Random();
            int ConstitutionModifier = 3;
            int ConstitutionSave = Rng.Next(1, 21) + ConstitutionModifier;
            int UpperLimit = activeParty.Count;
            int EnemyTarget = (UpperLimit == 1) ? 0 : Rng.Next(0, UpperLimit);
            Console.WriteLine($"The basilisk prepares its gaze-attack to attack {activeParty[EnemyTarget]}... {activeParty[EnemyTarget]} rolled a {ConstitutionSave}.");

            if (ConstitutionSave < 12)
            {
                Console.WriteLine($"{activeParty[EnemyTarget]} got petrified!");
                activeParty.RemoveAt(EnemyTarget);
            }
            else
            {
                Console.WriteLine($"{activeParty[EnemyTarget]} dodged the attack!");
            }
            return activeParty;
        }

        static int WeaponAttack(int AmountDice, int ValueDice)
        {
            var Rng = new Random();
            int TotalDmg = 0;

            for (int i = 0; i < AmountDice; i++)
            {
                TotalDmg += Rng.Next(1, ValueDice + 1);
            }
            return TotalDmg;
        }

        static void GameOverScreen()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("You didnt vanquish the big bad evil! Yippie");
            Console.WriteLine("======================================");
        }

        static void VictoryScreen()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("You vanquished the big bad evil! Yippie");
            Console.WriteLine("======================================");
        }

        static void InitiateCombat(List<string> activeParty, int EnemyHp) 
        {
            var Rng = new Random();

            while (EnemyHp > 0 && activeParty.Count > 0)
            {
                for(int i = 0; i < activeParty.Count; i++)
                {
                    int CurrentAttack = WeaponAttack(1, 4);
                    // Ternary if-else, if HP goes below 0, turn it to 0. Else just keep attacking
                    EnemyHp = (EnemyHp - CurrentAttack < 0) ? 0 : EnemyHp - CurrentAttack;

                    Console.WriteLine($"{ activeParty[i] } hits for {CurrentAttack} Damage! The Foe has {EnemyHp} Healthpoints left.");

                    if(EnemyHp == 0) 
                    {
                        Console.WriteLine("Thy foe has been vanquished.");
                        break; 
                    }
                }
                if (EnemyHp > 0)
                {
                    PetrifyBasilisk(activeParty);
                }
            }

            if(activeParty.Count >= 0)
            {
                GameOverScreen();
            }
            else
            {
                VictoryScreen();
            }
        }


    }
}