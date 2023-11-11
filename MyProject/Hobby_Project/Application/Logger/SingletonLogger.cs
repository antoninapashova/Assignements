using System.Text;

namespace Application.Logger
{
    public sealed class SingletonLogger : ILog
    {
        private static SingletonLogger instance = null;
        private static readonly object padlock = new object();
        private const string FILE_PATH = @"C:\\Users\\PC\\Desktop\\Assignements\\Assignements\\MyProject\\Hobby_Project\\Application\\Logger\\Logger.txt ";

        SingletonLogger() {}

        public static SingletonLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonLogger();
                        }
                    }
                }

                return instance;
            }
        }
        
        public void LogError(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*-------------------------------*");
            sb.Append("[Error]");
            sb.Append(DateTime.Now.ToShortTimeString() + " ");
            sb.Append(message);

            try
            {
                using (StreamWriter writer = new StreamWriter(FILE_PATH, true))
                {
                    writer.WriteLine(sb.ToString());
                    writer.Flush();
                }
            } 
            catch (Exception e)
            {
                
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Inner exception: " + e.InnerException);
            }
        }

        public void LogWarning(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Warning]");
            sb.Append(DateTime.Now.ToShortTimeString() + " ");
            sb.Append(message);

            try
            {
                using (StreamWriter writer = new StreamWriter(FILE_PATH, true))
                {
                    writer.WriteLine(sb.ToString());
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LogInfo(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Info]");
            sb.Append(DateTime.Now.ToShortTimeString() + " ");
            sb.Append(message);

           try
           {
                using (StreamWriter writer = new StreamWriter(FILE_PATH, true))
                {
                    writer.WriteLine(sb.ToString());
                    writer.Flush();
                }
           }
           catch (Exception e)
           {
                Console.WriteLine(e.Message);
           }
        }
    }
}
