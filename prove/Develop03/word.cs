using System;
using System.Text;


    public class Word
    {

 private Scripture _scripture;

 public Word(Scripture scripture){
      _scripture = scripture;
 }

public void word() {

//Here the string becomes a list of char
var words= _scripture._text.Split();
Console.Clear();

Random rdm = new Random();
List<int> hiddenWords = new ();
int pos = 0;

for (int i = 0; i < words.Count(); i++)
{
    //With each key pressed, the char is replaced by '-'
    Console.ReadLine();
    Console.Clear();

    //Take a random string and check if it has already been used
    while (true)
    {
        pos = rdm.Next(0, words.Count() - 1);

        if (hiddenWords.Count() == words.Count() - 1)
        {
            Console.ReadLine();
            Environment.Exit(1);
        }

        //Add to list
        if (!hiddenWords.Any(x => x == pos))
        {
            hiddenWords.Add(pos);
            break;
        }

    }

    //Change the string
    words[pos] = "-";

    //The char list returns to a string and shows on the screen
    StringBuilder str = new StringBuilder();
    _scripture._text = str.AppendJoin(" ", words).ToString();
    Console.WriteLine("{0} \n {1}" ,_scripture._reference,_scripture._text);

    Console.WriteLine("\nPress Enter do continue or type 'quit' to exit");
    string input = Console.ReadLine();
    if (input == "quit")
    {
        break; 
    }
     
   }

 }
    }

   


