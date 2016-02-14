using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDS_CheckIn_System.Helper
{
    public static class AppSettingsHelper
    {
        public static string GetAppSettingsValue(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}
