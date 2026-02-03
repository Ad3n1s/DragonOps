using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dragon_
{
    public partial class AskData2 : Form
    {
        public AskData2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("The Process number cannot be empty", "Info");
                return;
            }

            var data = textBox1.Text;
            Program.hh.SendCommand($"killpr={data}", Program.AppState.CurrentUser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
