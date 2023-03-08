public class Checklist : Goal
{
    private int _timesCompleted = 0;
    private int _toComplete;
    private int _bonusPoints;
    public Checklist()
    {
        _type = 3;

    }

    public override void SetProperties()
    {
        Console.WriteLine("What is the name of your goal?");
        _name = Console.ReadLine();
        Console.WriteLine("What is a short description of it?");
        _description = Console.ReadLine();
        Console.WriteLine("How many times would you like to complete this goal?");
        _toComplete = int.Parse(Console.ReadLine());
        Console.WriteLine("How many points should be awarded each time you complete this goal?");
        _pointValue = int.Parse(Console.ReadLine());
        Console.WriteLine($"How many bonus points should be awarded after you have finished it {_toComplete} times?");
        _bonusPoints = int.Parse(Console.ReadLine());


    }
    public override void Display(int count)
    {
        Console.WriteLine($"{count}. [{_timesCompleted}/{_toComplete}] {_name} ({_description})");
    }
    public override string SaveFormat()
    {
        return $"{_type}~{_timesCompleted}~{_name}~{_description}~{_pointValue}~{_toComplete}~{_bonusPoints}";
    }
    public override void AssignLoad(string[] parts)
    {

        _type = int.Parse(parts[0]);
        _timesCompleted = int.Parse(parts[1]);
        _name = parts[2];
        _description = parts[3];
        _pointValue = int.Parse(parts[4]);
        _toComplete = int.Parse(parts[5]);
        _bonusPoints = int.Parse(parts[6]);

        if (_timesCompleted == _toComplete)
        {
            _completed = "X";
        }
    }
    public override int RecordEvent()
    {
        int totalPoints = 0;

        if (_completed == " ")
        {
            _timesCompleted++;

            Console.WriteLine("");
            Console.WriteLine($"Good Work! You've received {_pointValue} points.");
            Console.WriteLine($"{_name} {_timesCompleted}/{_toComplete}");

            totalPoints = _pointValue;

            if (_timesCompleted == _toComplete)
            {
                _completed = "X";
                Console.WriteLine($"You've completed this task and have received {_bonusPoints} bonus points!");

                totalPoints += _bonusPoints;
            }
        }
        else
        {
            Console.WriteLine("You have already completed this task.");

            totalPoints = 0;
        }

        return totalPoints;

    }
}