using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CONSTRUCTION
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=YASHLAPTOP\\SQLEXPRESS01;Initial Catalog=CONSTRUCTION;Integrated Security=True;Encrypt=False";

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            string bid = ID.Text;
            string name = NAV.Text;
            string email = EMAIL.Text;
            
            
            string insert_query = "INSERT INTO banks (bank_id,name,email) VALUES ( '" + bid + "','" + name + "', '" + email + "');";

            SqlCommand com = new SqlCommand(insert_query, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Inserted...");

            ID.Clear();
            NAV.Clear();
            EMAIL.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu aa = new menu();
            aa.Show();
            this.Close();
        }
    }
}
