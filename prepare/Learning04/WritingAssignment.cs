// WritingAssignment class inherits from Assignment class and adds a new field, title.
public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor of the WritingAssignment class that calls the constructor of its parent class and sets the title.
    public WritingAssignment(string studentName, string topic, string title) 
        : base(studentName, topic)
    {
        _title = title;
    }

    // A method of WritingAssignment class that returns the title of the assignment along with the student name.
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}
