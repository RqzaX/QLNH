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
    public partial class FormLogin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
        
        public FormLogin()
        {
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMatKhau.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                conn.Open();
                string query = "SELECT PHAN_QUYEN FROM NHAN_VIEN WHERE TAI_KHOAN = @username AND MAT_KHAU = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                // Câu lệnh SQL kiểm tra tài khoản
                object result = cmd.ExecuteScalar();
                if(result != null)
                {
                    string role = result.ToString();
                    MessageBox.Show($"Đăng nhập thành công! Vai trò: {role}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormTrangChu mainform = new FormTrangChu();
                    mainform.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
