using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console . Write("Enter your grade persentege: ");
        string gradeFromUser = Console.ReadLine();
        double gradePercentage = double.Parse(gradeFromUser);


        if (gradePercentage > 100)
        {
            Console.WriteLine("Enter values ​​from 0 to 100.");
        }
        else if (gradePercentage >= 90)
        {
           Console.WriteLine($"Your grade is A."); 
        }
        else if(gradePercentage >= 80)
        {
            Console.WriteLine("Your grade is B.");
        }

        else if(gradePercentage >= 70)
        {
            Console.WriteLine("Your grande is C.");
        } 
        else if (gradePercentage >= 60)
        {
            Console.WriteLine("Your grade is D.");
        }
        else if (gradePercentage < 60)
        {
            Console.WriteLine("Your grade is F.");
        }

        if (gradePercentage > 100)
        {
            Console.WriteLine("Enter values​from 0 to 100");
        }
        else if (gradePercentage >=70)
        {
            Console.WriteLine("Congratulations you passed.");
        }
        else
        {
            Console.WriteLine("Sorry, you are not aproved, please try next time.");
        }
    }
}