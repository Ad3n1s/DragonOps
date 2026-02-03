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
    public partial class AskData3 : Form
    {
        public AskData3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("The Error Title cannot be empty", "Info");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("The Error Description cannot be empty", "Info");
                return;
            }

            var title = textBox1.Text;
            var description = textBox2.Text;
            Program.hh.SendCommand($"fakerr={title}|{description}", Program.AppState.CurrentUser);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
