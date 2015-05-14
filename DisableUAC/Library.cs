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
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System","EnableLUA", 0, RegistryValueKind.DWord);
        }
    }
}