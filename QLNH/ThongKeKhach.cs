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

namespace QLNH
{
    public partial class ThongKeKhach : Form
    {
        SqlConnection conn = new SqlConnection("Data Source =LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
        public ThongKeKhach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ghichu= cbbGhichu.SelectedItem.ToString();

            try
            {
                conn.Open();
                SqlCommand cmdghichu= new SqlCommand("sp_laykhachhang",conn);
                cmdghichu.CommandType = CommandType.StoredProcedure;
                cmdghichu.Parameters.AddWithValue("@ghichukhach", (object)ghichu ?? DBNull.Value);

                SqlDataAdapter data = new SqlDataAdapter(cmdghichu);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dgvKhach.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("loi" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
