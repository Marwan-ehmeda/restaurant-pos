namespace WindowsFormsApplication4
{
    partial class Form9PAid
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
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(147, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 24);
            this.label7.TabIndex = 45;
            this.label7.Text = "طريقة الدفع";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(137, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 24);
            this.label5.TabIndex = 43;
            this.label5.Text = "المبلغ المتبقي";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.LightGray;
            this.textBox5.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.Red;
            this.textBox5.Location = new System.Drawing.Point(22, 305);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(316, 41);
            this.textBox5.TabIndex = 42;
            this.textBox5.Tag = " ";
            this.textBox5.Text = " ";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox9_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(137, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "المبلغ المدفوع";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.LightGray;
            this.textBox4.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Red;
            this.textBox4.Location = new System.Drawing.Point(22, 226);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(316, 41);
            this.textBox4.TabIndex = 40;
            this.textBox4.Tag = " ";
            this.textBox4.Text = " ";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox9_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(137, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 39;
            this.label2.Text = "قيمة الخصم";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightGray;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(22, 142);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(316, 41);
            this.textBox2.TabIndex = 38;
            this.textBox2.Tag = " ";
            this.textBox2.Text = " 0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox9_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(130, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "المبلغ الاجمالي";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.White;
            this.textBox9.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.Color.Red;
            this.textBox9.Location = new System.Drawing.Point(22, 64);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(316, 41);
            this.textBox9.TabIndex = 36;
            this.textBox9.Tag = "0.00";
            this.textBox9.Text = " 0.00";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            this.textBox9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox9_KeyPress);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.DarkRed;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(22, 450);
            this.button8.Margin = new System.Windows.Forms.Padding(1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(324, 38);
            this.button8.TabIndex = 46;
            this.button8.Text = "ادفع الأن";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(324, 117);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(40, 19);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = " ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightGray;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "نقدي",
            "فيزا"});
            this.comboBox1.Location = new System.Drawing.Point(22, 389);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 43);
            this.comboBox1.TabIndex = 48;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(22, 490);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 38);
            this.button1.TabIndex = 49;
            this.button1.Text = "طباعة";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form9PAid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(365, 538);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox9);
            this.Name = "Form9PAid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "0.00";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form9PAid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}