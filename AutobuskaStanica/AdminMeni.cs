using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutobuskaStanica
{
    public partial class AdminMeni : Form
    {
        public static AdminMeni instanca;

        public AdminMeni()
        {
            InitializeComponent();
            label1.Text = "";
            label1.Text += "Dobrodosao, \n " + Prijava.instanca.admin;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            instanca = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Radnici instancaR = new Radnici();
            instancaR.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rute instancaRute = new Rute();
            instancaRute.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Prijava.instanca.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stanice instancaS = new Stanice();
            instancaS.Show();
            this.Hide();
        }
    }
}
