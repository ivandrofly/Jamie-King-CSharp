using System;
using System.Reflection;

namespace Reflection_to_the_Max
{
    class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override string ToString()
        {
            return "{ X: " + X + ", Y: " + Y + "}";
        }
    }
    class Program
    {
        static void Main()
        {
            // Earsly Binding
            Vector vec = new Vector { X = 4, Y = 9 };
            Console.WriteLine(vec.ToString());

            // Late Binding
            Type vecType = typeof(Vector);
            Vector vec2 = Activator.CreateInstance(vecType) as Vector;
            
            PropertyInfo xPropInfo = vecType.GetProperty("X");
            PropertyInfo yPropInfo = vecType.GetProperty("Y");

            xPropInfo.SetValue(vec2, 4, null);
            yPropInfo.SetValue(vec2, 9, null);
            MethodInfo toStringInfo = vecType.GetMethod("ToString");

            string Result = toStringInfo.Invoke(vec2, null) as string;
            MethodInfo writeLineInfo = typeof(Console).GetMethod("WriteLine", new[] { typeof(string) });
            writeLineInfo.Invoke(null, new[] { Result });
        }
    }
}
