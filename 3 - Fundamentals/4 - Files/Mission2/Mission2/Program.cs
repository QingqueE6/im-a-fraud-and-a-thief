// See https://aka.ms/new-console-template for more information
string TravellerName = null;
string FileName = "player-name.txt";
string BackerFileName = "backers.txt";

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

BackerCheck(BackerFileName, TravellerName);

    static void CreateFile(string Filename, string Text)
    {
        // By Default and with MonoDevelop, the file is located in bin/Debug/text.txt
        // Same in Rider basically, bin/Debug/Net8.0/text.txt
        File.WriteAllText(Filename, Text);
    }

    static void BackerCheck(string BackerFileName, string NameToCheck)
    {
        bool IsBacker = false;
        string[] Backers = File.ReadAllLines(BackerFileName);
        foreach (string Backer in Backers)
        {    
           if (Backer == NameToCheck)
           {
               Console.WriteLine("You successfully enter Dr. Fred's secret laboratory and are greeted with a warm welcome for backing the game's Kickstarter!");
               IsBacker = true;
               break;
           } 
        }
        if (!IsBacker)
        {
            Console.WriteLine("Unfortunately I cannot let you into Dr. Fred's secret laboratory.");
        }
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
        // deletes the first thing it can find in bin/Debug (or bin/debug/net8.0/) if not defined!
        File.Delete(Filename); 
    }       
