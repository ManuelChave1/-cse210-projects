using System;
using System.Text;
class Program
{
    static void Main()
    {

        Scripture scripture = new Scripture("1 Nephi 3:7 ","And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        Word word = new Word(scripture);
        word.word();

    }
}








