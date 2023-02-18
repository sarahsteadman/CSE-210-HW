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
            Console.WriteLine();
            SetDuration();
            Console.Clear();
        }
        public void SetDuration()
        {
            Console.WriteLine("How long, in seconds, would you like to do this activity for?");
            _durationDesired = int.Parse(Console.ReadLine());

        }
        public void GetReady()
        {
            Console.WriteLine("Get Ready...");
            PauseAnimation(1);
        }
        public void DisplayEnd()
        {
            Console.WriteLine("Good Job!");
            Console.WriteLine("");
            PauseAnimation(2);
            Console.WriteLine($"You completed another {_durationDesired} seconds of the {_activityName} Activity.");
            PauseAnimation(4);

            Console.Clear();
        }
        public void PauseAnimation(int seconds)
        {

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(seconds);

            while (startTime < futureTime)
            {

                Console.Write("|");
                Thread.Sleep(200);
                Console.Write("\b");

                Console.Write("\\");
                Thread.Sleep(200);
                Console.Write("\b");

                Console.Write("-");
                Thread.Sleep(200);
                Console.Write("\b");

                Console.Write("/");
                Thread.Sleep(200);
                Console.Write("\b");



                startTime = DateTime.Now;
            }
            Console.Write("\b \b");
        }
    }