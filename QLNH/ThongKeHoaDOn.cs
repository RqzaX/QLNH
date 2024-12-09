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
    public partial class ThongKeHoaDOn : Form
    {
        SqlConnection conn = new SqlConnection("Data Source =LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
        public ThongKeHoaDOn()
        {
            InitializeComponent();
            cbbDanhmuc.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string trangthai= cbbDanhmuc.SelectedItem?.ToString()??"Tất cả";
            DateTime tungay = dtTuNgay.Value;
            DateTime denngay=dtDenNgay.Value;
            dgvHoadon.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            
            try
            {
                conn.Open();

                SqlCommand cmdhd = new SqlCommand("sp_hoadon",conn);
                cmdhd.CommandType = CommandType.StoredProcedure;

                cmdhd.Parameters.AddWithValue("@trangthaiHD",trangthai);
                cmdhd.Parameters.AddWithValue("@tungay", tungay);
                cmdhd.Parameters.AddWithValue("@denngay", denngay);

                SqlDataAdapter data = new SqlDataAdapter(cmdhd);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dgvHoadon.DataSource = dt;
                
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Loi" + ex);
            }
        }

        private void dgvHoadon_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
