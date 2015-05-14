using System;
using System.IO;
using System.Linq;
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
            //taken from http://blog.pythonaro.com/2013/05/fully-disable-user-access-control-uac.html
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System","EnableLUA", 0);
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorAdmin", 0);
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "PromptOnSecureDesktop", 0);
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Action Center\\Checks\\{C8E6F269-B90A-4053-A3BE-499AFCEC98C4}.check.0", "CheckSetting", StringToByteArray("23004100430042006C006F00620000000000000000000000010000000000000000000000"), RegistryValueKind.Binary);
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}