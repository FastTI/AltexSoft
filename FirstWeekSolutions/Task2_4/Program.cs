using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4
{
    /*Дан двухмерный массив размерностью MxN. 
     * Необходимо заполнить его случайными числами в диапазоне от -500 до 500 
     * и отсортировать столбцы матрицы по сумме элементов столбца.*/
    class Program
    {
        private static void Main(string[] args)
        {
            int[,] arr = new int[5, 5];
            List<int> listOfSumCol; // For sum of columns

            //Fill two-dimensional array  random numbers in range   
            RandomTwoArray(arr, -500, 500);

            Skin("Random matrix",ConsoleColor.Yellow);
            PrintArray(arr);

            //Write sum of columns to list
            listOfSumCol = SumOfCol(arr);
            Skin("\nSum of columns matrix",ConsoleColor.Yellow);

            for (int i = 0; i < listOfSumCol.Count; i++)
            {
                Console.Write(i + 1 + "й <" + listOfSumCol[i] + "> ");
            }

            listOfSumCol.Sort();
            Skin("\n\nSorted sum of columns",ConsoleColor.Yellow);

            for (int i = 0; i < listOfSumCol.Count; i++)
            {
                Console.Write(i + 1 + "й <" + listOfSumCol[i] + "> ");
            }

            //Sorting by sum of columns
            SortBySumOfCol(arr);

            Skin("\n\nSorted array by sum of elements",ConsoleColor.Yellow);

            PrintArray(arr);
        }
        //Fill random numbers
        private static int[,] RandomTwoArray(int[,] arr, int from, int to)
        {
           Random rand = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(from, to);
                }
            }
            return arr;
        }

        //Print sums of columns
        private static List<int> SumOfCol(int[,] arr)
        {
            List<int> sumOfCol = new List<int>();
            int sumCol = 0;
            int tempR = 0, tempC = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sumCol += arr[tempR, tempC];
                    tempR++;
                }
                sumOfCol.Add(sumCol);
                tempC++;
                tempR = 0;
                sumCol = 0;
            }
            return sumOfCol;
        }

        //Method for coloring the text
        private static void Skin(string text,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Sort by sum elements of columns
        private static int[,] SortBySumOfCol(int[,] arr)
        {
            int sumCurrentCol = 0; //sum of current column
            int sumPrevCol = 0; //sum of previous column

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    sumPrevCol = 0;
                    for (int k = 0; k < arr.GetLength(0); k++)
                    {
                        sumPrevCol += arr[k, j - 1];
                    }
                    sumCurrentCol = 0;
                    for (int k = 0; k < arr.GetLength(0); k++)
                    {
                        sumCurrentCol += arr[k, j];
                    }

                    if (sumPrevCol > sumCurrentCol)
                    {
                        for (int k = 0; k < arr.GetLength(0); k++)
                        {
                            int temp = arr[k, j];
                            arr[k, j] = arr[k, j - 1];
                            arr[k, j - 1] = temp;
                        }

                    }
                }
            }

            return arr;
        }

        private static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
