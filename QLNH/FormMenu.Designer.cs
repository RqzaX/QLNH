namespace QLNH
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbNameUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lb4 = new System.Windows.Forms.Label();
            this.txtTimKiemMonAn = new System.Windows.Forms.TextBox();
            this.btnDatDon = new System.Windows.Forms.Button();
            this.lbTrangThai = new System.Windows.Forms.Label();
            this.cbbBan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.btnXoaMon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvMenuMon = new System.Windows.Forms.DataGridView();
            this.btnThemMon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.btnXoaTatCaMon = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuMon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbNameUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 69);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QLNH.Properties.Resources.profile;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = global::QLNH.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(740, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tbNameUser
            // 
            this.tbNameUser.AutoSize = true;
            this.tbNameUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNameUser.Location = new System.Drawing.Point(807, 23);
            this.tbNameUser.Name = "tbNameUser";
            this.tbNameUser.Size = new System.Drawing.Size(78, 29);
            this.tbNameUser.TabIndex = 1;
            this.tbNameUser.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnXoaTatCaMon);
            this.panel2.Controls.Add(this.lbTongTien);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lb4);
            this.panel2.Controls.Add(this.txtTimKiemMonAn);
            this.panel2.Controls.Add(this.btnDatDon);
            this.panel2.Controls.Add(this.lbTrangThai);
            this.panel2.Controls.Add(this.cbbBan);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgvGioHang);
            this.panel2.Controls.Add(this.dgvMenuMon);
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1054, 668);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tìm món";
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb4.Location = new System.Drawing.Point(658, 551);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(121, 29);
            this.lb4.TabIndex = 10;
            this.lb4.Text = "Tổng tiền:";
            // 
            // txtTimKiemMonAn
            // 
            this.txtTimKiemMonAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemMonAn.Location = new System.Drawing.Point(151, 18);
            this.txtTimKiemMonAn.Name = "txtTimKiemMonAn";
            this.txtTimKiemMonAn.Size = new System.Drawing.Size(479, 34);
            this.txtTimKiemMonAn.TabIndex = 8;
            this.txtTimKiemMonAn.TextChanged += new System.EventHandler(this.txtTimKiemMonAn_TextChanged);
            // 
            // btnDatDon
            // 
            this.btnDatDon.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnDatDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatDon.ForeColor = System.Drawing.Color.White;
            this.btnDatDon.Location = new System.Drawing.Point(803, 591);
            this.btnDatDon.Name = "btnDatDon";
            this.btnDatDon.Size = new System.Drawing.Size(227, 56);
            this.btnDatDon.TabIndex = 7;
            this.btnDatDon.Text = "Đặt Đơn";
            this.btnDatDon.UseVisualStyleBackColor = false;
            this.btnDatDon.Click += new System.EventHandler(this.btnDatDon_Click);
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.AutoSize = true;
            this.lbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangThai.Location = new System.Drawing.Point(851, 83);
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(0, 25);
            this.lbTrangThai.TabIndex = 6;
            // 
            // cbbBan
            // 
            this.cbbBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbBan.FormattingEnabled = true;
            this.cbbBan.Location = new System.Drawing.Point(740, 77);
            this.cbbBan.Name = "cbbBan";
            this.cbbBan.Size = new System.Drawing.Size(290, 37);
            this.cbbBan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(640, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bàn số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(777, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Giỏ hàng";
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnXoaMon});
            this.dgvGioHang.Location = new System.Drawing.Point(636, 132);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.RowTemplate.Height = 24;
            this.dgvGioHang.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvGioHang.Size = new System.Drawing.Size(403, 416);
            this.dgvGioHang.TabIndex = 2;
            this.dgvGioHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellContentClick);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.HeaderText = "";
            this.btnXoaMon.MinimumWidth = 6;
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.ReadOnly = true;
            this.btnXoaMon.Text = "Xóa";
            this.btnXoaMon.UseColumnTextForButtonValue = true;
            // 
            // dgvMenuMon
            // 
            this.dgvMenuMon.AllowUserToAddRows = false;
            this.dgvMenuMon.AllowUserToDeleteRows = false;
            this.dgvMenuMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenuMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnThemMon});
            this.dgvMenuMon.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvMenuMon.GridColor = System.Drawing.Color.Black;
            this.dgvMenuMon.Location = new System.Drawing.Point(3, 61);
            this.dgvMenuMon.MultiSelect = false;
            this.dgvMenuMon.Name = "dgvMenuMon";
            this.dgvMenuMon.ReadOnly = true;
            this.dgvMenuMon.RowHeadersVisible = false;
            this.dgvMenuMon.RowHeadersWidth = 51;
            this.dgvMenuMon.RowTemplate.Height = 24;
            this.dgvMenuMon.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvMenuMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuMon.Size = new System.Drawing.Size(627, 600);
            this.dgvMenuMon.TabIndex = 0;
            this.dgvMenuMon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuMon_CellContentClick);
            // 
            // btnThemMon
            // 
            this.btnThemMon.HeaderText = "Thao tác";
            this.btnThemMon.MinimumWidth = 6;
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.ReadOnly = true;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseColumnTextForButtonValue = true;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(785, 551);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(0, 29);
            this.lbTongTien.TabIndex = 12;
            // 
            // btnXoaTatCaMon
            // 
            this.btnXoaTatCaMon.BackColor = System.Drawing.Color.Crimson;
            this.btnXoaTatCaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTatCaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaTatCaMon.Location = new System.Drawing.Point(645, 591);
            this.btnXoaTatCaMon.Name = "btnXoaTatCaMon";
            this.btnXoaTatCaMon.Size = new System.Drawing.Size(118, 56);
            this.btnXoaTatCaMon.TabIndex = 13;
            this.btnXoaTatCaMon.Text = "Xóa tất cả món";
            this.btnXoaTatCaMon.UseVisualStyleBackColor = false;
            this.btnXoaTatCaMon.Click += new System.EventHandler(this.btnXoaTatCaMon_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 760);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuMon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tbNameUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvMenuMon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.ComboBox cbbBan;
        private System.Windows.Forms.Label lbTrangThai;
        private System.Windows.Forms.Button btnDatDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimKiemMonAn;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.DataGridViewButtonColumn btnThemMon;
        private System.Windows.Forms.DataGridViewButtonColumn btnXoaMon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Button btnXoaTatCaMon;
    }
}