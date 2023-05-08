public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

   // Constructor that takes student name, topic, textbook section, and problems as parameters
public MathAssignment(string studentName, string topic, string textbookSection, string problems) 
    : base(studentName, topic)
{
    _textbookSection = textbookSection; // set the textbook section field to the passed value
    _problems = problems; // set the problems field to the passed value
}

// Method that returns the homework list for this math assignment
public string GetHomeworkList()
{
    return $"Section {_textbookSection} Problems {_problems}"; // return a string that contains the textbook section and problems
}
}
