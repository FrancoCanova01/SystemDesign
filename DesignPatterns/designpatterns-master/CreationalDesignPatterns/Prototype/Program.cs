using System;

namespace Prototype
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            //castea a Person lo que devuelve MemberwiseClone
            //que parece ser metodo de alguna librería ...
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Creas persona y le estableces valores
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            // Perform a shallow copy of p1 and assign it to p2.
            Person p2 = p1.ShallowCopy();
            // Make a deep copy of p1 and assign it to p3.
            Person p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");

            //Salen los valores metidos a mano arriba
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);


            //p2 era shallow copy de p1. Sale igual que p1
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            //p3 era deep copy de p1. Sale igual que p1
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3. Cambian los valores de p1
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;


            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");

            //Salen los valores de arriba
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);

            //para p2, la modificación en p1 cambio su ID
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);

            //para p3, la modificación en p1 no cambió a p3
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
