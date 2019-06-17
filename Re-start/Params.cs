using System;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Params : Form
    {
        private int i;
        MainWindow main = new MainWindow();

        public Params()
        {
            InitializeComponent();
        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void Panel2_Click(object sender, EventArgs e)
        {
            i = 1;
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            i = 2;
        }

        private void Panel3_Click(object sender, EventArgs e)
        {
            i = 3;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            i = 4;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Выбор цвета
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            //Присваивания цветов
            switch (i)
            {
                case 1:
                    panel2.BackColor = colorDialog1.Color;
                    break;
                case 2:
                    panel1.BackColor = colorDialog1.Color;
                    break;
                case 3:
                    panel3.BackColor = colorDialog1.Color;
                    break;
                case 4:
                    button1.BackColor = colorDialog1.Color;
                    break;
            }
        }

        private void Params_Load(object sender, EventArgs e)
        {
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
            main.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Применение изменений
            main.panel6.BackColor = main.panel9.BackColor = panel2.BackColor;
            main.button1.BackColor = main.button2.BackColor =
                main.button3.BackColor = main.button4.BackColor = main.button5.BackColor = main.button6.BackColor = main.button7.BackColor =
                main.button12.BackColor = main.button11.BackColor = main.button10.BackColor = main.button8.BackColor =
                main.button13.BackColor = main.button14.BackColor = main.button28.BackColor = main.button29.BackColor = main.button20.BackColor =
                button1.BackColor;
            main.panel1.BackColor = main.panel10.BackColor = main.panel7.BackColor = main.panel2.BackColor = panel1.BackColor;
            main.panel3.BackColor = panel3.BackColor;
            Program.fff.Close();
            Hide();
            main.Show();
        }
    }
}
