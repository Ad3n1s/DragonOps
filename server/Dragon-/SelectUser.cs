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
    public partial class SelectUser : Form
    {
        public SelectUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                MessageBox.Show("User cannot be empty", "Warning");
                return;
            }

            Program.hh.AddUser(Convert.ToInt32(textBox3.Text));
            Program.Log($"User {textBox3.Text} was chosen to be controlled.");
            this.Close();
        }

        private void SelectUser_Load(object sender, EventArgs e)
        {

        }
    }
}
