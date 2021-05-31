// Fig. 19.17: QueueTest.cs
// Testing class QueueInheritance.
using System;
using QueueInheritanceLibrary;
using LinkedListLibrary;

// demonstrate functionality of class QueueInheritance
class QueueTest
{
    static void Main()
    {
        QueueInheritance<int> intQueue = new QueueInheritance<int>();
        QueueInheritance<double> doubleQueue = new QueueInheritance<double>();

        // create objects to store in the queue
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

        // use method Enqueue to add items to queue
        intQueue.Enqueue(aInt);
        intQueue.Enqueue(bInt);
        intQueue.Enqueue(cInt);
        intQueue.Enqueue(dInt);
        intQueue.Enqueue(eInt);
        intQueue.Display();
        intQueue.Minimum();
        Console.WriteLine($"Minumum in the intQueue: {intQueue.GetMinimum()}");
        Console.WriteLine($"Last value in the intQueue: {intQueue.GetLast()}\n\n");

        doubleQueue.Enqueue(aDouble);
        doubleQueue.Enqueue(bDouble);
        doubleQueue.Enqueue(cDouble);
        doubleQueue.Enqueue(dDouble);
        doubleQueue.Enqueue(eDouble);
        doubleQueue.Display();
        Console.WriteLine($"Minumum in the doubleQueue: {doubleQueue.GetMinimum()}");
        Console.WriteLine($"Last value in the doubleQueue: {doubleQueue.GetLast()}\n");

        // use method Dequeue to remove items from queue
        //object removedObject = null;

        // remove items from queue
        //try
        //{
        //    while (true)
        //    {
        //        removedObject = intQueue.Dequeue();
        //        Console.WriteLine($"{removedObject} dequeued");
        //        intQueue.Display();
        //    }
        //}
        //catch (EmptyListException emptyListException)
        //{
        //    // if exception occurs, write stack trace
        //    Console.Error.WriteLine(emptyListException.StackTrace);
        //}
    }
}

