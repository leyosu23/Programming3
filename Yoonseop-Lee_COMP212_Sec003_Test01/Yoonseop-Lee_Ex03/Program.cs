using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoonseop_Lee_Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> wordsDictionary = CollectWords();
            DisplayDictionary(wordsDictionary);

            string[] duplicates = wordsDictionary
            .Where(dic => dic.Value > 1)
            .Select(dic => dic.Key)
            .ToArray();

            Console.Write($"Display the name of all the words repeated more than one: ");

            foreach (var item in duplicates)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }

        private static SortedDictionary<string, int> CollectWords()
        {
            // create a new sorted dictionary
            var dictionary = new SortedDictionary<string, int>();

            Console.Write("Enter a sentence: "); 
            string input = Console.ReadLine(); 
            string[] words = Regex.Split(input, @"\s+");

            foreach (var word in words)
            {
                var key = word.ToLower(); 
                if (dictionary.ContainsKey(key))
                {
                    ++dictionary[key];
                }
                else
                {
                    dictionary.Add(key, 1);
                }
            }
            return dictionary;
        }

        private static void DisplayDictionary<K, V>(
           SortedDictionary<K, V> dictionary)
        {
            Console.WriteLine(
               $"\nSorted dictionary contains:\n{"Key",-12}{"Value",-12}");

            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine($"{key,-12}{dictionary[key],-12}");
            }

        }


    }
}
