using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH
{
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ThongKeHoaDOn form = new ThongKeHoaDOn();
            form.ShowDialog();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            ThongKeBan form = new ThongKeBan();
            form.ShowDialog();
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            ThongKeKhach form = new ThongKeKhach();
            form.ShowDialog();
        }
    }
}
