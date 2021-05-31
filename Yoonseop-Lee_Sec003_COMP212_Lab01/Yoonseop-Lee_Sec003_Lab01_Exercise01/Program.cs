using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoonseop_Lee_Sec003_Lab01_Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, string, string[]> min = (string string1, string string2, string string3) =>
            {
                string[] strArray = { string1, string2, string3 };
                Array.Sort(strArray);
                return strArray;
            };
            string firstPerson = "Tom";
            string secondPerson = "Smith";
            string thirdPerson = "Jhon";
            Console.Write($"Three people {firstPerson} , {secondPerson} , {thirdPerson}" +
                $" in the alphabetical order = > ");
            DisplayStringArray(min(firstPerson, secondPerson, thirdPerson));


            Action<int, int, int> avg = (int value1, int value2, int value3) =>
            {
                int result = (value1 + value2 + value3) / 3;
                Console.WriteLine($"Average score of \"{value1}\", \"{ value2}\", \"{ value3}\" is {result}");
            };
            avg(100, 90, 80);
        }

        // Display String Array
        public static void DisplayStringArray(string[] strArray)
        {
            foreach (string item in strArray)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
