using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Prava : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Prava()
        {
            InitializeComponent();
        }

        private void Prava_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(RoleLoad);
            thread.Start();
        }

        public void RoleLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtRole.Clear();
                        dataComb.dtRoleFill();
                        dataComb.dependency.OnChange += Roleonchange;
                        dataGridView1.DataSource = dataComb.dtRole;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "Наименование роли";
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[9].Visible = false;
                        dataGridView1.Columns[10].Visible = false;
                        dataGridView1.Columns[11].Visible = false;
                        dataGridView1.Columns[12].Visible = false;
                        dataGridView1.Columns[13].Visible = false;
                        dataGridView1.Columns[14].Visible = false;
                        dataGridView1.Columns[15].Visible = false;
                        dataGridView1.Columns[16].Visible = false;
                        dataGridView1.Columns[17].Visible = false;
                        dataGridView1.Columns[18].Visible = false;
                        dataGridView1.Columns[19].Visible = false;
                        dataGridView1.Columns[20].Visible = false;
                        dataGridView1.Columns[21].Visible = false;
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Roleonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                RoleLoad();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[2].Value);
            checkBox2.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value);
            checkBox3.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
            checkBox4.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
            checkBox5.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value);
            checkBox6.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value);
            checkBox7.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value);
            checkBox8.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[9].Value);
            checkBox9.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[10].Value);
            checkBox10.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[11].Value);
            checkBox12.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[12].Value);
            checkBox13.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[13].Value);
            checkBox15.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[14].Value);
            checkBox16.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[15].Value);
            checkBox17.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[16].Value);
            checkBox18.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[17].Value);
            checkBox19.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[18].Value);
            checkBox20.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[19].Value);
            checkBox21.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[20].Value);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            procedure.SpADD_Role(textBox1.Text, Convert.ToInt32(checkBox1.Checked), Convert.ToInt32(checkBox2.Checked), Convert.ToInt32(checkBox3.Checked), Convert.ToInt32(checkBox4.Checked), Convert.ToInt32(checkBox5.Checked), Convert.ToInt32(checkBox6.Checked),
                Convert.ToInt32(checkBox7.Checked), Convert.ToInt32(checkBox8.Checked), Convert.ToInt32(checkBox9.Checked), Convert.ToInt32(checkBox10.Checked),
                Convert.ToInt32(checkBox12.Checked), Convert.ToInt32(checkBox13.Checked), Convert.ToInt32(checkBox15.Checked),
                Convert.ToInt32(checkBox16.Checked), Convert.ToInt32(checkBox17.Checked), Convert.ToInt32(checkBox18.Checked), Convert.ToInt32(checkBox19.Checked),
                Convert.ToInt32(checkBox20.Checked), Convert.ToInt32(checkBox21.Checked));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            procedure.SpUpd_Role((int)dataGridView1.CurrentRow.Cells[0].Value, textBox1.Text, Convert.ToInt32(checkBox1.Checked), Convert.ToInt32(checkBox2.Checked), Convert.ToInt32(checkBox3.Checked), Convert.ToInt32(checkBox4.Checked), Convert.ToInt32(checkBox5.Checked), Convert.ToInt32(checkBox6.Checked),
               Convert.ToInt32(checkBox7.Checked), Convert.ToInt32(checkBox8.Checked), Convert.ToInt32(checkBox9.Checked), Convert.ToInt32(checkBox10.Checked),
               Convert.ToInt32(checkBox12.Checked), Convert.ToInt32(checkBox13.Checked), Convert.ToInt32(checkBox15.Checked),
               Convert.ToInt32(checkBox16.Checked), Convert.ToInt32(checkBox17.Checked), Convert.ToInt32(checkBox18.Checked), Convert.ToInt32(checkBox19.Checked),
               Convert.ToInt32(checkBox20.Checked), Convert.ToInt32(checkBox21.Checked));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            procedure.SpDel_Role ((int)dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
