using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TwitchInfo
{
    class Tools
    {

        public static bool RunOnStartup(string appName, bool isChecked)
        {
            return Tools.RunOnStartup(appName, "", isChecked);
        }

        public static bool RunOnStartup(string appName, string path, bool isChecked)
        {
            if (path.Equals("")) return false;

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);

            if (isChecked)
            {
                if (registryKey.GetValue(appName) == null)
                    registryKey.SetValue(appName, path);
            }
            else
            {
                if (registryKey.GetValue(appName) != null)
                    registryKey.DeleteValue(appName);
            }

            return true;
        }

    }
}
