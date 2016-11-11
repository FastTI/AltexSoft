using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    //class for implementation tasks
    static class ImplementTask
    {


        #region Print objects Teacher ant Students
        //Print teachers and them students
        public static void PrintTeacherStudents(Teacher[] teachers, Student[] students)
        {
            int count = 0;
            foreach (var teacher in teachers)
            {
                Skin(String.Format("\nTeacher of {0} - {1} {2} and his students", teacher.Subject, teacher.Surname, teacher.Name),ConsoleColor.Yellow);
                foreach (var student in students)
                {
                    if (student.TeacherID == teacher.ID)
                    {
                        Console.WriteLine(student.ToString());
                        teacher.StudentsOfTeacher.Add(student);
                        count++;
                    }
                }
                if (count == 0)
                    Console.WriteLine("           At the moment it has no students");
                count = 0;
            }
        }

        #endregion

        #region ToString(), Equals(), GetHashCode()

        //Implementation ToEqual() Methods
        public static void TestOverridedEquals<T,V>(T obj1, V obj2) where T : class where V : class
        {
            Skin("\nOverrided Equals() \n", ConsoleColor.Yellow);
            if (obj1.Equals(obj2))
                Console.WriteLine("\nObject {0} equals object {1}",obj1.GetType().Name,obj2.GetType().Name);
            else
                Console.WriteLine("\nObject {0} not equals object {1}", obj1.GetType().Name, obj2.GetType().Name);
        }

        //Implementation GetHashCode()
        public static void TestOverridedGetHashCode<T, V>(T obj1, V obj2) where T : class where V : class
        {
            Skin("\nOverrided GetHashCode()\n", ConsoleColor.Yellow);
            Console.WriteLine("HashCode {0} object = {1}\nHashCode {2} object = {3}\n",obj1.GetType().Name,obj1.GetHashCode(),obj2.GetType().Name,obj2.GetHashCode());
            if (obj1.GetHashCode()==obj2.GetHashCode())
                Console.WriteLine("They are Equals");
            else
                Console.WriteLine("They are not Equals");
        }

        //Implementation ToString() Methods
        public static void TestOverridedToString(Person[] person, Teacher[] teacher, Student[] student)
        {
           Skin("\nOverride ToString() methods from Person,Teacher,Student\n",ConsoleColor.Yellow);
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(person[i].ToString());
                Console.WriteLine(teacher[i].ToString());
                Console.WriteLine(student[i].ToString());
            }
        }
        #endregion

        #region GetInnerTypes 

        public static void GetInnetTypes<T>(T[] obj) where T : class
        {
            var typeObj = obj.GetType().Name;

            int countP = 0;
            int countS = 0;
            int countT = 0;
            Student st;
            List<Student>tempSt = new List<Student>();
            
            foreach (var item in obj)
            {
                if (item != null)
                {
                    if (item is Person)
                        countP++;
                    if (item as Student != null)
                    {
                        countS++;
                        st = item as Student;
                        if (st.Course + 1 <= 5)
                            st.Course++;
                        else st.Course = 0; //it is like graduate
                        tempSt.Add(st);
                    }
                    if (item.GetType().Name == new Teacher().GetType().Name)
                        countT++;
                }
            }
            Console.WriteLine("There are {0} Persons; {1} Students; {2} Teachers\n", countP, countS, countT);
            if (tempSt.Count > 0)
            {
                Console.WriteLine("Students transfered to another course");
                foreach (var student in tempSt)
                    student.Print();
            }
            

        }

        #endregion

        #region Random static methods
        //Implementation statics random methods. its return random person, teacher and student
        public static void ImplementRandomMethods(Person[] personArr,Teacher[] teacherArr, Student[] studentArr )
        {
            
            Skin("\nRandom person\n",ConsoleColor.Yellow);
            Person.RandomPerson(personArr);
            Skin("\nRandom teacher\n",ConsoleColor.Yellow);
            Teacher.RandomTeacher(teacherArr);
            Skin("\nRandom student\n",ConsoleColor.Yellow);
           // Student.RandomStudent(studentArr);
            

        }
      
        
        #endregion

        #region Parents for Object
        //Get Parent obgects
        public static void GetParents<T>(T obj) where T : class
        {
            Type i = obj.GetType();

            foreach (var type in i.Assembly.GetTypes())
            {
                if (type.Name == obj.GetType().Name)
                {
                    Console.WriteLine("{0} derived from: ", type.Name);
                    var derived = type;
                    do
                    {
                        derived = derived.BaseType;
                        if (derived != null)
                            Console.WriteLine("   {0}", derived.Name);
                    } while (derived != null);
                    Console.WriteLine();
                }

            }
        }

        #endregion


        //Just Skin for foreground console color
        public static void Skin(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

}
