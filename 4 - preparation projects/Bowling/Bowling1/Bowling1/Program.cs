namespace Bowling1;

class Program
{        
    public static string[] EmptyScoreBoard =
    {
        "+-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+", 
        "| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |",
        "| ----| ----| ----| ----| ----| ----| ----| ----| ----| ----|",
        "|     |     |     |     |     |     |     |     |     |     |",
        "+-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+"
    };

    public static string[] ScoreBoard;
    
    static void Main(string[] args)
    {
        int Frames = 6;
        PlayBowling(Frames); 
    }
    
    // =======  M == E == T == H == O == D == S =======
    
    static void DisplayScore(int CurrentFrames)
    {
        if (CurrentFrames <= 0) CurrentFrames = 1;
        int MaxLimit = (CurrentFrames * 6) + 1;
        
        Console.WriteLine("Scoreboard:");
        foreach (string line in ScoreBoard)
        {
            Console.WriteLine(line.Substring(0, MaxLimit));
        }
    }

    static (char Throw1, char Throw2) RollPins()
    {
        Random BirdJesus = new Random();
        int MaxLimit = 10;
        int FirstThrow = 0;
        int SecondThrow = 0;
        
        FirstThrow = BirdJesus.Next(0, MaxLimit + 1);
        
        if (FirstThrow != MaxLimit)
        {
            MaxLimit = MaxLimit - FirstThrow;
            SecondThrow = BirdJesus.Next(0, MaxLimit + 1);
        }
        
        (char Throw1, char Throw2) = ResultChars(FirstThrow, SecondThrow);
        return (Throw1, Throw2);
    }

    // Only used inside RollPins to make the results to chars, to fit the string array scoreboard 
    static (char Throw1, char Throw2) ResultChars(int FirstThrow, int SecondThrow)
    {       
        char FirstThrowChar;
        char SecondThrowChar;

        if (FirstThrow == 10)
        {
            FirstThrowChar = 'X';
            SecondThrowChar = ' ';
        }
        else if (FirstThrow + SecondThrow == 10)
        {
            FirstThrowChar = (char)(FirstThrow + '0');
            SecondThrowChar = '/';
        }
        else
        {
            FirstThrowChar = (char)(FirstThrow + '0');
            SecondThrowChar = (char)(SecondThrow + '0');
            if (FirstThrowChar == '0') FirstThrowChar = '-';
            if (SecondThrowChar == '0') SecondThrowChar = '-';
        }
        return (FirstThrowChar, SecondThrowChar);
    }

    static void PlayBowling(int Frames)
    {
        ScoreBoard = EmptyScoreBoard;
        for (int i = 1; i <= Frames; i++)
        {
            (char Throw1, char Throw2) = RollPins();
            int Throw2Pos = (i * 6) - 1;
            int Throw1Pos = Throw2Pos - 2;
            char[] charArray = ScoreBoard[1].ToCharArray();
            charArray[Throw1Pos] = Throw1;
            charArray[Throw2Pos] = Throw2;
            ScoreBoard[1] = new string(charArray);
        }
        
        DisplayScore(Frames);
    }
}