using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport
{
    class Verification
    {
        public static DataTable GetAllVerificationData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ROW_NUMBER()   OVER (ORDER BY VerificationDataId)  AS ROWID");
            sb.Append(" ,VerificationDataId");
            sb.Append("  ,[MobilePhone]");
            sb.Append(" ,[VerifyCode]");
            sb.Append(" ,[VerifyExpiredTime]");
            sb.Append(" ,[TokenBindingDate]");
            sb.Append("  ,[CreatedTime]");
            sb.Append("  ,[LiveArea]");
            sb.Append("   ,[wechatopenid]");
            sb.Append("FROM [ESP_GlobalCN_APP].[dbo].[Verification_Data] VD ");
            string sql = sb.ToString();
            Dictionary<string, object> param = new Dictionary<string, object>();
            DataTable dt=DB.DBQuery(sql, param);
            return dt;
        }
    }
}
