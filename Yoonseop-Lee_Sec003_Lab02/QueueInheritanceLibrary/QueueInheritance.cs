using System;
using LinkedListLibrary;

namespace QueueInheritanceLibrary
{
    // class QueueInheritance inherits List's capabilities
    public class QueueInheritance<T> : LinkedListLibrary.LinkedList<T> where T : IComparable<T>
    {
        // pass name "queue" to List constructor
        public QueueInheritance() : base("queue") { }

        // place dataValue at end of queue by inserting 
        // dataValue at end of linked list
        public void Enqueue(T dataValue)
        {
            InsertAtBack(dataValue);
        }

        // remove item from front of queue by removing
        // item at front of linked list
        public object Dequeue()
        {
            return RemoveFromFront();
        }

        public T GetMinimum()
        {
            return Minimum();
        }
        public T GetLast()
        {
            return GetLastNode();
        }

    }
}

