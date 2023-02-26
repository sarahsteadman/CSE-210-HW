public class Goal
{
protected string _name;
protected string _type;
protected string _description;
protected int _pointValue;
protected char _completed;

public void SetProperties()
{
    Console.WriteLine("What is the name of your goal?");
    _name = Console.ReadLine();
    Console.WriteLine("What is a short description of it?");
    _description = Console.ReadLine();
    Console.WriteLine("How many points should be awarded for this goal?");
    _pointValue = int.Parse(Console.ReadLine());

}

public void Display(int count)
{
    Console.WriteLine($"{count}. [{_completed}] {_name} ({_description})");
}
public string SaveFormat()
{
    return $"{_type}~{_completed}~{_name}~{_description})~{_pointValue}";
}

}