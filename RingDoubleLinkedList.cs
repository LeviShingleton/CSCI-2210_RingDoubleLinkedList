///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Mini Assignment - Ring Double Linked List
// Description: Basic implementation of ring double linked list.
//
///////////////////////////////////////////////////////////////////////////////

using System.Collections;

namespace RingDoubleLinkedList
{
    internal class RingDoubleLinkedList<T> : ICollection<T>, IEnumerable<T> where T: IComparable<T>
    {
        // Doubly linked - nodes have previous and next
        // Ring - head's previous is tail, tails next is head

        DoubleLinkedListNode<T> head, tail;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        #region Operators
        public static RingDoubleLinkedList<T> operator +(RingDoubleLinkedList<T> list, T item)
        {
            list.Add(item);
            return list;
        }

        public static RingDoubleLinkedList<T> operator -(RingDoubleLinkedList<T> list, T item)
        {
            list.Remove(item);
            return list;
        }
        #endregion

        /// <summary>
        /// Removes the head node from the linked list and returns its stored value.
        /// </summary>
        /// <returns>The value of the removed head node.</returns>
        public T? Pop()
        {
            var node = head;
            head = node?.Next;
            head.Previous = tail;
            tail.Next = head;
            Count--;

            return (node != null) ? node.Value : default(T);
        }

        /// <summary>
        /// Places a new node at the head of the linked list.
        /// </summary>
        /// <param name="item">The value to be stored in the new (head) node.</param>
        public void Add(T item)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(item);
            Count++;

            if (head == null)
            {
                head = node;
                tail = node;
                head.Next = head.Previous = head;
                return;
            }
            // Set next of new node to current head
            node.Next = head;
            // Set previous of current head to the generated node
            head.Previous = node;
            
            

            // Set head to generated node.
            head = node;
            tail.Next = head;
            head.Previous = tail;

            
        }

        /// <summary>
        /// Removes references to head and tail of linked list, effectively clearing its contents.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Determines if the RingDoubleLinkedList contains a given item.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <returns>Bool indicating if item was found.</returns>
        public bool Contains(T item)
        {
            var currentNode = head;

            while (currentNode is not null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var node = head;

            for (int i = arrayIndex; i < array.Length; i++)
            {
                array[i] = node.Value;
                node = node?.Next;
            }
        }

        /// <summary>
        /// Searches for the first instance of a node containing an item and removes it from the linked list.
        /// </summary>
        /// <param name="item">The value to be removed from the list.</param>
        /// <returns>Boolean value indicating if the item was successfully removed.</returns>
        public bool Remove(T item)
        {
            var currentNode = head;

            if (head.Value.Equals(item))
            {
                head = head.Next;
                head.Previous = tail;
                tail.Next = head;
                Count--;
                return true;
            }

            while (currentNode != null)
            {
                if (currentNode.Next != null && currentNode.Next.Value.Equals(item))
                {
                    // If tail is being removed, make sure that head's previous is currentNode.
                    if (currentNode.Next == tail)
                    {
                        head.Previous = currentNode;
                        tail = currentNode;
                    }
                    // Remove it from the list
                    currentNode.Next = currentNode.Next?.Next;
                    currentNode.Next.Previous = currentNode;
                    Count--;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        /// <summary>
        /// Iteration support
        /// </summary>
        /// <returns>IEnumerator for looping</returns>
        public IEnumerator<T> GetEnumerator()
        {
            DoubleLinkedListNode<T> currentNode = head;

            if (currentNode != null)
            {
                do
                {
                    yield return currentNode.Value;
                    currentNode = currentNode.Next;
                }
                while (currentNode != head);
            }
            else
            {
                Console.WriteLine("It is not possible to loop through the ring double linked list.");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
