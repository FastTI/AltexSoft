using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_5
{
    #region Description of task
    /*Создать иерархиюклассов Person-Student-Teacher. В каждом классе должны быть свойства, а также виртуальная функция Print 
     * и переопределенная функция ToString(). Основная программа создает массив объектов Person или их наследников, 
     * после чего выдает его на экран. У каждого Teacher должен быть список Students, которыми он руководит, 
     * у каждого Student - Teacher, который им руководит.
     * 
     * Дляклассов Person-Student-Teacher реализовать и оттестировать ToString(), Equals(), GetHashCode().
     * 
     * Для классов Person-Student-Teacher реализовать статические методы RandomPerson, RandomStudent, RandomTeacher, 
     * которые возвращают случайного из некоторого статического массива.
     * 
     * С помощью is, as, GetType определить, сколько в массиве персон, студентов и преподавателей 
     * и перевести всех студентов на следующий курс.
     * Для классов Person-Student-Teacher реализовать глубокое клонирование, 
     * определив виртуальный метод Clone(). Клон должен возвращать точную копию по значению и типу. 
     * 
     * Проиллюстрировать Clone на примере контейнера персон - должны создаваться клоны объекты ровно тех типов,
     * которые содержатся в исходном контейнере.
     * 
     * Используя метод GetType() класса Student и метод BaseType() класса Type, вывести всех предков класса Student (написать общий метод)
*/
    #endregion

    
    class Program
    {
       
        static void Main(string[] args)
        {
            //Arrays Person,Teacher,Student
            Person[]  persons = InitPersons();
            Teacher[] teachers = InitTeachers();
            Student[] students = InitStudents();

            //some objects Person,Teacher,Student to demonstrate in tasks
            Person somePerson = new Person("Anrew", "Nikolaev", 34);
            Person somePerson2 = new Person("Anrew", "Nikolaev", 35);
            Teacher someTeacher = new Teacher(2, "Sergey", "Bubka", 45, "Programming", "Lecturer");
            Teacher someTeacher2 = new Teacher(1, "Serge", "Bubka", 45, "Programming", "Lecturer");
            Student someStudent = new Student("Katya", "Ivanova", 23, "Economy", 5, 2);
            Student someStudent2 = new Student("Katya", "Ivanova", 24, "Economy", 5, 1);

            
            #region 1.Teachers and them students

            Console.WriteLine("Task1:" );

            ImplementTask.PrintTeacherStudents(teachers,students);

            Console.WriteLine(new string('-',100));
            #endregion

            #region 2.Testing ToString(), Equals(), GetHashCode()

            Console.WriteLine("\nTask2\n");
            //Print overrided ToString()
            ImplementTask.TestOverridedToString(persons, teachers, students);

            //Print equal or not object with overrided methods Equals
            ImplementTask.TestOverridedEquals(somePerson, somePerson2);

            //Print equal or not object with overrided methods GetHashCode()
            ImplementTask.TestOverridedGetHashCode(somePerson, somePerson2);
            Console.WriteLine(new string('-', 100));
            #endregion

            #region 3.Implementation Random static methods
            Console.WriteLine("\nTask3\n");

            ImplementTask.ImplementRandomMethods(persons,teachers,students);

            Console.WriteLine(new string('-', 100));
            #endregion  

            #region 4. Count elements in objects Person,Student or Teacher and transfer all students to the next course
            Console.WriteLine("\nTask4\n");

            //if parameter will be students then all of it will transfered to another course 
            //and if upper course more than 6 (if 6 courses max) then course of student will be equally 0 that mining graduate student)
            ImplementTask.GetInnetTypes(students);

            Console.WriteLine(new string('-', 100));

            #endregion

            #region 5. Deep Clone()
            Console.WriteLine("\nTask5\n");

            Person clonedPerson = somePerson.Clone(somePerson2) as Person;
            clonedPerson.Print();

            Console.WriteLine(new string('-', 100));

            #endregion

            #region 6. GetParents with using Type.BaseType
            Console.WriteLine("\nTask6\n");

            ImplementTask.GetParents(someStudent);

            Console.WriteLine(new string('-', 100));
            #endregion

            
        }

        static Person[] InitPersons()
        {
            Person[] arrOfPersons = new Person[]
            {
                new Person("Andrew", "Andreev", 23),
                new Person("Sergey", "Sergeev", 40),
                new Person("Anna", "Sidorova", 35),
                new Person("Katrin", "Karpova", 30),
                new Person("Petro", "Ivanov", 40),

            };
            return arrOfPersons;
        }
        static Teacher[] InitTeachers()
        {
            Teacher[] arrOfTeachers = new Teacher[]
            {
                new Teacher(1,"Andrew", "Seleznew", 39,"Programming","Assistant professor"),
                new Teacher(2,"Sergey", "Znamenov", 26,"Philosophy","Postgraduate"),
                new Teacher(3,"Anna", "Sidorko", 35,"Economy", "Senior Lecturer"),
                new Teacher(4,"Katrin", "Karpova", 30,"Programming","lecturer"),
                new Teacher(5,"Petro", "Bogaturev", 40 ,"Economy","lecturer")

            };
            return arrOfTeachers;
        }
        static Student[] InitStudents()
        {
            Student[] arrOfStudents = new Student[]
            {
                new Student("Inna", "Dementieva", 20, "Programming", 3,1),
                new Student("Artem", "Dementiev", 21, "Programming", 4,1),
                new Student("Igor", "Igorev", 19, "Philosophy", 2,2),
                new Student("Anna", "Zviaginceva", 20, "Economy", 3,2),
                new Student("Stepan", "Menshov", 22, "Programming", 5,3),
                new Student("Anton", "Stepanov", 21, "Philosophy", 4,3),
                new Student("Denis", "Druz", 20, "Economy", 3,4),
                new Student("Alex", "Nadezgdin", 21, "Economy", 4,4),
                new Student("Inna", "Bulkina", 18, "Programming", 1,4)
            };
            return arrOfStudents;
        }
    }
}
