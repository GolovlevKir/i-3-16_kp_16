using LibraryForSQLCon;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Re_start
{
    public partial class StatusRem : Form
    {
        public StatusRem()
        {
            InitializeComponent();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
            command.CommandText = "SELECT dbo.Repairs.Status FROM dbo.Repairs JOIN dbo.Contracts ON dbo.Repairs.Contr_ID = dbo.Contracts.ID_Contr where dbo.Contracts.Num_Contr = '" + maskedTextBox1.Text + "'";
            Registry_Class.sqlConnection.Open();
            string NumDogo;
            try
            {
                NumDogo = command.ExecuteScalar().ToString();
            }
            catch
            {
                NumDogo = "Набранный вами договор, введен неверно!";
            }
            Registry_Class.sqlConnection.Close();
            label1.Text = "Результат: " + NumDogo;
        }
    }
}
