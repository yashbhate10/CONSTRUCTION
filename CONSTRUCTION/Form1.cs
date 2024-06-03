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

namespace CONSTRUCTION
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(200, Color.Aqua);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection = "Data Source=YASHLAPTOP\\SQLEXPRESS01;Initial Catalog=CONSTRUCTION;Integrated Security=True;Encrypt=False";

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();


            string name = Na.Text;
            string email = Email.Text;
            string phone = phno.Text;
            string bid = Bid.Text;
            string insert_query = "INSERT INTO clients (name, email, phone, bank_id) VALUES ('" + name + "', '" + email + "', '" + phone + "', '" + bid + "');";

            SqlCommand com = new SqlCommand(insert_query, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Inserted...");
           
            Na.Clear();
            Email.Clear();
            phno.Clear();
            Bid.Clear();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            client aa = new client();
            aa.Show();
            this.Close();
        }
    }
}

