using System;


Console.Write("Enter your grade persentege: ");
string gradeFromUser = Console.ReadLine();
double gradePercentage = double.Parse(gradeFromUser);

string letter = "";

if (gradePercentage > 100)
{
    Console.WriteLine("Enter values from 0 to 100.");
}
else if (gradePercentage >= 90)
{
    letter = "A";
}
else if (gradePercentage >= 80)
{
    letter = "B";
}

else if (gradePercentage >= 70)
{
    letter = "C";
}
else if (gradePercentage >= 60)
{
    letter = "D";
}
else if (gradePercentage < 60)
{
    letter = "F";
}
Console.WriteLine($"Your grade is: {letter}");

if (gradePercentage > 100)
{
    Console.WriteLine("Enter values from 0 to 100");
}
else if (gradePercentage >= 70)
{
    Console.WriteLine("Congratulations you passed.");
}
else
{
    Console.WriteLine("Sorry, you are not aproved, please try next time.");
}
