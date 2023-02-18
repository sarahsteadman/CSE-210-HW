public class Grounding : Activity
{
    private string[] _senses = { "What are five things you can see right now?", "What are four things you can touch right now?", "What are three things you can hear right now?", "What are two things you can smell right now?", "What is one things you can see right now?" };

    public Grounding()
    {
        _activityName = "Grounding";
        _description = "This activity will help you calm down and connect to your body by asking questions about your five senses.";
    }

    public void DisplayGrounding()
    {
        int count = 5;
        DisplayStart();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_durationDesired);

        foreach (string sense in _senses)
        {
            int count2 = count;
            Console.WriteLine(sense);

            while (count2 >= 1)
            {
                Console.ReadLine();

                count2--;
            }

            startTime = DateTime.Now;
            if (startTime > futureTime)
            {
                break;
            }

            count--;
        }

        DisplayEnd();

    }
}