using System;
using System.IO;

namespace Mission1
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            string TravellerName = null;
            string FileName = "player-name.txt";

            if (File.Exists(FileName))
            {
                TravellerName = File.ReadAllText("player-name.txt");
            }
            if (!string.IsNullOrEmpty(TravellerName))
            {
                WelcomeReturningPlayer(TravellerName);
            }
            else
            {
                WelcomeNewPlayer(FileName);

            }
        }

        static void CreateFile(string Filename, string Text)
        {
            // By Default and with MonoDevelop, the file is located in bin/Debug/text.txt
            File.WriteAllText(Filename, Text);
        }

        static void WelcomeNewPlayer(string FileName)
        {
            Console.WriteLine("Welcome to your biggest adventure yet!");
            Console.WriteLine("What is your name, traveler?");
            string TravellerName = Console.ReadLine();

            Console.WriteLine($"Nice to meet you, {TravellerName}!");
            CreateFile(FileName, TravellerName);
        }

        static void WelcomeReturningPlayer(string TravellerName)
        {
            Console.WriteLine($"Welcome back, {TravellerName}, let's continue!");
        }

        static void DeleteFile(string Filename)
        {
            // deletes the first thing it can find in bin/Debug if not defined!
            File.Delete(Filename); 
        }       
    }
}

