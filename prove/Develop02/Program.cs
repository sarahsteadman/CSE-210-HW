using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal currentJournal = new Journal();
        string choice = "What is the point of a Do loop if I can't define a variable inside of it? It's a glorified while loop!";
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("");

        do
        {
            Menu();
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry currentEntry = NewEntry();
                currentJournal._entries.Add(currentEntry);
            }
            else if (choice == "2")
            {
                currentJournal.Display();
            }
            else if (choice == "3")
            {
                currentJournal = new Journal();
                Console.WriteLine("What is the name of the file you would like to Load?");
                currentJournal._name = Console.ReadLine();
                currentJournal.Load();
            }
            else if (choice == "4")
            {
                currentJournal.Save();
            }
            else if (choice != "5")
            {
                Console.WriteLine("Please select an option from the menu!");
            }
        }
        while (choice != "5");
    }
    static void Menu()
    {
        Console.WriteLine("");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine("");
    }
    static Entry NewEntry()
    {
        Entry currentEntry = new Entry();
        DateTime date = DateTime.Today;
        currentEntry._date = date.ToShortDateString();

        Console.WriteLine("Would you like a prompt?(Y/N)");
        string promptQuestion = Console.ReadLine();

        if (promptQuestion.ToLower() == "y")
        {
            currentEntry._entryPrompt = GenoratePrompt();
            Console.WriteLine($"{currentEntry._entryPrompt}");
            Console.WriteLine("");
        }
        else if (promptQuestion.ToLower() == "n")
        {
            currentEntry._entryPrompt = "Free Response";
            Console.WriteLine($"Write below!");
            Console.WriteLine("");
        }

        currentEntry._response = Console.ReadLine();

        return currentEntry;
    }
    static string GenoratePrompt()
    {
        List<string> prompts = new List<string>()
                {
                    "Who was the most interesting person I interacted with today?",
                    "What was the best part of my day?",
                    "How did I see the hand of the Lord in my life today?",
                    "What was the strongest emotion I felt today?",
                    "If I had one thing I could do over today, what would it be?",
                    "What am I feeling right now?",
                    "What am I looking forward to?",
                    "What are some things I am grateful for?",
                    "Who has shown me kindness today?",
                    "Who or what impacted me the most today?"
                };

        var random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
    public class Journal
    {
        public string _name;
        public List<Entry> _entries = new List<Entry>();

        public void Display()
        {
            Console.WriteLine("");
            Console.WriteLine($"{_name}");
            foreach (Entry i in _entries)
            {
                Console.WriteLine($"{i._date} {i._entryPrompt} {i._response}");
            }
        }

        public void Save()
        {
            Console.WriteLine("What would you like to name this Journal?");
            _name = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(_name))
            {
                foreach (Entry i in _entries)
                {
                    outputFile.WriteLine($"{i._date}~{i._entryPrompt}~{i._response}");
                }

            }
        }
        public void Load()
        {
            string[] lines = System.IO.File.ReadAllLines(_name);

            foreach (string line in lines)
            {
                Entry currentEntry = new Entry();
                string[] parts = line.Split("~");

                currentEntry._date = parts[0];
                currentEntry._entryPrompt = parts[1];
                currentEntry._response = parts[2];

                _entries.Add(currentEntry);
            }
            Display();

        }

    }
    public class Entry
    {
        public string _response;
        public string _entryPrompt;
        public string _date;
    }

}