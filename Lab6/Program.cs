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
            string name = GetName("Please enter your name: ");

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            bool repeat = true;
            while (repeat)
            {
                string[] userInput = GetWord("Please enter a sentence to be translated into Pig Latin: ");
                Console.Write("\nYour entry translated to Pig Latin is: ");
                for (int i = 0; i < userInput.Count(); i++)
                {
                    string word = userInput[i];
                    int position = word.ToLower().IndexOfAny(vowels);
            
                    char[] arrayOne = word.ToCharArray(0, position);
                    string preString = new string(arrayOne);
                    string postString = word.Substring(position);
                    if (position == 0)
                    {
                        string result = string.Concat(word, "way");
                        Console.Write(result+" ");
                    }
                    else
                    {
                        string result = string.Concat(postString, preString, "ay");
                        Console.Write(result + " ");
                    }
                }
                repeat = DoAgain($"\n\nWould you like to translate another sentence to Pig Latin, {name}? (Y or N): ");
            }
            Console.WriteLine("Thank you for using the Pig Latin Translator!\n\nGoodbye!");
        }

        private static string GetName(string prompt)
        {
            Console.Write(prompt);
            string name = Console.ReadLine();
            Console.Write($"\nHello {name}! ");
            return name;
        }

        private static string[] GetWord(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            string[] arrayOne = input.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
            return arrayOne;
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
