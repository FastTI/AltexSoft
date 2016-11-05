using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    /*Реализовать класс для организации работы со списком студентов группы, 
     * включив следующие данные: ФИО, год рождения, домашний адрес, какую школу окончил. 
     * Вывести информацию о студентах, окончивших заданную школу, отсортировав их по году рождения.*/
    class Program
    {
        static void Main(string[] args)
        {
            var listOfStudents = new List<Students>()
              { 
                new Students(){FSP = "Андрей Андреев Андреевич",BirthDay = new DateTime(1988,10,23),Adress = "Пушкина 41", NumberOfSchool = 10},
                new Students(){FSP = "Петр Петров Петрович",BirthDay = new DateTime(1989,10,25),Adress = "Пушкина 23", NumberOfSchool = 10},
                new Students(){FSP = "Игорь Игорев Игоревич",BirthDay = new DateTime(1987,5,12),Adress = "Ленина 100", NumberOfSchool = 13},
                new Students(){FSP = "Денис Денисов Денисович",BirthDay = new DateTime(2000,6,1),Adress = "Калинина 4", NumberOfSchool = 13},
                new Students(){FSP = "Сергей Сергеев Сергеевич",BirthDay = new DateTime(2000,12,6),Adress = "Гагарина 7", NumberOfSchool = 13}
              };

            Console.Write("At just moment list has information about school № ");

            //List of school
            List<int> numOfSchool = GetNumOfSchool(listOfStudents);

            foreach (var i in numOfSchool)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Graduates(listOfStudents);
        }

        //Return list numbers of school
        static List<int> GetNumOfSchool(List<Students> students)
        {
            var result = new List<int>();
            foreach (Students student in students)
            {
                if (!result.Contains(student.NumberOfSchool))
                    result.Add(student.NumberOfSchool);
            }
            return result;
        }

        //Print list of graduates sorted by birthday
        static void Graduates(List<Students> listOfStudents)
        {
            try
            {
                Console.Write("\nSchool № ");
                uint schoolNumber = Convert.ToUInt16(Console.ReadLine());

                //Sorting list of students
                listOfStudents.Sort(new Students());
                int countS = 0;//count graduate of school

                foreach (var list in listOfStudents)
                {
                    //If school equal with school from list print info about student
                    if (list.NumberOfSchool == schoolNumber)
                    {
                        Console.WriteLine("\n{0} \n{1} \n{2} ", list.FSP, list.Adress,
                        list.BirthDay.ToShortDateString());
                        countS++;
                    }

                }
                if (countS > 0)
                    Console.WriteLine("\nAll students who ended School № {0} - {1}", schoolNumber, countS);
                else
                    Console.WriteLine("In list no one student from this school");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error\n          Maybe you enter wrong school format");
            }
        }

    }
}
