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
    public partial class FormNhanVien : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-R1ZAX\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True");
        public FormNhanVien()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            cbbPhanQuyen.DataSource = LoadQuyen();
            cbbPhanQuyen.DisplayMember = "PHAN_QUYEN";
            dgvNhanVien.DataSource = LoadNhanVien();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public DataTable LoadQuyen()
        {
            DataTable dQT = null;
            try
            {
                conn.Open();
                SqlCommand cmdQ = new SqlCommand();
                cmdQ.CommandText = "sp_DSQuyen";
                cmdQ.CommandType = CommandType.StoredProcedure;
                cmdQ.Connection = conn;
                dQT = new DataTable();
                SqlDataAdapter daQ = new SqlDataAdapter(cmdQ);
                daQ.Fill(dQT);
                conn.Close();
                return dQT;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public DataTable LoadNhanVien()
        {
            DataTable dtNV = null;
            try
            {
                conn.Open();
                SqlCommand cmdNV = new SqlCommand();
                cmdNV.CommandText = "sp_DSNhanVien";
                cmdNV.CommandType = CommandType.StoredProcedure;
                cmdNV.Connection = conn;
                dtNV = new DataTable();
                SqlDataAdapter daNV = new SqlDataAdapter(cmdNV);
                daNV.Fill(dtNV);
                conn.Close();
                return dtNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            return null;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[dong].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[dong].Cells[1].Value.ToString();
            txtTaiKhoan.Text = dgvNhanVien.Rows[dong].Cells[2].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[dong].Cells[3].Value.ToString();
            cbbPhanQuyen.Text = dgvNhanVien.Rows[dong].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemNhanVien", conn);
                cmd.CommandText = "sp_ThemNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paTenNV = new SqlParameter("@tennv", txtTenNV.Text);
                cmd.Parameters.Add(paTenNV);
                SqlParameter paTaiKhoan = new SqlParameter("@taikhoan", txtTaiKhoan.Text);
                cmd.Parameters.Add(paTaiKhoan);
                SqlParameter paMatKhau = new SqlParameter("@matkhau", txtMatKhau.Text);
                cmd.Parameters.Add(paMatKhau);
                SqlParameter paPhanQuyen = new SqlParameter("@phanquyen", cbbPhanQuyen.Text);
                cmd.Parameters.Add(paPhanQuyen);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Thêm Nhân Viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Clear();
                    txtTenNV.Clear();
                    cbbPhanQuyen.SelectedIndex = 0;
                    txtMatKhau.Clear();
                    txtTaiKhoan.Clear();
                    txtTenNV.Focus();
                }
                else MessageBox.Show("Thêm Nhân Viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);
                cmd.CommandText = "sp_XoaNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaNV = new SqlParameter("@manhanvien", txtMaNV.Text);
                cmd.Parameters.Add(paMaNV);
                

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Xóa Nhân Viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Clear();
                    txtTenNV.Clear();
                    cbbPhanQuyen.SelectedIndex = 0;
                    txtMatKhau.Clear();
                    txtTaiKhoan.Clear();
                    txtTenNV.Focus();
                }
                else MessageBox.Show("Xóa Nhân Viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatNhanVien", conn);
                cmd.CommandText = "sp_CapNhatNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaNV = new SqlParameter("@manhanvien", txtMaNV.Text);
                cmd.Parameters.Add(paMaNV);
                SqlParameter paTenNV = new SqlParameter("@tennv", txtTenNV.Text);
                cmd.Parameters.Add(paTenNV);
                SqlParameter paTaiKhoan = new SqlParameter("@taikhoan", txtTaiKhoan.Text);
                cmd.Parameters.Add(paTaiKhoan);
                SqlParameter paMatKhau = new SqlParameter("@matkhau", txtMatKhau.Text);
                cmd.Parameters.Add(paMatKhau);
                SqlParameter paPhanQuyen = new SqlParameter("@phanquyen", cbbPhanQuyen.Text);
                cmd.Parameters.Add(paPhanQuyen);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Sửa Nhân Viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Clear();
                    txtTenNV.Clear();
                    cbbPhanQuyen.SelectedIndex = 0;
                    txtMatKhau.Clear();
                    txtTaiKhoan.Clear();
                    txtTenNV.Focus();
                }
                else MessageBox.Show("Sửa Nhân Viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = LoadNhanVien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TimNhanVien", conn);
                cmd.CommandText = "sp_TimNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaNV = new SqlParameter("@tennv", txtTimKiem.Text);                                                
                cmd.Parameters.Add(paMaNV);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;                                                 
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
