///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Mini Assignment - Ring Double Linked List
// Description: Basic implementation of ring double linked list.
//
///////////////////////////////////////////////////////////////////////////////

namespace RingDoubleLinkedList
{
    internal class DoubleLinkedListNode<T>
    {
        public T Value;
        public DoubleLinkedListNode<T> Next, Previous;


        public DoubleLinkedListNode(T element)
        {
            Value = element;
        }
        public DoubleLinkedListNode()
        {
            Value = default(T);
        }
    }
}
