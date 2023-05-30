using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime date;      // Stores the date of the activity
    private int duration;       // Stores the duration of the activity in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();     // Calculates and returns the distance of the activity
    public abstract double GetSpeed();        // Calculates and returns the speed of the activity
    public abstract double GetPace();         // Calculates and returns the pace of the activity

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        // Returns a summary string containing the activity details
        return $"{date.ToString("dd MMM yyyy")} {GetType().Name} ({duration} min): " +
               $"Distance: {distance.ToString("0.0")} {GetDistanceUnit()}, " +
               $"Speed: {speed.ToString("0.0")} {GetSpeedUnit()}, " +
               $"Pace: {pace.ToString("0.0")} {GetPaceUnit()}";
    }

    // Virtual methods with default implementations that can be overridden by derived classes
    protected virtual string GetDistanceUnit()
    {
        return "units";
    }

    protected virtual string GetSpeedUnit()
    {
        return "units/h";
    }

    protected virtual string GetPaceUnit()
    {
        return "min/units";
    }

    // Calculate the total minutes from the duration
    protected int GetMinutes()
    {
        return duration;
    }
}

public class Running : Activity
{
    private double distance;      // Stores the distance covered during the run

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (GetMinutes() / 60);
    }

    public override double GetPace()
    {
        return GetMinutes() / distance;
    }
}

public class Cycling : Activity
{
    private double speed;      // Stores the speed of cycling in km/h

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * (GetMinutes() / 60);
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    protected override string GetSpeedUnit()
    {
        return "km/h";
    }

    protected override string GetPaceUnit()
    {
        return "min/km";
    }
}

public class Swimming : Activity
{
    private int laps;      // Stores the number of laps swam

    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000;      // Converts laps to kilometers
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return distance / (GetMinutes() / 60);
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return GetMinutes() / distance;
    }

    protected override string GetDistanceUnit()
    {
        return "km";
    }

    protected override string GetPaceUnit()
    {
        return "min/km";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        DateTime date = new DateTime(2022, 11, 3);
        
        // Creating instances of different activity types and adding them to the activities list
        activities.Add(new Running(date, 30, 3.0));
        activities.Add(new Running(date, 30, 4.8));
        activities.Add(new Cycling(date, 30, 15.0));
        activities.Add(new Cycling(date, 30, 24.1));
        activities.Add(new Swimming(date, 30, 20));
        activities.Add(new Swimming(date, 30, 40));

        // Displaying the summary of each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
