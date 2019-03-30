using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Nurdaulet", 18);
            Console.WriteLine("Object create");

            XmlSerializer formatter = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Object serialized");

            }

            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);

                Console.WriteLine("Object Deserialize");
                Console.WriteLine("Name: {0} --- Age:{1}", newPerson.Name, newPerson.Age); 


            }

            Console.ReadLine(); 
        }



    }
}


