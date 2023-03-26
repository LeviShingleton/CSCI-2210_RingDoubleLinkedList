namespace RingDoubleLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RingDoubleLinkedList<int> myList = new RingDoubleLinkedList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(12);
            myList.Add(756);
            myList.Add(922);
            myList.Add(54);


            Console.WriteLine($"There are {myList.Count} nodes in myList.");
            foreach (var num in myList)
            {
                Console.WriteLine(num.ToString());
            }

            // Remove middle
            Console.WriteLine("\nRemoving 3...");
            myList.Remove(3);
            foreach (var num in myList)
            {
                Console.WriteLine(num.ToString());
            }
            Console.WriteLine($"There are {myList.Count} nodes in myList.\n");

            // Pop head
            Console.WriteLine($"{myList.Pop()} was popped from the list.");
            foreach (var num in myList)
            {
                Console.WriteLine(num.ToString());
            }
            Console.WriteLine($"There are {myList.Count} nodes in myList.\n");

            // Remove tail
            Console.WriteLine("Removing 1...");
            myList.Remove(1);
            foreach (var num in myList)
            {
                Console.WriteLine(num.ToString());
            }
            Console.WriteLine($"There are {myList.Count} nodes in myList.\n");

            Console.WriteLine("Remainders:");
            foreach (var num in myList)
            {
                Console.WriteLine(num.ToString());
            }

            Console.WriteLine("\nClearing...");
            myList.Clear();
            if(myList.Count == 0)
            {
                Console.WriteLine("The list's Count is 0.");
            }
            else if (myList.Count > 0) 
            {
                Console.WriteLine("The list's Count is greater than 0.");            
            }

            foreach (var num in myList)
            {
                Console.WriteLine(num.ToString());
            }
        }
    }
}