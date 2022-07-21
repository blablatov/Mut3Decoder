using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace Mut3Decoder
{
    class DbSettings
    {
        public static string server { get; set; }
        public static string port { get; set; }
        public static string dBase { get; set; }
        public static string userId { get; set; }
        public static string pass { get; set; }
    }
}

