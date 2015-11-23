using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

class AccessRegistryTool
{
    Connector js = new Connector();
    static RegistryKey reg = Registry.LocalMachine;
    static RegistryKey sb;

    static string subkey = @"Software\Kids_CheckIn_System";

    static public string ReadValue(string KeyName)
    {
        string val = "";

        try
        {
            sb = reg.OpenSubKey(subkey);
            val = sb.GetValue(KeyName).ToString();
        }
        catch(Exception ex)
        {
            val = "";
        }
       
        return val;
    }

    static public bool WriteValue(string KeyName, string Value)
    {
        try
        {
            sb = reg.CreateSubKey(subkey);
            sb.SetValue(KeyName,Value);
        }
        catch(Exception ex)
        {
            return false;
        }

        return true;
    }

    
}
