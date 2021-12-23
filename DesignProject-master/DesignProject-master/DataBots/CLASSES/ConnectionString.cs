using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBots.CLASSES
{
    static internal class ConnectionString
    {
        public static string GetConString(string name)
        {
            var outPut = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return  outPut;
        }
    }
}
