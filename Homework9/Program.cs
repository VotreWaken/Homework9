using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class Program
    {
        public delegate bool DelegateArray(int num);
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            DelegateArray[] filter_arr = new DelegateArray[10];
            filter_arr[0] += Even_numbers;

            int[] even_arr = FilterArray(arr, filter_arr[0]);
            Console.Write($"Even: "); Show_arr(even_arr);

            filter_arr[1] += Odd_numbers;

            int[] odd_arr = FilterArray(arr, filter_arr[1]);
            Console.Write($"Odd: "); Show_arr(odd_arr);

            filter_arr[2] += Prime_numbers;

            int[] prime_arr = FilterArray(arr, filter_arr[2]);
            Console.Write($"Prime: "); Show_arr(prime_arr);

            filter_arr[3] += Fibbonaci;
            int[] fibonacci_arr = FilterArray(arr, filter_arr[3]);
            Console.Write($"Fibonacci: "); Show_arr(fibonacci_arr);
        }
        static void Show_arr(int[] _arr)
        {
            foreach (int item in _arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        private static bool Even_numbers(int num)
        {
            return num % 2 == 0;
        }
        private static bool Odd_numbers(int num)
        {
            return num % 2 != 0;
        }
        private static bool Prime_numbers(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;

        }

        private static bool Fibbonaci(int num)
        {
            int a = 0;
            int b = 1;

            while (b < num)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            return b == num;
        }
        static int[] FilterArray(int[] numbers, DelegateArray filter)
        {
            int[] result = new int[numbers.Length];
            int index = 0;

            foreach (int number in numbers)
            {
                if (filter(number))
                {
                    result[index] = number;
                    index++;
                }
            }

            Array.Resize(ref result, index);

            return result;
        }
    }
}
