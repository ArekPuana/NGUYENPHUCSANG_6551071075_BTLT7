namespace QuanLyLoaiPhong;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label lblSoPhong;
    private Label lblTangSo;
    private Label lblLoaiPhong;
    private Label lblTinhTrang;
    private Label lblTimLoaiPhong;
    private Label lblTimTinhTrang;

    private TextBox txtSoPhong;

    private NumericUpDown nudTangSo;

    private ComboBox cboLoaiPhong;
    private ComboBox cboTinhTrang;
    private ComboBox cboTimLoaiPhong;
    private ComboBox cboTimTinhTrang;

    private PictureBox pictureBoxPhong;

    private Button btnChonAnh;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private Button btnTimKiem;
    private Button btnQuanLyLoaiPhong;

    private DataGridView dgvPhong;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        lblSoPhong = new Label();
        lblTangSo = new Label();
        lblLoaiPhong = new Label();
        lblTinhTrang = new Label();
        lblTimLoaiPhong = new Label();
        lblTimTinhTrang = new Label();

        txtSoPhong = new TextBox();

        nudTangSo = new NumericUpDown();

        cboLoaiPhong = new ComboBox();
        cboTinhTrang = new ComboBox();
        cboTimLoaiPhong = new ComboBox();
        cboTimTinhTrang = new ComboBox();

        pictureBoxPhong = new PictureBox();

        btnChonAnh = new Button();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        btnTimKiem = new Button();
        btnQuanLyLoaiPhong = new Button();

        dgvPhong = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)
            nudTangSo).BeginInit();

        ((System.ComponentModel.ISupportInitialize)
            pictureBoxPhong).BeginInit();

        ((System.ComponentModel.ISupportInitialize)
            dgvPhong).BeginInit();

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
            "Quản lý Phòng - Sunrise Homestay";

        // =====================================================
        // SỐ PHÒNG
        // =====================================================

        lblSoPhong.AutoSize = true;
        lblSoPhong.Location =
            new Point(30, 35);
        lblSoPhong.Text =
            "Số phòng";

        txtSoPhong.Location =
            new Point(110, 32);
        txtSoPhong.Size =
            new Size(120, 23);

        // =====================================================
        // TẦNG
        // =====================================================

        lblTangSo.AutoSize = true;
        lblTangSo.Location =
            new Point(250, 35);
        lblTangSo.Text =
            "Tầng số";

        nudTangSo.Location =
            new Point(310, 32);
        nudTangSo.Size =
            new Size(90, 23);

        nudTangSo.Minimum = 0;
        nudTangSo.Maximum = 100;

        // =====================================================
        // LOẠI PHÒNG
        // =====================================================

        lblLoaiPhong.AutoSize = true;
        lblLoaiPhong.Location =
            new Point(420, 35);
        lblLoaiPhong.Text =
            "Loại phòng";

        cboLoaiPhong.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cboLoaiPhong.Location =
            new Point(495, 32);
        cboLoaiPhong.Size =
            new Size(140, 23);

        // =====================================================
        // TÌNH TRẠNG
        // =====================================================

        lblTinhTrang.AutoSize = true;
        lblTinhTrang.Location =
            new Point(650, 35);
        lblTinhTrang.Text =
            "Tình trạng";

        cboTinhTrang.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cboTinhTrang.Location =
            new Point(720, 32);
        cboTinhTrang.Size =
            new Size(120, 23);

        // =====================================================
        // PICTUREBOX
        // =====================================================

        pictureBoxPhong.BorderStyle =
            BorderStyle.FixedSingle;

        pictureBoxPhong.Location =
            new Point(850, 20);

        pictureBoxPhong.Size =
            new Size(150, 100);

        pictureBoxPhong.SizeMode =
            PictureBoxSizeMode.Zoom;

        pictureBoxPhong.TabStop = false;

        // =====================================================
        // CHỌN ẢNH
        // =====================================================

        btnChonAnh.Location =
            new Point(850, 125);

        btnChonAnh.Size =
            new Size(150, 32);

        btnChonAnh.Text =
            "Chọn ảnh...";

        btnChonAnh.UseVisualStyleBackColor =
            true;

        btnChonAnh.Click +=
            btnChonAnh_Click;

        // =====================================================
        // THÊM
        // =====================================================

        btnThem.Location =
            new Point(30, 80);

        btnThem.Size =
            new Size(100, 35);

        btnThem.Text =
            "Thêm";

        btnThem.UseVisualStyleBackColor =
            true;

        btnThem.Click +=
            btnThem_Click;

        // =====================================================
        // SỬA
        // =====================================================

        btnSua.Location =
            new Point(140, 80);

        btnSua.Size =
            new Size(100, 35);

        btnSua.Text =
            "Sửa";

        btnSua.UseVisualStyleBackColor =
            true;

        btnSua.Click +=
            btnSua_Click;

        // =====================================================
        // XÓA
        // =====================================================

        btnXoa.Location =
            new Point(250, 80);

        btnXoa.Size =
            new Size(100, 35);

        btnXoa.Text =
            "Xóa";

        btnXoa.UseVisualStyleBackColor =
            true;

        btnXoa.Click +=
            btnXoa_Click;

        // =====================================================
        // LÀM MỚI
        // =====================================================

        btnLamMoi.Location =
            new Point(360, 80);

        btnLamMoi.Size =
            new Size(100, 35);

        btnLamMoi.Text =
            "Làm mới";

        btnLamMoi.UseVisualStyleBackColor =
            true;

        btnLamMoi.Click +=
            btnLamMoi_Click;

        // =====================================================
        // QUẢN LÝ LOẠI PHÒNG
        // =====================================================

        btnQuanLyLoaiPhong.Location =
            new Point(470, 80);

        btnQuanLyLoaiPhong.Size =
            new Size(150, 35);

        btnQuanLyLoaiPhong.Text =
            "Quản lý loại phòng";

        btnQuanLyLoaiPhong.UseVisualStyleBackColor =
            true;

        btnQuanLyLoaiPhong.Click +=
            btnQuanLyLoaiPhong_Click;

        // =====================================================
        // TÌM LOẠI PHÒNG
        // =====================================================

        cboTimLoaiPhong.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cboTimLoaiPhong.Location =
            new Point(30, 175);

        cboTimLoaiPhong.Size =
            new Size(210, 23);

        // =====================================================
        // TÌM TÌNH TRẠNG
        // =====================================================

        cboTimTinhTrang.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cboTimTinhTrang.Location =
            new Point(250, 175);

        cboTimTinhTrang.Size =
            new Size(190, 23);

        // =====================================================
        // TÌM KIẾM
        // =====================================================

        btnTimKiem.Location =
            new Point(455, 172);

        btnTimKiem.Size =
            new Size(100, 30);

        btnTimKiem.Text =
            "Tìm kiếm";

        btnTimKiem.UseVisualStyleBackColor =
            true;

        btnTimKiem.Click +=
            btnTimKiem_Click;

        // =====================================================
        // DATAGRIDVIEW
        // =====================================================

        dgvPhong.Location =
            new Point(30, 220);

        dgvPhong.Size =
            new Size(970, 370);

        dgvPhong.AllowUserToAddRows =
            false;

        dgvPhong.AllowUserToDeleteRows =
            false;

        dgvPhong.MultiSelect =
            false;

        dgvPhong.ReadOnly =
            true;

        dgvPhong.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvPhong.AutoGenerateColumns =
            false;

        dgvPhong.RowTemplate.Height =
            60;

        dgvPhong.RowHeadersWidth =
            40;

        // =====================================================
        // CỘT MÃ PHÒNG
        // =====================================================

        var colMaPhong =
            new DataGridViewTextBoxColumn();

        colMaPhong.Name =
            "MaPhong";

        colMaPhong.HeaderText =
            "Mã phòng";

        colMaPhong.DataPropertyName =
            "MaPhong";

        colMaPhong.Width =
            80;

        // =====================================================
        // CỘT ẢNH
        // =====================================================

        var colHinhAnh =
            new DataGridViewImageColumn();

        colHinhAnh.Name =
            "HinhAnh";

        colHinhAnh.HeaderText =
            "Ảnh";

        colHinhAnh.DataPropertyName =
            "HinhAnh";

        colHinhAnh.Width =
            100;

        colHinhAnh.ImageLayout =
            DataGridViewImageCellLayout.Zoom;

        // =====================================================
        // CỘT SỐ PHÒNG
        // =====================================================

        var colSoPhong =
            new DataGridViewTextBoxColumn();

        colSoPhong.Name =
            "SoPhong";

        colSoPhong.HeaderText =
            "Số phòng";

        colSoPhong.DataPropertyName =
            "SoPhong";

        colSoPhong.Width =
            110;

        // =====================================================
        // CỘT TẦNG
        // =====================================================

        var colTangSo =
            new DataGridViewTextBoxColumn();

        colTangSo.Name =
            "TangSo";

        colTangSo.HeaderText =
            "Tầng";

        colTangSo.DataPropertyName =
            "TangSo";

        colTangSo.Width =
            80;

        // =====================================================
        // CỘT LOẠI PHÒNG
        // =====================================================

        var colLoaiPhong =
            new DataGridViewTextBoxColumn();

        colLoaiPhong.Name =
            "TenLoai";

        colLoaiPhong.HeaderText =
            "Loại phòng";

        colLoaiPhong.DataPropertyName =
            "TenLoai";

        colLoaiPhong.Width =
            150;

        // =====================================================
        // CỘT GIÁ
        // =====================================================

        var colGia =
            new DataGridViewTextBoxColumn();

        colGia.Name =
            "GiaMoiDem";

        colGia.HeaderText =
            "Giá/đêm";

        colGia.DataPropertyName =
            "GiaMoiDem";

        colGia.Width =
            110;

        colGia.DefaultCellStyle.Format =
            "N0";

        // =====================================================
        // CỘT TÌNH TRẠNG
        // =====================================================

        var colTinhTrang =
            new DataGridViewTextBoxColumn();

        colTinhTrang.Name =
            "TinhTrang";

        colTinhTrang.HeaderText =
            "Tình trạng";

        colTinhTrang.DataPropertyName =
            "TinhTrang";

        colTinhTrang.Width =
            130;

        // =====================================================
        // ADD COLUMNS
        // =====================================================

        dgvPhong.Columns.AddRange(
            colMaPhong,
            colHinhAnh,
            colSoPhong,
            colTangSo,
            colLoaiPhong,
            colGia,
            colTinhTrang);

        // =====================================================
        // EVENTS
        // =====================================================

        dgvPhong.SelectionChanged +=
            dgvPhong_SelectionChanged;

        dgvPhong.CellFormatting +=
            dgvPhong_CellFormatting;

        Load +=
            Form1_Load;

        // =====================================================
        // ADD CONTROLS
        // =====================================================

        Controls.Add(lblSoPhong);
        Controls.Add(txtSoPhong);

        Controls.Add(lblTangSo);
        Controls.Add(nudTangSo);

        Controls.Add(lblLoaiPhong);
        Controls.Add(cboLoaiPhong);

        Controls.Add(lblTinhTrang);
        Controls.Add(cboTinhTrang);

        Controls.Add(pictureBoxPhong);
        Controls.Add(btnChonAnh);

        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);
        Controls.Add(btnQuanLyLoaiPhong);

        Controls.Add(cboTimLoaiPhong);
        Controls.Add(cboTimTinhTrang);
        Controls.Add(btnTimKiem);

        Controls.Add(dgvPhong);

        ((System.ComponentModel.ISupportInitialize)
            nudTangSo).EndInit();

        ((System.ComponentModel.ISupportInitialize)
            pictureBoxPhong).EndInit();

        ((System.ComponentModel.ISupportInitialize)
            dgvPhong).EndInit();

        ResumeLayout(false);
        PerformLayout();
    }
}