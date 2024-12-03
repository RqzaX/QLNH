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
    public partial class FormTrangChu : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-R1ZAX\\SQLEXPRESS; Initial Catalog = QuanLyNhaHang; Integrated Security = True; TrustServerCertificate=True");
        public FormTrangChu()
        {
            InitializeComponent();
        }
        private void LoadFormIntoPanel(Form form)
        {
            panelChinh.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelChinh.Controls.Add(form);
            form.Show();
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            // Hiển thị FormMenu trong panelContainer
            LoadFormIntoPanel(formMenu);
        }

        private void btnBep_Click(object sender, EventArgs e)
        {
            Bep formBep = new Bep();
            // Hiển thị FormMenu trong panelContainer
            LoadFormIntoPanel(formBep);
        }
    }
}
