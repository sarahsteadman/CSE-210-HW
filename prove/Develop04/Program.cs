using System;

class Program
{
    static void Main(string[] args)
    {
        Breathing bInstance = new Breathing();
        Reflection rInstance = new Reflection();
        Listing lInstance = new Listing();
        int choice = 0;

        while (choice != 4)
        {
            choice = Menu();

            switch (1)
            {
                case 1:
                    bInstance.DisplayBreathing();
                    break;
                case 2:
                    rInstance.DisplayReflection();
                    break;
                case 3:
                    lInstance.DisplayListing();
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
        Console.WriteLine(" 4. Quit");
        Console.WriteLine("Select a choice from the menu:");

        int choice = int.Parse(Console.ReadLine());

        return choice;
    }
    public class Activity
    {
        protected string _activityName;
        protected string _description;
        protected int _durationDesired;

        public void DisplayStart()
        {
            GetReady();
            Console.WriteLine($"Welcome to the {_activityName} Activity.");
            Console.WriteLine();
            Console.WriteLine(_description);
            SetDuration();
        }
        public void SetDuration()
        {
            Console.WriteLine("How long, in seconds, would you like to do this activity for?");
            _durationDesired = int.Parse(Console.ReadLine());

        }
        public void GetReady()
        {
            Console.WriteLine("Get Ready...");
            PauseAnimation(5);
        }
        public void DisplayEnd()
        {
            Console.WriteLine($"You completed another {_durationDesired} seconds of the {_activityName} Activity.");
        }
        public void PauseAnimation(int seconds)
        {

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(seconds);

            DateTime currentTime = DateTime.Now;
            while (currentTime < futureTime)
            {

                Console.Write("|");
                Thread.Sleep(200);
                Console.Write("\b \b");

                Console.Write("\\");
                Thread.Sleep(200);
                Console.Write("\b \b");

                Console.Write("-");
                Thread.Sleep(200);
                Console.Write("\b \b");

                Console.Write("/");
                Thread.Sleep(200);
                Console.Write("\b \b");


                currentTime = DateTime.Now;
            }
        }
    }
    public class Breathing : Activity
    {
        public Breathing()
        {
            _activityName = "Breathing";
            _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }
        public void DisplayBreathing()
        {
            DisplayStart();

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(_durationDesired);
            DateTime currentTime = DateTime.Now;

            while (currentTime < futureTime)
            {
                string[] commands = new string[2] { "Breathe in...", "Breathe out..." };

                foreach (string command in commands)
                {
                    Console.WriteLine(command);
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"\n {i}");
                        Thread.Sleep(1000);
                        Console.Write("\b \b");
                    }
                    Console.WriteLine("");
                }
            }

            DisplayEnd();

        }
    }
    public class Reflection : Activity
    {
        private string[] _promptsReflection = { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
        private string[] _questions = { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };
        public Reflection()
        {
            _activityName = "Reflection";
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }
        public void DisplayReflection()
        {
            DisplayStart();

            var random = new Random();
            string prompt = _promptsReflection[random.Next(0, _promptsReflection.Length)];

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(_durationDesired);
            DateTime currentTime = DateTime.Now;

            while (currentTime < futureTime)
            {
                Console.WriteLine(prompt);
                Console.WriteLine("");
                foreach (string question in _questions)
                {
                    Console.WriteLine(question);
                    Console.WriteLine("");

                    Thread.Sleep(7000);
                }
            }

            DisplayEnd();
        }
    }
    public class Listing : Activity
    {
        string[] _promptsListing = {"Who are people that you appreciate?","What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"
};
        public Listing()
        {
            _activityName = "Listing";
            _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }
        public void DisplayListing()
        {
            DisplayStart();

            var random = new Random();
            string prompt = _promptsListing[random.Next(0, _promptsListing.Length)];

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(_durationDesired);
            DateTime currentTime = DateTime.Now;

            Console.WriteLine(prompt);
            while (currentTime < futureTime)
            {
                Console.ReadLine();
            }

            DisplayEnd();
        }

    }

}