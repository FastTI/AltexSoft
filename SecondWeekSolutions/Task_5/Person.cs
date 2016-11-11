using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
   public class Person
    {

        public string Name { get; set;}
        public string Surname { get; set; }

        public byte Age { get; set; }


       //Constructor by default need for reflection deep clone
        public Person()
        {

        }
        public Person(string name, string surname, byte age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        public virtual void Print()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}",Name,Surname,Age);
        }

        public override string ToString()
        {
            //return String.Format("Overrided ToString() Method from {0}", this.GetType().Name);
            return String.Format("\nName: {0}\nSurname: {1}\nAge: {2}", Name, Surname, Age);
        }

        public override bool Equals(Object obj)
        {
            var a = this.GetType().Name;
            var b = obj.GetType().Name;
            if (obj != null || this.GetType() == obj.GetType())
            {
                Person tempPerson = (Person) obj;
                if (this.Name == tempPerson.Name && this.Surname == tempPerson.Surname && this.Age == tempPerson.Age && this.GetHashCode() == tempPerson.GetHashCode())
                    return true;
            }
            return false;
                
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static void RandomPerson(Person[] personArr)
        {
            if (personArr.Length > 0)
            {
                Random rand = new Random();
                int tempPerson = rand.Next(0, personArr.Length);
                personArr[tempPerson].Print();  
            }
            else
                Console.WriteLine("This array are empty");
                  
        }

        public virtual object Clone(object objSource)
        {
            //Get the type of source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            object objTarget = Activator.CreateInstance(typeSource);
 
            //Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
 
            //Assign all source property to taget object 's properties
                foreach (PropertyInfo property in propertyInfo)
                {
                    //Check whether property can be written to
                    if (property.CanWrite)
                    {
                        //Check whether property type is value type, enum or string type
                        if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType == typeof(System.String))
                        {
                            property.SetValue(objTarget, property.GetValue(objSource, null), null);
                        }
                        //Else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                        else
                        {
                            object objPropertyValue = property.GetValue(objSource, null);
                            if (objPropertyValue == null)
                            {
                                property.SetValue(objTarget, null, null);
                            }
                            else
                            {
                                property.SetValue(objTarget, Clone(objPropertyValue), null);
                            }
                        }
                    }
                }
            return objTarget;
          }


      }

}

