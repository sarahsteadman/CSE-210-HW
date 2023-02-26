using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> allGoals = new List<Goal>();

        int choice = 0;

        while (choice != 6)
        {
            choice = Menu();

            switch (choice)
            {
                case 1:
                    int goalchoice = GoalMenu();
                    switch (goalchoice)
                    {
                        case 1:
                            Simple simpleGoal = new Simple();
                            break;
                        case 2:
                            Eternal eternalGoal = new Eternal();
                            break;
                        case 3:
                            Checklist checklistGoal = new Checklist();
                            break;
                    }
                    break;
                case 2:
                    Console.Clear();

                    int count = 1;

                    foreach (Goal goal in allGoals)
                    {
                        goal.Display(count);

                        count++;
                    }
                    break;
                case 3:
                    Console.Clear();

                    Console.WriteLine("What would you like to name this save file?");
                    string saveFile = Console.ReadLine();

                    using (StreamWriter outputFile = new StreamWriter(saveFile))
                    {
                        foreach (Goal goal in allGoals)
                        {
                            outputFile.WriteLine(goal.SaveFormat());
                        }

                    }
                    break;
                case 4:
                    Console.WriteLine("What file would you like to open?");
                    string loadFile = Console.ReadLine();
                    string[] lines = System.IO.File.ReadAllLines(loadFile);

                    foreach (string line in lines)
                    {
                        Goal currentEntry = new Goal();
                        string[] parts = line.Split("~");

                        currentEntry._date = parts[0];
                        currentEntry._entryPrompt = parts[1];
                        currentEntry._response = parts[2];

                        _entries.Add(currentEntry);
                    }
                    Display();
                    break;
                case 5:
                    Console.Clear();
                    gInstance.DisplayGrounding();
                    break;
            }
        }
        Console.Clear();
    }

    static int Menu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Create New Goal");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. Quit");
        Console.WriteLine("Select a choice from the menu:");

        int choice = int.Parse(Console.ReadLine());

        return choice;
    }

    static int GoalMenu()
    {
        Console.WriteLine("What type of goal would you like?");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        int choice = int.Parse(Console.ReadLine());

        return choice;
    }
}