using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    class People
    {
        public string name;
        public List<string> messages;

        public People() { }

        public People(string name)
        {
            this.name = name;
            messages = new List<string>();
        }

        public void sendMessage(People p, string message)
        {
            this.messages.Add("Me: " + message);
            p.messages.Add(this.name + ": " + message);
        }

        public void serializeMessage()
        {
            FileStream fs = new FileStream("mymessage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<string>));
            xs.Serialize(fs, this.messages);
            fs.Close();
        }

        public List<string> DesirializeMessagee()
        {
            List<string> output = new List<string>();
            FileStream fs = new FileStream("mymessage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<string>));
            output = xs.Deserialize(fs) as List<string>;
            fs.Close();

            return output;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            People p1 = new People("Nurdaulet");
            People p2 = new People("Illyas");

            p1.sendMessage(p2, "Hello");
            p2.sendMessage(p1, "Hi, how are u");
            p1.sendMessage(p2, "norm");
            p2.sendMessage(p1, "mmm");

            p1.serializeMessage();
            List<string> messageNurdaulet = new List<String>();
            messageNurdaulet = p1.DesirializeMessagee();

            foreach (string s in messageNurdaulet)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}