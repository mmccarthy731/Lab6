using System;
using System.Linq;

namespace Lab6
{
    class Program
    {
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        static void Main(string[] args)
        {
            //Greet the user, get user name
            Console.WriteLine("This is the Pig Latin Translator!\nThis program takes a sentence that you enter and translates it into Pig Latin!");
            string name = GetName("\nPlease enter your name: ");
            Console.Write($"\nHello, {name}! ");

            bool repeat = true;
            while (repeat)
            {
                string[] userInput = GetInput("Please enter a sentence to be translated into Pig Latin: ");
                string pigLatin = Translate(userInput);
                Console.WriteLine($"\nYour entry translated to Pig Latin is:\n\n{pigLatin}\n");
                repeat = DoAgain($"Would you like to translate another sentence, {name}? (Y or N): ");
            }
            Console.WriteLine("Thank you for using the Pig Latin Translator!\n\nGoodbye!");
            Console.ReadLine();
        }

        //Method to obtain user name
        private static string GetName(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        //Method to prompt for input and store into string array
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

        //Method to test if string is alpha-numeric
        private static bool IsAlpha(string input)
        {
            char[] letters = input.ToCharArray();
            int numAndSym = 0;
            foreach(char letter in letters)
            {
                if (!char.IsLetter(letter))
                {
                    numAndSym++;
                }
            }
            if (numAndSym == 1 && input.Contains("'") && input.IndexOf("'") != 0 && input.IndexOf("'") != (input.Length - 1)) //This will allow contractions to be translated
            {
                return true;
            }
            else if (numAndSym == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to translate string into Pig Latin
        private static string Translate(string[] userInput)
        {
            int words = userInput.Count();
            string[] resultArray = new string[words]; //declare new array to store result
            for (int i = 0; i < words; i++)
            {
                string word = userInput[i];
                int position = word.ToLower().IndexOfAny(vowels);
                if (position < 0) //if no vowels, do not translate
                {
                    resultArray[i] = word;
                }
                else
                {
                    char[] arrayOne = word.ToCharArray(0, position);//cut letters before first vowel out, store in char array
                    string preString = new string(arrayOne);//cast char array to string, store in string variable
                    string postString = word.Substring(position); //store remaining letters in seperate string variable

                    if (!IsAlpha(word)) //calls IsAplha method to determine if input is valid word or contraction
                    {
                        resultArray[i] = word; //if not valid word or contraction, do not translate
                    }
                    else if (position == 0) //code for words that begin with vowel
                    {
                        resultArray[i] = string.Concat(word, "way");
                    }
                    else //catch-all for all other words
                    {
                        resultArray[i] = string.Concat(postString, preString, "ay");
                    }
                }
            }
            string resultString = string.Join(" ", resultArray); //combine array strings into one string
            return resultString;
        }

        //Method to control the while loop
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
