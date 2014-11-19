namespace LetterService.ConsoleClient
{
    using System;

    public class EntryPoint
    {
        static void Main()
        {
            var client = new LetterServiceClient();
            var text = "This is text. Just some text. Some, text, Text.";
            var searchedWord = "text";

            Console.WriteLine("Test text: " + text);
            Console.WriteLine("Test searched word: " + searchedWord);
            Console.WriteLine();
            Console.WriteLine("Press any key to get the occurences of the word in the text.");
            Console.WriteLine();

            Console.ReadKey();

            var occurences = client.GetOccurences(text, searchedWord);

            Console.WriteLine("Number of occurences of the searched word " + occurences);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit the program.");

            Console.ReadKey();

            client.Close();
        }
    }
}
