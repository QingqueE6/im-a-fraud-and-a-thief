// See https://aka.ms/new-console-template for more information
while (true) // while loop for continuous checking
{
    Console.WriteLine("Set a new price. You can: \n- Put in a new number\n- Make calculations and set the result of that as a price");
    int Price = NewPrice(); 
    Console.WriteLine($"The new price is {Price}");
}

static int NewPrice()
{
    int FirstValue = 0;
    int SecondValue = 0;
    int Price = 0;
    string Operand;
    
    string MrPoopyButtholesCleverInput = Console.ReadLine(); 
    string[] MrPoopyButtholesCleverInputs = MrPoopyButtholesCleverInput.Split(' ');

    if (MrPoopyButtholesCleverInputs.Length == 3)
    {
        int InputIntoInt = Int32.Parse(MrPoopyButtholesCleverInputs[0]);
        FirstValue = InputIntoInt;
        int InputIntoIntAgain = Int32.Parse(MrPoopyButtholesCleverInputs[2]);
        SecondValue = InputIntoIntAgain;
        Operand = MrPoopyButtholesCleverInputs[1];
        Price = JesseWeNeedToDoSomeMath(FirstValue, SecondValue, Operand);
    }
    else if (MrPoopyButtholesCleverInputs.Length == 4)
    {
        int InputIntoInt = Int32.Parse(MrPoopyButtholesCleverInputs[0]);
        FirstValue = InputIntoInt;
        int InputIntoIntAgain = Int32.Parse(MrPoopyButtholesCleverInputs[3]);
        SecondValue = InputIntoIntAgain;
        Operand = MrPoopyButtholesCleverInputs[1];
        Price = JesseWeNeedToDoSomeMath(FirstValue, SecondValue, Operand);
    }
    else if (MrPoopyButtholesCleverInputs.Length == 1)
    {        
        int InputIntoInt = Int32.Parse(MrPoopyButtholesCleverInputs[0]);
        FirstValue = InputIntoInt;
        Price = FirstValue;
    }
    return Price;
}

static int JesseWeNeedToDoSomeMath(int Value1, int Value2, string Operand)
{
    int Result = 0;
    switch (Operand)
    {
        case "+":
            Result = Value1 + Value2;
            break;
        case "plus":
            goto case "+";
        case "-":
            Result = Value1 - Value2;
            break;
        case "minus":
            goto case "-";
        case "*":
            Result = Value1 * Value2;
            break;
        case "x":
            goto case "*";
        case "times":
            goto case "*";
        case "/":
            Result = Value1 / Value2;
            break;
        case "divided":
            goto case "/";
    }
    return Result;
}



