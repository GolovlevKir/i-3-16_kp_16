using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibraryForSQLCon;

namespace Re_start
{
    class DataBase_Configuration
    {
        public event Action<DataTable> dtServers;
        public event Action<DataTable> dtDatabases;
        public event Action<bool> conState;
        private Registry_Class registry = new Registry_Class();
        public string cds, cui, cpw;
        public static bool logCon;

        public void Servers_get()
        {
            //Получение серверов
            SqlDataSourceEnumerator sourceEnumerator
                = SqlDataSourceEnumerator.Instance;
            dtServers(sourceEnumerator.GetDataSources());
        }

        public void Databases_get()
        {
            //Подключение
            SqlConnection sql = new SqlConnection("Data Source = " + cds +
                "; Initial Catalog = master; Persist Security Info = true; " +
                " User ID = " + cui + "; Password = \"" + cpw + "\"");
            try
            {
                //Поиск серверов
                SqlCommand command = new SqlCommand("select name from sys.databases " +
                    "where name not in ('master','tempdb','model','msdb')", sql);
                DataTable table = new DataTable();
                sql.Open();
                table.Load(command.ExecuteReader());
                //Заполнение таблицы
                dtDatabases(table);
            }
            catch (SqlException ex)
            {
                //Вывод исключения
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Закрытие подключения
                sql.Close();
            }
        }

        public void Connection_check()
        {
            try
            {
                //Получение данных реестра
                registry.Registry_Get();
                //открытие подключения
                Registry_Class.sqlConnection.Open();
                conState(true);
                logCon = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conState(false);
                logCon = false;
            }
            finally
            {
                //Закрытие подключения
                Registry_Class.sqlConnection.Close();
            }
        }
    }
}
