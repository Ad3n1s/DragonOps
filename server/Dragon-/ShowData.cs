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
    public partial class ShowData : Form
    {
        public ShowData()
        {

            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyToClipboardButton_Click(sender, e);
        }

        private void ShowData_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Program.AppState.CurrentResponse;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
