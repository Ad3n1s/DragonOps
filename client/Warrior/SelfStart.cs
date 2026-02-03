using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Warrior
{
    public class SelfStart
    {
        public void AddSelfToStartup()
        {
            // this adds the current program into a self startup list, so everytime they reboot it starts the program automatically.
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            string appName = Path.GetFileNameWithoutExtension(exePath);

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key == null)
                    throw new Exception("Run registry key not found");

                var existing = key.GetValue(appName);

                if (existing != null && existing.ToString() == exePath)
                    return; // already added & enabled

                key.SetValue(appName, $"\"{exePath}\"", RegistryValueKind.String);
            }
        }
    }
}
