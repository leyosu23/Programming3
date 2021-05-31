using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public class LinkedList<T> where T : IComparable<T>
    {   // class List declaration
        private ListNode<T> firstNode;
        private ListNode<T> lastNode;
        private string name; // string like "list" to display

        // construct empty List with specified name
        public LinkedList(string listName)
        {
            name = listName;
            firstNode = lastNode = null;
        }

        // construct empty List with "list" as its name 
        public LinkedList() : this("list") { }

        // Insert object at front of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, firstNode refers to new node.
        public void InsertAtFront(T insertItem)
        {
            if (IsEmpty())
            {
                firstNode = lastNode = new ListNode<T>(insertItem);
            }
            else
            {
                firstNode = new ListNode<T>(insertItem, firstNode);
            }
        }

        // Insert object at end of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, lastNode's Next property refers to new node.
        public void InsertAtBack(T insertItem)
        {
            if (IsEmpty())
            {
                firstNode = lastNode = new ListNode<T>(insertItem);
            }
            else
            {
                lastNode = lastNode.Next = new ListNode<T>(insertItem);
            }
        }

        // remove first node from List
        public object RemoveFromFront()
        {
            if (IsEmpty())
            {
                throw new EmptyListException(name);
            }

            object removeItem = firstNode.Data; // retrieve data

            // reset firstNode and lastNode references
            if (firstNode == lastNode)
            {
                firstNode = lastNode = null;
            }
            else
            {
                firstNode = firstNode.Next;
            }

            return removeItem; // return removed data
        }

        // remove last node from List
        public object RemoveFromBack()
        {
            if (IsEmpty())
            {
                throw new EmptyListException(name);
            }

            object removeItem = lastNode.Data; // retrieve data

            // reset firstNode and lastNode references
            if (firstNode == lastNode)
            {
                firstNode = lastNode = null;
            }
            else
            {
                ListNode<T> current = firstNode;

                // loop while current.Next is not lastNode
                while (current.Next != lastNode)
                {
                    current = current.Next; // move to next node
                }

                // current is new lastNode
                lastNode = current;
                current.Next = null;
            }

            return removeItem; // return removed data
        }

        // return true if List is empty
        public bool IsEmpty()
        {
            return firstNode == null;
        }

        // output List contents
        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine($"Empty {name}");
            }
            else
            {
                Console.Write($"The {name} is: ");

                ListNode<T> current = firstNode;

                // output current node data while not at end of list
                while (current != null)
                {
                    Console.Write($"{current.Data} ");
                    current = current.Next;
                }

                Console.WriteLine("\n");
            }
        }

        public T Minimum()
        {
            ListNode<T> current = firstNode;
            T min;

            if (firstNode == null)
            {
                firstNode = null;
                min = firstNode.Data;
                return min;
            }
            else
            {
                min = firstNode.Data;

                while (current != null)
                {
                    if (min.CompareTo(current.Data) > 0)
                    {
                        min = current.Data;
                    }
                    current = current.Next;
                }
                return min;
            }
        }

        public T GetLastNode()
        {
            return lastNode.Data;
        }


    }
}
