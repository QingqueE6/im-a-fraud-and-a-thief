namespace MissionAlphaOmega;

class Program
{
    static int width;
    static int height;
    static char[,] levelMatrix;
    static Tuple<int, int> playerPosition;
    static string fileName = "MazeLevel.txt";
    static string levelName = File.ReadLines("MazeLevel.txt").Take(1).First();
    static int Actions = 0;

    static void Main(string[] args)
    {
        string dimensionInput = File.ReadLines(fileName).Skip(1).Take(1).First();
        var dimensions = GetDimension(dimensionInput);
        levelMatrix = new char[dimensions.Item1, dimensions.Item2];
        levelMatrix = LoadLevel();
        playerPosition = SpawnPlayer();
        
        StartGame();
        PlayGame();
    }
    // =====================================================================================================================

    static void PlayGame()
    {
        while (true)
        {
            var playerInput = Console.ReadKey(true);
            if (playerInput.Key == ConsoleKey.Escape) break;
            int Y = playerPosition.Item1;
            int X= playerPosition.Item2;
            
            switch (playerInput.Key)
            {
                case ConsoleKey.UpArrow:
                    if (levelMatrix[Y-1, X] == ' ' || levelMatrix[Y-1, X] == 'M')
                    {
                        levelMatrix[Y,X] = ' ';
                        playerPosition = new Tuple<int, int>(Y-1, X); 
                    }
                    break;
                case ConsoleKey.DownArrow: 
                    if (levelMatrix[Y+1, X] == ' ' || levelMatrix[Y+1, X] == 'M')
                    {
                        levelMatrix[Y,X] = ' ';
                        playerPosition = new Tuple<int, int>(Y+1, X); 
                    }
                    break;
                case ConsoleKey.LeftArrow: 
                    if (levelMatrix[Y, X-1] == ' ' || levelMatrix[Y, X-1] == 'M')
                    {
                        levelMatrix[Y,X] = ' ';
                        playerPosition = new Tuple<int, int>(Y, X-1); 
                    }
                    break;
                case ConsoleKey.RightArrow: 
                    if (levelMatrix[Y, X+1] == ' ' || levelMatrix[Y, X+1] == 'M')
                    {
                        levelMatrix[Y,X] = ' ';
                        playerPosition = new Tuple<int, int>(Y, X+1); 
                    }
                    break;
            }
            Y = playerPosition.Item1;
            X = playerPosition.Item2;
            Actions++;
            
            if (levelMatrix[Y, X] == ' ')
            {
                levelMatrix[Y, X] = '\u263a';
                PrintLevelWithColors();
            }
            else if (levelMatrix[Y, X] == 'M')
            {
                levelMatrix[Y, X] = '\u263a';
                PrintLevelWithColors();
                Victory();
            }
        }
    }
    
    // =====================================================================================================================

    static void StartGame()
    {
        Console.WriteLine("Welcome to Mission Alpha Omega.");
        Console.WriteLine($"Get Ready for: {levelName}");
        Console.WriteLine("Press any key to continue...");

        Console.ReadKey();
        Console.Clear();
        PrintLevelWithColors();
        // PrintLevel();
    }
    
    // =====================================================================================================================
    
    static void Victory()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("You have reached the Goal!");
        Console.WriteLine($"Amount of Turns: {Actions}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    
    // =====================================================================================================================
    
    static void SpawnTrees()
    {
        Random Rngesus = new Random();

        for (int iy = 0; iy < 2; iy++)
        {
            for (int ix = 0; ix < width; ix++)
            {
                int random = Rngesus.Next(1, 101);
                char IsItATree = (random > 71) ? '\u2660' : ' ';
                levelMatrix[iy, ix] = IsItATree;
            }
        }
    }

    // =====================================================================================================================

    static Tuple<int, int> SpawnPlayer()
    {
        for (int iy = 0; iy < levelMatrix.GetLength(0); iy++)
        {
            for (int ix = 0; ix < levelMatrix.GetLength(1); ix++)
            {
                if (levelMatrix[iy, ix] == 'S')
                {
                    levelMatrix[iy, ix] = '\u263a';
                    return new Tuple<int, int>(iy, ix);
                }
            }
        }

        return new Tuple<int, int>(0, 0);
    }

    // =====================================================================================================================

    static void PrintLevel()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(levelMatrix[i, j]);
            }

            Console.WriteLine();
        }

        PrintLevelDetails();
    }

    // =====================================================================================================================

    static void PrintLevelWithColors()
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char cell = levelMatrix[y, x];
                switch (cell)
                {
                    case '\u263a':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case '\u2660':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'M':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        Console.ResetColor();
                        break;
                }

                Console.Write(cell);
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        PrintLevelDetails();
    }

    // =====================================================================================================================

    static void PrintLevelDetails()
    {
        Console.WriteLine($"Level: {levelName}");
        Console.WriteLine($"Player position: {playerPosition}");
    }

    // =====================================================================================================================

    static char[,] LoadLevel()
    {
        int y = levelMatrix.GetLength(0);
        int x = levelMatrix.GetLength(1);
        var lines = File.ReadLines(fileName).Skip(2);
        int iy = 0;

        foreach (string line in lines)
        {
            if (iy >= y) break;
            char[] charLine = line.ToCharArray();

            for (int ix = 0; ix < x; ix++)
            {
                levelMatrix[iy, ix] = charLine[ix];
            }

            iy++;
        }

        SpawnTrees();
        return levelMatrix;
    }

    // =====================================================================================================================

    static Tuple<int, int> GetDimension(string dimensionInput)
    {
        string[] stringDimensions = dimensionInput.Split('x', 2);
        width = Int32.Parse(stringDimensions[0]);
        height = Int32.Parse(stringDimensions[1]);
        return new Tuple<int, int>(height, width);
    }

    // =====================================================================================================================

    
}