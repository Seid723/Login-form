using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InventoryMgmt
{
    public partial class inventorypage : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=ytvideo;Uid=Seko;Pwd=YkS9!827xQ#");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        void ogrenciler()
        {
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM ogrenciler", con);
            dataGridView1.DataSource = dt;
            adapter.Fill(dt);
            con.Close();
        }
        public inventorypage()
        {
            InitializeComponent();
        }

        private void inventorypage_Load(object sender, EventArgs e)
        {
            ogrenciler();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                richTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                richTextBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                richTextBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                richTextBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
                throw;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = "INSERT INTO ogrenciler(Fullname , Pass ,Phone ,Country  ) " + "VALUES(@Fullname , @Pass , @Phone , @Country) ";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Fullname", richTextBox1.Text); // string
            cmd.Parameters.AddWithValue("@Pass", Convert.ToInt64(richTextBox4.Text)); // BIGINT
            cmd.Parameters.AddWithValue("@Phone", Convert.ToInt32(richTextBox3.Text)); // INT
            cmd.Parameters.AddWithValue("@Country", richTextBox2.Text); // string
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ogrenciler();
            MessageBox.Show("Added Successfully!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = ("DELETE FROM ogrenciler WHERE Fullname=@Fullname");
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Fullname", richTextBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ogrenciler();
            MessageBox.Show("Deleted Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = ("UPDATE ogrenciler SET Fullname=@Fullname , Pass=@Pass , Phone=@Phone , Country=@Country" + "WHERE Fullname=@Fullname ");
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Fullname", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@Pass", Convert.ToInt64(richTextBox4.Text));
            cmd.Parameters.AddWithValue("@Phone", Convert.ToInt32(richTextBox3.Text));
            cmd.Parameters.AddWithValue("@Country", richTextBox2.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ogrenciler();
            MessageBox.Show("Edited Successfully!", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
