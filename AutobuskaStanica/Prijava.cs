using System;
using System.Data;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.LinkLabel;

namespace AutobuskaStanica
{

    public partial class Prijava : Form
    {

        public static Prijava instanca;
        public string admin;

        public Prijava()
        {
            InitializeComponent();
            instanca = this;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox1.Clear();
            PrikazStanica();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false;

        }

        public string connectionString = "Server=127.0.0.1;Database=autobuskastanica1;Uid=root;Pwd=;";
        public string RadnikID, StanicaID, TrenutniRadnik;
        private void PrikazStanica()
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT NazivStanice, Adresa, StanicaID FROM autobuskastanica";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string naziv = reader.GetString("NazivStanice");
                                string adresa = reader.GetString("Adresa");
                                //StanicaID = reader.GetString("StanicaID");
                                string comboBoxItem = $"{naziv} - {adresa}";
                                comboBox1.Items.Add(comboBoxItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void clearCombo()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            PrikazStanica();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selektovanaStanica = comboBox1.SelectedItem as string;
            if (!string.IsNullOrEmpty(selektovanaStanica))
            {
                string nazivStanice = selektovanaStanica.Split('-')[0].Trim();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT Ime, Prezime, RadnikID, StanicaID FROM radnik WHERE StanicaID = (SELECT StanicaID FROM autobuskastanica WHERE NazivStanice = @nazivStanice)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@nazivStanice", nazivStanice);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                comboBox2.Items.Clear();
                                while (reader.Read())
                                {
                                    string ime = reader.GetString("Ime");
                                    string prezime = reader.GetString("Prezime");
                                    string radnikid = reader.GetString("RadnikID");
                                    RadnikID = reader.GetString("RadnikID");
                                    StanicaID = reader.GetString("StanicaID");
                                    string worker = $"{ime} {prezime} - {radnikid}";
                                    comboBox2.Items.Add(worker);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrenutniRadnik = comboBox2.SelectedItem.ToString();
            int index = TrenutniRadnik.LastIndexOf('-');
            RadnikID = TrenutniRadnik.Substring(index + 1).Trim();

            string sifra = textBox1.Text;
            string podatak1 = RadnikID + " " + sifra;

            string putanjaDatoteke = "C:\\Users\\Administrator\\source\\repos\\AutobuskaStanica\\RadnikSifre.txt";

            if (checkPassword(putanjaDatoteke, podatak1))
            {
                GlavniMeni instancaGM = new GlavniMeni();
                instancaGM.Show();
                textBox1.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Prijava nije uspešna. Proverite RadnikID i šifru.", "Neuspela prijava", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkPassword(string putanja, string podatak)
        {
            if (!File.Exists(putanja)) return false;
            string[] linije = File.ReadAllLines(putanja);
            return linije.Any(linija => linija.Trim() == podatak);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string unesenaSifra = textBox2.Text;
            string[] linijeAdminFajla = System.IO.File.ReadAllLines("C:\\Users\\Administrator\\source\\repos\\AutobuskaStanica\\Admin.txt");
            foreach (string linija in linijeAdminFajla)
            {
                string[] delovi = linija.Split(' ');
                if (delovi.Length == 2)
                {
                    string adminIme = delovi[0];
                    string adminSifra = delovi[1];
                    if (unesenaSifra == adminSifra)
                    {
                        admin = adminIme;
                        AdminMeni instancaAM = new AdminMeni();
                        textBox1.Clear();
                        clearCombo();
                        instancaAM.Show();
                        this.Hide();  
                        return;  
                    }
                }
            }
            MessageBox.Show("Pogrešna šifra.");
        }
    }


}