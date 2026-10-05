namespace QuanLyLichKham
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTenBenhNhan;
        private Label lblSDT;
        private Label lblNgayKham;
        private Label lblGioKham;
        private Label lblBacSi;
        private Label lblTrangThai;

        private TextBox txtTenBenhNhan;
        private TextBox txtSDT;

        private DateTimePicker dtpNgayKham;
        private DateTimePicker dtpGioKham;

        private ComboBox cboBacSi;
        private ComboBox cboTrangThai;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnQuanLyBacSi;

        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblTimBacSi;

        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;

        private ComboBox cboTimBacSi;
        private Button btnTimKiem;

        private DataGridView dgvLichKham;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTenBenhNhan = new Label();
            lblSDT = new Label();
            lblNgayKham = new Label();
            lblGioKham = new Label();
            lblBacSi = new Label();
            lblTrangThai = new Label();

            txtTenBenhNhan = new TextBox();
            txtSDT = new TextBox();

            dtpNgayKham = new DateTimePicker();
            dtpGioKham = new DateTimePicker();

            cboBacSi = new ComboBox();
            cboTrangThai = new ComboBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnQuanLyBacSi = new Button();

            lblTuNgay = new Label();
            lblDenNgay = new Label();
            lblTimBacSi = new Label();

            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();

            cboTimBacSi = new ComboBox();
            btnTimKiem = new Button();

            dgvLichKham = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();

            // lblTenBenhNhan
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Location = new Point(20, 25);
            lblTenBenhNhan.Text = "Tên bệnh nhân";

            // txtTenBenhNhan
            txtTenBenhNhan.Location = new Point(140, 20);
            txtTenBenhNhan.Size = new Size(230, 27);

            // lblSDT
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(20, 65);
            lblSDT.Text = "Số điện thoại";

            // txtSDT
            txtSDT.Location = new Point(140, 60);
            txtSDT.Size = new Size(230, 27);

            // lblNgayKham
            lblNgayKham.AutoSize = true;
            lblNgayKham.Location = new Point(20, 105);
            lblNgayKham.Text = "Ngày khám";

            // dtpNgayKham
            dtpNgayKham.Location = new Point(140, 100);
            dtpNgayKham.Size = new Size(180, 27);
            dtpNgayKham.Format = DateTimePickerFormat.Short;

            // lblGioKham
            lblGioKham.AutoSize = true;
            lblGioKham.Location = new Point(20, 145);
            lblGioKham.Text = "Giờ khám";

            // dtpGioKham
            dtpGioKham.Location = new Point(140, 140);
            dtpGioKham.Size = new Size(180, 27);
            dtpGioKham.Format = DateTimePickerFormat.Time;
            dtpGioKham.ShowUpDown = true;

            // lblBacSi
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new Point(400, 25);
            lblBacSi.Text = "Bác sĩ";

            // cboBacSi
            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBacSi.Location = new Point(470, 20);
            cboBacSi.Size = new Size(280, 28);

            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(400, 65);
            lblTrangThai.Text = "Trạng thái";

            // cboTrangThai
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(470, 60);
            cboTrangThai.Size = new Size(180, 28);

            // btnThem
            btnThem.Location = new Point(800, 20);
            btnThem.Size = new Size(90, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Location = new Point(900, 20);
            btnSua.Size = new Size(90, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(800, 65);
            btnXoa.Size = new Size(90, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Location = new Point(900, 65);
            btnLamMoi.Size = new Size(90, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            // btnQuanLyBacSi
            btnQuanLyBacSi.Location = new Point(800, 110);
            btnQuanLyBacSi.Size = new Size(190, 35);
            btnQuanLyBacSi.Text = "Quản lý bác sĩ";
            btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;

            // lblTuNgay
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(20, 200);
            lblTuNgay.Text = "Từ ngày";

            // dtpTuNgay
            dtpTuNgay.Location = new Point(80, 195);
            dtpTuNgay.Size = new Size(150, 27);
            dtpTuNgay.Format = DateTimePickerFormat.Short;

            // lblDenNgay
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(250, 200);
            lblDenNgay.Text = "Đến ngày";

            // dtpDenNgay
            dtpDenNgay.Location = new Point(320, 195);
            dtpDenNgay.Size = new Size(150, 27);
            dtpDenNgay.Format = DateTimePickerFormat.Short;

            // lblTimBacSi
            lblTimBacSi.AutoSize = true;
            lblTimBacSi.Location = new Point(490, 200);
            lblTimBacSi.Text = "Bác sĩ";

            // cboTimBacSi
            cboTimBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimBacSi.Location = new Point(540, 195);
            cboTimBacSi.Size = new Size(250, 28);

            // btnTimKiem
            btnTimKiem.Location = new Point(810, 190);
            btnTimKiem.Size = new Size(100, 35);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += btnTimKiem_Click;

            // dgvLichKham
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvLichKham.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLichKham.MultiSelect = false;

            dgvLichKham.Location = new Point(20, 245);
            dgvLichKham.Size = new Size(970, 300);

            dgvLichKham.Columns.Add(
                "MaLich",
                "Mã lịch");

            dgvLichKham.Columns.Add(
                "TenBenhNhan",
                "Tên bệnh nhân");

            dgvLichKham.Columns.Add(
                "SDT",
                "SDT");

            dgvLichKham.Columns.Add(
                "NgayKham",
                "Ngày khám");

            dgvLichKham.Columns.Add(
                "GioKham",
                "Giờ khám");

            dgvLichKham.Columns.Add(
                "BacSi",
                "Bác sĩ");

            dgvLichKham.Columns.Add(
                "ChuyenKhoa",
                "Chuyên khoa");

            dgvLichKham.Columns.Add(
                "TrangThai",
                "Trạng thái");

            dgvLichKham.SelectionChanged +=
                dgvLichKham_SelectionChanged;

            // Form
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(1020, 580);

            Controls.Add(lblTenBenhNhan);
            Controls.Add(txtTenBenhNhan);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(lblNgayKham);
            Controls.Add(dtpNgayKham);

            Controls.Add(lblGioKham);
            Controls.Add(dtpGioKham);

            Controls.Add(lblBacSi);
            Controls.Add(cboBacSi);

            Controls.Add(lblTrangThai);
            Controls.Add(cboTrangThai);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnQuanLyBacSi);

            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);

            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);

            Controls.Add(lblTimBacSi);
            Controls.Add(cboTimBacSi);
            Controls.Add(btnTimKiem);

            Controls.Add(dgvLichKham);

            Name = "Form1";
            Text = "Quản lý Lịch khám - An Khang Clinic";
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}