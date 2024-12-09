using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;

namespace QLNH
{
    public partial class FormMenu : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
        public FormMenu()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            cbbBan.DataSource = LoadDuLieuBan();
            cbbBan.DisplayMember = "DanhSachBan";
            cbbBan.ValueMember = "MA_BAN";
            dgvMenuMon.DataSource = LoadDuLieuMenuMon();
            dgvGioHang.Columns.Add("MA_MON", "Mã món");
            dgvGioHang.Columns.Add("TEN_MON", "Tên món");
            dgvGioHang.Columns.Add("GIA", "Giá");
            dgvGioHang.Columns.Add("SO_LUONG", "Số lượng");
            cbbBan.Text = null;
            lb4.Text = $"Tổng tiền: {0:C}";
            dgvGioHang.Columns["MA_MON"].Visible = false;
            dgvMenuMon.Columns["MA_MON"].Visible = false;
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
        public DataTable LoadDuLieuBan()
        {
            DataTable dt = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_LayDanhSachBan";
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
        private void dgvMenuMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool check = true;
            // Kiểm tra nếu người dùng nhấn vào cột "Thêm món"
            if (dgvMenuMon.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ hàng hiện tại
                string maMon = dgvMenuMon.Rows[e.RowIndex].Cells["MA_MON"].Value.ToString();
                string tenMon = dgvMenuMon.Rows[e.RowIndex].Cells["TEN_MON"].Value.ToString();
                string gia = dgvMenuMon.Rows[e.RowIndex].Cells["GIA"].Value.ToString();
                string trangThai = dgvMenuMon.Rows[e.RowIndex].Cells["TRANG_THAI"].Value.ToString();
                int test = 0;
                // Kiểm tra trạng thái món ăn
                if (trangThai == "Còn Món" || trangThai == "Còn món")
                {
                    // Kiểm tra có trùng món hay không
                    foreach (DataGridViewRow row in dgvGioHang.Rows)
                    {
                        // Trùng món thì +1 số lượng
                        if (row.Cells["TEN_MON"].Value.ToString() == tenMon)
                        {
                            int soLuong = Convert.ToInt32(row.Cells["SO_LUONG"].Value);
                            row.Cells["SO_LUONG"].Value = soLuong + 1;
                            TinhTongTien();
                            check = false;
                            break;
                        }
                    }
                    // Tránh chèn 1 món nhiều dòng
                    if (check)
                    {
                        int soLuong = 1;
                        dgvGioHang.Rows.Add(test, maMon, tenMon, gia, soLuong);
                        TinhTongTien();
                        check = false;
                    }
                }
                else
                {
                    MessageBox.Show($"Món '{tenMon}' đã hết, không thể thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                decimal gia = decimal.Parse(row.Cells["GIA"].Value.ToString());
                int soLuong = int.Parse(row.Cells["SO_LUONG"].Value.ToString());
                tongTien += gia * soLuong;
            }
            lbTongTien.Text = $"{tongTien:C}";
        }
        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào cột "Xóa món"
            if (dgvGioHang.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                dgvGioHang.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        private void txtTimKiemMonAn_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemMonAn.Text;
            dgvMenuMon.DataSource = TimKiemMonAn(keyword);
        }
        // Tìm kiếm món ăn từ cơ sở dữ liệu
        private DataTable TimKiemMonAn(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TimKiemMonAn", conn);
                cmd.CommandText = "sp_TimKiemMonAn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", keyword);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        private void LuuHoaDon(int maBan, string trangThai, DataGridView dgvGioHang)
        {
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                conn.Open();

                // Kiểm tra xem MA_BAN có tồn tại trong bảng BAN
                string checkQuery = "SELECT COUNT(*) FROM BAN WHERE MA_BAN = @MA_BAN";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MA_BAN", maBan);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Mã bàn không tồn tại trong bảng BAN.");
                        return; // Dừng quá trình nếu MA_BAN không hợp lệ
                    }
                }

