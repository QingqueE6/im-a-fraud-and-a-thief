// See https://aka.ms/new-console-template for more information, .NET6.0
// https://docs.google.com/document/d/1qf61PNCAHMNSIjLPgtNrMANnvBKPb6tjiuUd3iylnk4/edit
Random rng = new Random();
int TankDistance = rng.Next(39, 71);
string BattlefieldStation = "_/";
string Battlefield = "________________________________________________________________________________";

Console.WriteLine("Enter your username: ");
string UserName = Console.ReadLine();

while(TankDistance > 0){
    Console.Clear();
    string currentBattlefield = Battlefield.Remove(TankDistance, 1).Insert(TankDistance, "T");
    Console.WriteLine("Heres a map of the current situation:\n" + BattlefieldStation + currentBattlefield);
    Console.WriteLine("Ready your shot, " + UserName + "! 1 is the closest you can go and");
    int PlayerDistance = Convert.ToInt32(Console.ReadLine()) - 1;

    if(PlayerDistance < TankDistance || PlayerDistance > TankDistance){
        string DynamicReply = (PlayerDistance < TankDistance) ? "Bit too short!" : "Bit too far!";

        TankDistance = MoveTank(TankDistance);
        string PlayerDestination = currentBattlefield.Remove(PlayerDistance, 1).Insert(PlayerDistance, "*");
        Console.WriteLine(BattlefieldStation + PlayerDestination);

        Console.WriteLine(DynamicReply + "\nPress to continue");
        Console.ReadKey();
    }

    else if(PlayerDistance == TankDistance){
        string PlayerDestination = currentBattlefield.Remove(TankDistance, 1).Insert(TankDistance, "*");
        Console.WriteLine(BattlefieldStation + PlayerDestination + "\nBullseye!\nPress to continue");
        Console.ReadKey();
        break;
    }
}

Action resultAction = (TankDistance <= 0) 
    ? new Action(GameOverScreen) 
    : new Action(VictoryScreen);

resultAction();

// Functions
static void GameOverScreen(){
    Console.Clear();
    Console.WriteLine("======================================================================\nYou absolute waste of air and energy, you screwed it.\nNow the tank is rolling in, killing the poor folk of your hometown.\nI hope you rot in hell, you disgusting pig.\nI despise you.\nI hate you.\n======================================================================");  
}

static void VictoryScreen(){
    Console.Clear();
    Console.WriteLine("======================================================================\nYou bested the approaching tank, you felled the enemy.\nPeople are cheering, your comrades finally feel at ease.\nBut at what cost? Your so-called enemy had hopes and dreams too.\nAre you happy with your choices?\n======================================================================");  
}

static int MoveTank(int TankDistance){
    Random rng = new Random();
    int RandomStepsForward = rng.Next(1, 16);
    int NewTankDistance = TankDistance - RandomStepsForward;
    return NewTankDistance;
}
