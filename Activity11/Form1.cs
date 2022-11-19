using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Activity11
{
    public partial class Form1 : Form
    {
        string connectionString = "server = localhost; uid = root; pwd=; database=payroll";
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lname = textBox1.Text.Trim();
            string fname = textBox2.Text.Trim();
            string mname = textBox3.Text.Trim();
            string position = textBox6.Text.Trim();
            decimal rate = Convert.ToDecimal(textBox6.Text.Trim());
            int hoursWorked = Convert.ToInt32(textBox4.Text.Trim());
            char status = Convert.ToChar(comboBox1.Text);

            try {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connected!");
                }
            } 
            catch (Exception err) {
                Console.WriteLine(err.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
