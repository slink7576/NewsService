
using BusinessLogicLayer.SubSystemInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.SubSystems
{
    public class LoggingSubSystem : ILoggingSubSystem
    {
        const string LOGPATH = "C:\\log.txt";
        public string GetRecords()
        {
            if (File.Exists(LOGPATH))
            {
                using (StreamReader file = new StreamReader(LOGPATH))
                {
                    string data = file.ReadToEnd();
                    file.Close();
                    return data;
                }

            }
            else
            {
                return "Log file is empty";
            }
        }

        public void RecordAction(string action)
        {
            if (File.Exists(LOGPATH))
            {
                using (StreamWriter file = new StreamWriter(LOGPATH, true))
                {

                    file.WriteLine(DateTime.Now + " " + action);

                    file.Close();
                }
            }
            else
            {
                using (File.Create(LOGPATH))
                {

                }
                using (StreamWriter file = new StreamWriter(LOGPATH, true))
                {

                    file.WriteLine("[" + DateTime.Now + "]" + "    " + action);
                    file.Close();

                }
                
            }
        }
    }
}