using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task4_2
{
    /*Реализовать класс для организации работы со списком студентов группы,
    * включив следующие данные: ФИО, номер группы, результаты сдачи трех экзаменов. 
    * Вывести информацию о студентах, успешно сдавших сессию, отсортировав по номеру группы.*/
    class Program
    {
        static void Main(string[] args)
        {
           string fileOfStudents = "Students.txt";//файл в папке Debug
           var listOfStudents = ListOfStudentsFromFile(fileOfStudents);


            int count = 0;
            listOfStudents.Sort(new Students());
            Console.WriteLine("Экзамен сдали: \n");
            foreach (var list in listOfStudents)
            {
                for (int i = 0; i < list.Ratings.Length; i++)
                {
                    if (list.Ratings[i] == "зачет")
                    {
                        count++;
                    }
                }

                if (count == 3)
                    Console.WriteLine("{0}\n№ группы: {1}",list.FSP,list.GroupNum);
                
                count = 0;
            }

        }

        //Список студентов из файла
        static List<Students> ListOfStudentsFromFile(string fileStudents)
        {
            List<Students> listSt = new List<Students>();
            using (StreamReader stream = new StreamReader(fileStudents, Encoding.Default))
            {
                while (!stream.EndOfStream)
                {
                    string[] lines = stream.ReadLine().Split(';');
                    listSt.Add(new Students() { FSP = lines[0], GroupNum = Convert.ToInt32(lines[1]), Ratings = new string[] { lines[2], lines[3], lines[4] } });
                }

            }
            return listSt;
        }



    }
}
