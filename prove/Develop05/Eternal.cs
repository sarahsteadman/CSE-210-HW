public class Eternal : Goal
{
    private int _timesCompleted = 0;

    public Eternal()
    {
        _type = 1;

    }
    public override string SaveFormat()
    {
        return $"{_type}~{_timesCompleted}~{_name}~{_description})~{_pointValue}";
    }
    public override void Display(int count)
    {
        Console.WriteLine($"{count}. [{_timesCompleted}] {_name} ({_description})");
    }
    public override void AssignLoad(string[] parts)
    {

        _type = int.Parse(parts[0]);
        _timesCompleted = int.Parse(parts[1]);
        _name = parts[2];
        _description = parts[3];
        _pointValue = int.Parse(parts[4]);
    }
    public override int RecordEvent()
    {
        _timesCompleted++;
        Console.WriteLine($"Good work! You have received {_pointValue} points for doing this task.");
        Console.WriteLine($"Task completed {_timesCompleted} time(s).");

        return _pointValue;
    }
}