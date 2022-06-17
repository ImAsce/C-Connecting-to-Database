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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            /*if (textBox8.Text == "Male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if (textBox8.Text == "Female")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }*/
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'registrationFormDBDataSet1.RegistrationFormTB' table. You can move, or remove it, as needed.
            this.registrationFormTBTableAdapter1.Fill(this.registrationFormDBDataSet1.RegistrationFormTB);
            // TODO: This line of code loads data into the 'registrationFormDBDataSet.RegistrationFormTB' table. You can move, or remove it, as needed.
            this.registrationFormTBTableAdapter.Fill(this.registrationFormDBDataSet.RegistrationFormTB);

           

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.registrationFormTBTableAdapter1.FillBy(this.registrationFormDBDataSet1.RegistrationFormTB);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.registrationFormTBTableAdapter1.FillBy1(this.registrationFormDBDataSet1.RegistrationFormTB);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.registrationFormTBTableAdapter1.FillBy2(this.registrationFormDBDataSet1.RegistrationFormTB);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
