using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;


namespace Dragon_
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            
            InitializeComponent();
            panel5.Controls.Clear();
            label2.Text = "Dashboard";
            dashboard dash = new dashboard();
            dash.Dock = DockStyle.Fill; // make it fill the panel
            dash.TopLevel = false;      // if it's a Form, set TopLevel false (but better as UserControl)

            // Add to panel
            panel5.Controls.Add(dash);
            dash.BringToFront();
            dash.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            panel4.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };

        }
        [DllImport("user32.dll")] static extern void ReleaseCapture();
        [DllImport("user32.dll")] static extern void SendMessage(IntPtr h, int m, int w, int l);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClients_Click(object sender, EventArgs e)
        {

        }

        private void btnClients_Click_1(object sender, EventArgs e)
        {
            label2.Text = "Clients";
            Clients dash = new Clients();
            dash.Dock = DockStyle.Fill; // make it fill the panel
            dash.TopLevel = false;      // if it's a Form, set TopLevel false (but better as UserControl)

            // Add to panel
            panel5.Controls.Add(dash);
            dash.BringToFront();
            dash.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "Attacks";
            Attacks dash = new Attacks();
            dash.Dock = DockStyle.Fill; // make it fill the panel
            dash.TopLevel = false;      // if it's a Form, set TopLevel false (but better as UserControl)

            // Add to panel
            panel5.Controls.Add(dash);
            dash.BringToFront();
            dash.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "DDOS Panel";
            ddos dash = new ddos();
            dash.Dock = DockStyle.Fill; // make it fill the panel
            dash.TopLevel = false;      // if it's a Form, set TopLevel false (but better as UserControl)

            // Add to panel
            panel5.Controls.Add(dash);
            dash.BringToFront();
            dash.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Dashboard";
            dashboard dash = new dashboard();
            dash.Dock = DockStyle.Fill; // make it fill the panel
            dash.TopLevel = false;      // if it's a Form, set TopLevel false (but better as UserControl)

            // Add to panel
            panel5.Controls.Add(dash);
            dash.BringToFront();
            dash.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
