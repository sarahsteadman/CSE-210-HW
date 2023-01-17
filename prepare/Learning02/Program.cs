using System;

class Program
{
    static void Main(string[] args)
    {
        job job1 = new job();
        job1._jobTitle = "Master of silly times";
        job1._company = "Floop";
        job1._start = 1800;
        job1._end = 2380;

        job job2 = new job();
        job2._jobTitle = "Master of dance";
        job2._company = "Flip";
        job2._start = 1809;
        job2._end = 2382;
 

        resume resume1 = new resume();
        resume1._name = "Zelda Z";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        
        resume1.display_resume();
        
    }
}