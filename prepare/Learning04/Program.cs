using System;

class Program
{
    static void Main(string[] args)
    {
    
        Assignment a1 = new Assignment("Manuel Chave", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        
        MathAssignment a2 = new MathAssignment("Sanine Chave", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Maria Rita", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }


internal class Assignment
{
}