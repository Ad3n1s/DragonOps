using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dragon_.Program;

namespace Dragon_
{
    public partial class Clients : Form
    {
        public void RefreshGrid()
        {
            dgvClients.Rows.Clear();

            foreach (var c in ClientStore.Clients)
            {
                dgvClients.Rows.Add(
                    c.Id,
                    c.Name,
                    c.IP,
                    c.Status,
                    c.Activity,
                    c.LastCheck
                );
            }
        }
        public Clients()
        {
            InitializeComponent();
            MakeRoundedPerfect(btnPing, 6);
            MakeRoundedPerfect(btnRefresh, 6);
            MakeRoundedPerfect(btnSendm, 6);
            MakeRoundedPerfect(button2, 6);

            dgvClients.Rows.Clear();

            foreach (var c in ClientStore.Clients)
            {
                dgvClients.Rows.Add(
                    c.Id,
                    c.Name,
                    c.IP,
                    c.Status,
                    c.Activity,
                    c.LastCheck
                );
            }
        }
        void MakeRoundedPerfect(Button b, int r = 6)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;

            b.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                GraphicsPath p = new GraphicsPath();
                p.AddArc(0, 0, r, r, 180, 90);
                p.AddArc(b.Width - r, 0, r, r, 270, 90);
                p.AddArc(b.Width - r, b.Height - r, r, r, 0, 90);
                p.AddArc(0, b.Height - r, r, r, 90, 90);
                p.CloseFigure();

                b.Region = new Region(p);
            };
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectUser s = new SelectUser();
            s.Show();
        }


        


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvClients.Rows.Clear();

            foreach (var c in ClientStore.Clients)
            {
                dgvClients.Rows.Add(
                    c.Id,
                    c.Name,
                    c.IP,
                    c.Status,
                    c.Activity,
                    c.LastCheck
                );
            }
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            new Thread(() => { Program.hh.PingAllClients(); }).Start();
            MessageBox.Show("Please Wait until all clients return the signal then press Refresh!", "Wait");


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(@".\data\logs.txt") { UseShellExecute = true });
            }
            catch { }
        }
    }
}
