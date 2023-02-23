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
        int i = 5;


        while (startTime < futureTime)
        {
            string[] commands = new string[2] { "Breathe in...", "Breathe out..." };

            foreach (string command in commands)
            {
                Console.Write(command);
                while (i > 0)
                {

                    Console.Write(i);
                    Thread.Sleep(1000);
                    Console.Write("\b");
                    i--;
                }

                Console.Write(" ");
                Console.WriteLine("");
                i = 5;
            }
            Console.WriteLine("");
            startTime = DateTime.Now;
        }
        Console.WriteLine("");
        DisplayEnd();

    }
}