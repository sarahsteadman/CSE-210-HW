using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is our grade percentage?");
        string stringGrade = Console.ReadLine();
        int intGrade = int.Parse(stringGrade);

        string letter = "A monkey's butt!";

        if (intGrade >= 90)
        {
             letter = "A";
        }
        else if (intGrade >= 80)
        {
             letter = "B";
        }else if (intGrade >= 70)
        {
             letter = "C";
        }else if (intGrade >= 60)
        {
             letter = "D";
        }else
        {
             letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (intGrade > 70)
        {
            Console.WriteLine("You passed! Hooray!");
        }
        else 
        {
            Console.WriteLine("You did not pass this course. Please retake it.");
        }
    }
}