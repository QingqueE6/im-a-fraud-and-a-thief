string fileName = "MazeLevel.txt";
string levelName = File.ReadLines("MazeLevel.txt").Take(1).First();
string dimensionInput = File.ReadLines("MazeLevel.txt").Skip(1).Take(1).First();
var dimensions = GetDimension(dimensionInput);
char[,] levelMatrix = new char[dimensions.Item1, dimensions.Item2];

levelMatrix = LoadLevel(levelMatrix, fileName);
var playerPosition = SpawnPlayer(levelMatrix);
PrintLevel(levelMatrix);
PrintLevelDetails(levelName, playerPosition);

// =====================================================================================================================

static Tuple<int, int> SpawnPlayer(char[,] levelMatrix)
{
    for (int iy = 0; iy < levelMatrix.GetLength(0); iy++)
    {
        for (int ix = 0; ix < levelMatrix.GetLength(1); ix++)
        {
            if (levelMatrix[iy, ix] == 'S')
            {
                levelMatrix[iy, ix] = 'O';
                return new Tuple<int, int>(iy, ix);
            }
        }
    }
    return new Tuple<int, int>(0, 0);
}

// =====================================================================================================================

static void PrintLevel(char[,] levelMatrix)
{
    int y = levelMatrix.GetLength(0);
    int x = levelMatrix.GetLength(1);

    for (int i = 0; i < y; i++)
    {
        for (int j = 0; j < x; j++)
        {
            Console.Write(levelMatrix[i, j]);
        }
        Console.WriteLine();
    }
}

// =====================================================================================================================

static void PrintLevelDetails(string levelName, Tuple<int, int> playerPosition)
{
    Console.WriteLine($"Level: {levelName}");
    Console.WriteLine($"Player position: {playerPosition}");
}

// =====================================================================================================================

static char[,] LoadLevel(char[,] levelMatrix, string fileName)
{
    int y = levelMatrix.GetLength(0);
    int x = levelMatrix.GetLength(1);
    var lines = File.ReadLines(fileName).Skip(2);
    int iy = 0;
    
    foreach (string line in lines)
    {
        if(iy >= y) break; 
        char[] charLine = line.ToCharArray();
        
        for (int ix = 0; ix < x; ix++)
        {
                levelMatrix[iy, ix] = charLine[ix];
        }
        iy++;
    }
    return levelMatrix; 
}

// =====================================================================================================================

static Tuple<int, int> GetDimension(string dimensionInput)
{
    string[] stringDimensions = dimensionInput.Split('x', 2);
    int dimensionX = Int32.Parse(stringDimensions[0]);
    int dimensionY = Int32.Parse(stringDimensions[1]);
    return new Tuple<int, int>(dimensionY, dimensionX);
}

// =====================================================================================================================




