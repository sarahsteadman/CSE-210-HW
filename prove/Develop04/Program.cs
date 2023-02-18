using System;

class Program
{
    static void Main(string[] args)
    {
        Breathing bInstance = new Breathing();
        Reflection rInstance = new Reflection();
        Listing lInstance = new Listing();
        Grounding gInstance = new Grounding();
        int choice = 0;

        while (choice != 5)
        {
            choice = Menu();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    bInstance.DisplayBreathing();
                    break;
                case 2:
                    Console.Clear();
                    rInstance.DisplayReflection();
                    break;
                case 3:
                    Console.Clear();
                    lInstance.DisplayListing();
                    break;
                case 4:
                    Console.Clear();
                    gInstance.DisplayGrounding();
                    break;
            }
        }
    }

    static int Menu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Start Breathing Activity");
        Console.WriteLine(" 2. Start Reflecting Activity");
        Console.WriteLine(" 3. Start Listing Activity");
        Console.WriteLine(" 4. Start Grounding Activity");
        Console.WriteLine(" 5. Quit");
        Console.WriteLine("Select a choice from the menu:");

        int choice = int.Parse(Console.ReadLine());

        return choice;
    }
}