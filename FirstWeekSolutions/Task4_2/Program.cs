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
            var listOfStudents = ListOfStudentsFromFile();
            var listSuccesfulSt = new List<Students>();//для создания списка студентов сдавших сессию
            int count = 0;//счетчик зачетов

            foreach (var list in listOfStudents)
            {
                foreach (var r in list.Ratings)
                {
                    if (r.Value == "зачет")
                        count++;
                }
                if (count == list.Ratings.Values.Count)
                    listSuccesfulSt.Add(list);

                count = 0;
            }

            listSuccesfulSt.Sort(new Students());
            Console.WriteLine("Экзамен сдали: \n");
            foreach (var st in listSuccesfulSt)
            {
                Console.WriteLine("\n{0}  № группы:{1}\nРезультаты:", st.FSP, st.GroupNum);
                foreach (var rating in st.Ratings)
                {
                    Console.WriteLine(new string(' ', 10) + "{0}: {1}", rating.Key, rating.Value);
                }
            }

        }

        //Список студентов из файла
        static List<Students> ListOfStudentsFromFile()
        {
            string fileOfStudents = "Students.txt";
            List<Students> listSt = new List<Students>();
            using (StreamReader stream = new StreamReader(fileOfStudents, Encoding.Default))
            {
                while (!stream.EndOfStream)
                {
                    string[] lines = stream.ReadLine().Split(';');
                    listSt.Add(new Students()
                    {
                        FSP = lines[0],
                        GroupNum = Convert.ToInt32(lines[1]),
                        Ratings = new Dictionary<string, string>()
                        {
                            {lines[2],lines[3]},
                            {lines[4],lines[5]},
                            {lines[6],lines[7]}
                        }
                    });
                }

            }
            return listSt;
        }



    }
}
