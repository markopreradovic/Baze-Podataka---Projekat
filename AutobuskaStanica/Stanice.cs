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
    public partial class Stanice : Form
    {
        public static Stanice instanca;
        public string connectionString = "Server=127.0.0.1;Database=autobuskastanica1;Uid=root;Pwd=;";

        public Stanice()
        {
            InitializeComponent();
            instanca = this;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            prikazStanica();
        }

        private void prikazStanica()
        {
            try
            {
                listView1.Items.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM stanice", connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["StanicaID"].ToString());
                            item.SubItems.Add(reader["NazivStanice"].ToString());
                            item.SubItems.Add(reader["Mjesto"].ToString());
                            item.SubItems.Add(reader["BrojPerona"].ToString());
                            item.SubItems.Add(reader["Adresa"].ToString());
                            item.SubItems.Add(reader["Kontakt"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom učitavanja stanica: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminMeni.instanca.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int StanicaID = Convert.ToInt32(textBox1.Text);
            string NazivStanice = textBox2.Text;
            string Mjesto = textBox3.Text;
            int BrojPerona = Convert.ToInt32(textBox4.Text);
            string Adresa = textBox5.Text;
            string Kontakt = textBox6.Text;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand("UnesiStanicu", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StanicaID1", StanicaID);
                        command.Parameters.AddWithValue("@NazivStanice1", NazivStanice);
                        command.Parameters.AddWithValue("@Mjesto1", Mjesto);
                        command.Parameters.AddWithValue("@BrojPerona1", BrojPerona);
                        command.Parameters.AddWithValue("@Adresa1", Adresa);
                        command.Parameters.AddWithValue("@Kontakt1", Kontakt);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Podaci su uspješno dodani u tabelu autobuskastanica.");
                        prikazStanica();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom dodavanja podataka: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox8.Text))
                {
                    int stanicaID = Convert.ToInt32(textBox8.Text);
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand("DELETE FROM autobuskastanica WHERE StanicaID = @StanicaID", connection))
                        {
                            command.Parameters.AddWithValue("@StanicaID", stanicaID);
                            int affectedRows = command.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Stanica je uspješno obrisana!");
                                prikazStanica();
                            }
                            else
                            {
                                MessageBox.Show("Stanica s navedenim StanicaID nije pronađena.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unesite ID za brisanje.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja stanice: " + ex.Message);
            }

        }
    }
}
