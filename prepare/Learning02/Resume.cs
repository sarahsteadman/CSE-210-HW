public class resume
{
    public string _name;
    public List<job> _jobs = new List<job>();

    public void display_resume()
    {
        Console.WriteLine($"{_name}");

        foreach (job position in _jobs)
        {
            position.display();
        }
    }

}    