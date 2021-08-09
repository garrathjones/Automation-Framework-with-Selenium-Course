using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EAAutoFramework.Config
{
    public class ConfigReader
    {
        public static string InitialiseTest()
        {
            return ConfigurationManager.AppSettings["AUT"].ToString();
        }
    }
}
