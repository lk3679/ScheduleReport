using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ScheduleReport
{
    class DB
    {
        public static string ConnetionString()
        {
            string DSN = System.Configuration.ConfigurationManager.AppSettings["DSN"].ToString();
            return Utility.deCrypt(DSN);
        }

        public static DataTable DBQuery(string SQL, Dictionary<string, object> param)
        {
            string DBstring = DB.ConnetionString();
            DataTable dt = new DataTable();

            if (IsServerConnected() == false)
                return dt;
            
                SqlDataAdapter da = new SqlDataAdapter(SQL, DBstring);
            foreach (KeyValuePair<string, object> item in param)
                da.SelectCommand.Parameters.AddWithValue("@" + item.Key, item.Value);

            da.Fill(dt);
            return dt;
        }

        public static bool IsServerConnected()
        {
            using (var l_oConnection = new SqlConnection(DB.ConnetionString()))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

    }
}
