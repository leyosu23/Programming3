using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary;
namespace MyLinkedListLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var intList = new LinkedListLibrary.LinkedList<int>();
            var doubleList = new LinkedListLibrary.LinkedList<double>();

            // create data to store in List
            int aInt = 12;
            int bInt = 36;
            int cInt = 42;
            int dInt = 52;
            int eInt = 62;
            double aDouble = 47.13;
            double bDouble = 77.53;
            double cDouble = 12.34;
            double dDouble = 30.31;
            double eDouble = 15.39;

            // use List insert methods       
            intList.InsertAtFront(aInt);
            intList.InsertAtFront(bInt);
            intList.InsertAtFront(cInt);
            intList.InsertAtFront(dInt);
            intList.InsertAtFront(eInt);
            intList.Display();
            Console.WriteLine($"Minimum of intList is {intList.Minimum()}\n");
            Console.WriteLine($"Last Node of intList is { intList.GetLastNode()}\n\n");

            doubleList.InsertAtBack(aDouble);
            doubleList.InsertAtFront(bDouble);
            doubleList.InsertAtFront(cDouble);
            doubleList.InsertAtFront(dDouble);
            doubleList.InsertAtFront(eDouble);
            doubleList.Display();
            Console.WriteLine($"Minimum of doubleList is {doubleList.Minimum()}\n");
            Console.WriteLine($"Last Node of doubleList is { doubleList.GetLastNode()}\n");


            // remove data from list and display after each removal
            //try
            //{
            //    object removedObject = list.RemoveFromFront();
            //    Console.WriteLine($"{removedObject} removed");
            //    list.Display();

            //    removedObject = list.RemoveFromFront();
            //    Console.WriteLine($"{removedObject} removed");
            //    list.Display();

            //    removedObject = list.RemoveFromBack();
            //    Console.WriteLine($"{removedObject} removed");
            //    list.Display();

            //    removedObject = list.RemoveFromBack();
            //    Console.WriteLine($"{removedObject} removed");
            //    list.Display();
            //}
            //catch (EmptyListException emptyListException)
            //{
            //    Console.Error.WriteLine($"\n{emptyListException}");
            //}
        }
    }
}
