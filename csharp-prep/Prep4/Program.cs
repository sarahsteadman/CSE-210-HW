using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

        List<float> numbers = new List<float>();
        float answer = 8;
        float sum = 0;
        float amount = -1;
        float largest = -999999999;
        while (answer != 0)
            {
                Console.WriteLine("Enter a number: ");
                string answer_string = Console.ReadLine();
                answer = float.Parse(answer_string);

                numbers.Add(answer);

            }

        foreach (float number in numbers)
            {
                sum = sum + number;
                amount = amount + 1;
                if (number > largest)
                    {
                        largest = number;
                    }
            }

        float average = sum / amount;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}