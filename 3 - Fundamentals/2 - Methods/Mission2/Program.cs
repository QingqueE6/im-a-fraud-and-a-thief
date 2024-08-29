using System;
using System.Collections.Generic;
// https://docs.google.com/document/d/1ccB0ordY0TXg4F1I8UyLNr7ied_h-h4UY6zE4cnR19s/edit
namespace Mission1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> CharacterNames = new List<string> {
                "Jonathan Joestar",
                "Johnny Bravo",
                "John Romero",
                "John Carmack"
            };

            CharacterNames = SimulateCombat(CharacterNames, "Orc", 2, 8, 6, 10); // Orc Encounter
            CharacterNames = SimulateCombat(CharacterNames, "Azer", 6, 8, 12, 18); // Azer Encounter
            CharacterNames = SimulateCombat(CharacterNames, "Troll", 8, 10, 40, 16); // Troll Encounter

            if (CharacterNames.Count != 0)
            {
                Survivors(CharacterNames);
            }

        }

        static List<string> SimulateCombat(List<string> CharacterNames, string MonsterName, int MonsterAmountDice, int MonsterValueDice, int MonsterBonus, int savingThrowDC)
        {
            int MonsterHp = DiceRoll(MonsterAmountDice, MonsterValueDice, MonsterBonus);

            while (MonsterHp > 0 && CharacterNames.Count > 0)
            {
                for (int i = 0; i < CharacterNames.Count; i++)
                {
                    int CurrentAttack = DiceRoll(2, 12); // I made it 2d12 to make sure I reach the final ending
                    // If HP goes below 0, turn it to 0. Else just keep attacking
                    MonsterHp = (MonsterHp - CurrentAttack < 0) ? 0 : MonsterHp - CurrentAttack;

                    Console.WriteLine($"{ CharacterNames[i] } hits for {CurrentAttack} Damage! The Foe has {MonsterHp} Healthpoints left.");

                    if (MonsterHp == 0)
                    {
                        Console.WriteLine("Thy foe has been vanquished.");
                        break;
                    }
                }
                if (MonsterHp > 0)
                {
                    SavingThrow(CharacterNames, savingThrowDC, MonsterName);
                }
            }

            if (CharacterNames.Count == 0)
            {
                GameOverScreen();
                return CharacterNames;
            }
            else
            {
                VictoryScreen();
                return CharacterNames;
            }
        }

        // ====================== smaller methods ======================

        static int DiceRoll(int AmountDice, int ValueDice, int FixedBonus = 0)
        {
            var Rng = new Random();
            int TotalDice = FixedBonus;

            for (int i = 0; i < AmountDice; i++)
            {
                TotalDice += Rng.Next(1, ValueDice + 1);
            }
            return TotalDice;
        }

        static List<string> SavingThrow(List<string> activeParty, int DcCheck, string monsterName)
        {
            if (activeParty.Count == 0)
            {
                return activeParty;
            }
            var Rng = new Random();
            int DcModifier = 3;
            int Save = DiceRoll(1, 20, DcModifier);

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

        // ====================== resultscreens ======================

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

        static void Survivors(List<string> CharacterNames)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Your party has survived. The remaining survivors are:");
            foreach (string Name in CharacterNames) {
                Console.WriteLine(Name);
            }
            Console.WriteLine("======================================");
        }
    }
}


