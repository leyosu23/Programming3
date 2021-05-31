using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoonseop_Lee_Sec003_Lab01_Exercise02
{
    class Program
    {
        public delegate bool NumberPredicate(double number);
        static void Main(string[] args)
        {
            double[] doubleArr = { 20, 31.1, 22, 28, 13.3, 14.4, 15.5, 16.6, 50, 57.7, 69.9, 80.1 };
            NumberPredicate GradesPredicate = value => value >= 50;
            FilterArray(doubleArr, GradesPredicate);
        }

        private static void FilterArray(double[] Array, NumberPredicate predicate)
        {
            List<double> result = new List<double>();

            foreach (double item in Array)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            Console.Write("Use a lambda expression to filter numbers (grater than or equal to 50): ");
            foreach (double item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
