namespace AutobuskaStanica
{
    partial class IzdateKarte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzdateKarte));
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            label6 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader3, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader12, columnHeader13, columnHeader14, columnHeader15, columnHeader16 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 69);
            listView1.Name = "listView1";
            listView1.Size = new Size(1256, 506);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "KartaID";
            columnHeader1.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "BusID";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 70;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tip";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "DatumPolaska";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "VrijemePolaska";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "MjestoPolaska";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "MjestoDolaska";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "VrijemeIzdavanja";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            columnHeader10.Width = 120;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "PutnikID";
            columnHeader12.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "RadnikID";
            columnHeader13.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "StanicaID";
            columnHeader14.TextAlign = HorizontalAlignment.Center;
            columnHeader14.Width = 70;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "NazivAutoprevoznika";
            columnHeader15.TextAlign = HorizontalAlignment.Center;
            columnHeader15.Width = 150;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Cijena";
            columnHeader16.TextAlign = HorizontalAlignment.Center;
            columnHeader16.Width = 70;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 27F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(336, 47);
            label6.TabIndex = 17;
            label6.Text = "Izdate Karte ";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Transparent;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.ForeColor = SystemColors.Control;
            radioButton1.Location = new Point(12, 581);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(167, 41);
            radioButton1.TabIndex = 18;
            radioButton1.TabStop = true;
            radioButton1.Text = "Svi radnici";
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.ForeColor = SystemColors.Control;
            radioButton2.Location = new Point(12, 647);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(252, 41);
            radioButton2.TabIndex = 19;
            radioButton2.Text = "Prijavljen Radnik";
            radioButton2.UseVisualStyleBackColor = false;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(1126, 599);
            button1.Name = "button1";
            button1.Size = new Size(142, 35);
            button1.TabIndex = 20;
            button1.Text = "Nazad";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(307, 590);
            label1.Name = "label1";
            label1.Size = new Size(154, 28);
            label1.TabIndex = 21;
            label1.Text = "Mjesto Polaska";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(467, 595);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 23);
            textBox1.TabIndex = 22;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(467, 652);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(165, 23);
            textBox2.TabIndex = 24;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(307, 647);
            label2.Name = "label2";
            label2.Size = new Size(158, 28);
            label2.TabIndex = 23;
            label2.Text = "Mjesto Dolaska";
            // 
            // IzdateKarte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1280, 789);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label6);
            Controls.Add(listView1);
            Name = "IzdateKarte";
            Text = "IzdateKarte";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private Label label6;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
    }
}