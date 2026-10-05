namespace QuanLyLoaiPhong;

partial class FormLoaiPhong
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTenLoai;
    private Label lblGiaMoiDem;
    private Label lblMoTa;

    private TextBox txtTenLoai;
    private TextBox txtMoTa;

    private NumericUpDown nudGiaMoiDem;

    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;

    private DataGridView dgvLoaiPhong;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components =
            new System.ComponentModel.Container();

        lblTenLoai = new Label();
        lblGiaMoiDem = new Label();
        lblMoTa = new Label();

        txtTenLoai = new TextBox();
        txtMoTa = new TextBox();

        nudGiaMoiDem = new NumericUpDown();

        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();

        dgvLoaiPhong = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)
            nudGiaMoiDem).BeginInit();

        ((System.ComponentModel.ISupportInitialize)
            dgvLoaiPhong).BeginInit();

        SuspendLayout();

        // =====================================================
        // FORM
        // =====================================================

        AutoScaleDimensions =
            new SizeF(7F, 15F);

        AutoScaleMode =
            AutoScaleMode.Font;

        ClientSize =
            new Size(850, 520);

        StartPosition =
            FormStartPosition.CenterParent;

        Text =
            "Quản lý Loại phòng - Sunrise Homestay";

        // =====================================================
        // TÊN LOẠI
        // =====================================================

        lblTenLoai.AutoSize = true;

        lblTenLoai.Location =
            new Point(30, 35);

        lblTenLoai.Text =
            "Tên loại phòng";

        txtTenLoai.Location =
            new Point(150, 32);

        txtTenLoai.Size =
            new Size(250, 23);

        // =====================================================
        // GIÁ
        // =====================================================

        lblGiaMoiDem.AutoSize = true;

        lblGiaMoiDem.Location =
            new Point(30, 75);

        lblGiaMoiDem.Text =
            "Giá mỗi đêm";

        nudGiaMoiDem.Location =
            new Point(150, 72);

        nudGiaMoiDem.Size =
            new Size(250, 23);

        nudGiaMoiDem.Minimum =
            0;

        nudGiaMoiDem.Maximum =
            1000000000;

        nudGiaMoiDem.DecimalPlaces =
            0;

        nudGiaMoiDem.ThousandsSeparator =
            true;

        // =====================================================
        // MÔ TẢ
        // =====================================================

        lblMoTa.AutoSize = true;

        lblMoTa.Location =
            new Point(30, 115);

        lblMoTa.Text =
            "Mô tả";

        txtMoTa.Location =
            new Point(150, 112);

        txtMoTa.Size =
            new Size(250, 70);

        txtMoTa.Multiline =
            true;

        // =====================================================
        // THÊM
        // =====================================================

        btnThem.Location =
            new Point(450, 30);

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
            new Point(560, 30);

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
            new Point(670, 30);

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
            new Point(450, 75);

        btnLamMoi.Size =
            new Size(100, 35);

        btnLamMoi.Text =
            "Làm mới";

        btnLamMoi.UseVisualStyleBackColor =
            true;

        btnLamMoi.Click +=
            btnLamMoi_Click;

        // =====================================================
        // DATAGRIDVIEW
        // =====================================================

        dgvLoaiPhong.Location =
            new Point(30, 220);

        dgvLoaiPhong.Size =
            new Size(740, 240);

        dgvLoaiPhong.AllowUserToAddRows =
            false;

        dgvLoaiPhong.AllowUserToDeleteRows =
            false;

        dgvLoaiPhong.MultiSelect =
            false;

        dgvLoaiPhong.ReadOnly =
            true;

        dgvLoaiPhong.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvLoaiPhong.AutoGenerateColumns =
            false;

        // =====================================================
        // MÃ LOẠI
        // =====================================================

        var colMaLoai =
            new DataGridViewTextBoxColumn();

        colMaLoai.Name =
            "MaLoai";

        colMaLoai.HeaderText =
            "Mã loại";

        colMaLoai.DataPropertyName =
            "MaLoai";

        colMaLoai.Width =
            70;

        // =====================================================
        // TÊN LOẠI
        // =====================================================

        var colTenLoai =
            new DataGridViewTextBoxColumn();

        colTenLoai.Name =
            "TenLoai";

        colTenLoai.HeaderText =
            "Tên loại";

        colTenLoai.DataPropertyName =
            "TenLoai";

        colTenLoai.Width =
            180;

        // =====================================================
        // GIÁ
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
            120;

        colGia.DefaultCellStyle.Format =
            "N0";

        // =====================================================
        // MÔ TẢ
        // =====================================================

        var colMoTa =
            new DataGridViewTextBoxColumn();

        colMoTa.Name =
            "MoTa";

        colMoTa.HeaderText =
            "Mô tả";

        colMoTa.DataPropertyName =
            "MoTa";

        colMoTa.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill;

        dgvLoaiPhong.Columns.AddRange(
            colMaLoai,
            colTenLoai,
            colGia,
            colMoTa);

        // =====================================================
        // EVENTS
        // =====================================================

        dgvLoaiPhong.SelectionChanged +=
            dgvLoaiPhong_SelectionChanged;

        Load +=
            FormLoaiPhong_Load;

        // =====================================================
        // ADD CONTROLS
        // =====================================================

        Controls.Add(lblTenLoai);
        Controls.Add(txtTenLoai);

        Controls.Add(lblGiaMoiDem);
        Controls.Add(nudGiaMoiDem);

        Controls.Add(lblMoTa);
        Controls.Add(txtMoTa);

        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);

        Controls.Add(dgvLoaiPhong);

        ((System.ComponentModel.ISupportInitialize)
            nudGiaMoiDem).EndInit();

        ((System.ComponentModel.ISupportInitialize)
            dgvLoaiPhong).EndInit();

        ResumeLayout(false);
        PerformLayout();
    }
}