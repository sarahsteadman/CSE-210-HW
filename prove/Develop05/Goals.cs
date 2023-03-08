public class Goal
{
    protected string _name;
    protected int _type;
    protected string _description;
    protected int _pointValue;
    protected string _completed = " ";

    public virtual void SetProperties()
    {
        Console.WriteLine("What is the name of your goal?");
        _name = Console.ReadLine();
        Console.WriteLine("What is a short description of it?");
        _description = Console.ReadLine();
        Console.WriteLine("How many points should be awarded for this goal?");
        _pointValue = int.Parse(Console.ReadLine());

    }
    public int GetPoints()
    {
        return _pointValue;
    }
    public virtual void Display(int count)
    {
        Console.WriteLine($"{count}. [{_completed}] {_name} ({_description})");
    }
    public virtual string SaveFormat()
    {
        return $"{_type}~{_completed}~{_name}~{_description}~{_pointValue}";
    }
    public virtual void AssignLoad(string[] parts)
    {

        _type = int.Parse(parts[0]);
        _completed = parts[1];
        _name = parts[2];
        _description = parts[3];
        _pointValue = int.Parse(parts[4]);
    }
    public virtual int RecordEvent()
    {
        if (_completed == " ")
        {
            _completed = "X";
            Console.WriteLine($"Good Work! You've received {_pointValue} points.");
            return _pointValue;
        }
        else
        {
            Console.WriteLine("This goal is already complete.");
            return 0;
        }
    }
    public string GetCompleted()
    {
        return _completed;
    }

}