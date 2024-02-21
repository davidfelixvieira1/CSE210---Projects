using System;
using System.Collections.Generic;

// Base class for goals
public class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool IsCompleted { get; set; }

    public virtual void MarkComplete()
    {
        IsCompleted = true;
        Console.WriteLine($"Goal '{Name}' completed! You earned {Value} points.");
    }

    public virtual void DisplayProgress()
    {
        Console.WriteLine($"[{(IsCompleted ? 'X' : ' ')}] {Name}");
    }
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    private int completedCount;

    public ChecklistGoal(string name, int value, int targetCount)
    {
        Name = name;
        Value = value;
        TargetCount = targetCount;
    }

    public override void MarkComplete()
    {
        completedCount++;
        Console.WriteLine($"Goal '{Name}' completed ({completedCount}/{TargetCount})! You earned {Value} points.");

        if (completedCount == TargetCount)
        {
            Console.WriteLine($"Bonus: You achieved the target {TargetCount} times! Bonus: {Value * 5} points.");
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"[{completedCount}/{TargetCount}] {Name}");
    }
}

// Class to manage goals and user score
public class EternalQuestManager
{
    private List<Goal> goals = new List<Goal>();
    private int userScore = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(Goal goal)
    {
        if (!goal.IsCompleted)
        {
            goal.MarkComplete();
            userScore += goal.Value;
        }
        else
        {
            Console.WriteLine($"Goal '{goal.Name}' has already been completed.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        foreach (var goal in goals)
        {
            goal.DisplayProgress();
        }

        Console.WriteLine($"Your Score: {userScore} points");
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        EternalQuestManager manager = new EternalQuestManager();

        // Create goals
        Goal runMarathon = new SimpleGoal("Run a Marathon", 1000);
        Goal readScriptures = new EternalGoal("Read Scriptures", 100);
        Goal attendTemple = new ChecklistGoal("Attend Temple", 50, 10);

        // Add goals to manager
        manager.AddGoal(runMarathon);
        manager.AddGoal(readScriptures);
        manager.AddGoal(attendTemple);

        // Record events
        manager.RecordEvent(runMarathon);
        manager.RecordEvent(readScriptures);
        manager.RecordEvent(attendTemple);
        manager.RecordEvent(attendTemple);
        manager.RecordEvent(attendTemple);

        // Display goals and score
        manager.DisplayGoals();
    }
}