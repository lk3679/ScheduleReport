using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport
{
    class Report
    {
        public static void Add()
        {
            DataTable dt = Verification.GetAllVerificationData();
            string Date = DateTime.Now.ToString("yyyyMMdd");
            string FilePath = System.Configuration.ConfigurationManager.AppSettings["FilePath"].ToString();
            string Filename=string.Format("ExportData_{0}.csv", DateTime.Now.ToString("yyyyMMddhhmmss"));
            string ExportFilePath = FilePath + Filename;
            Utility.CreateCSVFile(dt, ExportFilePath);
            Log.WriteLog("新增" + ExportFilePath + "完成");
        }
    }
}
