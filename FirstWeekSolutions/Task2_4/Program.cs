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
            List<int> ListOfSumCol; // для суммы столбцов

            //Заполнение двумерного массива случайными числами в у казанном диапазоне   
            RandomTwoArray(arr, -500, 500);
            YellowSkin("Рандомная матрица");
            PrintArray(arr);

            //В список записываетс сумма столбцов
            ListOfSumCol = SumOfCol(arr);
            YellowSkin("\nСумма столбцов матрицы");

            for (int i = 0; i < ListOfSumCol.Count; i++)
            {
                Console.Write(i + 1 + "й <" + ListOfSumCol[i] + "> ");
            }

            ListOfSumCol.Sort();
            YellowSkin("\n\nОтсортированные суммы столбцов");

            for (int i = 0; i < ListOfSumCol.Count; i++)
            {
                Console.Write(i + 1 + "й <" + ListOfSumCol[i] + "> ");
            }

            //Сортировка по сумме столбцов
            SortBySumOfCol(arr);
            YellowSkin("\n\nОтсортированный по сумме элементов массив");
            PrintArray(arr);
        }
        //Заполнить случайными числами
        private static int[,] RandomTwoArray(int[,] arr, int from, int to)
        {
            //int[,] arr = new int[col,row];

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

        //Вывести суммы столбцов
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

        private static void YellowSkin(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Сортировка по сумме элементов столбца
        private static int[,] SortBySumOfCol(int[,] arr)
        {
            int sumCurrentCol = 0; //сумма текущего столбца
            int sumPrevCol = 0; //сумма предыдущего столбца

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
