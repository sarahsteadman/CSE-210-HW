using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> allGoals = new List<Goal>();
        int totalPoints = 0;

        int choice = 0;

        while (choice != 7)
        {
            choice = Menu(totalPoints);

            switch (choice)
            {
                // Create new goal
                case 1:

                    Console.WriteLine("");
                    int goalchoice = GoalMenu();
                    Console.WriteLine("");

                    Goal goal = new Goal();

                    switch (goalchoice)
                    {
                        case 1:
                            goal = new Eternal();
                            break;
                        case 2:
                            goal = new Simple();
                            break;
                        case 3:
                            goal = new Checklist();
                            break;
                    }

                    goal.SetProperties();
                    allGoals.Add(goal);

                    Console.WriteLine();
                    Console.WriteLine("Goal Added");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    break;

                // Display Goals
                case 2:
                    Console.WriteLine("");
                    DisplayList(allGoals);

                    Console.WriteLine("Press enter to bring up  the menu.");
                    Console.ReadLine();
                    break;

                // Save Goals
                case 3:

                    Console.WriteLine("");
                    Console.WriteLine("What would you like to name this save file?");
                    string saveFile = Console.ReadLine();

                    using (StreamWriter outputFile = new StreamWriter(saveFile))
                    {
                        foreach (Goal goalByAnotherName in allGoals)
                        {
                            outputFile.WriteLine(goalByAnotherName.SaveFormat());
                        }

                    }

                    Console.WriteLine();
                    Console.WriteLine("Goals Saved");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    break;

                // Load Goals
                case 4:

                    (allGoals, totalPoints) = LoadGoals();
                    DisplayList(allGoals);

                    Thread.Sleep(1000);
                    break;

                // Complete a goal
                case 5:

                    Console.WriteLine();
                    DisplayList(allGoals);
                    Console.WriteLine();
                    Console.WriteLine("Which Goal did you accomplish?");

                    int completed = int.Parse(Console.ReadLine()) - 1;

                    int newPoints = allGoals[completed].RecordEvent();
                    totalPoints += newPoints;

                    Thread.Sleep(1000);

                    break;

                // Add a premade goal
                case 6:

                    Console.Clear();
                    string fish = "fry";
                    while (fish == "fry")
                    {
                        int selection = 0;
                        string answer = reccomendedGoals();
                        bool isNumber = int.TryParse(answer, out selection);
                        selection -= 1;
                        
                        if (isNumber)
                        {
                            Goal newGoal = makeRecGoal(selection);
                            allGoals.Add(newGoal);
                            Console.WriteLine($"Goal Added");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        else
                        { 
                            Console.Clear();
                            break; 
                            }
                    }
                    break;

            }
        }
        Console.Clear();
    }

    static int Menu(int points)
    {
        Console.WriteLine("");
        Console.WriteLine($"Points: {points}");
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Create New Goal");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. View Reccomended Goals");
        Console.WriteLine(" 7. Quit");
        Console.WriteLine("Select a choice from the menu:");

        int choice = int.Parse(Console.ReadLine());

        return choice;
    }

    static int GoalMenu()
    {

        Console.WriteLine("What type of goal would you like?");
        Console.WriteLine(" 1. Eternal Goal");
        Console.WriteLine(" 2. Simple Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.WriteLine("");

        int choice = int.Parse(Console.ReadLine());

        return choice;
    }

    static void DisplayList(List<Goal> allGoals)
    {
        Console.Clear();

        int count = 1;

        foreach (Goal goal in allGoals)
        {
            goal.Display(count);

            count++;
        }
    }

    static (List<Goal>, int) LoadGoals()
    {
        List<Goal> allGoals = new List<Goal>();
        int points = 0;

        Console.WriteLine("What file would you like to open?");
        string loadFile = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(loadFile);

        foreach (string line in lines)
        {
            Goal currentEntry = createGoal(line);

            if (currentEntry.GetCompleted() == "X")
            {
                points += currentEntry.GetPoints();
            }

            allGoals.Add(currentEntry);
        }

        return (allGoals, points);
    }

    static Goal createGoal(string line)
    {
        string[] parts = line.Split("~");

        int type = int.Parse(parts[0]);
        Goal currentEntry = new Goal();

        switch (type)
        {
            case 1:
                currentEntry = new Eternal();
                break;
            case 2:
                currentEntry = new Simple();
                break;
            case 3:
                currentEntry = new Checklist();
                break;

        }

        currentEntry.AssignLoad(parts);

        return currentEntry;
    }

    static string reccomendedGoals()
    {

        Console.WriteLine("Spiritual Goals:");
        Console.WriteLine("1. Read the Book of Mormon everyday for a week");
        Console.WriteLine("2. Attend the temple");
        Console.WriteLine("3. Say gratitude prayers");
        Console.WriteLine("");
        Console.WriteLine("Health Goals:");
        Console.WriteLine("4. Excercise 3 times");
        Console.WriteLine("5. Eat a salad");
        Console.WriteLine("6. Meditate");
        Console.WriteLine("");
        Console.WriteLine("Household Goals");
        Console.WriteLine("");
        Console.WriteLine("7. Clean 3 rooms in the house");
        Console.WriteLine("8. Do the laundry");
        Console.WriteLine("9. Keep the house vacuumed");
        Console.WriteLine("");
        Console.WriteLine("Select a number from above to add it to your goal list.");
        Console.WriteLine("Enter 'quit' when you're done selcting goals.");
        Console.WriteLine("");
        return Console.ReadLine();
    }

    static Goal makeRecGoal(int selection)
    {
        string[] recGoals = {
                "3~0~Read the Book of Mormon everyday for a week~Read at least a verse in the Book of Mormon on 7 seperate days~50~7~200",
                "2~ ~Attend the Temple~Preform any ordinence in the temple~200",
                "1~0~Say gratitude prayers~When you pray, say a prayer in which you only thank God without asking Him for anything.~45",
                "3~0~Exercise 3 times~Do any kind of exercise on 3 seperate occasions~100~3~200",
                "2~ ~Eat a Salad~Eat a healthy salad~100",
                "1~0~Meditate~Sit for at least 5 minutes and focus on your breathing~45",
                "3~0~Clean 3 rooms in your house~Pick 3 rooms in your house and check off each one after you clean it.~100~3~200",
                "2~ ~Do the Laundry~Wash, fold, and put away the laundry~400",
                "1~0~Keep the house vacuumed~Each time you vacuum the house, check this off~75"
            };

        Goal newGoal = createGoal(recGoals[selection]);
        return newGoal;
    }
}

