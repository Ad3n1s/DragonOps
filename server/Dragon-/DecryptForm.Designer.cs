namespace Dragon_
{
    partial class DecryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecryptForm));
            textBox3 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(46, 57, 113);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.FromArgb(0, 179, 165);
            textBox3.Location = new Point(73, 147);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(646, 21);
            textBox3.TabIndex = 8;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 179, 165);
            label2.Location = new Point(12, 101);
            label2.Name = "label2";
            label2.Size = new Size(306, 28);
            label2.TabIndex = 7;
            label2.Text = "Please Input the Decryption Key";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 179, 165);
            panel1.ForeColor = Color.FromArgb(0, 179, 165);
            panel1.Location = new Point(51, 174);
            panel1.Name = "panel1";
            panel1.Size = new Size(704, 1);
            panel1.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(46, 57, 113);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(0, 179, 165);
            textBox1.Location = new Point(73, 303);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(646, 21);
            textBox1.TabIndex = 11;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 179, 165);
            label1.Location = new Point(12, 257);
            label1.Name = "label1";
            label1.Size = new Size(292, 28);
            label1.TabIndex = 10;
            label1.Text = "Please Input the Decryption IV";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 179, 165);
            panel2.ForeColor = Color.FromArgb(0, 179, 165);
            panel2.Location = new Point(44, 330);
            panel2.Name = "panel2";
            panel2.Size = new Size(704, 1);
            panel2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 179, 165);
            label3.Location = new Point(305, 9);
            label3.Name = "label3";
            label3.Size = new Size(133, 31);
            label3.TabIndex = 12;
            label3.Text = "Decrpytion";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(36, 45, 90);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 179, 165);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(290, 371);
            button1.Name = "button1";
            button1.Size = new Size(175, 53);
            button1.TabIndex = 13;
            button1.Text = "Decrypt";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // DecryptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 57, 113);
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DecryptForm";
            Text = "DecryptForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private Label label2;
        private Panel panel1;
        private TextBox textBox1;
        private Label label1;
        private Panel panel2;
        private Label label3;
        private Button button1;
    }
}