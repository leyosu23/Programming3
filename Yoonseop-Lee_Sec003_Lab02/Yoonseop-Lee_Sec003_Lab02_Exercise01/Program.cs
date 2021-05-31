using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoonseop_Lee_Sec003_Lab02_Exercise01
{
    class Program 
    {
        static void Main(string[] args)
        {
            // create arrays of int, double and char
            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            char[] charArray = { 'H', 'E', 'L', 'L', 'O', 'W', 'O', 'R', 'L', 'D' };

            int intSearchKey = 5;
            Console.WriteLine(Search(intArray, intSearchKey));

            char charSearchKey = 'D';
            Console.WriteLine(Search(charArray, charSearchKey));

        } 
        private static int Search<T>(T[] inputArray, T searchKey)
        {
            foreach (var item in inputArray)
            {
                Console.Write($"{item} ");
            }
            Console.Write($"\nSearch key \"{searchKey}\" is the element of: ");
            
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (CompareTo<T>(inputArray[i], searchKey))
                {
                    return i;
                }
            }
            return -1;
        }

        static bool CompareTo<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }

    }
}
