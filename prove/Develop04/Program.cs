using System;
using System.Threading;

// Base class for Mindfulness Activity
public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public virtual void Run()
    {
        DisplayStartingMessage();
        // Additional common logic for all activities
        DisplayEndingMessage();
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity: {_description}");
        // Logic to set duration
        _duration = SetDuration();
        Console.WriteLine($"Duration set to {_duration} seconds.");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed the {_name} activity.");
        Console.WriteLine($"Total time: {_duration} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    private int SetDuration()
    {
        // Logic to get user input for duration
        Console.Write("Enter duration in seconds: ");
        return Convert.ToInt32(Console.ReadLine());
    }
}

// Derived class for Breathing Activity
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "Helps you relax by walking you through breathing in and out slowly.")
    {
    }

    public override void Run()
    {
        base.Run();
        Console.WriteLine("Get ready to breathe...");
        Thread.Sleep(2000); // Pause for 2 seconds before starting

        for (int i = 0; i < _duration; i++)
        {
            Console.WriteLine((i % 2 == 0) ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}

// Derived class for Reflection Activity
public class ReflectionActivity : Activity
{
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        // Add more questions...
    };

    public ReflectionActivity() : base("Reflection", "Helps you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public override void Run()
    {
        base.Run();
        Console.WriteLine("Get ready to reflect...");
        Thread.Sleep(2000); // Pause for 2 seconds before starting

        Random random = new Random();

        for (int i = 0; i < _duration; i++)
        {
            string prompt = _prompts[random.Next(_prompts.Length)];
            Console.WriteLine($"Prompt: {prompt}");

            foreach (var question in _questions)
            {
                Console.WriteLine(question);
                // Display spinner animation
                Console.Write("Processing");
                for (int j = 0; j < 3; j++)
                {
                    Thread.Sleep(500); // Pause for 0.5 seconds
                    Console.Write(".");
                }
                Console.WriteLine();
            }

            Thread.Sleep(1000); // Pause for 1 second before next prompt
        }
    }
}

// Derived class for Listing Activity
public class ListingActivity : Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        // Add more prompts...
    };

    public ListingActivity() : base("Listing", "Helps you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        base.Run();
        Console.WriteLine("Get ready to list...");
        Thread.Sleep(2000); // Pause for 2 seconds before starting

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Start listing...");

        // Simulate user listing items for the specified duration
        for (int i = 0; i < _duration; i++)
        {
            // Simulate user entering items
            Console.WriteLine($"Item {i + 1}");
            Thread.Sleep(1000); // Pause for 1 second
        }

        Console.WriteLine($"You listed {_duration} items.");
        Thread.Sleep(1000); // Pause for 1 second before ending
    }
}

public class Program
{
    static void Main()
    {
        Console.WriteLine("Mindfulness Program");

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 4)
            {
                break;
            }

            Activity selectedActivity = null;

            switch (choice)
            {
                case 1:
                    selectedActivity = new BreathingActivity();
                    break;
                case 2:
                    selectedActivity = new ReflectionActivity();
                    break;
                case 3:
                    selectedActivity = new ListingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid activity.");
                    continue;
            }

            selectedActivity.Run();
        }
    }
}