namespace Dragon_
{
    partial class CmdLine
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
            label1 = new Label();
            textBox3 = new TextBox();
            panel1 = new Panel();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 179, 165);
            label1.Location = new Point(248, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 46);
            label1.TabIndex = 0;
            label1.Text = "Command Line";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(46, 57, 113);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.FromArgb(0, 179, 165);
            textBox3.Location = new Point(174, 102);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(502, 21);
            textBox3.TabIndex = 7;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 179, 165);
            panel1.ForeColor = Color.FromArgb(0, 179, 165);
            panel1.Location = new Point(145, 144);
            panel1.Name = "panel1";
            panel1.Size = new Size(569, 1);
            panel1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 179, 165);
            label2.Location = new Point(33, 94);
            label2.Name = "label2";
            label2.Size = new Size(120, 31);
            label2.TabIndex = 8;
            label2.Text = "Command";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(36, 45, 90);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 179, 165);
            button1.Location = new Point(292, 160);
            button1.Name = "button1";
            button1.Size = new Size(190, 41);
            button1.TabIndex = 9;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 179, 165);
            label3.Location = new Point(33, 214);
            label3.Name = "label3";
            label3.Size = new Size(87, 31);
            label3.TabIndex = 10;
            label3.Text = "Output";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(36, 45, 90);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.FromArgb(0, 179, 165);
            richTextBox1.Location = new Point(145, 254);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(569, 116);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(36, 45, 90);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(0, 179, 165);
            button2.Location = new Point(174, 382);
            button2.Name = "button2";
            button2.Size = new Size(190, 56);
            button2.TabIndex = 12;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(36, 45, 90);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(0, 179, 165);
            button3.Location = new Point(435, 382);
            button3.Name = "button3";
            button3.Size = new Size(190, 56);
            button3.TabIndex = 13;
            button3.Text = "Copy";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // CmdLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 57, 113);
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CmdLine";
            Text = "CmdLine";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox3;
        private Panel panel1;
        private Label label2;
        private Button button1;
        private Label label3;
        private RichTextBox richTextBox1;
        private Button button2;
        private Button button3;
    }
}