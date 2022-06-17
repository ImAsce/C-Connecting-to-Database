using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Belvis___Final_Lab_1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'registrationFormDBDataSet.RegistrationFormTB' table. You can move, or remove it, as needed.
            this.registrationFormTBTableAdapter.Fill(this.registrationFormDBDataSet.RegistrationFormTB);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string connectionString;
                SqlConnection con;
                connectionString = @"Data Source=BELVIS-DJ\SQLEXPRESS01;Initial Catalog=RegistrationFormDB;Integrated Security=True";

                con = new SqlConnection(connectionString);
                con.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                String sql = "";
                DataTable dt = new DataTable();

                sql = "SELECT * FROM RegistrationFormTB WHERE ID LIKE '" + Int32.Parse(textBox1.Text) + "%' ORDER BY ID ASC";
                dataAdapter = new SqlDataAdapter(sql, con);
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                string connectionString;
                SqlConnection con;
                connectionString = @"Data Source=BELVIS-DJ\SQLEXPRESS01;Initial Catalog=RegistrationFormDB;Integrated Security=True";

                con = new SqlConnection(connectionString);
                con.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                String sql = "";
                DataTable dt = new DataTable();

                sql = "SELECT * FROM RegistrationFormTB ORDER BY ID ASC";
                dataAdapter = new SqlDataAdapter(sql, con);
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }
    }
}
