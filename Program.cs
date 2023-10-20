

using System;

namespace _368_HW3
    // Yair Kimmel T0036400
    // children are 2x parent + 1 or 2x parent + 2 
    // parent is the floor of child-1/ 2 

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 52, 6, 8, 30, 14, 567, 15, 38, 10, 5 };
            Heap heap = new Heap(numbers);

            Console.WriteLine("Original: " + string.Join(", ", heap.array));

            heap.Heapify();

            Console.WriteLine("Heapified: " + string.Join(", ", heap.array));

            int iterations = heap.lastPosition;

            for (int i = 0; i < iterations ; i++)
            {
                heap.swap(heap.lastPosition, 0);
                heap.lastPosition--;
                heap.trickleDown(0);
 
            }

            Console.WriteLine("Sorted: " + string.Join(", ", heap.array));

        } 


        
    }
    class Heap {
        public int lastPosition;
        public int[] array;

    
        public Heap(int[] inputArray)
        {
            this.array = (int[])inputArray.Clone(); 
            this.lastPosition = array.Length - 1;
        }

        public void Heapify()
        {
            for (int i = lastPosition / 2; i >= 0; i--)
            {
                trickleDown(i);
            }
        }

        public int remove()
        {
            int tmp = array[0];
            swap(array[0], lastPosition--);
            trickleDown(array[0]);
            return tmp; 
        } 


        public void swap(int from, int to)
        {
            int tmp = array[from];
            this.array[from] = this.array[to];
            this.array[to] = tmp;

        }

        public void trickleDown(int parent)
        {
            int left = (2 * parent) + 1;
            int right = (2 * parent) + 2;

            if (left == lastPosition && array[parent] < array[left]) { 
                swap(parent, left);
                return; 

            }
            if (right == lastPosition && array[parent] < array[right])
            {
                swap(parent, right);
                return;
            }
            if (left >= lastPosition || right >= lastPosition)
            {
                return; 
            }
            if (array[left] > array[right] && array[parent] < array[left]) {
                swap(parent, left);
                trickleDown(left); 
            }
            if (array[parent] < array[right])
            {
                swap(parent, right); 
                trickleDown(right);
            }
        }

       

    }
}