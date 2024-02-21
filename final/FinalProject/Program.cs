using System;
using System.Collections.Generic;

// Base class for goals
public class Goal
{
    protected string name; // Change the access modifier to protected
    private int points;
    private bool isCompleted;

    public Goal(string name)
    {
        this.name = name;
        points = 0;
        isCompleted = false;
    }

    public void MarkComplete()
    {
        isCompleted = true;
        points += 100; // Placeholder: Points earned for completing a goal
    }

    public void DisplayProgress()
    {
        Console.WriteLine($"Goal: {name}, Points: {points}, Completed: {isCompleted}");
    }
}

// Derived class for Eternal Goals
public class EternalGoal : Goal
{
    public EternalGoal(string name) : base(name)
    {
        // Additional initialization for EternalGoal
    }

    // Actual implementation for EternalGoal action
    public void DoEternalAction()
    {
        Console.WriteLine($"Performing eternal action for goal: {name}");
        // Replace this with your specific implementation
        Console.WriteLine("Read scriptures for 15 minutes.");
    }
}

// Derived class for Checklist Goals
public class ChecklistGoal : Goal
{
    private int completionCount;
    private int targetCount;

    public ChecklistGoal(string name, int targetCount) : base(name)
    {
        this.targetCount = targetCount;
        completionCount = 0;
    }

    // Actual implementation for ChecklistGoal action
    public void DoChecklistAction()
    {
        Console.WriteLine($"Performing checklist action for goal: {name}");
        // Replace this with your specific implementation
        Console.WriteLine("Attended the temple.");
    }

    public void MarkChecklistItemComplete()
    {
        completionCount++;
        if (completionCount >= targetCount)
        {
            MarkComplete(); // Bonus: Mark the entire goal as complete when the checklist is done
        }
    }
}

// User class managing goals and interactions
public class User
{
    public List<Goal> Goals { get; private set; }

    public User()
    {
        Goals = new List<Goal>();
    }

    public void CreateGoal(string goalName, string goalType, int targetCount = 0)
    {
        Goal newGoal;

        switch (goalType.ToLower())
        {
            case "eternal":
                newGoal = new EternalGoal(goalName);
                break;
            case "checklist":
                newGoal = new ChecklistGoal(goalName, targetCount);
                break;
            default:
                newGoal = new Goal(goalName);
                break;
        }

        Goals.Add(newGoal);
    }

    public void RecordEvent(Goal goal)
    {
        goal.MarkComplete();
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            goal.DisplayProgress();
        }
    }
}

class Program
{
    static void Main()
    {
        // Example interaction
        User user = new User();
        user.CreateGoal("Study C#", "eternal");
        user.CreateGoal("Run a Marathon", "checklist", 10);

        // Placeholder: Record events, display goals, etc.
        user.RecordEvent(user.Goals[0]);
        user.RecordEvent(user.Goals[1]);

        // Placeholder: Perform actions specific to each goal type
        if (user.Goals[0] is EternalGoal)
        {
            ((EternalGoal)user.Goals[0]).DoEternalAction();
        }

        if (user.Goals[1] is ChecklistGoal)
        {
            ((ChecklistGoal)user.Goals[1]).DoChecklistAction();
        }

        user.DisplayGoals();
    }
}