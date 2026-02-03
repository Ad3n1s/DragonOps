namespace Dragon_
{
    partial class Clients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients));
            dgvClients = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            ClientName = new DataGridViewTextBoxColumn();
            ipAdd = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            activity = new DataGridViewTextBoxColumn();
            last = new DataGridViewTextBoxColumn();
            btnRefresh = new Button();
            btnSendm = new Button();
            btnPing = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.BackgroundColor = Color.FromArgb(46, 57, 113);
            dgvClients.BorderStyle = BorderStyle.Fixed3D;
            dgvClients.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dgvClients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Nirmala UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(0, 179, 165);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Columns.AddRange(new DataGridViewColumn[] { Id, ClientName, ipAdd, status, activity, last });
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.GridColor = Color.FromArgb(46, 57, 113);
            dgvClients.Location = new Point(12, 12);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersVisible = false;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClients.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(46, 57, 113);
            dgvClients.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(0, 179, 165);
            dgvClients.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 57, 113);
            dgvClients.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 179, 165);
            dgvClients.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvClients.Size = new Size(725, 323);
            dgvClients.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Width = 65;
            // 
            // ClientName
            // 
            ClientName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ClientName.HeaderText = "Client Name";
            ClientName.MinimumWidth = 100;
            ClientName.Name = "ClientName";
            // 
            // ipAdd
            // 
            ipAdd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ipAdd.HeaderText = "IP Address";
            ipAdd.MinimumWidth = 100;
            ipAdd.Name = "ipAdd";
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.Width = 75;
            // 
            // activity
            // 
            activity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            activity.HeaderText = "Activity";
            activity.MinimumWidth = 120;
            activity.Name = "activity";
            // 
            // last
            // 
            last.HeaderText = "Last Check";
            last.MinimumWidth = 6;
            last.Name = "last";
            last.Width = 120;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(0, 179, 165);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Sitka Display", 12F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageAlign = ContentAlignment.TopCenter;
            btnRefresh.Location = new Point(12, 356);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(152, 74);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextAlign = ContentAlignment.BottomCenter;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSendm
            // 
            btnSendm.BackColor = Color.FromArgb(0, 179, 165);
            btnSendm.FlatAppearance.BorderSize = 0;
            btnSendm.FlatStyle = FlatStyle.Flat;
            btnSendm.Font = new Font("Sitka Display", 12F);
            btnSendm.ForeColor = Color.White;
            btnSendm.Image = (Image)resources.GetObject("btnSendm.Image");
            btnSendm.ImageAlign = ContentAlignment.TopCenter;
            btnSendm.Location = new Point(393, 356);
            btnSendm.Name = "btnSendm";
            btnSendm.Size = new Size(152, 74);
            btnSendm.TabIndex = 1;
            btnSendm.Text = "Select User";
            btnSendm.TextAlign = ContentAlignment.BottomCenter;
            btnSendm.UseVisualStyleBackColor = false;
            btnSendm.Click += button2_Click;
            // 
            // btnPing
            // 
            btnPing.BackColor = Color.FromArgb(0, 179, 165);
            btnPing.FlatAppearance.BorderSize = 0;
            btnPing.FlatStyle = FlatStyle.Flat;
            btnPing.Font = new Font("Sitka Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPing.ForeColor = Color.White;
            btnPing.Image = (Image)resources.GetObject("btnPing.Image");
            btnPing.ImageAlign = ContentAlignment.TopCenter;
            btnPing.Location = new Point(203, 356);
            btnPing.Name = "btnPing";
            btnPing.Size = new Size(152, 74);
            btnPing.TabIndex = 1;
            btnPing.Text = "Ping All Clients";
            btnPing.TextAlign = ContentAlignment.BottomCenter;
            btnPing.UseVisualStyleBackColor = false;
            btnPing.Click += btnPing_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 179, 165);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Sitka Display", 12F);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(581, 356);
            button2.Name = "button2";
            button2.Size = new Size(152, 74);
            button2.TabIndex = 2;
            button2.Text = "View Logs";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 57, 113);
            ClientSize = new Size(745, 442);
            Controls.Add(button2);
            Controls.Add(btnSendm);
            Controls.Add(btnPing);
            Controls.Add(btnRefresh);
            Controls.Add(dgvClients);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Clients";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvClients;
        private Button btnRefresh;
        private Button btnSendm;
        private Button btnPing;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn ClientName;
        private DataGridViewTextBoxColumn ipAdd;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn activity;
        private DataGridViewTextBoxColumn last;
        private Button button2;
    }
}