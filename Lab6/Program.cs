using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the Pig Latin Translator!\n\nThis program takes a word that you enter and translates it into Pig Latin!\n");

            bool repeat = true;
            while (repeat)
            {
                string name = GetName("Please enter your name: ");

                string userInput = GetWord("Please enter a word to be translated into Pig Latin: ");

                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                int position = userInput.ToLower().IndexOfAny(vowels);
                string postString = userInput.Substring(position);
                char[] arrayOne = userInput.ToCharArray(0, position);
                string preString = new string(arrayOne);

                if (position == 0)
                {
                    string result = string.Concat(userInput, "way");
                    Console.WriteLine($"{userInput} is {result} in Pig Latin.");
                }
                else
                {
                    string result = string.Concat(postString, preString, "ay");
                    Console.WriteLine($"{userInput} is {result} in Pig Latin.");
                }
                repeat = DoAgain($"Would you like to translate another word to Pig Latin, {name}? (Y or N): ");
            }
            Console.WriteLine("Thank you for using the Pig Latin Translator!\n\nGoodbye!");
        }

        private static string GetName(string prompt)
        {
            Console.Write(prompt);
            string name = Console.ReadLine();
            Console.Write($"Hello {name}! ");
            return name;
        }

        private static string GetWord(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            if(!input.Contains('a') && !input.Contains('e') && !input.Contains('i') && !input.Contains('o') && !input.Contains('u'))
            {
                Console.WriteLine("The word you entered contained no vowels and could not be translated to Pig Latin.");
                return GetWord(prompt);
            }
            return input;
        }

        private static bool DoAgain(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.Write("Invalid input. ");
                return DoAgain(prompt);
            }
        }
    }
}
