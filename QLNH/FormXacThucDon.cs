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
    public partial class FormXacThucDon : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
        private int soMon, maBan;
        private string tongTien;
        private DataGridView dgvGioHang;
        public FormXacThucDon(int soMon, int maBan, string tongTien, DataGridView dgvGioHang)
        {
            InitializeComponent();
            this.soMon = soMon;
            this.maBan = maBan;
            this.tongTien = tongTien;
            this.dgvGioHang = dgvGioHang;
        }
        private void FormXacThucDon_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            string ngay = currentDate.ToString("dd/MM/yyyy");
            string thoigian = currentDate.ToString("HH:mm:ss");
            lbNgay.Text = ngay;
            lbThoiGian.Text = thoigian;
            txtSoBan.Text = GetSoBan(maBan).ToString();
            txtSoMon.Text = soMon.ToString();
            txtTongTien.Text = tongTien;
            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangThai.SelectedIndex = 0;
            // Khởi tạo Label
            lbNgayDat.Visible = false;// Ẩn
            lbTenKH.Visible = false;
            dateNgay.Visible = false;
            dateTime.Visible = false;
            txtTenKH.Visible = false;
        }

        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra giá trị được chọn trong ComboBox
            if (cbbTrangThai.SelectedItem != null && cbbTrangThai.SelectedItem.ToString() == "Đặt trước")
            {
                // Hiển thị các thành phần khi chọn "Đặt trước"
                lbTenKH.Visible = true;
                lbNgayDat.Visible = true;
                dateNgay.Visible = true;
                dateTime.Visible = true;
                txtTenKH.Visible = true;
            }
            else
            {
                // Ẩn các thành phần khi chọn giá trị khác
                lbNgayDat.Visible = false;
                lbTenKH.Visible = false;
                dateNgay.Visible = false;
                dateTime.Visible = false;
                txtTenKH.Visible = false;
            }
        }
        public string GetSoBan(int maBan)
        {
            string soBan = string.Empty;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LaySoBan", conn);
                cmd.CommandType = CommandType.StoredProcedure; // Xác định đây là một Store

                // Thêm tham số cho SP
                cmd.Parameters.AddWithValue("@maBan", maBan);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    soBan = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return soBan;
        }

        private void btnXacNhanDatDon_Click(object sender, EventArgs e)
        {
            // Nếu chọn đặt bàn trước
            if(cbbTrangThai.SelectedIndex == 1)
            {
                if(txtTenKH.Text.Length != 0)
                {
                    try
                    {
                        conn.Open();
                        DateTime currentDate = DateTime.Now;
                        string thoigian = dateNgay.Text + " " + dateTime.Text;
                        // Tạo SqlCommand để gọi Stored Procedure
                        SqlCommand cmd = new SqlCommand("sp_ThemDatBan", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TEN_KH", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@MA_BAN", maBan);
                        cmd.Parameters.AddWithValue("@NGAY_DAT", thoigian);
                        cmd.Parameters.AddWithValue("@TRANG_THAI", "Đã xác nhận");

                        MessageBox.Show($"Đặt bàn thành công!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { conn.Close(); }
                } else
                {
                    MessageBox.Show("Chưa nhập tên khách hàng ?", "Thông báo");
                }
            } else // Chọn phục vụ ngay
            {
                try
                {
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { conn.Close(); }
            }
        }
        public int ThemHoaDon(DateTime ngayLap, DateTime thoiGian, int soBan, decimal tongTien, string trangThai, string ghiChu)
        {
            int maHoaDon = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);
                cmd.Parameters.AddWithValue("@SoBan", soBan);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                SqlParameter outputIdParam = new SqlParameter("@MaHoaDon", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                maHoaDon = (int)outputIdParam.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
            return maHoaDon;
        }

    }
}
