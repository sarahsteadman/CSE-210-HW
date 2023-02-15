using System;

class Program
{
    static void Main(string[] args)
    {
        Assignments bob = new Assignments();
        bob.SetSummary("Frank", "PE");
        Console.WriteLine(bob.GetSummary());

        Writing susan = new Writing();
        susan.SetHomeworkList("Mary Waters", "Eurepean History", "The Causes of WW2");
        Console.WriteLine(susan.GetHomeworkList());

        Math dave = new Math();
        dave.SetHomeworkList("Robert", "Fractions", "7.3", "8-19");
        Console.WriteLine(dave.GetHomeworkList());
    }
    public class Assignments
    {
        protected string _name;
        protected string _topic;

        public void SetSummary(string name, string topic)
        {
            _name = name;
            _topic = topic;
        }
        public string GetSummary()
        {
            return $"{_name} - {_topic}";
        }

    }

    public class Math : Assignments
    {
        private string _textbook;
        private string _problems;

        public string GetHomeworkList()
        {
            return $"Section {_textbook} Problems {_problems}";
        }
        public void SetHomeworkList(string name, string topic, string textbook, string problems)
        {
            _name = name;
            _topic = topic;
            _textbook = textbook;
            _problems = problems;
        }
    }

    public class Writing : Assignments
    {
        private string _title;

        public string GetHomeworkList()
        {
            return $"{_title} by {_name}";
        }
        public void SetHomeworkList(string name, string topic, string title)
        {
            _name = name;
            _topic = topic;
            _title = title;

        }
    }
}