public class Job
{
    private string _jobTitle;
    private string _company;
    private string _startDate;
    private string _endDate;

    public string JobTitle
    {
        get { return _jobTitle; }
        set { _jobTitle = value; }
    }

    public string Company
    {
        get { return _company; }
        set { _company = value; }
    }

    public string StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }

    public string EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }

    public void Display()
    {
        Console.WriteLine("{0} ({1}) {2}-{3}", _jobTitle, _company, _startDate, _endDate);
    }
}
