namespace Dragon_
{
    partial class KLogger
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
            button2 = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(36, 45, 90);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(0, 179, 165);
            button2.Location = new Point(202, 420);
            button2.Name = "button2";
            button2.Size = new Size(174, 56);
            button2.TabIndex = 5;
            button2.Text = "Copy";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(36, 45, 90);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 179, 165);
            button1.Location = new Point(12, 420);
            button1.Name = "button1";
            button1.Size = new Size(174, 56);
            button1.TabIndex = 6;
            button1.Text = "Start Logging";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(36, 45, 90);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.FromArgb(0, 179, 165);
            richTextBox1.Location = new Point(30, 66);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(526, 335);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 179, 165);
            label1.Location = new Point(16, 6);
            label1.Name = "label1";
            label1.Size = new Size(321, 46);
            label1.TabIndex = 3;
            label1.Text = "Clients Key Strokes";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(36, 45, 90);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(0, 179, 165);
            button3.Location = new Point(398, 420);
            button3.Name = "button3";
            button3.Size = new Size(174, 56);
            button3.TabIndex = 5;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // KLogger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 57, 113);
            ClientSize = new Size(584, 488);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KLogger";
            Text = "KLogger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private RichTextBox richTextBox1;
        private Label label1;
        private Button button3;
    }
}