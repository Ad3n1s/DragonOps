using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dragon_
{
    public partial class CmdLine : Form
    {
        public CmdLine()
        {
            InitializeComponent();
            MessageBox.Show("After Each Command you run, please wait at least 5 seconds before you run another!", "Note");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Program.AppState.CmdResponse = null;
            richTextBox1.Text = string.Empty;

            if (textBox3.Text == null)
            {
                MessageBox.Show("Warning", "Command cant be empty");

            }
            else
            {
                
                Program.hh.SendCommand($"runcmd={textBox3.Text}", Program.AppState.CurrentUser);
                textBox3.Text = string.Empty;
                check();
            }
            
        }
        private void check()
        {
            while (true)
            {

                if (Program.AppState.CmdResponse == null)
                {
                    Task.Delay(2000);
                }
                else
                {
                    richTextBox1.Text = Program.AppState.CmdResponse;
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CopyToClipboardButton_Click(sender, e);
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            // Capture the text from the RichTextBox into a local variable on the UI thread
            string textToCopy = richTextBox1.Text;

            // Create a new thread for the clipboard operation
            Thread staThread = new Thread(
                delegate ()
                {
                    try
                    {
                        Clipboard.SetText(textToCopy);
                    }
                    catch (ExternalException ex)
                    {
                        // Handle cases where the clipboard might be in use by another process
                        MessageBox.Show($"Clipboard error: {ex.Message}");
                    }
                });

            // Set the thread's apartment state to STA
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join(); // Wait for the operation to complete
        }
    }
}
