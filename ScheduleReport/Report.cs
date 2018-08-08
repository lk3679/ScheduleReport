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
            string Filename=string.Format("ExportData_{0}.csv", DateTime.Now.ToString("yyyyMMddhhmmss"));
            string FilePath = @"D:\" + Filename;
            Utility.CreateCSVFile(dt,FilePath);
            Console.WriteLine("新增"+FilePath+"完成");
        }
    }
}
