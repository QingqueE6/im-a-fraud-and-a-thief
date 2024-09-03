using System;
using System.IO;

namespace TestingGrounds
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string ExampleFile = "text.txt";
            string ExampleFile2 = "text2.txt";
            string ExampleString = "Hello World";
            string ExampleString2 = "Goodbye World";

            CreateFile(ExampleFile, ExampleString);
            CreateFile(ExampleFile2, ExampleString2);
            DeleteFile(ExampleFile);

        }

        static void CreateFile(string Filename, string Text)
        {
            // By Default and with MonoDevelop, the file is located in bin/Debug/text.txt
            File.WriteAllText(Filename, Text);
        }

        static void DeleteFile(string Filename)
        {
           // deletes the first thing it can find in bin/Debug if not defined!
            File.Delete(Filename);
        }
    }
}
