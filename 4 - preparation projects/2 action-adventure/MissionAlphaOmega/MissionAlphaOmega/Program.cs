namespace MissionAlphaOmega;

class Program
{
    static int width;
    static int height;
    static char[,] levelMatrix;
    static Tuple<int, int> playerPosition;
    static string fileName = "MazeLevel.txt";
    static string levelName = File.ReadLines("MazeLevel.txt").Take(1).First();

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
                
                switch (playerInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (levelMatrix[playerPosition.Item1 -1, playerPosition.Item2] == ' ')
                        {
                            levelMatrix[playerPosition.Item1, playerPosition.Item2] = ' ';
                            playerPosition = new Tuple<int, int>(playerPosition.Item1 - 1, playerPosition.Item2); 
                        }
                        break;
                    case ConsoleKey.DownArrow: 
                        if (levelMatrix[playerPosition.Item1 + 1, playerPosition.Item2] == ' ')
                        {
                            levelMatrix[playerPosition.Item1, playerPosition.Item2] = ' ';
                            playerPosition = new Tuple<int, int>(playerPosition.Item1 + 1, playerPosition.Item2); 
                        }
                        break;
                    case ConsoleKey.LeftArrow: 
                        if (levelMatrix[playerPosition.Item1, playerPosition.Item2 - 1] == ' ')
                        {
                            levelMatrix[playerPosition.Item1, playerPosition.Item2] = ' ';
                            playerPosition = new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 - 1); 
                        }
                        break;
                    case ConsoleKey.RightArrow: 
                        if (levelMatrix[playerPosition.Item1, playerPosition.Item2 + 1] == ' ')
                        {
                            levelMatrix[playerPosition.Item1, playerPosition.Item2] = ' ';
                            playerPosition = new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 + 1); 
                            
                        }
                        break;
                }
                levelMatrix[playerPosition.Item1, playerPosition.Item2] = '\u263a';
                PrintLevelWithColors();
            }

        }
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