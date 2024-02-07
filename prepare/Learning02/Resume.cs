using System;
using System.Collections.Generic;

namespace MyNamespace
{
    public class Resume
    {
        public string _name;
        public List<Job> _jobs = new List<Job>();

        public Resume()
        {
            _jobs = new List<Job>();
        }

        public void Display()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine("Jobs: Restaurant attendant, Representative and successful Team Leader customer service");

            foreach (Job job in _jobs)
            {
                job.Display();
            }
        }
    }
}