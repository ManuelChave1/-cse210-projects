using System;
using System.Text;


    public class Word
    {

         //Aqui a string virac uma lista de char
 private Scripture _scripture;

 public Word(Scripture scripture){
      _scripture = scripture;
 }

public void word() {
var words= _scripture._text.Split();
Console.Clear();

Random rdm = new Random();
List<int> hiddenWords = new ();
int pos = 0;

for (int i = 0; i < words.Count(); i++)
{
    //A cada tecla pressionada o char é subsituido por '-'
    Console.ReadLine();
    Console.Clear();

    //Pega uma sring aleatória e verifica se ja foi usada
    while (true)
    {
        pos = rdm.Next(0, words.Count() - 1);

        //Para a aplicação
        if (hiddenWords.Count() == words.Count() - 1)
        {
            Console.ReadLine();
            Environment.Exit(1);
        }

        //Adiciona na lista
        if (!hiddenWords.Any(x => x == pos))
        {
            hiddenWords.Add(pos);
            break;
        }

    }

    //Muda a string
    words[pos] = "-";

    //A lista de char volta a ser uma string e mostra na tela
    StringBuilder str = new StringBuilder();
    _scripture._text = str.AppendJoin(" ", words).ToString();
    Console.WriteLine(_scripture._text);

    Console.WriteLine("\nPress Enter do contue or type 'quit' to exit");
    string input = Console.ReadLine();
    if (input == "quit")
    {
        Console.WriteLine("Voce desistiu do jogo");
        break;
        
    }
     
   }

 }
    }

   

