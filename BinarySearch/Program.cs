using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{

    class Program
    {
        public static void Main(string[] args)
        {
            var myList = new List<int> { 1, 3, 5, 7, 9 };
            Console.WriteLine(BinarySearch(myList, 3)); // => 1
            //Console.WriteLine(BinarySearch(myList, -1)); // => null gets printed as an empty string
        }

        private static int? BinarySearch(IList<int> list, int item)
        {
            var low = 0;
            var high = list.Count() - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                var guess = list[mid];
                if (guess == item) return mid;
                if (guess > item)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return null;
        }

        public static (bool, int) BinarySearch(int[] sortedValues, int value, bool descending = false)
        {
            // Внутренняя рекурсивная функция
            (bool, int) SearchOnRange(int left, int right)
            {
                if (left >= right)
                {
                    return (false, left);
                }

                if (sortedValues[left] == value)
                {
                    return (true, left);
                }

                int middle = left + (right - left) / 2;
                
                if (sortedValues[middle] == value)
                {
                    return middle == left + 1
                        ? (true, middle)
                        : SearchOnRange(left, middle + 1);
                }

                return sortedValues[middle] < value == descending
                    ? SearchOnRange(left, middle)
                    : SearchOnRange(middle + 1, right);
            }

            // Тело внешней нерекурсивной функции
            return SearchOnRange(0, sortedValues.Length);
        }
    }
}