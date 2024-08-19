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
    public partial class Rute : Form
    {
        public static Rute instanca;
        public string connectionString = "Server=127.0.0.1;Database=autobuskastanica1;Uid=root;Pwd=;";

        public Rute()
        {
            InitializeComponent();
            instanca = this;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ucitajRute();
        }

        private void ucitajRute()
        {
            try
            {
                listView1.Items.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM ruta", connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["RutaID"].ToString());
                            item.SubItems.Add(reader["Ruta"].ToString());
                            item.SubItems.Add(reader["VrijemePolaska"].ToString());
                            item.SubItems.Add(reader["MjestoPolaska"].ToString());
                            item.SubItems.Add(reader["MjestoDolaska"].ToString());
                            item.SubItems.Add(reader["Peron"].ToString());
                            item.SubItems.Add(reader["StanicaID"].ToString());
                            item.SubItems.Add(reader["NazivAutoprevoznika"].ToString());
                            item.SubItems.Add(reader["Cijena"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom učitavanja ruta: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string RutaID = textBox1.Text;
            string Ruta = textBox2.Text;
            float Cijena = float.Parse(textBox3.Text);
            string VrijemePolaska = textBox4.Text;
            string MjestoPolaska = textBox6.Text;
            string MjestoDolaska = textBox5.Text;
            int VozacID = Convert.ToInt32(textBox8.Text);
            int KondukterID = Convert.ToInt32(textBox7.Text);
            int StanicaID = Convert.ToInt32(textBox10.Text);
            int Peron = Convert.ToInt32(textBox11.Text);
            int BrojStanica = Convert.ToInt32(textBox12.Text);
            string NazivAutoprevoznika = textBox9.Text;
            int BusID = Convert.ToInt32(textBox13.Text);
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("UnesiRutu", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RutaID1", RutaID);
                        command.Parameters.AddWithValue("@Ruta1", Ruta);
                        command.Parameters.AddWithValue("@VrijemePolaska1", VrijemePolaska);
                        command.Parameters.AddWithValue("@MjestoPolaska1", MjestoPolaska);
                        command.Parameters.AddWithValue("@MjestoDolaska1", MjestoDolaska);
                        command.Parameters.AddWithValue("@BrojStanica1", BrojStanica);
                        command.Parameters.AddWithValue("@VozacID1", VozacID);
                        command.Parameters.AddWithValue("@KondukterID1", KondukterID);
                        command.Parameters.AddWithValue("@BusID1", BusID);
                        command.Parameters.AddWithValue("@StanicaID1", StanicaID);
                        command.Parameters.AddWithValue("@Cijena1", Cijena);
                        command.Parameters.AddWithValue("@NazivAutoprevoznika1", NazivAutoprevoznika);
                        command.Parameters.AddWithValue("@Peron1", Peron);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Uspješan unos rute");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom unosa rute!");
            }
            ucitajRute();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminMeni.instanca.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int rutaID = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand("DELETE FROM ruta WHERE RutaID = @RutaID1", connection))
                        {
                            command.Parameters.AddWithValue("@RutaID1", rutaID);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Uspješno obrisana ruta.");
                            ucitajRute();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Molimo izaberite rutu za brisanje.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja rute");
            }
        }
    }
}
