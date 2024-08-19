using MySql.Data.MySqlClient;
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
    public partial class IzdateKarte : Form
    {

        public static IzdateKarte instanca;
        public string connectionString = "Server=127.0.0.1;Database=autobuskastanica1;Uid=root;Pwd=;";
        public string RadnikID;
        public IzdateKarte()
        {
            InitializeComponent();
            prikazKarata();
            instanca = this;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void prikazKarata()
        {
            listView1.Items.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM IzdateKarte";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["KartaID"].ToString());
                                item.SubItems.Add(reader["BusID"].ToString());
                                item.SubItems.Add(reader["Tip"].ToString());


                                
                                DateTime datumPolaska = (DateTime)reader["DatumPolaska"];
                                string formatiraniDatum = datumPolaska.ToString("dd MM yyyy");
                                item.SubItems.Add(formatiraniDatum);

                                item.SubItems.Add(reader["VrijemePolaska"].ToString());
                                item.SubItems.Add(reader["MjestoPolaska"].ToString());
                                item.SubItems.Add(reader["MjestoDolaska"].ToString());
                                item.SubItems.Add(reader["VrijemeIzdavanja"].ToString());
                                item.SubItems.Add(reader["PutnikID"].ToString());
                                item.SubItems.Add(reader["RadnikID"].ToString());
                                item.SubItems.Add(reader["StanicaID"].ToString());
                                item.SubItems.Add(reader["NazivAutoprevoznika"].ToString());
                                item.SubItems.Add(reader["Cijena"].ToString());
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM IzdateKarte";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["KartaID"].ToString());
                            item.SubItems.Add(reader["BusID"].ToString());
                            item.SubItems.Add(reader["Tip"].ToString());
                            item.SubItems.Add(reader["DatumPolaska"].ToString());
                            item.SubItems.Add(reader["VrijemePolaska"].ToString());
                            item.SubItems.Add(reader["MjestoPolaska"].ToString());
                            item.SubItems.Add(reader["MjestoDolaska"].ToString());
                            item.SubItems.Add(reader["VrijemeIzdavanja"].ToString());
                            item.SubItems.Add(reader["PutnikID"].ToString());
                            item.SubItems.Add(reader["RadnikID"].ToString());
                            item.SubItems.Add(reader["StanicaID"].ToString());
                            item.SubItems.Add(reader["NazivAutoprevoznika"].ToString());
                            item.SubItems.Add(reader["Cijena"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int index = Prijava.instanca.TrenutniRadnik.LastIndexOf('-');
            RadnikID = Prijava.instanca.TrenutniRadnik.Substring(index + 1).Trim();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM IzdateKarte WHERE RadnikID=@RadnikID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RadnikID", RadnikID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["KartaID"].ToString());
                            item.SubItems.Add(reader["BusID"].ToString());
                            item.SubItems.Add(reader["Tip"].ToString());
                            item.SubItems.Add(reader["DatumPolaska"].ToString());
                            item.SubItems.Add(reader["VrijemePolaska"].ToString());
                            item.SubItems.Add(reader["MjestoPolaska"].ToString());
                            item.SubItems.Add(reader["MjestoDolaska"].ToString());
                            item.SubItems.Add(reader["VrijemeIzdavanja"].ToString());
                            item.SubItems.Add(reader["PutnikID"].ToString());
                            item.SubItems.Add(reader["RadnikID"].ToString());
                            item.SubItems.Add(reader["StanicaID"].ToString());
                            item.SubItems.Add(reader["NazivAutoprevoznika"].ToString());
                            item.SubItems.Add(reader["Cijena"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlavniMeni.instanca.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Mjesto = textBox1.Text;
            listView1.Items.Clear(); 
            if (string.IsNullOrWhiteSpace(Mjesto))
            {
                prikazKarata(); 
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM IzdateKarte WHERE MjestoPolaska = @Mjesto";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Mjesto", Mjesto);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["MjestoPolaska"].ToString() == Mjesto)
                            {
                                ListViewItem item = new ListViewItem(reader["KartaID"].ToString());
                                item.SubItems.Add(reader["BusID"].ToString());
                                item.SubItems.Add(reader["Tip"].ToString());
                                item.SubItems.Add(reader["DatumPolaska"].ToString());
                                item.SubItems.Add(reader["VrijemePolaska"].ToString());
                                item.SubItems.Add(reader["MjestoPolaska"].ToString());
                                item.SubItems.Add(reader["MjestoDolaska"].ToString());
                                item.SubItems.Add(reader["VrijemeIzdavanja"].ToString());
                                item.SubItems.Add(reader["PutnikID"].ToString());
                                item.SubItems.Add(reader["RadnikID"].ToString());
                                item.SubItems.Add(reader["StanicaID"].ToString());
                                item.SubItems.Add(reader["NazivAutoprevoznika"].ToString());
                                item.SubItems.Add(reader["Cijena"].ToString());
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string Mjesto = textBox2.Text;
            listView1.Items.Clear(); 
            if (string.IsNullOrWhiteSpace(Mjesto))
            {
                prikazKarata(); 
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM IzdateKarte WHERE MjestoDolaska = @Mjesto";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Mjesto", Mjesto);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["MjestoDolaska"].ToString() == Mjesto)
                            {
                                ListViewItem item = new ListViewItem(reader["KartaID"].ToString());
                                item.SubItems.Add(reader["BusID"].ToString());
                                item.SubItems.Add(reader["Tip"].ToString());
                                item.SubItems.Add(reader["DatumPolaska"].ToString());
                                item.SubItems.Add(reader["VrijemePolaska"].ToString());
                                item.SubItems.Add(reader["MjestoPolaska"].ToString());
                                item.SubItems.Add(reader["MjestoDolaska"].ToString());
                                item.SubItems.Add(reader["VrijemeIzdavanja"].ToString());
                                item.SubItems.Add(reader["PutnikID"].ToString());
                                item.SubItems.Add(reader["RadnikID"].ToString());
                                item.SubItems.Add(reader["StanicaID"].ToString());
                                item.SubItems.Add(reader["NazivAutoprevoznika"].ToString());
                                item.SubItems.Add(reader["Cijena"].ToString());
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
