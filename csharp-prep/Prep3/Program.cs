using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        Console.WriteLine("Guess a number between 1-100: ");
        string answer_string = Console.ReadLine();
        int answer = int.Parse(answer_string);

        while (answer != number)
        {
            if (answer > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }

            Console.WriteLine("Guess again: ");
            answer_string = Console.ReadLine();
            answer = int.Parse(answer_string);

        }

        Console.WriteLine("You guessed it!");

    }
}