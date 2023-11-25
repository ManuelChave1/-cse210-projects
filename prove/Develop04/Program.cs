using System;
using System.Threading;

// Base class for all activities
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }
     public void getReady()
     {
       Console.Write("Get ready..."); animationsStrings();
       Console.WriteLine(" ");
     }
    public virtual void StartActivity()
    {
        Console.Clear();
        // Common starting message, set duration, pause, etc.
        Console.WriteLine($"Welcome to the {_name} Activity.\n\n{_description}\n");
        Console.Write("How long in seconds would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Thread.Sleep(500);       
    }
    public virtual void EndActivity()
    {
        // Common ending message, display duration, pause, etc.
        Console.WriteLine("Well Done!!\n");
        Console.WriteLine($"Congratulations! You have completed another {_duration} seconds  of the {_name} Activity.");
        animationsStrings();
    }

    public virtual void animationsStrings()
     {
       List<string> animationsStrings = new List<string>();
        animationsStrings.Add("|");
        animationsStrings.Add("/");
        animationsStrings.Add("-");
        animationsStrings.Add("\\");
        animationsStrings.Add("|");
        animationsStrings.Add("/");
        animationsStrings.Add("-");
        animationsStrings.Add("\\");

        foreach ( string s in animationsStrings)
        {
            Console.Write(s);
             Thread.Sleep(800);
              Console.Write("\b");
        }
               Console.WriteLine("  ");
     }
      public virtual void CountDown()
    {
       for (int i = 5; i > 0; i--){
             Console.Write(i);
             Thread.Sleep(800);
             Console.Write("\b");
        }
    }   
}

// Specific activity classes inheriting from Activity
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    public override void StartActivity()
    {
        base.StartActivity();
         Console.Clear();
         getReady();
         DateTime start = DateTime.Now; 
         DateTime end = start.AddSeconds(_duration);
         while (DateTime.Now < end)
         {
            Console.Write("Breathe in...");CountDown();
            Console.WriteLine(" ");
            Console.Write("Now breathe out...");CountDown();
            Console.WriteLine(" ");   
            Console.WriteLine(" ");   
         }
    }
}

public class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life")
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        // Implementing reflection exercise specific functionality
                 // list of prompt rendoms
         List<string> rendomPrompt = new List<string>();
         rendomPrompt.Add("--Think of a time when you stood up for someone else--");
         rendomPrompt.Add("--Think of a time  when you did something really difficult--");
         rendomPrompt.Add("--Think of a time when you helped someone in need--");
         rendomPrompt.Add("--Think of a time when you did something truly selfless--");
         rendomPrompt.Add("--Think of a time when you stood up for someone else--");

            Random rendPrompt = new Random();
            var rendon = rendPrompt.Next(0,rendomPrompt.Count);
              // list of questions ramdoms
         List<string> rendomQuestions = new List<string>();
         rendomQuestions.Add("> Why was this experience meaningful to you?");
         rendomQuestions.Add("> Have you ever done anything like this before?");
         rendomQuestions.Add("> How did you get started?");
         rendomQuestions.Add("> How did you feel when it was complete?");
         rendomQuestions.Add("> What made this time different than other times when you were not as successful?");
         rendomQuestions.Add("> What is your favorite thing about this experience?"); 
         rendomQuestions.Add("> What could you learn from this experience that applies to other situations?");   
         rendomQuestions.Add("> What did you learn about yourself through this experience?");  
         rendomQuestions.Add("> How can you keep this experience in mind in the future?");

           Random rendQuestion = new Random();
           var question = rendQuestion.Next(0,rendomQuestions.Count);

         Console.Clear();
         getReady();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine(rendomPrompt[rendon]);
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");CountDown();
        Console.Clear();
        DateTime start = DateTime.Now; 
        DateTime end = start.AddSeconds(_duration);
        int i = 0;
        while ( DateTime.Now < end && i < rendomQuestions.Count)
         {
             Console.WriteLine(rendomQuestions[i]);
             Console.ReadKey();
             i++;
         }

         Console.WriteLine(" ");
    }
}

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area")
    {
    }
    public override void StartActivity()
    {
        base.StartActivity();
        // Implementing listing exercise specific functionality
        List<string> ListingActivityList = new List<string>();
        ListingActivityList.Add("Who are people that you apreciate?");
        ListingActivityList.Add("What are personal strenghts of yours?");
        ListingActivityList.Add("Who are people that you have helped this week?");
        ListingActivityList.Add("When have you felt the Holy Ghost this month?");
        ListingActivityList.Add("Who are some of your personal heroes?");

                Random listingActivity = new Random();
                var Rendlisting = listingActivity.Next(0,ListingActivityList.Count);
              // list of user prompt
        List<string> userPrompt = new List<string>();

        Console.Clear();
        getReady();
        Console.WriteLine("List as many responses you can to the following prompt:\n");
        Console.WriteLine(ListingActivityList[Rendlisting]);
        Thread.Sleep(1000);
        Console.Write("You may begin in: ");CountDown();
        Console.WriteLine(" ");

        DateTime start = DateTime.Now; 
        DateTime end = start.AddSeconds(_duration);
        string respomse;
        int i = 0;

        while ( DateTime.Now < end)
         {
            Console.Write("> ");
            respomse = Console.ReadLine();
            userPrompt.Add(respomse);
            i++;     
         }

        Console.Write("\nYou listed {0} items! \n\n",userPrompt.Count);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();

        // Handle menu system to choose activity
        string chosenActivity = "";
        while (chosenActivity != "1" && chosenActivity != "2" && chosenActivity != "3" && chosenActivity != "4")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            chosenActivity = Console.ReadLine();
        }

         switch (chosenActivity)
         {
             case "1":
               Console.Clear();
                breathing.StartActivity();
                breathing.EndActivity();
                 break;
             case "2":
                 reflection.StartActivity();
                 reflection.EndActivity();
                 break;
             case "3":
                  listing.StartActivity();
                  listing.EndActivity();
                 break;
            case "4":
                 break;
             default:
                Console.WriteLine("Invalid choice!");
                 break;
         }    
    }
}

