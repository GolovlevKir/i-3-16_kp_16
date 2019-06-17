using Microsoft.Win32;
using System;
using System.Data.SqlClient;

namespace LibraryForSQLCon
{
    public class Registry_Class
    {
        public static string DS = "Empty", IC = "Empty", UI = "Empty", PW = "Empty";
        public static
            string error_message = "App:start:" + DateTime.Now.ToLongDateString();
        public static SqlConnection sqlConnection = new SqlConnection();

        public void Registry_Get()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Re-start");
            try
            {
                DS = key.GetValue("DS").ToString();
                IC = key.GetValue("IC").ToString();
                UI = key.GetValue("UI").ToString();
                PW = key.GetValue("PW").ToString();
            }
            catch
            {
                key.SetValue("DS", "Empty");
                key.SetValue("IC", "Empty");
                key.SetValue("UI", "Empty");
                key.SetValue("PW", "Empty");
            }
            finally
            {
                sqlConnection.ConnectionString = "Data Source = " + DS +
                    "; Initial Catalog = " + IC + "; Persist Security Info = true; " +
                    "User ID = " + UI + "; Password = \"" + PW + "\"";
            }
        }



        public void Registry_Set(string ds, string ic, string ui, string pw)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Re-start");
            try
            {
                key.SetValue("DS", ds);
                key.SetValue("IC", ic);
                key.SetValue("UI", ui);
                key.SetValue("PW", pw);
                Registry_Get();
            }
            catch (Exception ex)
            {
                error_message += "\n" + DateTime.Now.ToLongDateString() + ex.Message;
            }
        }

        public static string OrganizationName = "", DirPath = "";
        public static double DocLM = 0, DocTM = 0, DocRM = 0, DocBM = 0;

        public void ConfigurationGet()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey registryKey = registry.CreateSubKey("Re-start");
            RegistryKey subKey = registryKey.CreateSubKey("Configuration");
            try
            {
                OrganizationName = subKey.GetValue("OrganizationName").ToString();
                DirPath = subKey.GetValue("DirPath").ToString();
                DocLM = Convert.ToDouble(subKey.GetValue("DocLM").ToString());
                DocTM = Convert.ToDouble(subKey.GetValue("DocTM").ToString());
                DocRM = Convert.ToDouble(subKey.GetValue("DocRM").ToString());
                DocBM = Convert.ToDouble(subKey.GetValue("DocBM").ToString());
            }
            catch
            {
                subKey.SetValue("OrganizationName", "Empty");
                subKey.SetValue("DirPath", "Empty");
                subKey.SetValue("DocLM", 0.0);
                subKey.SetValue("DocTM", 0.0);
                subKey.SetValue("DocRM", 0.0);
                subKey.SetValue("DocBM", 0.0);

            }
        }

        public string server()
        {
            return DS;
        }
        public void MajorConfigurationSet(string Organization_Name)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey registryKey = registry.CreateSubKey("Re-start");
            RegistryKey subKey = registryKey.CreateSubKey("Configuration");
            subKey.SetValue("OrganizationName", Organization_Name);
            ConfigurationGet();
        }

        public void DocumentConfigurationSet(string Path, decimal DocLM,
            decimal DocTM, decimal DocRM, decimal DocBM)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey registryKey = registry.CreateSubKey("Re-start");
            RegistryKey subKey = registryKey.CreateSubKey("Configuration");
            subKey.SetValue("DirPath", Path);
            subKey.SetValue("DocLM", DocLM);
            subKey.SetValue("DocTM", DocTM);
            subKey.SetValue("DocRM", DocRM);
            subKey.SetValue("DocBM", DocBM);
        }
    }
}
