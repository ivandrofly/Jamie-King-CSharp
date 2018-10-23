using System;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace Our_Own_Serializer
{
    [DataContract]
    class Person
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember(Name = "Weight")]
        public int Age { get; set; }
    }

    class MeSerializer
    {
        Type targetType;
        public MeSerializer(Type targetType)
        {
            this.targetType = targetType;
            if (!targetType.IsDefined(typeof(DataContractAttribute), false))
            {
                throw new Exception("No soup for your!");
            }
        }

        public void WriteObject(Stream stream, object graph)
        {
            IEnumerable<PropertyInfo> serializebleProperties =
                targetType.GetProperties().Where(p => p.IsDefined(typeof(DataMemberAttribute), false));

            var writer = new StreamWriter(stream);
            writer.WriteLine("<" + targetType.Name + ">");
            foreach (PropertyInfo propInfo in serializebleProperties)
            {
                writer.Write("\t<" + propInfo.Name + ">" + propInfo.GetValue(graph, null) +
                    "</" + propInfo.Name + ">");
            }
            writer.WriteLine("</" + targetType.Name + ">");
            writer.Flush();
        }
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
            //var serializer = new DataContractSerializer(me.GetType());
            var serializer = new MeSerializer(me.GetType());
            var someRam = new MemoryStream();
            serializer.WriteObject(someRam, me);
            someRam.Seek(0, SeekOrigin.Begin);
            Console.WriteLine(
                XElement.Parse(
                Encoding.UTF8.GetString(someRam.GetBuffer()).Replace("\0", "")));
            // Encoding.UTF8 support é á
        }
    }
}
