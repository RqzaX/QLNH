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
    public partial class Bep : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
        public Bep()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        public DataTable LoadDuLieuMenuMon()
        {
            DataTable dtMenu = null;
            try
            {
                conn.Open();
                SqlCommand cmdMon = new SqlCommand();
                cmdMon.CommandText = "sp_LayDSMon";
                cmdMon.CommandType = CommandType.StoredProcedure;
                cmdMon.Connection = conn;
                dtMenu = new DataTable();
                SqlDataAdapter daMenu = new SqlDataAdapter(cmdMon);
                daMenu.Fill(dtMenu);
                conn.Close();
                return dtMenu;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public DataTable LoadDuTenDanhMuc()
        {
            DataTable dt = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_LayDanhMuc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void Bep_Load(object sender, EventArgs e)
        {
            cbbDanhMuc.DataSource = LoadDuTenDanhMuc();
            cbbDanhMuc.DisplayMember = "TENDANHMUC";
            dgvDanhSachMon.DataSource = LoadDuLieuMenuMon();
        }

        private void dgvDanhSachMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMaMon.Text = dgvDanhSachMon.Rows[dong].Cells[0].Value.ToString();
            txtTenMon.Text = dgvDanhSachMon.Rows[dong].Cells[1].Value.ToString();
            cbbDanhMuc.Text = dgvDanhSachMon.Rows[dong].Cells[2].Value.ToString();
            txtGia.Text = dgvDanhSachMon.Rows[dong].Cells[3].Value.ToString();
            cbbTrangThai.Text = dgvDanhSachMon.Rows[dong].Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaMonAn", conn);
                cmd.CommandText = "sp_XoaMonAn";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter dataAdapter = new SqlParameter("@maMon", txtMaMon.Text);
                cmd.Parameters.Add(dataAdapter);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Xóa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDanhSachMon.Refresh();
                    txtMaMon.Clear();
                    txtTenMon.Clear();
                    cbbDanhMuc.SelectedIndex = 0;
                    txtGia.Clear();
                    cbbTrangThai.SelectedIndex = 0;
                    txtTenMon.Focus();
                }
                else MessageBox.Show("Xóa món không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvDanhSachMon.DataSource = LoadDuLieuMenuMon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemMon", conn);
                cmd.CommandText = "sp_ThemMon";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paTenmon = new SqlParameter("@tenmon", txtTenMon.Text);
                cmd.Parameters.Add(paTenmon);
                SqlParameter paDanhmuc = new SqlParameter("@danhmuc", cbbDanhMuc.Text);
                cmd.Parameters.Add(paDanhmuc);
                SqlParameter paGia = new SqlParameter("@gia", Convert.ToDecimal(txtGia.Text));
                cmd.Parameters.Add(paGia);
                SqlParameter paTrangThai = new SqlParameter("@trangthai", cbbTrangThai.Text);
                cmd.Parameters.Add(paTrangThai);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Thêm món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDanhSachMon.Refresh();
                    txtMaMon.Clear();
                    txtTenMon.Clear();
                    cbbDanhMuc.SelectedIndex = 0;
                    txtGia.Clear();
                    cbbTrangThai.SelectedIndex = 0;
                    txtTenMon.Focus();
                }
                else MessageBox.Show("Thêm món không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvDanhSachMon.DataSource = LoadDuLieuMenuMon();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SuaMon", conn);
                cmd.CommandText = "sp_SuaMon";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMamon = new SqlParameter("@mamon", txtMaMon.Text);
                cmd.Parameters.Add(paMamon);
                SqlParameter paTenmon = new SqlParameter("@tenmon", txtTenMon.Text);
                cmd.Parameters.Add(paTenmon);
                SqlParameter paDanhmuc = new SqlParameter("@danhmuc", cbbDanhMuc.Text);
                cmd.Parameters.Add(paDanhmuc);
                SqlParameter paGia = new SqlParameter("@gia", Convert.ToDecimal(txtGia.Text));
                cmd.Parameters.Add(paGia);
                if(cbbTrangThai.SelectedIndex == 1)
                {
                    string query = "UPDATE MON_AN SET TRANG_THAI = N'Đã hết' WHERE MA_MON = @mamon;";
                    SqlCommand cmd1 = new SqlCommand(query, conn);
                    cmd1.Parameters.AddWithValue("@mamon", txtMaMon.Text);
                    cmd1.ExecuteNonQuery();
                } else
                {
                    string query = "UPDATE MON_AN SET TRANG_THAI = N'Còn món' WHERE MA_MON = @mamon;";
                    SqlCommand cmd1 = new SqlCommand(query, conn);
                    cmd1.Parameters.AddWithValue("@mamon", txtMaMon.Text);
                    cmd1.ExecuteNonQuery();
                }

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Sửa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Sửa món không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                conn.Close();
            }
            dgvDanhSachMon.DataSource = LoadDuLieuMenuMon();
        }
    }
}
