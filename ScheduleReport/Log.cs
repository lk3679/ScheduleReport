using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport
{
    class Log
    {
        public static void WriteLog(string message)
        {
            string filePath = System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString();
            string fileName = filePath +"ReportLog" + ".txt";

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
            using (StreamWriter sw = File.AppendText(fileName))
            {
                add(message, sw);
            }
        }
        private static void add(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
