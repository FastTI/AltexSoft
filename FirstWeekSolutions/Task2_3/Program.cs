using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3
{
    /*Дан одномерный массив размерностью N. 
    * Необходимо заполнить его случайными числами в диапазоне от -500 до 500 и отсортировать. */       
    class Program
    {
        static void Main(string[] args)
        {
            var arrNumbs = new int[100];

            //Array fill random elements
            RandomNumbers(arrNumbs, -500, 500);

            Console.WriteLine("Not sorted array\n");
            foreach (var elem in arrNumbs)
            {
                Console.Write(elem + " ");
            }
            //Sorting array
            SimpleSort(arrNumbs);

            Console.WriteLine("\n\nSorted array\n");
            foreach (var i in arrNumbs)
            {
                Console.Write(i + " ");
            }
        }

        private static int[] RandomNumbers(int[] arr, int from, int to)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(from, to);
            }
            return arr;

        }

        static int[] SimpleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }

    }
}
