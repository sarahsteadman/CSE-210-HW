public class Listing : Activity
{
    private string[] _promptsListing = { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };
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
        int count = 0;

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_durationDesired);


        Console.WriteLine(prompt);
        while (startTime < futureTime)
        {
            Console.ReadLine();
            startTime = DateTime.Now;
            count++;
        }

        Console.WriteLine($"You submitted {count} answers.");
        DisplayEnd();
    }
}