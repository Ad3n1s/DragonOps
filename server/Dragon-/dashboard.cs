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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            label2.Text = Program.GetClientsNumber(0);
            string filePath = "data/last_run.txt";

            // SHOW last run (only on load)
            if (File.Exists(filePath))
            {
                string lastRun = File.ReadAllText(filePath);
                label6.Text = lastRun;
            }
            else
            {
                string to = DateTime.Now.ToString("yyyy-MM-dd");
                string te = DateTime.Now.ToString("HH:mm:ss");
                label6.Text = to + " " + te;
            }

            // UPDATE file with current time (for next launch)
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            File.WriteAllText(filePath, today + " " + time);

            label5.Text = Program.GetClientsNumber(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
