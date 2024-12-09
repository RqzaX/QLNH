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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNH
{
    public partial class FormDSBan : Form
    {
        public FormDSBan()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            txtSoBan.Validating += new CancelEventHandler(check_number);
            dgvBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-R1ZAX\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True");

        public DataTable LoadBanAll()
        {
            DataTable dtB = null;
            try
            {
                conn.Open();
                SqlCommand cmdB = new SqlCommand();
                cmdB.CommandText = "sp_DanhSachBan";
                cmdB.CommandType = CommandType.StoredProcedure;
                cmdB.Connection = conn;
                dtB = new DataTable();
                SqlDataAdapter daB = new SqlDataAdapter(cmdB);
                daB.Fill(dtB);
                conn.Close();
                return dtB;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public DataTable LoadBan()
        {
            DataTable dtTT = null;
            try
            {
                conn.Open();
                SqlCommand cmdTT = new SqlCommand();
                cmdTT.CommandText = "sp_DSTrangThai";
                cmdTT.CommandType = CommandType.StoredProcedure;
                cmdTT.Connection = conn;
                dtTT = new DataTable();
                SqlDataAdapter daTT = new SqlDataAdapter(cmdTT);
                daTT.Fill(dtTT);
                conn.Close();
                return dtTT;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void FormDSBan_Load(object sender, EventArgs e)
        {
            cbbTrangThai.DataSource = LoadBan();
            cbbTrangThai.DisplayMember = "TRANG_THAI";
            dgvBan.DataSource = LoadBanAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemBan", conn);
                cmd.CommandText = "sp_ThemBan";
                cmd.CommandType = CommandType.StoredProcedure;                
                SqlParameter paSoBan = new SqlParameter("@soban", txtSoBan.Text);
                cmd.Parameters.Add(paSoBan);
                SqlParameter paTrangThai = new SqlParameter("@trangthai", cbbTrangThai.Text);
                cmd.Parameters.Add(paTrangThai);                

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Thêm Bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaBan.Clear();
                    txtSoBan.Clear();
                    cbbTrangThai.SelectedIndex = 0;
                    txtSoBan.Focus();
                    
                }
                else MessageBox.Show("Thêm Bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvBan.DataSource = LoadBanAll();
        }

        private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMaBan.Text = dgvBan.Rows[dong].Cells[0].Value.ToString();
            txtSoBan.Text = dgvBan.Rows[dong].Cells[1].Value.ToString();            
            cbbTrangThai.Text = dgvBan.Rows[dong].Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaBan", conn);
                cmd.CommandText = "sp_XoaBan";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaB = new SqlParameter("@maban", txtMaBan.Text);
                cmd.Parameters.Add(paMaB);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Xóa Bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaBan.Clear();
                    txtSoBan.Clear();
                    cbbTrangThai.SelectedIndex = 0;
                    txtSoBan.Focus();
                }
                else MessageBox.Show("Xóa Bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvBan.DataSource = LoadBanAll();
        }        
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SuaBan", conn);
                cmd.CommandText = "sp_SuaBan";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaB = new SqlParameter("@maban", txtMaBan.Text);
                cmd.Parameters.Add(paMaB);
                SqlParameter paTenB = new SqlParameter("@soban", txtSoBan.Text);
                cmd.Parameters.Add(paTenB);                
                SqlParameter paTT = new SqlParameter("@trangthai", cbbTrangThai.Text);
                cmd.Parameters.Add(paTT);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Sửa Bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaBan.Clear();
                    txtSoBan.Clear();
                    cbbTrangThai.SelectedIndex = 0;
                    txtSoBan.Focus();
                }
                else MessageBox.Show("Sửa Bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvBan.DataSource = LoadBanAll();
        }
        
        private void check_number(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtSoBan.Text, out _) && txtSoBan.Text != "") 
            {
                e.Cancel = true; 
                errorProvider1.SetError(txtSoBan, "Chỉ được nhập số!");
            }
            else
            {
                errorProvider1.SetError(txtSoBan, ""); 
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem.Text != "")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_TimBan", conn);
                    cmd.CommandText = "sp_TimBan";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paMaB = new SqlParameter("@tk", txtTimKiem.Text);
                    cmd.Parameters.Add(paMaB);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBan.DataSource = dt;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dgvBan.DataSource = LoadBanAll();
            }            
        }
    }

}
