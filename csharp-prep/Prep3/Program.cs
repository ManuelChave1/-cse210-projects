using System;





// Console.WriteLine("Welocme to guessing game!");
/* Console.Write("What is the magic number? ");
 int magicNum = int.Parse(Console.ReadLine());
 Console.Write("What is your guess? ");
 int guess = int.Parse(Console.ReadLine());

if(guess == magicNum)
 {
     Console.Write("You guessed it!");
 }
 else if (guess > magicNum)
 {
     Console.Write("Lower");
 }
 else if (guess < magicNum)
 {
     Console.Write("Higher");
 }
*/
// part 3 assigment
Random randomGenerator = new Random();
int magicNumber = randomGenerator.Next(1, 101);

int guess = -1;

// We could also use a do-while loop here...
while (guess != magicNumber)
{
    Console.Write("What is your guess? ");
    guess = int.Parse(Console.ReadLine());

    if (magicNumber > guess)
    {
        Console.WriteLine("Higher");
    }
    else if (magicNumber < guess)
    {
        Console.WriteLine("Lower");
    }
    else
    {
        Console.WriteLine("You guessed it!");
    }
}
