using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoonseop_Lee_Sec003_Lab02_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("This is to test whether the extension method count can return a right answer or not");

            CountWords countw = new CountWords();
            Console.WriteLine(countw.Uppercase(sb.ToString()));
            // Extension method
            Console.WriteLine(countw.Count2(sb.ToString()));
        }
    }
    public static class CountWordsExtensions
    {
        public static int Count2(this CountWords value, string sentence)
        {
            string[] strArray = sentence.Split();
            int result = strArray.Length;
            return result;
        }
    }
}
