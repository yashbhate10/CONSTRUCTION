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
using System.Windows.Forms.VisualStyles;

namespace CONSTRUCTION
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
            data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void data()
        {
            string connection = "Data Source=YASHLAPTOP\\SQLEXPRESS01;Initial Catalog=CONSTRUCTION;Integrated Security=True;Encrypt=False";

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CLIENTS", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgrid.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu form = new menu();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchClients();
        }

        private void SearchClients()
        {
            string connection = "Data Source=YASHLAPTOP\\SQLEXPRESS01;Initial Catalog=CONSTRUCTION;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string match = textBox1.Text.Trim();
                int id;
                bool isNumeric = int.TryParse(match, out id);

                string query = "SELECT * FROM clients WHERE client_id LIKE @id OR name LIKE @match OR email LIKE @match OR phone LIKE @id OR bank_id LIKE @match";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", isNumeric ? "%" + id + "%" : "%%");
                    cmd.Parameters.AddWithValue("@match", "%" + match + "%");

                    

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dgrid.DataSource = dt;
                }
            }
            }
    }
}
