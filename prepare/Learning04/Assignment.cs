public class Assignment
{
    private string _studentName;
    private string _topic;

   // This is the constructor of the Assignment class
public Assignment(string studentName, string topic)
{
    _studentName = studentName;
    _topic = topic;
}

// This is a public method that returns a string with the student's name and the topic of the assignment
public string GetSummary()
{
    return $"{_studentName} - {_topic}";
}

// This is a protected method that returns the student's name
protected string GetStudentName()
{
    return _studentName;
}
}
