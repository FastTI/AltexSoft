using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_3
{
    /*Реализовать класс для организации работы со списком багажных ведомостей камеры хранения, 
     * включив следующие данные: ФИО пассажира, количество вещей, общий вес вещей. 
     * Вывести информацию о тех пассажирах, средний вес багажа которых превышает заданный, 
     * отсортировав их по количеству вещей, сданных в камеру хранения*/
    class Program
    {
        static void Main(string[] args)
        {
            List<BaggageList> listOfBagage = ListOfBaggageFromFile();
            float maxWeight = 0;

            do
            {
                var listOfOverBaggage = new List<BaggageList>();//list of passangers with overweight
                Console.WriteLine("Enter max weight:");
                
                    string input = Console.ReadLine();
                    //Check to correct weight
                    while (!float.TryParse(input, out maxWeight) || float.Parse(input) <= 0)
                    {
                        Console.WriteLine("Enter correct weight");
                        input = Console.ReadLine();
                    }
                    
                    //Check hwo overweight and writing to list
                    foreach (var baggage in listOfBagage)
                    {
                        if (baggage.ThingsWeight/baggage.NumOfThings > maxWeight)
                            listOfOverBaggage.Add(baggage);
                    }
                     
                    if (listOfOverBaggage.Count>0)
                    {
                        Console.WriteLine("\nOverweight passengers: \n");
                        listOfOverBaggage.Sort(new BaggageList());
                        foreach (var bag in listOfOverBaggage)
                        {
                            Console.WriteLine(bag.ToString());
                        }
                    }
                    else Console.WriteLine("Passangers with overweight not found");
 
            } while (EscPress());
        }

        //BaggageList from file
        static List<BaggageList> ListOfBaggageFromFile()
        {
            string fileOfBaggage = "BaggageList.txt";
            var listBg = new List<BaggageList>();
            using (var stream = new StreamReader(fileOfBaggage, Encoding.Default))
            {
                while (!stream.EndOfStream)
                {
                    string[] lines = stream.ReadLine().Split(';');
                    listBg.Add(new BaggageList()
                    {
                      FirstName=lines[0],
                      Surname= lines[1],
                      Patronymic= lines[2],
                      NumOfThings = Convert.ToInt16(lines[3]),
                      ThingsWeight = Convert.ToSingle(lines[4])
                    }
                    );
                }

            }
            return listBg;
        }
        
        //For end of cycle
        static bool EscPress()
        {
            var cki = new ConsoleKeyInfo();
            Console.WriteLine("\nFinish operation?\nPress any key to continue/Press Esc to quit");
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return false;
            }
            else
            Console.Clear();
         
            return true;
        }


    }
}
