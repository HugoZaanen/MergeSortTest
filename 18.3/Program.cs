using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Random();
            var data = new int[10];//create space for array

            //fill array with random ints in range 10-99
            for(var i = 0; i < data.Length;i++)
            {
                data[i] = generator.Next(10,100);
            }

            Console.WriteLine("Unsorted array:");
            Console.WriteLine(string.Join(" ", data + "\n"));//display array

            MergeSort(data);//sort array

            Console.WriteLine("Sorted array:");
            Console.WriteLine(string.Join(" ", data) + "\n");//display array
        }

        //calls recursive SortArray method to begin merge sorting
        public static void MergeSort(int[] values)
        {
            SortArray(values, 0, values.Length - 1)//sort entire array
        }

        //splits array, sorts subarray and merges subarrays into sorted array
        private static void SortArray(int[] values, int low, int high)
        {
            //test base case; size of array equals 1
            if((high - low) >= 1)//if not base case
            {
                int middle1 = (low + high) / 2;//calculate middle of array
                int middle2 = middle1 + 1;//calculate next element over

                //output split step
                Console.WriteLine($"Split:    {Subarray(values, low, high)}");
                Console.WriteLine($"          {Subarray(values, low, middle1)}");
                Console.WriteLine($"          {Subarray(values, middle2, high)}");

                //split array in half; sort each half (recursive calls)
                SortArray(values, low, middle1);//first half of array
                SortArray(values, middle2, high);//second half of array

                //merge two sorted arrays after split calls return
                MergeSort(values, low, middle1, middle2, high);
            }
        }

        //merge two sorted subarrays into one sorted subarray
        private static void MergeSort(int[] values, int left, int middle1, 
            int middle2, int right)
        {
            int leftIndex = left;//index into left subarray
            int rightIndex = middle2;//index into right subarray
            int combinedIndex = left;//index into temporary working array
            int[] combined = new int[values.Length];

            //output two subarrays before merging
            Console.WriteLine($"merge:   {Subarray(values, left, middle1)}");
            Console.WriteLine($"         {Subarray(values,middle2, right)}");

            //merge arrays until reaching end of either
            while(leftIndex <= middle1 && rightIndex <= right)
            {
                //place smaller of two current elements into result
                //and move to next space in arrays
                if(values[leftIndex] <= values[rightIndex])
                {
                    combined[combinedIndex++] = values[leftIndex++];
                }
                else
                {
                    combined[combinedIndex++] = values[rightIndex++];
                }
            }


        }
    }
}
