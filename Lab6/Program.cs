using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        static char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static void Main(string[] args)
        {
            Console.WriteLine("This is the Pig Latin Translator!\nThis program takes a sentence that you enter and translates it into Pig Latin!");
            string name = GetName("Please enter your name: ");
            Console.Write($"Hello, {name}! ");

            bool repeat = true;
            while (repeat)
            {
                string[] userInput = GetInput("Please enter a sentence to be translated into Pig Latin: ");
                string pigLatin = Translate(userInput);
                Console.WriteLine($"\nYour entry translated to Pig Latin is:\n\n{pigLatin}\n");
                repeat = DoAgain($"Would you like to translate another sentence to Pig Latin, {name}? (Y or N): ");
            }
            Console.WriteLine("Thank you for using the Pig Latin Translator!\n\nGoodbye!");
        }

        private static string GetName(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private static string[] GetInput(string prompt)
        {
            Console.WriteLine($"{prompt}\n");
            string input = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(input))
            {
                Console.Write("You didn't input anything! ");
                return GetInput(prompt);
            }
            string[] arrayOne = input.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
            return arrayOne;
        }

        private static bool IsAlpha(string input)
        {
            char[] letters = input.ToCharArray();
            foreach(char letter in letters)
            {
                if (!char.IsLetter(letter))
                {
                    return false;
                }
            }
            return true;
        }

        private static string Translate(string[] userInput)
        {
            int length = userInput.Count();
            string[] resultArray = new string[length];
            for (int i = 0; i < length; i++)
            {
                string word = userInput[i];
                int position = word.ToLower().IndexOfAny(vowels);
                if (position < 0)
                {
                    resultArray[i] = word;
                }
                else
                {
                    char[] arrayOne = word.ToCharArray(0, position);
                    string preString = new string(arrayOne);
                    string postString = word.Substring(position);
                    if (!IsAlpha(word) && !word.Contains("'"))
                    {
                        resultArray[i] = word;
                    }
                    else if (position == 0)
                    {
                        resultArray[i] = string.Concat(word, "way");
                    }
                    else
                    {
                        resultArray[i] = string.Concat(postString, preString, "ay");
                    }
                }
            }
            string resultString = string.Join(" ", resultArray);
            return resultString;
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
