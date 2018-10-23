using System.IO;
namespace Static_s_Roots
{
    class Logger
    {
        static StreamWriter outStream;
        static int logNumber = 0;

        static public void initializeLogging()
        {
            outStream = new StreamWriter("mylog.txt");
        }
        static public void shutDownLoggin()
        {
            outStream.Close();
        }
        static public void logMessage(string message)
        {
            outStream.WriteLine((logNumber++) + ": " + message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Logger.initializeLogging();
            Logger.logMessage("I love static data");
            Logger.logMessage("static data exists before and after main()");
            Logger.logMessage("When I think static, I think memory that created by the compiler");
            Logger.shutDownLoggin();
        }
    }
}
