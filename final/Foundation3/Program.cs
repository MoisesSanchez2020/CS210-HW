using System;

// Base Event class
public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    // Returns the standard details of the event
    public string GetStandardDetails()
    {
        return $"Event Title: {title}\n" +
               $"Description: {description}\n" +
               $"Date: {date.ToShortDateString()}\n" +
               $"Time: {time.ToString()}\n" +
               $"Address: {address.GetAddressDetails()}";
    }

    // Returns the full details of the event (including specific details of derived event types)
    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    // Returns a short description of the event
    public virtual string GetShortDescription()
    {
        return $"Event Type: Generic Event\n" +
               $"Event Title: {title}\n" +
               $"Date: {date.ToShortDateString()}";
    }
}

// Lecture class (derived from Event)
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    // Overrides the GetFullDetails method to include lecture-specific details
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
               $"Type: Lecture\n" +
               $"Speaker: {speaker}\n" +
               $"Capacity: {capacity}";
    }
}

// Reception class (derived from Event)
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // Overrides the GetFullDetails method to include reception-specific details
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
               $"Type: Reception\n" +
               $"RSVP Email: {rsvpEmail}";
    }
}

// OutdoorGathering class (derived from Event)
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    // Overrides the GetFullDetails method to include outdoor gathering-specific details
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
               $"Type: Outdoor Gathering\n" +
               $"Weather Forecast: {weatherForecast}";
    }
}

// Address class
public class Address
{
    private string street;
    private string city;
    private string state;
    private string postalCode;

    public Address(string street, string city, string state, string postalCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.postalCode = postalCode;
    }

    // Returns the address details as a formatted string
    public string GetAddressDetails()
    {
        return $"Street: {street}\n" +
               $"City: {city}\n" +
               $"State: {state}\n" +
               $"Postal Code: {postalCode}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create instances of each event type
        Address address1 = new Address("123 Main St", "Cityville", "Stateville", "12345");
        Address address2 = new Address("456 Elm St", "Townville", "Stateville", "67890");

        // Generic Event
        Event genericEvent = new Event("Generic Event", "A generic event description.", DateTime.Now, TimeSpan.FromHours(2), address1);

        // Lecture Event
        Lecture lecture = new Lecture("Lecture Event", "A lecture event description.", DateTime.Now, TimeSpan.FromHours(3), address2, "John Doe", 100);

        // Reception Event
        Reception reception = new Reception("Reception Event", "A reception event description.", DateTime.Now, TimeSpan.FromHours(4), address1, "rsvp@example.com");

        // Outdoor Gathering Event
        OutdoorGathering outdoorGathering = new OutdoorGathering("Outdoor Gathering Event", "An outdoor gathering event description.", DateTime.Now, TimeSpan.FromHours(5), address2, "Sunny");

        // Output the details of each event
        Console.WriteLine("Generic Event:");
        Console.WriteLine(genericEvent.GetStandardDetails());
        Console.WriteLine(genericEvent.GetFullDetails());
        Console.WriteLine(genericEvent.GetShortDescription());

        Console.WriteLine("\nLecture Event:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine("\nReception Event:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine("\nOutdoor Gathering Event:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
