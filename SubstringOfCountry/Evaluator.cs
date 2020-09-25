using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.ExceptionServices;

namespace SubstringOfCountry
{
    class Evaluator
    {
        List<string> countryList = new List<string>();
        List<string> confirmedList = new List<string>();

        public Evaluator(string[] inputWords)
        {
            // Load in the list of countries
            using (StreamReader sr = new StreamReader("countries.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string countryString = sr.ReadLine();
                    countryString = countryString.ToUpper().Trim();
                    countryList.Add(countryString);
                }
                sr.Close();
            }

            Console.Clear();

            // For each inputted word, check it against the list of countries to see if it is present anywhere. If so, add it to the confirmed list.
            for (int i = 0; i < inputWords.Length; i++)
            {
                confirmedList.Clear();

                // (Make sure this word was not already stripped clean after removal of digits and punctuation).
                if (inputWords[i] != "")
                {
                    inputWords[i] = inputWords[i].ToUpper().Trim();

                    foreach (var country in countryList)
                    {
                        if (country.Contains(inputWords[i]))
                        {
                            confirmedList.Add(country);
                        }
                    }

                    // Output the results to the user.
                    if (confirmedList.Count <= 0)
                    {
                        Console.WriteLine($"\n\nYour word {inputWords[i]} is not part of a country name.");
                    }

                    else
                    {
                        Console.WriteLine($"\n\nYour word {inputWords[i]} is part of the following country names:");

                        foreach (var country in confirmedList)
                        {
                            Console.WriteLine(country);
                        }
                    }
                }
            }
        }
        public static bool ValidateFormat(string[] testWords)
        {
            // For each word in the string array
            for (int j = 0; j < testWords.Length; j++)
            {
                // Check user actually entered letters before instantiating object
                for (int i = 0; i < testWords[j].Length; i++)
                {
                    char testChar = testWords[j][i];
                    if (!(Char.IsLetter(testChar)))
                    {
                        Console.WriteLine($"{testWords[j]} is not valid. A to Z only.");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
