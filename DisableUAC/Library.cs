using System;
using System.IO;
using Microsoft.Win32;

namespace DisableUAC
{
    public static class Library
    {
        public static void WriteErrorLog(Exception ex)
        {
            WriteErrorLog(ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
        }

        public static void WriteErrorLog(string message)
        {
            StreamWriter sw = null;
            try
            {
                //this will write to the log if bad stuff happens
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\DisableUAC.log", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + message);
                //Don't leave the toilet seat up, there are ladies in the house
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
                //bad
            }
        }

        public static void WriteUACRegistryValue()
        {
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System","EnableLUA", 0);
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorAdmin", 0);
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "PromptOnSecureDesktop", 0);
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Action Center\\Checks\\{C8E6F269-B90A-4053-A3BE-499AFCEC98C4}.check.0", "CheckSetting", "23 00 41 00 43 00 42 00 6C 00 6F 00 62 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00", RegistryValueKind.Binary);
        }
    }
}