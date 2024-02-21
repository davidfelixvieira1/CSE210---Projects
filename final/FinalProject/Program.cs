using System;
using System.Collections.Generic;

public abstract class Goal
{
    private string name;
    protected int points;

    public Goal(string name)
    {
        this.name = name;
        this.points = 0;
    }

    public string GetName()
    {
        return name;
    }

    public int GetPoints()
    {
        return points;
    }

    public void DoEternalAction()
    {
        Console.WriteLine($"Performing eternal action for goal: {name}");
        points += 100;
    }

    public abstract void DoChecklistAction();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name) : base(name) { }

    public override void DoChecklistAction()
    {
        Console.WriteLine($"Performing checklist action for goal: {GetName()}");
        // Add specific actions for SimpleGoal if needed
    }
}

public class RepeatableGoal : Goal
{
    private int targetCount;
    private int currentCount;

    public RepeatableGoal(string name, int targetCount) : base(name)
    {
        this.targetCount = targetCount;
        this.currentCount = 0;
    }

    public override void DoChecklistAction()
    {
        Console.WriteLine($"Performing checklist action for goal: {GetName()}");
        currentCount++;

        if (currentCount == targetCount)
        {
            points += 50; // Adjust bonus points based on specific requirements
            Console.WriteLine("Bonus points for completing the checklist!");
        }
    }
}

public class Program
{
    static void Main()
    {
        List<Goal> goals = new List<Goal>
        {
            new SimpleGoal("Read a Book"),
            new RepeatableGoal("Go to the Gym", 10)
        };

        foreach (var goal in goals)
        {
            goal.DoChecklistAction();
            goal.DoEternalAction();
            Console.WriteLine($"Points for {goal.GetName()}: {goal.GetPoints()}\n");
        }
    }
}