                // Tạo JSON từ DataGridView (giỏ hàng)
                var chiTietList = new List<dynamic>();
                decimal tongTien = 0;  // Biến lưu tổng tiền

                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    // Kiểm tra nếu giá trị mã món và số lượng có hợp lệ
                    if (row.Cells["MA_MON"].Value != null && row.Cells["SO_LUONG"].Value != null && row.Cells["GIA"].Value != null)
                    {
                        int maMon = Convert.ToInt32(row.Cells["MA_MON"].Value); // Mã món ẩn
                        int soLuong = Convert.ToInt32(row.Cells["SO_LUONG"].Value);
                        decimal gia = Convert.ToDecimal(row.Cells["GIA"].Value);
                        decimal thanhTien = gia * soLuong;

                        // Thêm chi tiết vào danh sách chi tiết hóa đơn
                        chiTietList.Add(new
                        {
                            MA_MON = maMon,
                            SO_LUONG = soLuong,
                            THANH_TIEN = thanhTien
                        });

                        // Cộng dồn tổng tiền
                        tongTien += thanhTien;
                    }
                }

                // Chuyển đổi danh sách chi tiết thành chuỗi JSON
                string jsonChiTietHoaDon = JsonConvert.SerializeObject(chiTietList);

                // Gọi Stored Procedure để lưu hóa đơn
                using (SqlCommand cmd = new SqlCommand("sp_LuuHoaDon", conn))
                {
                    DateTime currentDate = DateTime.Now;
                    string ngayLapHD = currentDate.ToString("dd/MM/yyyy HH:mm:ss");

                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số cho stored procedure
                    cmd.Parameters.AddWithValue("@MA_BAN", maBan);
                    cmd.Parameters.AddWithValue("@NGAY_LAP", ngayLapHD);
                    cmd.Parameters.AddWithValue("@TONG_TIEN", tongTien);  // Sử dụng tổng tiền đã tính toán
                    cmd.Parameters.AddWithValue("@TRANG_THAI", trangThai);
                    cmd.Parameters.AddWithValue("@ChiTietHoaDon", jsonChiTietHoaDon);  // Chuỗi JSON chứa chi tiết hóa đơn

                    // Thực thi stored procedure
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Hóa đơn đã được lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDatDon_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count > 0)
            {
                if (cbbBan.SelectedItem != null)
                {

                    int maBan = Convert.ToInt32(cbbBan.SelectedValue);// Lấy mã bàn từ ComboBox
                    int soMon = dgvGioHang.Rows.Cast<DataGridViewRow>()
                                .Where(row => row.Cells["MA_MON"].Value != null)// Kiểm tra ô MA_MON có giá trị
                                .Count();
                    string tongTien = lbTongTien.Text;
                    // Gọi hàm kiểm tra trạng thái bàn từ Store
                    string trangThai = GetTrangThaiBan(maBan);
                    if (trangThai == "Đặt trước")
                    {
                        MessageBox.Show("Bàn đã được Đặt trước!");
                        return;
                    }
                    else if (trangThai == "Đang phục vụ")
                    {
                        MessageBox.Show("Bàn đang phục vụ!");
                        return;
                    }
                    else
                    {
                        DataGridView dgv = dgvGioHang;
                        FormXacThucDon formXacThuc = new FormXacThucDon(soMon , maBan, tongTien, dgv);
                        formXacThuc.ShowDialog();
                        //// Gọi hàm lưu hóa đơn
                        //LuuHoaDon(maBan, trangThai, dgvGioHang);

                        //// Làm mới giỏ hàng
                        //dgvGioHang.Rows.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Bàn trống! Vui lòng chọn bàn trước khi đặt đơn.");
                }
            }
            else
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng thêm món trước khi đặt đơn.");
            }
        }
        //////////// LẤY TRẠNG THÁI BÀN
        public string GetTrangThaiBan(int maBan)
        {
            string trangThaiBan = string.Empty;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KiemTraTrangThaiBan", conn);
                cmd.CommandType = CommandType.StoredProcedure; // Xác định đây là một Stored Procedure

                // Thêm tham số cho SP
                cmd.Parameters.AddWithValue("@maBan", maBan);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    trangThaiBan = result.ToString();  // Trạng thái bàn: 'Trống', 'Đã đặt', 'Đang phục vụ'
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

            return trangThaiBan;
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

        private void btnXoaTatCaMon_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tất cả các mục trong giỏ hàng không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            // Nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                dgvGioHang.Rows.Clear();
            }
        }
    }
}
