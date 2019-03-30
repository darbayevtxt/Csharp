using System;
using System.IO;
using System.Xml.Serialization;

namespace serialize2
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }

        public Person()
        {

        }
        public Person(string name, int age, Company comp)
        {
            Name = name;
            Age = age;
            Company = comp;
        }

    }

    [Serializable]
    public class Company
    {
        public string Name { get; set; }

        public Company() { }

        public Company(string name)
        {
            Name = name;
        }


        class Program
        {
            static void Main(string[] args)
            {
                Person person1 = new Person("Nurdaulet", 19, new Company("Microsoft"));
                Person person2 = new Person("Assan", 19, new Company("Apple"));

                Person[] people = new Person[] { person1, person2 };

                XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
                using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs,people); 
                }

                using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                {
                    Person[] newpeople = (Person[])formatter.Deserialize(fs); 
                    foreach (Person p in newpeople)
                    {
                        Console.WriteLine("Name: {0} --- Age: {1} --- Company: {2}", p.Name, p.Age, p.Company.Name); 
                    }
                }


                Console.ReadLine(); 

            }
        }
    }
}
