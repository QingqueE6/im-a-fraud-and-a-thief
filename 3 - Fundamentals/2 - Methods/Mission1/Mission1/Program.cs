using System;
using System.Collections.Generic;
// https://docs.google.com/document/d/1ccB0ordY0TXg4F1I8UyLNr7ied_h-h4UY6zE4cnR19s/edit
namespace Mission1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> characterNames = new List<string> {
                "Jonathan Joestar",
                "Johnny Bravo",
                "John Romero",
                "John Carmack"
            };

            characterNames = SimulateCombat(characterNames, "Orc", 15, 10); // Orc Encounter
            characterNames =  SimulateCombat(characterNames, "Azer", 39, 18); // Azer Encounter
            characterNames =  SimulateCombat(characterNames, "Troll", 84, 16); // Troll Encounter

            if (characterNames.Count != 0)
            {
                Survivors(characterNames);
            }

        }

        static List<string> SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
        {
            var Rng = new Random();

            while (monsterHP > 0 && characterNames.Count > 0)
            {
                for (int i = 0; i < characterNames.Count; i++)
                {
                    int CurrentAttack = WeaponAttack(5, 100);
                    // Ternary if-else, if HP goes below 0, turn it to 0. Else just keep attacking
                    monsterHP = (monsterHP - CurrentAttack < 0) ? 0 : monsterHP - CurrentAttack;

                    Console.WriteLine($"{ characterNames[i] } hits for {CurrentAttack} Damage! The Foe has {monsterHP} Healthpoints left.");

                    if (monsterHP == 0)
                    {
                        Console.WriteLine("Thy foe has been vanquished.");
                        break;
                    }
                }
                if (monsterHP > 0)
                {
                    SavingThrow(characterNames, savingThrowDC, monsterName);
                }
            }

            if (characterNames.Count == 0)
            {
                GameOverScreen();
                return characterNames;
            }
            else
            {
                VictoryScreen();
                return characterNames;
            }
        }

        static List<string> SavingThrow(List<string> activeParty, int DcCheck, string monsterName)
        {
            if (activeParty.Count == 0)
            {
                return activeParty;
            }
            var Rng = new Random();
            int DcModifier = 3;
            int Save = Rng.Next(1, 21) + DcModifier;
            int UpperLimit = activeParty.Count;
            int EnemyTarget = (UpperLimit == 1) ? 0 : Rng.Next(0, UpperLimit);
            Console.WriteLine($"The {monsterName} prepares its attack on {activeParty[EnemyTarget]}... {activeParty[EnemyTarget]} rolled a {Save}.");

            if (Save < DcCheck)
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

        static void Survivors(List<string> characterNames)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Your party has survived. The remaining survivors are:");
            foreach (string Name in characterNames) {
                Console.WriteLine(Name);
            }
            Console.WriteLine("======================================");
        }
    }
}


