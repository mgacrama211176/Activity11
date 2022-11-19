using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace Activity11
{
    public partial class Form1 : Form
    {
        string connectionString = "server = localhost; uid = root; pwd=; database=payroll";


        public Form1()
        {
            InitializeComponent();
            LoadList();
            comboBox1.SelectedIndex = 0;
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
            decimal rate = 0;
            int hoursWorked = 0;
            string status = comboBox1.Text.Substring(0, 1);

            try
            {
                rate = Convert.ToDecimal(textBox5.Text.Trim());
                try
                {
                    hoursWorked = Convert.ToInt32(textBox4.Text.Trim());
                    try
                    {
                        using (var connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "insert into employee(lastname,firstname,middlename,position,rate,hours_worked,status) values ('" + lname + "','" + fname + "','" + mname + "','" + position + "'," + rate + "," + hoursWorked + ",'" + status + "')";
                            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                            {
                                cmd.ExecuteNonQuery();

                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox6.Text = "";

                                textBox1.Focus();
                                MessageBox.Show("Added to database!");
                                LoadList();

                            }
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.ToString());
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    MessageBox.Show("Error: Hours Worked must be a number!");
                    textBox4.Text = "";
                    textBox4.Focus();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Error: rate must be a number!");
                textBox5.Text = "";
                textBox5.Focus();
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadList()
        {
            //connetion to DB
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from employee";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter();
                    mda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    mda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
