namespace AutobuskaStanica
{
    partial class GlavniMeni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlavniMeni));
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            listView1 = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            comboBox1 = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            label7 = new Label();
            textBox4 = new TextBox();
            label8 = new Label();
            textBox5 = new TextBox();
            button4 = new Button();
            textBox6 = new TextBox();
            label9 = new Label();
            button5 = new Button();
            columnHeader11 = new ColumnHeader();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1113, 526);
            button1.Name = "button1";
            button1.Size = new Size(180, 43);
            button1.TabIndex = 0;
            button1.Text = "Izdaj Kartu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader1, columnHeader2, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 44);
            listView1.Name = "listView1";
            listView1.Size = new Size(1095, 507);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ruta";
            columnHeader3.Width = 160;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Vrijeme Polaska";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Mjesto Polaska";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Mjesto Dolaska";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Cijena";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Broj Stanica";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Autoprevoznik";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            columnHeader7.Width = 110;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Peron";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "RutaID";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "StanicaID";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            columnHeader10.Width = 80;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(1101, 44);
            label1.Name = "label1";
            label1.Size = new Size(157, 40);
            label1.TabIndex = 2;
            label1.Text = "Tip Karte";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(1277, 44);
            label2.Name = "label2";
            label2.Size = new Size(157, 40);
            label2.TabIndex = 5;
            label2.Text = "Popust";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(1113, 281);
            label3.Name = "label3";
            label3.Size = new Size(140, 36);
            label3.TabIndex = 9;
            label3.Text = "Ime";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1114, 320);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 23);
            textBox1.TabIndex = 10;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(1113, 356);
            label4.Name = "label4";
            label4.Size = new Size(140, 36);
            label4.TabIndex = 11;
            label4.Text = "Prezime";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1114, 395);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(233, 23);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1114, 478);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(233, 23);
            textBox3.TabIndex = 14;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(1113, 439);
            label5.Name = "label5";
            label5.Size = new Size(140, 36);
            label5.TabIndex = 13;
            label5.Text = "Kontakt";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1113, 241);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 15;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(1113, 188);
            label6.Name = "label6";
            label6.Size = new Size(169, 36);
            label6.TabIndex = 16;
            label6.Text = "DatumPolaska";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.ForeColor = SystemColors.Control;
            radioButton2.Location = new Point(1113, 137);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(72, 19);
            radioButton2.TabIndex = 4;
            radioButton2.Text = "Povratna";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Transparent;
            radioButton1.ForeColor = SystemColors.Control;
            radioButton1.Location = new Point(1113, 98);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 19);
            radioButton1.TabIndex = 3;
            radioButton1.Text = "Jednosmjerna";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1277, 98);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(157, 23);
            comboBox1.TabIndex = 17;
            // 
            // button2
            // 
            button2.Location = new Point(50, 582);
            button2.Name = "button2";
            button2.Size = new Size(180, 43);
            button2.TabIndex = 18;
            button2.Text = "IZDATE KARTE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(876, 582);
            button3.Name = "button3";
            button3.Size = new Size(180, 43);
            button3.TabIndex = 19;
            button3.Text = "ODJAVA";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(307, 572);
            label7.Name = "label7";
            label7.Size = new Size(169, 31);
            label7.TabIndex = 20;
            label7.Text = "Mjesto Dolaska";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(307, 606);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(190, 23);
            textBox4.TabIndex = 21;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(534, 572);
            label8.Name = "label8";
            label8.Size = new Size(169, 31);
            label8.TabIndex = 22;
            label8.Text = "Vrijeme Polaska";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(534, 606);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(190, 23);
            textBox5.TabIndex = 23;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // button4
            // 
            button4.Location = new Point(1384, 650);
            button4.Name = "button4";
            button4.Size = new Size(98, 23);
            button4.TabIndex = 24;
            button4.Text = "Otkazi Kartu";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1233, 651);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(145, 23);
            textBox6.TabIndex = 25;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(1233, 620);
            label9.Name = "label9";
            label9.Size = new Size(98, 29);
            label9.TabIndex = 26;
            label9.Text = "KartaID";
            // 
            // button5
            // 
            button5.Location = new Point(50, 630);
            button5.Name = "button5";
            button5.Size = new Size(180, 43);
            button5.TabIndex = 27;
            button5.Text = "PUTNICI";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "BusID";
            // 
            // GlavniMeni
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1505, 690);
            Controls.Add(button5);
            Controls.Add(label9);
            Controls.Add(textBox6);
            Controls.Add(button4);
            Controls.Add(textBox5);
            Controls.Add(label8);
            Controls.Add(textBox4);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(button1);
            Name = "GlavniMeni";
            Text = "GlavniMeni";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListView listView1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Label label1;
        private Label label2;
        private ColumnHeader columnHeader8;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
        private Button button2;
        private Button button3;
        private Label label7;
        private TextBox textBox4;
        private Label label8;
        private TextBox textBox5;
        private Button button4;
        private TextBox textBox6;
        private Label label9;
        private Button button5;
        private ColumnHeader columnHeader11;
    }
}