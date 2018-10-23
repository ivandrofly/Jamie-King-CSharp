using System;
using System.Linq.Expressions;

namespace Parameter_Expression
{
    class Program
    {
        static void Main()
        {
            Expression<Func<int, bool>> test = i => i > 5;

            ConstantExpression constExp = Expression.Constant(5, typeof(int));
            //Console.WriteLine(constExp.NodeType);
            //Console.WriteLine(constExp.Type);
            //Console.WriteLine(constExp.Value);

            ParameterExpression iParam = Expression.Parameter(typeof(int), "i");
            //Console.WriteLine(iParam.NodeType);
            //Console.WriteLine(iParam.Type);
            ////Console.WriteLine(iParam.Value); // doesn't have value
            //Console.WriteLine(iParam.Name);

            BinaryExpression greaterThen = Expression.GreaterThan(iParam, constExp);
            Console.WriteLine(greaterThen.NodeType); // return ExpressionType.GreaterThan than
            Console.WriteLine(greaterThen.Type); // returns boolean
            Console.WriteLine(greaterThen.Left); // return i int32
            Console.WriteLine(greaterThen.Right); // returns const int32 which is 5 declared above

            Expression<Func<int, bool>> test2 =
                Expression.Lambda<Func<int, bool>>(greaterThen, iParam);

            Console.WriteLine("\r\n===============================");
            Func<int, bool> meDele = test2.Compile();
            Console.WriteLine(meDele(3));
            Console.WriteLine(meDele(8));
            Console.WriteLine("===============================");
            Console.WriteLine("Pess any keys to exit the execution");
            Console.Read();
        }
    }
}
