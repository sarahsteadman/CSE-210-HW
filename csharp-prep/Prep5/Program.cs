using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        float number = PromptUserNumber();
        float square = SquareNumber(number);
        DisplayResult(square, name);

    }
    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }
    static string PromptUserName()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
    static float PromptUserNumber()
        {
            Console.WriteLine("Please enter your favorite number: ");
            string stringsAreStupid = Console.ReadLine();
            float number = float.Parse(stringsAreStupid);
            return number;
        }
    static float SquareNumber(float number)
        {
            float square = number * number;
            return square;
        }
    static void DisplayResult(float square, string name)
        {
            Console.WriteLine($"{name}, the square of your number is {square}");
        }
    }