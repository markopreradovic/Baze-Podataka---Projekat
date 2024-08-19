using Microsoft.VisualBasic.ApplicationServices;
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

    public partial class Radnici : Form
    {
        public string connectionString = "Server=127.0.0.1;Database=autobuskastanica1;Uid=root;Pwd=;";
        public static Radnici instanca;
        public Radnici()
        {
            InitializeComponent();
            instanca = this;
            ucitajRadnike();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void ucitajRadnike()
        {
            listView1.Items.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM radnici";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["RadnikID"].ToString());
                            item.SubItems.Add(reader["Ime"].ToString());
                            item.SubItems.Add(reader["Prezime"].ToString());
                            string datumRodjenja = reader["DatumRodjenja"].ToString();
                            DateTime datum = DateTime.Parse(datumRodjenja);
                            item.SubItems.Add(datum.ToString("dd.MM.yyyy"));
                            item.SubItems.Add(reader["JMBG"].ToString());
                            item.SubItems.Add(reader["Kontakt"].ToString());
                            item.SubItems.Add(reader["Adresa"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            string Ime = textBox1.Text;
            string Prezime = textBox2.Text;
            string DatumRodjenja = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string JMBG = textBox4.Text;
            string Kontakt = textBox3.Text;
            string Adresa = textBox6.Text;
            int StanicaID = Convert.ToInt32(textBox5.Text);
            int RadnikID = Convert.ToInt32(textBox7.Text);
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    using (MySqlCommand command = new MySqlCommand("UnesiRadnika", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RadnikID1", RadnikID);
                        command.Parameters.AddWithValue("@Ime1", Ime);
                        command.Parameters.AddWithValue("@Prezime1", Prezime);
                        command.Parameters.AddWithValue("@DatumRodjenja1", DatumRodjenja);
                        command.Parameters.AddWithValue("@JMBG1", JMBG);
                        command.Parameters.AddWithValue("@Kontakt1", Kontakt);
                        command.Parameters.AddWithValue("@Adresa1", Adresa);
                        command.Parameters.AddWithValue("@StanicaID1", StanicaID);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Uspjesan unos");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom unosa radnika: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string Sifra = textBox8.Text;
            using (StreamWriter sw = File.AppendText("C:\\Users\\Administrator\\source\\repos\\AutobuskaStanica\\RadnikSifre.txt"))
            {
                sw.WriteLine($"{RadnikID} {Sifra}");
            }
            ucitajRadnike();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    int radnikID = int.Parse(selectedItem.SubItems[0].Text);
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand("DELETE FROM radnik WHERE RadnikID = @RadnikID", connection))
                        {
                            command.Parameters.AddWithValue("@RadnikID", radnikID);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Radnik uspešno obrisan.");
                        }
                        ucitajRadnike();
                    }
                }
                else
                {
                    MessageBox.Show("Molimo izaberite radnika za brisanje.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja radnika: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminMeni.instanca.Show();
            this.Close();
        }
    }
}
