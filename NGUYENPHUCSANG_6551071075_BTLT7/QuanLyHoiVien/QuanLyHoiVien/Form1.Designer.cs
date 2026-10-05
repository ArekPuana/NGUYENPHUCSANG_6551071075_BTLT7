namespace QuanLyHoiVien;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label lblHoTen;
    private Label lblSDT;
    private Label lblEmail;
    private Label lblNgaySinh;
    private Label lblHangThanhVien;
    private Label lblTimHang;

    private TextBox txtHoTen;
    private TextBox txtSDT;
    private TextBox txtEmail;
    private TextBox txtTimHoTen;

    private GroupBox grpGioiTinh;
    private RadioButton rdoNam;
    private RadioButton rdoNu;

    private DateTimePicker dtpNgaySinh;

    private ComboBox cboHangThanhVien;
    private ComboBox cboTimHang;

    private CheckBox chkTrangThai;

    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private Button btnTimKiem;

    private DataGridView dgvHoiVien;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        lblHoTen = new Label();
        lblSDT = new Label();
        lblEmail = new Label();
        lblNgaySinh = new Label();
        lblHangThanhVien = new Label();
        lblTimHang = new Label();

        txtHoTen = new TextBox();
        txtSDT = new TextBox();
        txtEmail = new TextBox();
        txtTimHoTen = new TextBox();

        grpGioiTinh = new GroupBox();
        rdoNam = new RadioButton();
        rdoNu = new RadioButton();

        dtpNgaySinh = new DateTimePicker();

        cboHangThanhVien = new ComboBox();
        cboTimHang = new ComboBox();

        chkTrangThai = new CheckBox();

        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        btnTimKiem = new Button();

        dgvHoiVien = new DataGridView();

        grpGioiTinh.SuspendLayout();

        ((System.ComponentModel.ISupportInitialize)dgvHoiVien)
            .BeginInit();

        SuspendLayout();

        // =====================================================
        // FORM
        // =====================================================

        AutoScaleDimensions =
            new SizeF(7F, 15F);

        AutoScaleMode =
            AutoScaleMode.Font;

        ClientSize =
            new Size(1050, 650);

        StartPosition =
            FormStartPosition.CenterScreen;

        Text =
            "Quản Lý Hội Viên Phòng Gym FitZone";

        // =====================================================
        // LABEL HỌ TÊN
        // =====================================================

        lblHoTen.AutoSize = true;

        lblHoTen.Location =
            new Point(35, 35);

        lblHoTen.Size =
            new Size(55, 15);

        lblHoTen.Text =
            "Họ tên";

        // =====================================================
        // TEXTBOX HỌ TÊN
        // =====================================================

        txtHoTen.Location =
            new Point(160, 32);

        txtHoTen.Size =
            new Size(220, 23);

        // =====================================================
        // GROUP GIỚI TÍNH
        // =====================================================

        grpGioiTinh.Location =
            new Point(410, 20);

        grpGioiTinh.Size =
            new Size(220, 60);

        grpGioiTinh.Text =
            "Giới tính";

        // =====================================================
        // RADIO NAM
        // =====================================================

        rdoNam.AutoSize = true;

        rdoNam.Location =
            new Point(25, 25);

        rdoNam.Size =
            new Size(48, 19);

        rdoNam.Text =
            "Nam";

        rdoNam.Checked = true;

        // =====================================================
        // RADIO NỮ
        // =====================================================

        rdoNu.AutoSize = true;

        rdoNu.Location =
            new Point(110, 25);

        rdoNu.Size =
            new Size(41, 19);

        rdoNu.Text =
            "Nữ";

        grpGioiTinh.Controls.Add(rdoNam);
        grpGioiTinh.Controls.Add(rdoNu);

        // =====================================================
        // LABEL SĐT
        // =====================================================

        lblSDT.AutoSize = true;

        lblSDT.Location =
            new Point(35, 70);

        lblSDT.Size =
            new Size(77, 15);

        lblSDT.Text =
            "Số điện thoại";

        // =====================================================
        // TEXTBOX SĐT
        // =====================================================

        txtSDT.Location =
            new Point(160, 67);

        txtSDT.Size =
            new Size(220, 23);

        // =====================================================
        // LABEL EMAIL
        // =====================================================

        lblEmail.AutoSize = true;

        lblEmail.Location =
            new Point(35, 105);

        lblEmail.Size =
            new Size(36, 15);

        lblEmail.Text =
            "Email";

        // =====================================================
        // TEXTBOX EMAIL
        // =====================================================

        txtEmail.Location =
            new Point(160, 102);

        txtEmail.Size =
            new Size(220, 23);

        // =====================================================
        // LABEL NGÀY SINH
        // =====================================================

        lblNgaySinh.AutoSize = true;

        lblNgaySinh.Location =
            new Point(35, 140);

        lblNgaySinh.Size =
            new Size(58, 15);

        lblNgaySinh.Text =
            "Ngày sinh";

        // =====================================================
        // DATETIMEPICKER
        // =====================================================

        dtpNgaySinh.Location =
            new Point(160, 137);

        dtpNgaySinh.Size =
            new Size(220, 23);

        dtpNgaySinh.Format =
            DateTimePickerFormat.Short;

        dtpNgaySinh.MaxDate =
            DateTime.Today;

        dtpNgaySinh.Value =
            DateTime.Today.AddYears(-18);

        // =====================================================
        // LABEL HẠNG THÀNH VIÊN
        // =====================================================

        lblHangThanhVien.AutoSize = true;

        lblHangThanhVien.Location =
            new Point(35, 180);

        lblHangThanhVien.Size =
            new Size(92, 15);

        lblHangThanhVien.Text =
            "Hạng thành viên";

        // =====================================================
        // COMBO HẠNG THÀNH VIÊN
        // =====================================================

        cboHangThanhVien.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cboHangThanhVien.FormattingEnabled = true;

        cboHangThanhVien.Location =
            new Point(160, 177);

        cboHangThanhVien.Size =
            new Size(220, 23);

        // =====================================================
        // CHECKBOX TRẠNG THÁI
        // =====================================================

        chkTrangThai.AutoSize = true;

        chkTrangThai.Location =
            new Point(35, 215);

        chkTrangThai.Size =
            new Size(109, 19);

        chkTrangThai.Text =
            "Đang hoạt động";

        chkTrangThai.Checked = true;

        // =====================================================
        // BUTTON THÊM
        // =====================================================

        btnThem.Location =
            new Point(700, 30);

        btnThem.Size =
            new Size(110, 35);

        btnThem.Text =
            "Thêm";

        btnThem.UseVisualStyleBackColor =
            true;

        btnThem.Click +=
            btnThem_Click;

        // =====================================================
        // BUTTON SỬA
        // =====================================================

        btnSua.Location =
            new Point(700, 75);

        btnSua.Size =
            new Size(110, 35);

        btnSua.Text =
            "Sửa";

        btnSua.UseVisualStyleBackColor =
            true;

        btnSua.Click +=
            btnSua_Click;

        // =====================================================
        // BUTTON XÓA
        // =====================================================

        btnXoa.Location =
            new Point(700, 120);

        btnXoa.Size =
            new Size(110, 35);

        btnXoa.Text =
            "Xóa";

        btnXoa.UseVisualStyleBackColor =
            true;

        btnXoa.Click +=
            btnXoa_Click;

        // =====================================================
        // BUTTON LÀM MỚI
        // =====================================================

        btnLamMoi.Location =
            new Point(700, 165);

        btnLamMoi.Size =
            new Size(110, 35);

        btnLamMoi.Text =
            "Làm mới";

        btnLamMoi.UseVisualStyleBackColor =
            true;

        btnLamMoi.Click +=
            btnLamMoi_Click;

        // =====================================================
        // Ô TÌM KIẾM HỌ TÊN
        // =====================================================

        txtTimHoTen.Location =
            new Point(35, 260);

        txtTimHoTen.Size =
            new Size(270, 23);

        // =====================================================
        // LABEL TÌM HẠNG
        // =====================================================

        lblTimHang.AutoSize = true;

        lblTimHang.Location =
            new Point(325, 264);

        lblTimHang.Size =
            new Size(32, 15);

        lblTimHang.Text =
            "Hạng";

        // =====================================================
        // COMBO TÌM HẠNG
        // =====================================================

        cboTimHang.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cboTimHang.FormattingEnabled = true;

        cboTimHang.Location =
            new Point(370, 260);

        cboTimHang.Size =
            new Size(150, 23);

        // =====================================================
        // BUTTON TÌM KIẾM
        // =====================================================

        btnTimKiem.Location =
            new Point(545, 257);

        btnTimKiem.Size =
            new Size(110, 30);

        btnTimKiem.Text =
            "Tìm kiếm";

        btnTimKiem.UseVisualStyleBackColor =
            true;

        btnTimKiem.Click +=
            btnTimKiem_Click;

        // =====================================================
        // DATAGRIDVIEW
        // =====================================================

        dgvHoiVien.AllowUserToAddRows =
            false;

        dgvHoiVien.AllowUserToDeleteRows =
            false;

        dgvHoiVien.AllowUserToResizeRows =
            false;

        dgvHoiVien.AutoGenerateColumns =
            false;

        dgvHoiVien.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;

        dgvHoiVien.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        dgvHoiVien.MultiSelect =
            false;

        dgvHoiVien.ReadOnly =
            true;

        dgvHoiVien.RowHeadersWidth =
            40;

        dgvHoiVien.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvHoiVien.Location =
            new Point(35, 310);

        dgvHoiVien.Size =
            new Size(975, 280);

        // =====================================================
        // CỘT MÃ HV
        // =====================================================

        var colMaHv =
            new DataGridViewTextBoxColumn();

        colMaHv.Name =
            "MaHv";

        colMaHv.HeaderText =
            "Mã HV";

        colMaHv.DataPropertyName =
            "MaHv";

        colMaHv.Width =
            65;

        // =====================================================
        // CỘT HỌ TÊN
        // =====================================================

        var colHoTen =
            new DataGridViewTextBoxColumn();

        colHoTen.Name =
            "HoTen";

        colHoTen.HeaderText =
            "Họ tên";

        colHoTen.DataPropertyName =
            "HoTen";

        colHoTen.Width =
            170;

        // =====================================================
        // CỘT GIỚI TÍNH
        // =====================================================

        var colGioiTinh =
            new DataGridViewTextBoxColumn();

        colGioiTinh.Name =
            "GioiTinh";

        colGioiTinh.HeaderText =
            "Giới tính";

        colGioiTinh.DataPropertyName =
            "GioiTinh";

        colGioiTinh.Width =
            80;

        // =====================================================
        // CỘT NGÀY SINH
        // =====================================================

        var colNgaySinh =
            new DataGridViewTextBoxColumn();

        colNgaySinh.Name =
            "NgaySinh";

        colNgaySinh.HeaderText =
            "Ngày sinh";

        colNgaySinh.DataPropertyName =
            "NgaySinh";

        colNgaySinh.Width =
            100;

        colNgaySinh.DefaultCellStyle.Format =
            "dd/MM/yyyy";

        // =====================================================
        // CỘT SĐT
        // =====================================================

        var colSdt =
            new DataGridViewTextBoxColumn();

        colSdt.Name =
            "Sdt";

        colSdt.HeaderText =
            "SĐT";

        colSdt.DataPropertyName =
            "Sdt";

        colSdt.Width =
            120;

        // =====================================================
        // CỘT HẠNG
        // =====================================================

        var colHang =
            new DataGridViewTextBoxColumn();

        colHang.Name =
            "HangThanhVien";

        colHang.HeaderText =
            "Hạng thành viên";

        colHang.DataPropertyName =
            "HangThanhVien";

        colHang.Width =
            130;

        // =====================================================
        // CỘT TRẠNG THÁI
        // =====================================================

        var colTrangThai =
            new DataGridViewTextBoxColumn();

        colTrangThai.Name =
            "TrangThai";

        colTrangThai.HeaderText =
            "Trạng thái";

        colTrangThai.DataPropertyName =
            "TrangThai";

        colTrangThai.Width =
            110;

        // =====================================================
        // ADD COLUMNS
        // =====================================================

        dgvHoiVien.Columns.AddRange(
            colMaHv,
            colHoTen,
            colGioiTinh,
            colNgaySinh,
            colSdt,
            colHang,
            colTrangThai);

        // =====================================================
        // EVENTS
        // =====================================================

        dgvHoiVien.SelectionChanged +=
            dgvHoiVien_SelectionChanged;

        dgvHoiVien.CellFormatting +=
            dgvHoiVien_CellFormatting;

        Load +=
            Form1_Load;

        // =====================================================
        // ADD CONTROLS
        // =====================================================

        Controls.Add(lblHoTen);
        Controls.Add(txtHoTen);

        Controls.Add(grpGioiTinh);

        Controls.Add(lblSDT);
        Controls.Add(txtSDT);

        Controls.Add(lblEmail);
        Controls.Add(txtEmail);

        Controls.Add(lblNgaySinh);
        Controls.Add(dtpNgaySinh);

        Controls.Add(lblHangThanhVien);
        Controls.Add(cboHangThanhVien);

        Controls.Add(chkTrangThai);

        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);

        Controls.Add(txtTimHoTen);
        Controls.Add(lblTimHang);
        Controls.Add(cboTimHang);
        Controls.Add(btnTimKiem);

        Controls.Add(dgvHoiVien);

        // =====================================================
        // GROUPBOX
        // =====================================================

        grpGioiTinh.ResumeLayout(false);
        grpGioiTinh.PerformLayout();

        ((System.ComponentModel.ISupportInitialize)dgvHoiVien)
            .EndInit();

        ResumeLayout(false);
        PerformLayout();
    }
}