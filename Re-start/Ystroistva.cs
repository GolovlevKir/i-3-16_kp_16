using System;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Ystroistva : Form
    {
        public Ystroistva()
        {
            InitializeComponent();

        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Ystroistva_Load(object sender, EventArgs e)
        {

        }
    }
}
