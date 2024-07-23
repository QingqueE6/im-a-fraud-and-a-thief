// See https://aka.ms/new-console-template for more information, .NET6.0
// https://docs.google.com/document/d/1qf61PNCAHMNSIjLPgtNrMANnvBKPb6tjiuUd3iylnk4/edit
Random rng = new Random();
int TankDistance = rng.Next(39, 71);
string BattlefieldStation = "_/";
string Battlefield = "________________________________________________________________________________";
int AmountTrys = 5;

    Console.WriteLine("Enter your username: ");
    string UserName = Console.ReadLine();
    Console.WriteLine("Greetings " + UserName + ", its time to hunt some tanks and shoot some loads with the boys™!");

    string currentBattlefield = Battlefield.Remove(TankDistance, 1).Insert(TankDistance, "T");
    Console.WriteLine(BattlefieldStation + currentBattlefield);
    Console.WriteLine("Heres a map of the current situation, ");
    
for (int i = AmountTrys; i > 0 ; i--){
    Console.WriteLine("Aim your shot, " + UserName + ". You have " + i + " bullet(s) left.");
    int PlayerDistance = Convert.ToInt32(Console.ReadLine());

    if(PlayerDistance < TankDistance){
        string PlayerDestination = currentBattlefield.Remove(PlayerDistance, 1).Insert(PlayerDistance, "*");
        Console.WriteLine(BattlefieldStation + PlayerDestination);
        Console.WriteLine("Just too short!");
        GameOver(i, AmountTrys);
    }
    else if(PlayerDistance > TankDistance){
        string PlayerDestination = currentBattlefield.Remove(PlayerDistance, 1).Insert(PlayerDistance, "*");
        Console.WriteLine(BattlefieldStation + PlayerDestination);
        Console.WriteLine("Bit too far!");
        GameOver(i, AmountTrys);
    }
    else if(PlayerDistance == TankDistance){
        string PlayerDestination = currentBattlefield.Remove(TankDistance, 1).Insert(TankDistance, "*");
        Console.WriteLine(BattlefieldStation + PlayerDestination);
        Console.WriteLine("Bullseye!");   
    }

}

static void GameOver(int j, int TotalTrys){
    if(j <= 1){
        Console.WriteLine("You absolute waste of air and energy, you fumbled not just once but " + TotalTrys + " times. Get a fucking grip, you piece of shit.\nNow the tank is rolling in, killing the poor folk of your hometown. I hope you rot in hell, you disgusting pig.\nI hate you. \nI despise you.");  
    }
}
