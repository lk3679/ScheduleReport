using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport
{
    class Utility
    {
        private static string strKey = "CASPER59";

        private static string strIV = "TEMPLATE";

        public static string enCrypt(string strSource)
        {
            byte[] buffer = Encoding.Default.GetBytes(strSource);
            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider tdes = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, tdes.CreateEncryptor(Encoding.Default.GetBytes(strKey), Encoding.Default.GetBytes(strIV)), CryptoStreamMode.Write);
            encStream.Write(buffer, 0, buffer.Length);
            encStream.FlushFinalBlock();
            ms.Close();
            encStream.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string deCrypt(string strSource)
        {
            byte[] buffer = Convert.FromBase64String(strSource);
            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider tdes = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, tdes.CreateDecryptor(Encoding.Default.GetBytes(strKey), Encoding.Default.GetBytes(strIV)), CryptoStreamMode.Write);
            encStream.Write(buffer, 0, buffer.Length);
            encStream.FlushFinalBlock();
            ms.Close();
            encStream.Close();
            return Encoding.Default.GetString(ms.ToArray());
        }
        public static void CreateCSVFile(DataTable dtDataTablesList, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            int iColCount = dtDataTablesList.Columns.Count;

            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dtDataTablesList.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTablesList.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

    }
}
