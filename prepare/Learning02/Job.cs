 public class job
        {
             public string _company;
             public string _jobTitle;
             public int _start;
             public int _end;

             public void display()
             {
                Console.WriteLine($"{_jobTitle} {_company} {_start}-{_end}");
             }
        }