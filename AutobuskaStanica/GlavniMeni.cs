using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutobuskaStanica
{
    public partial class GlavniMeni : Form
    {
        public static GlavniMeni instanca;
        public static bool glavniMeniFlag = false;

        public string connectionString = "Server=127.0.0.1;Database=autobuskastanica1;Uid=root;Pwd=;";

        //Podaci za izdavanje Karte
        public string KartaID;             // automatski
        public string Sjediste = "1";      // PROBLEM
        public string BusID;               // iz rute
        public string Peron;               // iz rute
        public string Tip;                 // iz funkcije
        public string DatumPolaska;        // iz pickera
        public string VrijemePolaska;      // iz rute
        public string MjestoPolaska;       // iz rute
        public string MjestoDolaska;       // iz rute
        public string VrijemeIzdavanja;    // trenutno vrijeme
        public string RutaID;              // iz rute
        public string PutnikID;            // iz funkcije generisiPutnika
        public string Cijena;              // iz rute
        public string RadnikID;            // iz prijave
        public string StanicaID;           // iz funkcije
        public string NazivAutoprevoznika; // iz funkcije

        public string ImePutnika, PrezimePutnika, Kontakt;

        public string ImeRadnika, PrezimeRadnika;

        public GlavniMeni()
        {
            InitializeComponent();
            comboBox1.Items.Add("Učenik (20%)");
            comboBox1.Items.Add("Student (15%)");
            comboBox1.Items.Add("Penzioner (30%)");
            comboBox1.Items.Add("*BEZ POPUSTA");
            instanca = this;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            PrikazRuta();
        }

        private void PrikazRuta()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Ruta, VrijemePolaska , Cijena, MjestoPolaska, MjestoDolaska, NazivAutoprevoznika ,BusID, RutaID, Peron, BrojStanica, StanicaID FROM ruta WHERE StanicaID=@StanicaID";
                    StanicaID = Prijava.instanca.StanicaID;
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StanicaID", StanicaID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = reader["Ruta"].ToString();
                                item.SubItems.Add(reader["VrijemePolaska"].ToString());
                                item.SubItems.Add(reader["MjestoPolaska"].ToString());
                                item.SubItems.Add(reader["MjestoDolaska"].ToString());
                                item.SubItems.Add(reader["Cijena"].ToString());
                                item.SubItems.Add(reader["BrojStanica"].ToString());
                                item.SubItems.Add(reader["NazivAutoprevoznika"].ToString());
                                item.SubItems.Add(reader["Peron"].ToString());
                                item.SubItems.Add(reader["RutaID"].ToString());
                                item.SubItems.Add(reader["StanicaID"].ToString());
                                item.SubItems.Add(reader["BusID"].ToString());
                                listView1.Items.Add(item);
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

        private void dohvatiRadnika()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT Ime, Prezime FROM radnik WHERE RadnikID=@RadnikID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RadnikID", RadnikID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ImeRadnika = reader["Ime"].ToString();
                                PrezimeRadnika = reader["Prezime"].ToString();
                            }
                        }
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void generisiPutnika()
        {
            string imePutnika = textBox1.Text;
            string prezimePutnika = textBox2.Text;
            string kontakt = textBox3.Text;
            string query = "INSERT INTO putnik (Ime, Prezime, Kontakt) VALUES (@imePutnika, @prezimePutnika, @kontakt);" +
                            "SELECT LAST_INSERT_ID();";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@imePutnika", imePutnika);
                        command.Parameters.AddWithValue("@prezimePutnika", prezimePutnika);
                        command.Parameters.AddWithValue("@kontakt", kontakt);
                        int putnikID = Convert.ToInt32(command.ExecuteScalar());
                        PutnikID = putnikID.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            generisiPutnika();

            //Tip karte
            if (radioButton1.Checked) Tip = "Jednosmjerna";
            else if (radioButton2.Checked) Tip = "Povratna";

            //Cijena karte za popust
            double cijena;
            if (comboBox1.SelectedItem.ToString() == "Učenik (20%)") cijena = 0.8;
            else if (comboBox1.SelectedItem.ToString() == "Student (15%)") cijena = 0.85;
            else if (comboBox1.SelectedItem.ToString() == "Penzioner (30%)") cijena = 0.7;
            else cijena = 1;
            if (Tip == "Povratna") cijena *= 1.8;

            DatumPolaska = dateTimePicker1.Value.ToString("yyyy/MM/dd");

            //Informacije o putniku
            ImePutnika = textBox1.Text;
            PrezimePutnika = textBox2.Text;
            Kontakt = textBox3.Text;

            //Informacije o radniku i stanici
            int index = Prijava.instanca.TrenutniRadnik.LastIndexOf('-');
            RadnikID = Prijava.instanca.TrenutniRadnik.Substring(index + 1).Trim();
            StanicaID = Prijava.instanca.StanicaID;
            dohvatiRadnika();

            //Prihvatanje podataka iz selektovanog itema
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                BusID = selectedItem.SubItems[6].Text;
                Peron = selectedItem.SubItems[8].Text;
                VrijemePolaska = selectedItem.SubItems[1].Text;
                MjestoPolaska = selectedItem.SubItems[2].Text;
                MjestoDolaska = selectedItem.SubItems[3].Text;
                VrijemeIzdavanja = DateTime.Now.ToString("HH:mm:ss");
                RutaID = selectedItem.SubItems[8].Text;
                NazivAutoprevoznika = selectedItem.SubItems[6].Text;
                Cijena = selectedItem.SubItems[4].Text;
                BusID = selectedItem.SubItems[10].Text;
                double num = Convert.ToDouble(Cijena);
                num = num * cijena;
                Cijena = num.ToString();
            }

            izdajKartu();

        }

        private void izdajKartu()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("UnesiKartu", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Sjediste", Sjediste);
                    command.Parameters.AddWithValue("@BusID", BusID);
                    command.Parameters.AddWithValue("@Peron", Peron);
                    command.Parameters.AddWithValue("@Tip", Tip);
                    command.Parameters.AddWithValue("@DatumPolaska", DatumPolaska);
                    command.Parameters.AddWithValue("@VrijemePolaska", VrijemePolaska);
                    command.Parameters.AddWithValue("@MjestoPolaska", MjestoPolaska);
                    command.Parameters.AddWithValue("@MjestoDolaska", MjestoDolaska);
                    command.Parameters.AddWithValue("@VrijemeIzdavanja", VrijemeIzdavanja);
                    command.Parameters.AddWithValue("@RutaID", RutaID);
                    command.Parameters.AddWithValue("@PutnikID", PutnikID);
                    command.Parameters.AddWithValue("@Cijena", Cijena);
                    command.Parameters.AddWithValue("@RadnikID", RadnikID);
                    command.Parameters.AddWithValue("@StanicaID", StanicaID);
                    command.Parameters.AddWithValue("@NazivAutoprevoznika", NazivAutoprevoznika);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            ispisKarte();
        }

        private void ispisKarte()
        {
            string query = "SELECT * FROM karta ORDER BY KartaID DESC LIMIT 1";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime datumPolaska = DateTime.Parse(reader["DatumPolaska"].ToString());
                            string formatiranDatum = datumPolaska.ToString("dd MMMM yyyy");
                            string message =
                                $"Radnik: {Prijava.instanca.TrenutniRadnik}\n" +
                                $"Podaci o putniku:\n" +
                                $"Ime putnika: {ImePutnika}\n" +
                                $"Prezime putnika: {PrezimePutnika}\n\n" +
                                $"Podaci o karti:\n" +
                                $"KartaID: {reader["KartaID"]}\n" +
                                $"Sjediste: {reader["Sjediste"]}\n" +
                                $"BusID: {reader["BusID"]}\n" +
                                $"Peron: {reader["Peron"]}\n" +
                                $"Tip: {reader["Tip"]}\n" +
                                $"DatumPolaska: {formatiranDatum}\n" +
                                $"VrijemePolaska: {reader["VrijemePolaska"]}\n" +
                                $"MjestoPolaska: {reader["MjestoPolaska"]}\n" +
                                $"MjestoDolaska: {reader["MjestoDolaska"]}\n" +
                                $"VrijemeIzdavanja: {reader["VrijemeIzdavanja"]}\n" +
                                $"RutaID: {reader["RutaID"]}\n" +
                                $"PutnikID: {reader["PutnikID"]}\n" +
                                $"Cijena: {reader["Cijena"]}\n" +
                                $"RadnikID: {reader["RadnikID"]}\n" +
                                $"StanicaID: {reader["StanicaID"]}\n" +
                                $"NazivAutoprevoznika: {reader["NazivAutoprevoznika"]}";

                            MessageBox.Show(message, "Uspjesno izdata karta");
                        }
                        else
                        {
                            MessageBox.Show("Nema unesenih karata.", "Greška");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Greška");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            glavniMeniFlag = true;
            IzdateKarte instancaIK = new IzdateKarte();
            instancaIK.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Prijava.instanca.Show();
            this.Close();
        }
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string mjestoDolaskaFilter = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(mjestoDolaskaFilter))
            {
                PrikazRuta();
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Ruta, VrijemePolaska , Cijena, MjestoPolaska, MjestoDolaska, BusID , RutaID, Peron, BrojStanica, StanicaID FROM ruta WHERE StanicaID=@StanicaID AND MjestoDolaska LIKE @MjestoDolaskaFilter";

                    StanicaID = Prijava.instanca.StanicaID;

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StanicaID", StanicaID);
                        command.Parameters.AddWithValue("@MjestoDolaskaFilter", "%" + mjestoDolaskaFilter + "%");

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = reader["Ruta"].ToString();
                                item.SubItems.Add(reader["VrijemePolaska"].ToString());
                                item.SubItems.Add(reader["MjestoPolaska"].ToString());
                                item.SubItems.Add(reader["MjestoDolaska"].ToString());
                                item.SubItems.Add(reader["Cijena"].ToString());
                                item.SubItems.Add(reader["BrojStanica"].ToString());
                                item.SubItems.Add(reader["BusID"].ToString());
                                item.SubItems.Add(reader["Peron"].ToString());
                                item.SubItems.Add(reader["RutaID"].ToString());
                                item.SubItems.Add(reader["StanicaID"].ToString());
                                listView1.Items.Add(item);
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string vrijemePolaskaFilter = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(vrijemePolaskaFilter))
            {
                PrikazRuta();
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Ruta, VrijemePolaska , Cijena, MjestoPolaska, MjestoDolaska, BusID , RutaID, Peron, BrojStanica, StanicaID FROM ruta WHERE StanicaID=@StanicaID AND VrijemePolaska LIKE @VrijemePolaskaFilter";

                    StanicaID = Prijava.instanca.StanicaID;

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StanicaID", StanicaID);
                        command.Parameters.AddWithValue("@VrijemePolaskaFilter", "%" + vrijemePolaskaFilter + "%");

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = reader["Ruta"].ToString();
                                item.SubItems.Add(reader["VrijemePolaska"].ToString());
                                item.SubItems.Add(reader["MjestoPolaska"].ToString());
                                item.SubItems.Add(reader["MjestoDolaska"].ToString());
                                item.SubItems.Add(reader["Cijena"].ToString());
                                item.SubItems.Add(reader["BrojStanica"].ToString());
                                item.SubItems.Add(reader["BusID"].ToString());
                                item.SubItems.Add(reader["Peron"].ToString());
                                item.SubItems.Add(reader["RutaID"].ToString());
                                item.SubItems.Add(reader["StanicaID"].ToString());
                                listView1.Items.Add(item);
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

        private void button4_Click(object sender, EventArgs e)
        {
            string kartaOtkaz = textBox6.Text;
            int kartaID = Convert.ToInt32(kartaOtkaz);
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("ObrisiKartu", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@KartaID1", kartaID);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Uspješno obrisana karta.");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom brisanja karte: " + ex.Message, "Greška");
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Putnici instancaP = new Putnici();
            instancaP.Show();
            this.Hide();
        }
    }


}
