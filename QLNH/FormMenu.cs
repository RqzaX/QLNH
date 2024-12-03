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
            dgvMenuMon.DataSource = LoadDuLieuMenuMon();
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
    }
}
