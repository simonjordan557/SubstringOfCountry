using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace SubstringOfCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Go();
        }

        static void Go()
        {
            string inputWords;

            

            {
                Console.WriteLine($"\nPlease enter the words you wish to test, separated by spaces. Press Enter when finished.\n");
                inputWords = Console.ReadLine();

                // Split input by white spaces
                string[] inputWordsArray = inputWords.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Strip input of any punctuation or numbers
                for (int i = 0; i < inputWordsArray.Length; i++)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (char c in inputWordsArray[i])
                    {
                        if (!char.IsPunctuation(c) && !char.IsDigit(c))
                        {
                            sb.Append(c);
                        }
                    }

                    inputWordsArray[i] = sb.ToString();
                }

                // Check user actually entered at least one letter before instantiating object
                if (Evaluator.ValidateFormat(inputWordsArray))
                {
                    Evaluator go = new Evaluator(inputWordsArray);
                }

                else
                {
                    Go();
                }

            }
        }
    }
}
