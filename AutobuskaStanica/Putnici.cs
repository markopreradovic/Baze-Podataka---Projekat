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
    public partial class Putnici : Form
    {

        public static Putnici instanca;
        public string connectionString = "Server=127.0.0.1;Database=autobuskastanica1;Uid=root;Pwd=;";
        public Putnici()
        {
            InitializeComponent();
            instanca = this;
            prikazPutnika();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void prikazPutnika()
        {
            listView1.Items.Clear();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Putnici";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["PutnikID"].ToString());
                            item.SubItems.Add(reader["Ime"].ToString());
                            item.SubItems.Add(reader["Prezime"].ToString());
                            item.SubItems.Add(reader["Kontakt"].ToString());
                            listView1.Items.Add(item);
                        }
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
            GlavniMeni.instanca.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string ime = textBox1.Text;
            listView1.Items.Clear();
            if (string.IsNullOrWhiteSpace(ime))
            {
                prikazPutnika();
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Putnici WHERE Ime LIKE @Ime";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ime", $"%{ime}%");
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["PutnikID"].ToString());
                                item.SubItems.Add(reader["Ime"].ToString());
                                item.SubItems.Add(reader["Prezime"].ToString());
                                item.SubItems.Add(reader["Kontakt"].ToString());
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string prezime = textBox2.Text;
            listView1.Items.Clear();
            if (string.IsNullOrWhiteSpace(prezime))
            {
                prikazPutnika();
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Putnici WHERE Prezime LIKE @prezime";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@prezime", $"%{prezime}%");
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["PutnikID"].ToString());
                                item.SubItems.Add(reader["Ime"].ToString());
                                item.SubItems.Add(reader["Prezime"].ToString());
                                item.SubItems.Add(reader["Kontakt"].ToString());
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
    }
}
