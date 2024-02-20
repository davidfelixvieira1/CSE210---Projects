// WritingAssignment.cs

public class WritingAssignment : Assignment
{
    private string _writingInformation;

    public WritingAssignment(string studentName, string topic, string writingInformation) : base(studentName, topic)
    {
        _writingInformation = writingInformation;
    }

    public string GetWritingInformation()
    {
        // You can either make _studentName protected in the base class or create a public GetStudentName method.
        // For simplicity, let's use a public method here.
        return $"{GetStudentName()} - {_writingInformation}";
    }
}