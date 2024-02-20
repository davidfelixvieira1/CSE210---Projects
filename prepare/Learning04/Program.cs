// Program.cs

using System;

class Program
{
    static void Main()
    {
        // Test Assignment class
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        string summary = assignment.GetSummary();
        Console.WriteLine(summary);

        // Test MathAssignment class
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3 Problems 8-19");
        string mathSummary = mathAssignment.GetSummary();
        string mathHomeworkList = mathAssignment.GetHomeworkList();

        Console.WriteLine(mathSummary);
        Console.WriteLine(mathHomeworkList);

        // Test WritingAssignment class
        WritingAssignment writingAssignment = new WritingAssignment("John Doe", "Essay", "Introduction, Body, Conclusion");
        string writingSummary = writingAssignment.GetSummary();
        string writingInfo = writingAssignment.GetWritingInformation();

        Console.WriteLine(writingSummary);
        Console.WriteLine(writingInfo);
    }
}