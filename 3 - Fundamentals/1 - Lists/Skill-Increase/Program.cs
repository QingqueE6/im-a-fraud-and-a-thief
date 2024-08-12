using System;
using System.Collections.Generic;

namespace SkillIncrease
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> Names = new List<string> {"Marc", "Jeremy Fragrance", "Seele", "Bakool Ja Ja's Left Nut (Fabio)"};
            Names.Add("Bill");
            Names.Remove("Seele");

            foreach (var Name in Names)
            {
                Console.WriteLine(Name);
            }
            Console.WriteLine($"Powerlevel Tierlist:\n{Names[0]}\n{Names[2]}\n{Names[3]}\n{Names[1]}\n");

        }
    }
}
