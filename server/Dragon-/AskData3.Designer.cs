namespace Dragon_
{
    partial class AskData3
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
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 179, 165);
            label2.Location = new Point(32, 85);
            label2.Name = "label2";
            label2.Size = new Size(121, 31);
            label2.TabIndex = 20;
            label2.Text = "Error Title";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 179, 165);
            label1.Location = new Point(276, 9);
            label1.Name = "label1";
            label1.Size = new Size(121, 31);
            label1.TabIndex = 19;
            label1.Text = "Fake Error";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(46, 57, 113);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(0, 179, 165);
            textBox1.Location = new Point(159, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(457, 21);
            textBox1.TabIndex = 18;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 179, 165);
            panel1.ForeColor = Color.FromArgb(0, 179, 165);
            panel1.Location = new Point(166, 129);
            panel1.Name = "panel1";
            panel1.Size = new Size(478, 1);
            panel1.TabIndex = 17;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(36, 45, 90);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(0, 179, 165);
            button2.Location = new Point(120, 245);
            button2.Name = "button2";
            button2.Size = new Size(190, 56);
            button2.TabIndex = 15;
            button2.Text = "Send Error";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(36, 45, 90);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 179, 165);
            button1.Location = new Point(373, 245);
            button1.Name = "button1";
            button1.Size = new Size(190, 56);
            button1.TabIndex = 16;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 179, 165);
            panel2.ForeColor = Color.FromArgb(0, 179, 165);
            panel2.Location = new Point(165, 212);
            panel2.Name = "panel2";
            panel2.Size = new Size(479, 1);
            panel2.TabIndex = 17;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(46, 57, 113);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.FromArgb(0, 179, 165);
            textBox2.Location = new Point(172, 173);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(458, 21);
            textBox2.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 179, 165);
            label3.Location = new Point(1, 163);
            label3.Name = "label3";
            label3.Size = new Size(165, 31);
            label3.TabIndex = 20;
            label3.Text = "Error Message";
            // 
            // AskData3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 57, 113);
            ClientSize = new Size(678, 352);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AskData3";
            Text = "AskData3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private TextBox textBox2;
        private Label label3;
    }
}