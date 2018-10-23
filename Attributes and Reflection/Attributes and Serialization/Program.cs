using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace Attributes_and_Serialization
{
    [Serializable]
    [System.Runtime.Serialization.DataContract]
    class Person
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember(Name = "Weight")]
        public int Age { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var me = new Person
            {
                FirstName = "Ivandro Ismael",
                LastName = "Gomes Jao",
                Age = 20
            };
            var serializer = new DataContractSerializer(me.GetType());
            var someRam = new MemoryStream();

            //System.Diagnostics.Debugger.Break();

            serializer.WriteObject(someRam, me);
            someRam.Seek(0, SeekOrigin.Begin);
            Console.WriteLine(XElement.Parse(Encoding.ASCII.GetString(someRam.GetBuffer()).Replace("\0", "")));
        }
    }
}
