using System.IO;
namespace Static_s_Roots
{
    class Logger
    {
        StreamWriter outStream;
        int logNumber = 0;
        static Logger theInstance = new Logger();

        //Note the constructor has to be private / you can also make this class sealed
        Logger() { }

        public void initializeLogging()
        {
            outStream = new StreamWriter("mylog.txt");
        }
        public void shutDownLoggin()
        {
            outStream.Close();
        }
        public void logMessage(string message)
        {
            outStream.WriteLine((logNumber++) + ": " + message);
        }

        public static Logger TheInstance
        {
            get
            {
                if (theInstance == null)
                    theInstance = new Logger();
                return theInstance;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Logger.TheInstance.initializeLogging();
            Logger.TheInstance.logMessage("I love static data");
            Logger.TheInstance.logMessage("static data exists before and after main()");
            Logger.TheInstance.logMessage("When I think static, I think memory that created by the compiler");
            Logger.TheInstance.shutDownLoggin();
        }
    }
}
