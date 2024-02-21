using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice;
        do
        {
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    DisplayPlayerInfo();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    CreateGoal();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    SaveGoals();
                    break;
                case 7:
                    LoadGoals();
                    break;
                case 8:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                    break;
            }
        } while (choice != 8);
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("List of Goal Names:");
        foreach (var goal in _goals)
        {
            Console.WriteLine($"- {goal.GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("List of Goal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Goal Description: ");
        string description = Console.ReadLine();
        Console.Write("Enter Goal Points: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points. Please enter a number.");
            return;
        }

        // You can implement logic to create different types of goals here
        // based on user input or other criteria.
        // For simplicity, let's assume the user is creating a SimpleGoal.
        Goal newGoal = new SimpleGoal(name, description, points);
        _goals.Add(newGoal);
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a Goal to Record Event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int index;
        do
        {
            Console.Write("Enter the number corresponding to the goal: ");
        } while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > _goals.Count);

        Goal selectedGoal = _goals[index - 1];
        int pointsEarned = selectedGoal.RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"Event recorded for {selectedGoal.GetName()}. Earned {pointsEarned} points.");
    }

    public void SaveGoals()
    {
        // Implement logic to save goals to a file
        Console.WriteLine("Goals saved to file.");
    }

    public void LoadGoals()
    {
        // Implement logic to load goals from a file
        Console.WriteLine("Goals loaded from file.");
    }
}