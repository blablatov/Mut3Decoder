using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;


namespace Mut3Decoder
{
    class Db
    {
        public SqlConnection sqlConnection;
        //SqlCommand Sqlcommand;

        public bool CheckConnect(string connStr)
        {
            try
            {
                //sqlConnection = new SqlConnection(connStr);
                //sqlConnection = new SqlConnection(@"User ID=" + DbSettings.userId + ";Password=" + DbSettings.pass + ";Integrated Security=false; server= " + DbSettings.server + "\\SQLEXPRESS; database=" + DbSettings.dBase + "");
                sqlConnection = new SqlConnection(@"User ID=" + DbSettings.userId + ";Password=" + DbSettings.pass + ";Integrated Security=false; server= " + DbSettings.server + "\\CAESARCOMPDB; database=" + DbSettings.dBase + "");
                sqlConnection.Open();
                if (sqlConnection != null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw new Exception ("Error of data for connect.."); 
            }
            finally
            {
                if (sqlConnection != null)
                sqlConnection.Close();
            }
        }
        public string SqlConnStr()
        {
            SqlConnectionStringBuilder strBuilder = new SqlConnectionStringBuilder();
            strBuilder.DataSource = DbSettings.server;
            //strBuilder.DataSource = Convert.ToString(DbSettings.port);
            strBuilder.AttachDBFilename = DbSettings.dBase;
            strBuilder.UserID = DbSettings.userId;
            strBuilder.Password = DbSettings.pass;
            strBuilder.ConnectTimeout = 20;
            strBuilder.IntegratedSecurity = false;
            strBuilder.CurrentLanguage = "utf8";
            return strBuilder.ConnectionString;

        }

    }
}