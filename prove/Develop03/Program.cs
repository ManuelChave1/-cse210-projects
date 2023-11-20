using System;
using System.Text;
class Program
{
    static void Main()
    {

Scripture scripture = new Scripture("Joao 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

Word word = new Word(scripture);
word.word();

}
}





  


