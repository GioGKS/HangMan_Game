using System;
using System.Collections;
using System.Text;
using static System.Random;

Console.WriteLine("Welcome To Hangman Game");
Console.WriteLine("-------------------------");

Random random = new Random();
List<string> wordDictionary = new List<string> { "galaxy", "beach", "country", "diamond", "facebook", "bridge", "machinegun", "youtube", "knowledge" };
int index = random.Next(wordDictionary.Count);
string randomWord = wordDictionary[index];

foreach(char x in randomWord)
{
    Console.Write("_ ");
}

int lengthOfWordtoguess = randomWord.Length;
int amountOftimesWrong = 0;
List<char> currentLettersguessed = new List<char>();
int currentLettersRight = 0;

while(amountOftimesWrong != 6 && currentLettersRight != lengthOfWordtoguess)
{
    Console.Write("\nLetters guessed So Far: ");
    foreach(char letter in currentLettersguessed)
    {
        Console.Write(letter + " ");
    }
    //Get User Input
    Console.Write("\nGuess a Letter: ");
    char letterGuessed = Console.ReadLine()[0];

    //Check If Letter has Already Guessed
    if (currentLettersguessed.Contains(letterGuessed))
    {
        Console.Write("\r\nYou have Alreade guessed this Letter.");
        printHangMan(amountOftimesWrong);
        currentLettersRight = printWord(currentLettersguessed, randomWord);
        printLines(randomWord);
    }
    else
    {
        // check If Letter Is In The World
        bool right = false;
        for (int i = 0; i < randomWord.Length; i++)
        {
            if(letterGuessed == randomWord[i])
            {
                right = true;
            }
        }
        if (right)
        {
            printHangMan(amountOftimesWrong);
            currentLettersguessed.Add(letterGuessed);
            currentLettersRight = printWord(currentLettersguessed, randomWord);
            Console.Write("\r\n");
            printLines(randomWord);
        }
        else
        {
            amountOftimesWrong++;
            currentLettersguessed.Add(letterGuessed);
            printHangMan(amountOftimesWrong);
            currentLettersRight = printWord(currentLettersguessed, randomWord);
            Console.Write("\r\n");
            printLines(randomWord);
        }
    }
}
Console.WriteLine("\r\n Game Is Over! thank you For Playing with Us..");


static void printHangMan(int numb)
{
    if (numb == 0)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");

    }

    else if (numb == 1)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" o  |");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }

    else if (numb == 2)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" o  |");
        Console.WriteLine(" |  |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }

    else if (numb == 3)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" o  |");
        Console.WriteLine("/|  |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }

    else if (numb == 4)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" o    |");
        Console.WriteLine("/|\\   |");
        Console.WriteLine("      |");
        Console.WriteLine("     ===");
    }

    else if (numb == 5)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" o    |");
        Console.WriteLine("/|\\   |");
        Console.WriteLine("/     |");
        Console.WriteLine("     ===");
    }

    else if (numb == 6)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" o    |");
        Console.WriteLine("/|\\   |");
        Console.WriteLine("/ \\   |");
        Console.WriteLine("      ===");
    }
}

static int printWord(List<char> guessedLetters, string randomWord)
{
    int counter = 0;
    int rightLetters = 0;
    Console.WriteLine("\r\n");
    foreach (char ch in randomWord)
    {
        if (guessedLetters.Contains(ch))
        {
            Console.Write(ch + " ");
            rightLetters++;
        }
        else
        {
            Console.Write(" ");
        }
        counter++;
    }
    return rightLetters;
}

static void printLines(string randomWord)
{
    Console.WriteLine("\r");
    foreach (char c in randomWord)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.Write("/u0305");
    }
}
