using MyNamespace;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Restaurant Attendant";
        job1._company = "Dr.Açai";
        job1._startYear = 2022;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Representative and successful Team Leader Customer Service";
        job2._company = "LifeWireless";
        job2._startYear = 2022;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "David Vieira";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}