using System;
using System.Collections.Generic;

// Base class representing a goal
public class Goal
{
    public string Name { get; set; }
    public bool Completed { get; protected set; }

    public virtual void MarkComplete()
    {
        Completed = true;
    }
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    public int Points { get; set; }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    public int Points { get; set; }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    public int PointsPerCompletion { get; set; }
    public int RequiredCompletions { get; set; }
    public int CurrentCompletions { get; protected set; }

    public override void MarkComplete()
    {
        CurrentCompletions++;
        if (CurrentCompletions == RequiredCompletions)
        {
            Completed = true;
        }
    }
}

// Class to manage goals and track progress
public class QuestTracker
{
    private List<Goal> goals;
    private int score;

    public QuestTracker()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            goal.MarkComplete();
            score += GetPointsForGoal(goal);
        }
    }

    private int GetPointsForGoal(Goal goal)
    {
        if (goal is SimpleGoal simpleGoal)
        {
            return simpleGoal.Points;
        }
        else if (goal is EternalGoal eternalGoal)
        {
            return eternalGoal.Points;
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            if (checklistGoal.Completed)
            {
                return checklistGoal.PointsPerCompletion * checklistGoal.RequiredCompletions;
            }
            else
            {
                return checklistGoal.PointsPerCompletion;
            }
        }

        return 0;
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string completionStatus = goal.Completed ? "[X]" : "[ ]";

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{completionStatus} {goal.Name} (Completed {checklistGoal.CurrentCompletions}/{checklistGoal.RequiredCompletions} times)");
            }
            else
            {
                Console.WriteLine($"{completionStatus} {goal.Name}");
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {score}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a quest tracker
        QuestTracker questTracker = new QuestTracker();

        // Create goals
        SimpleGoal marathonGoal = new SimpleGoal { Name = "Run a marathon", Points = 1000 };
        EternalGoal scriptureGoal = new EternalGoal { Name = "Read scriptures", Points = 100 };
        ChecklistGoal templeGoal = new ChecklistGoal { Name = "Attend the temple", PointsPerCompletion = 50, RequiredCompletions = 10 };

        // Add goals to the tracker
        questTracker.AddGoal(marathonGoal);
        questTracker.AddGoal(scriptureGoal);
        questTracker.AddGoal(templeGoal);

               bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("===== Eternal Quest =====");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Score");
            Console.WriteLine("4. Exit");
            Console.WriteLine("==========================");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    questTracker.DisplayGoals();
                    break;
                case "2":
                    Console.Write("Enter the index of the goal you completed: ");
                    if (int.TryParse(Console.ReadLine(), out int goalIndex))
                    {
                        questTracker.RecordEvent(goalIndex);
                        Console.WriteLine("Event recorded!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal index.");
                    }
                    break;
                case "3":
                    questTracker.DisplayScore();
                    break;
                case "4":
                    isRunning = false;
                    Console.WriteLine("Exiting Eternal Quest. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

