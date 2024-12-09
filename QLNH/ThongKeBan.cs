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
    public partial class ThongKeBan : Form
    {
        SqlConnection conn = new SqlConnection("Data Source =LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
            
        public ThongKeBan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ThongKeMonAN_Load(object sender, EventArgs e)
        {

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string trangthai=cbbDanhMuc.SelectedItem.ToString();
            try
            {
                conn.Open();
                SqlCommand cmdban = new SqlCommand("sp_laytrangthai", conn);
                cmdban.CommandType = CommandType.StoredProcedure;
                cmdban.Parameters.AddWithValue("@trangthai", (object)trangthai??DBNull.Value);

                SqlDataAdapter data= new SqlDataAdapter(cmdban);
                 DataTable dt = new DataTable();
                data.Fill(dt);
                 dgvHienThi.DataSource = dt;
                conn.Close();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show("loi" + ex);
            }
        }
      
        

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHienThi_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
