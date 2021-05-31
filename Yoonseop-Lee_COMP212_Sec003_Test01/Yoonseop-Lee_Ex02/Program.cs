using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoonseop_Lee_Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int>() { 5, 4, 3, 2, 1, 6, 7, 8, 15, 10 };

            var filtered =
            from value in values 
            where value % 2 ==0
            orderby value
            select value;

            var filtered2 =
            from value in values 
            where value % 2 != 0 && value % 5 == 0
            orderby value
            select value;

            // display filtered results
            Console.Write("Even values: ");
            foreach (var element in filtered)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();

            // display filtered results
            Console.Write("Odd values and multiplied by 5: ");
            foreach (var element in filtered2)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();


        }
    }
}
