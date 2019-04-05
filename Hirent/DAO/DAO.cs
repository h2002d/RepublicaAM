using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;

namespace Hirent.DAO
{
    public class DAO
    {
        public static string BPM_DB_Connectionstring = ConfigurationManager.ConnectionStrings["Hirent_DB_Connectionstring"].ConnectionString;
    }
}