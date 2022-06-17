using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belvis___Final_Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Gender()
        {
            string gender = "";

            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else if (radioButton2.Checked)
            {
                gender = "Female";
            }

            return gender;
        }

        public string Hobbies()
        {
            string hobbies = "";
            if(checkBox1.Checked)
            {
                hobbies = hobbies + checkBox1.Text + "; ";
            }
            if(checkBox2.Checked)
            {
                hobbies = hobbies + checkBox2.Text + "; ";
            }
            if(checkBox3.Checked)
            {
                hobbies = hobbies + checkBox3.Text + "; ";
            }
            if(checkBox4.Checked)
            {
                hobbies = hobbies + checkBox4.Text + "; ";
            }
            if(checkBox5.Checked)
            {
                hobbies = hobbies + checkBox5.Text + "; ";
            }
            if(textBox7.Text != "")
            {
                hobbies = hobbies + textBox7.Text;
            }

            return hobbies;
        }
            
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection con;
            connectionString = @"Data Source=BELVIS-DJ\SQLEXPRESS01;Initial Catalog=RegistrationFormDB;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT * FROM RegistrationFormTB ORDER BY ID ASC";

            command = new SqlCommand(sql, con);
            dataReader = command.ExecuteReader();
            
            //concat names and address
            
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " " + dataReader.GetValue(2) + " " + dataReader.GetValue(3)
                    + " - " + dataReader.GetValue(4) + " - " + dataReader.GetValue(5)
                    + " - " + dataReader.GetValue(6) + ", " + dataReader.GetValue(7) + ", " + dataReader.GetValue(8) 
                    + " - " + dataReader.GetValue(9) + "\n";
            }


            //separate names and address
            /*
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2)
                    + " - " + dataReader.GetValue(3) + " - " + dataReader.GetValue(4)
                    + " - " + dataReader.GetValue(5) + " - " + dataReader.GetValue(6) + " - " + dataReader.GetValue(7)
                    + " - " + dataReader.GetValue(8) + "\n";
            }
            */

            MessageBox.Show(Output);

            dataReader.Close();
            command.Dispose();
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection con;
            connectionString = @"Data Source=BELVIS-DJ\SQLEXPRESS01;Initial Catalog=RegistrationFormDB;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "INSERT INTO RegistrationFormTB values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "'" +
                ", '" + Gender() + "', '" + textBox4.Text + "', '" + textBox5.Text + "'" +
                ", '" + textBox6.Text + "', '" + listBox1.Text + "', '" + Hobbies() + "')";

            command = new SqlCommand(sql, con);
            adapter.InsertCommand = new SqlCommand(sql, con);
            adapter.InsertCommand.ExecuteNonQuery();

            MessageBox.Show("Data Saved Successfully!");

            command.Dispose();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton2.Checked = false;
            radioButton1.Checked = false;
            listBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            textBox7.Text = "";
            textBox8.Text = "";

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection con;
            connectionString = @"Data Source=BELVIS-DJ\SQLEXPRESS01;Initial Catalog=RegistrationFormDB;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            MessageBox.Show("Connection Successful!");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection con;
            connectionString = @"Data Source=BELVIS-DJ\SQLEXPRESS01;Initial Catalog=RegistrationFormDB;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "UPDATE RegistrationFormTB SET FirstName = '" + textBox1.Text + "', MiddleName = '" + textBox2.Text + "', LastName = '" + textBox3.Text + 
                "', Gender = '" + Gender() + "', Birthdate = '" + textBox4.Text + 
                "', Barangay = '" + textBox5.Text + "', Municipality = '" + textBox6.Text + "', Province = '" + listBox1.Text + 
                "', Hobbies = '" + Hobbies() + "' WHERE ID = " + Int32.Parse(textBox8.Text);

            command = new SqlCommand(sql, con);
            adapter.UpdateCommand = new SqlCommand(sql, con);
            adapter.UpdateCommand.ExecuteNonQuery();

            MessageBox.Show("Data Updated Successfully!");

            command.Dispose();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton2.Checked = false;
            radioButton1.Checked = false;
            listBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            textBox7.Text = "";
            textBox8.Text = "";

            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection con;
            connectionString = @"Data Source=BELVIS-DJ\SQLEXPRESS01;Initial Catalog=RegistrationFormDB;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "DELETE RegistrationFormTB WHERE ID = " + Int32.Parse(textBox8.Text);

            command = new SqlCommand(sql, con);
            adapter.UpdateCommand = new SqlCommand(sql, con);
            adapter.UpdateCommand.ExecuteNonQuery();

            MessageBox.Show("Data Deleted Successfully!");

            command.Dispose();
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
