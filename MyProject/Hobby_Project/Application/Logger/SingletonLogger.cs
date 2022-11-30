using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logger
{
    public sealed class SingletonLogger : ILog
    {
        private static SingletonLogger instance = null;
        private static readonly object padlock = new object();
        private const string FILE_PATH = @"C:\\Users\\PC\\Desktop\\Assignements\\Assignements\\MyProject\\Hobby_Project\\Application\\Logger\\";
        SingletonLogger() { }

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

        public void LogMessage(string commandType, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*-------------------------------*");
            sb.Append(DateTime.Now.ToShortTimeString() + " ");
            sb.Append(message);

            try
            {
                string fileName = checkFileName(commandType);
                string filePath = FILE_PATH + fileName;
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(sb.ToString());
                    writer.Flush();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ReadMessages(string commandType)
        {
            try
            {
                string file = checkFileName(commandType);
                string filePath = FILE_PATH + file;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private string checkFileName(string commandType)
        {
            string fileName = "";
            switch (commandType.ToUpper())
            {
            case "CREATE":
                fileName = "CreateCommands.txt";
                break;
            case "UPDATE":
                fileName = "UpdateCommands.txt";
                break;
            case "DELETE":
                fileName = "DeleteCommands.txt";
                break;
                default:
                    throw new Exception("Not supported opeartion!");
             }
           return fileName;
        }
    }
    
}
