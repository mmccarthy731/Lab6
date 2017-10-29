using System;
using System.Linq;

namespace Lab6
{
    class Program
    {
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        static char[] okSymbols = { '.', '!', '?', ',', ';', ':' };

        static void Main(string[] args)
        {
            //Greet the user, get user name
            Console.WriteLine("This is the Pig Latin Translator!\n\nThis program takes a sentence that you enter and translates it into Pig Latin!");
            string name = GetName("\nPlease enter your name: ");
            Console.Write($"\nHello, {name}! ");

            bool repeat = true;
            while (repeat)
            {
                string[] userInput = GetInput("Please enter a sentence to be translated into Pig Latin: ");
                string pigLatin = GetTranslation(userInput);
                Console.WriteLine($"\nYour entry translated to Pig Latin is:\n\n{pigLatin}\n");
                repeat = DoAgain($"Would you like to translate another sentence, {name}? (Y or N): ");
            }
            Console.WriteLine("\nThank you for using the Pig Latin Translator!\n\nGoodbye!");
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
            if (String.IsNullOrEmpty(input)) //Ensure that the user did not input a null string or white space
            {
                Console.Write("You didn't input anything! ");
                return GetInput(prompt);
            }
            string[] arrayOne = input.Split(null as string[], StringSplitOptions.RemoveEmptyEntries); //splits sentence at each space and stores into an array
            return arrayOne;
        }

        //Method to translate string into Pig Latin
        private static string GetTranslation(string[] userInput)
        {
            int words = userInput.Count();
            string[] resultArray = new string[words]; //declare new array to store result
            for (int i = 0; i < words; i++)
            {
                string word = userInput[i];
                int length = word.Length - 1;
                if(word.IndexOfAny(okSymbols) == length) //Code that allows valid words to be translated, even if immediately followed by proper punctuation for sentence
                {
                    string punct = word.Substring(length);
                    char[] letters = word.ToCharArray(0, length);
                    string result = new string(letters);
                    string resultWord = TranslateWord(result);
                    resultArray[i] = string.Concat(resultWord, punct); //word is translated to Pig Latin, and the punctuation remains at the end of the string
                }
                else
                {
                    resultArray[i] = TranslateWord(word);
                }
            }
            string resultString = string.Join(" ", resultArray); //combine array strings into one string
            return resultString;
        }

        //Method to translate individual words of user input string
        private static string TranslateWord(string word)
        {
            int position = word.ToLower().IndexOfAny(vowels);
            if (position < 0) //if no vowels, do not translate
            {
                return word;
            }
            else
            {
                char[] letters = word.ToCharArray(0, position);//cut letters before first vowel out, store in char array
                string preString = new string(letters);//cast char array to string, store in string variable
                string postString = word.Substring(position); //store remaining letters in seperate string variable

                if (!IsAlpha(word)) //calls IsAplha method to determine if input is valid word or contraction
                {
                    return word; //if not valid word or contraction, do not translate
                }
                else if (position == 0) //code for words that begin with vowel
                {
                    word = string.Concat(word, "way");
                    return word;
                }
                else //catch-all for all other words
                {
                    word = string.Concat(postString, preString, "ay");
                    return word;
                }
            }
        }

        //Method to test if string is alpha-numeric
        private static bool IsAlpha(string input)
        {
            char[] letters = input.ToCharArray();
            int numAndSym = 0;
            foreach (char letter in letters)
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
