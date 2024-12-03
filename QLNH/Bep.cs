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

        private void Bep_Load(object sender, EventArgs e)
        {
            cbbDanhMuc.DataSource = LoadDuLieuMenuMon();
            cbbDanhMuc.DisplayMember = "DANH_MUC";
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
                SqlParameter paGia = new SqlParameter("@gia", txtGia.Text);
                cmd.Parameters.Add(paGia);
                SqlParameter paTrangThai = new SqlParameter("@trangthai", cbbTrangThai.Text);
                cmd.Parameters.Add(paTrangThai);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Thêm món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvDanhSachMon.DataSource = LoadDuLieuMenuMon();
        }
    }
}
