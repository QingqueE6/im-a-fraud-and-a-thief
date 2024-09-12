// Skip(2), first 2 lines are levelname and dimension inputs
// !!! CHECK LINE 59 !!!
string fileName = "MazeLevel.txt";
string levelName = File.ReadLines("MazeLevel.txt").Take(1).First();
string dimensionInput = File.ReadLines("MazeLevel.txt").Skip(1).Take(1).First();
var Dimensions = GetDimension(dimensionInput);
string[,] levelMatrix = new string[Dimensions.Item1, Dimensions.Item2];

levelMatrix = LoadLevel(levelMatrix, fileName);
var PlayerPosition = SpawnPlayer(levelMatrix);
PrintMatrix(levelMatrix);
Console.WriteLine($"Player position: {PlayerPosition}");

static Tuple<int, int> SpawnPlayer(string[,] levelMatrix)
{
    for (int iy = 0; iy < levelMatrix.GetLength(0); iy++)
    {
        for (int ix = 0; ix < levelMatrix.GetLength(1); ix++)
        {
            if (levelMatrix[iy, ix] == "S")
            {
                levelMatrix[iy, ix] = "O";
                return new Tuple<int, int>(iy, ix);
            }
        }
    }
    return new Tuple<int, int>(0, 0);
}

static void PrintMatrix(string[,] levelMatrix)
{
    int Y = levelMatrix.GetLength(0);
    int X = levelMatrix.GetLength(1);

    for (int i = 0; i < Y; i++)
    {
        for (int j = 0; j < X; j++)
        {
            Console.Write(levelMatrix[i, j]);
        }
        Console.WriteLine();
    }
}

static string[,] LoadLevel(string[,] levelMatrix, string fileName)
{
    int Y = levelMatrix.GetLength(0);
    int X = levelMatrix.GetLength(1);
    var Lines = File.ReadLines(fileName).Skip(4);
    int iy = 0;
    
    foreach (string Line in Lines)
    {
        if(iy >= Y) break; 

        for (int ix = 0; ix < X; ix++)
        {       // the .ToString being mandatory here might be a good call to make the string levelmatrix a char levelmatrix!
                levelMatrix[iy, ix] = Line[ix].ToString();
        }
        iy++;
    }
    return levelMatrix; 
}

static Tuple<int, int> GetDimension(string dimensionInput)
{
    string[] stringDimensions = dimensionInput.Split('x', 2);
    int DimensionX = Int32.Parse(stringDimensions[0]);
    int DimensionY = Int32.Parse(stringDimensions[1]);
    return new Tuple<int, int>(DimensionY, DimensionX);
}




