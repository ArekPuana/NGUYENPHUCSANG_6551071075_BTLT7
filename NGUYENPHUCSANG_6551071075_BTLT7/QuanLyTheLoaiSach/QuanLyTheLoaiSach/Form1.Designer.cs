namespace QuanLyTheLoaiSach
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaTL;
        private Label lblTenTheLoai;
        private Label lblMoTa;
        private Label lblNgayTao;
        private Label lblTimKiem;

        private TextBox txtMaTL;
        private TextBox txtTenTheLoai;
        private TextBox txtMoTa;
        private TextBox txtTimKiem;

        private Label lblNgayTaoValue;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvTheLoai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaTL = new Label();
            lblTenTheLoai = new Label();
            lblMoTa = new Label();
            lblNgayTao = new Label();
            lblTimKiem = new Label();

            txtMaTL = new TextBox();
            txtTenTheLoai = new TextBox();
            txtMoTa = new TextBox();
            txtTimKiem = new TextBox();

            lblNgayTaoValue = new Label();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            dgvTheLoai = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();

            // =========================
            // lblMaTL
            // =========================
            lblMaTL.AutoSize = true;
            lblMaTL.Location = new Point(30, 30);
            lblMaTL.Text = "Mã thể loại:";

            // =========================
            // txtMaTL
            // =========================
            txtMaTL.Location = new Point(130, 27);
            txtMaTL.Size = new Size(250, 27);
            txtMaTL.ReadOnly = true;

            // =========================
            // lblTenTheLoai
            // =========================
            lblTenTheLoai.AutoSize = true;
            lblTenTheLoai.Location = new Point(30, 70);
            lblTenTheLoai.Text = "Tên thể loại:";

            // =========================
            // txtTenTheLoai
            // =========================
            txtTenTheLoai.Location = new Point(130, 67);
            txtTenTheLoai.Size = new Size(250, 27);

            // =========================
            // lblMoTa
            // =========================
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(30, 110);
            lblMoTa.Text = "Mô tả:";

            // =========================
            // txtMoTa
            // =========================
            txtMoTa.Location = new Point(130, 107);
            txtMoTa.Multiline = true;
            txtMoTa.Size = new Size(250, 70);

            // =========================
            // lblNgayTao
            // =========================
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new Point(30, 195);
            lblNgayTao.Text = "Ngày tạo:";

            // =========================
            // lblNgayTaoValue
            // =========================
            lblNgayTaoValue.AutoSize = true;
            lblNgayTaoValue.Location = new Point(130, 195);
            lblNgayTaoValue.Text = "";

            // =========================
            // btnThem
            // =========================
            btnThem.Location = new Point(30, 240);
            btnThem.Size = new Size(80, 35);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // =========================
            // btnSua
            // =========================
            btnSua.Location = new Point(120, 240);
            btnSua.Size = new Size(80, 35);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // =========================
            // btnXoa
            // =========================
            btnXoa.Location = new Point(210, 240);
            btnXoa.Size = new Size(80, 35);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // =========================
            // btnLamMoi
            // =========================
            btnLamMoi.Location = new Point(300, 240);
            btnLamMoi.Size = new Size(80, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;

            // =========================
            // lblTimKiem
            // =========================
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(430, 30);
            lblTimKiem.Text = "Tìm kiếm:";

            // =========================
            // txtTimKiem
            // =========================
            txtTimKiem.Location = new Point(500, 27);
            txtTimKiem.Size = new Size(300, 27);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // =========================
            // DataGridView
            // =========================
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.AutoGenerateColumns = false;
            dgvTheLoai.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvTheLoai.Location = new Point(30, 300);

            dgvTheLoai.MultiSelect = false;
            dgvTheLoai.ReadOnly = true;

            dgvTheLoai.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTheLoai.Size = new Size(770, 300);

            // ĐÚNG YÊU CẦU ĐỀ:
            // Chọn dòng -> tự động đổ dữ liệu
            dgvTheLoai.SelectionChanged +=
                dgvTheLoai_SelectionChanged;

            // =========================
            // Cột Mã TL
            // =========================
            var colMaTL =
                new DataGridViewTextBoxColumn();

            colMaTL.Name = "colMaTL";
            colMaTL.HeaderText = "Mã TL";
            colMaTL.DataPropertyName = "MaTl";
            colMaTL.Width = 80;

            // =========================
            // Cột Tên thể loại
            // =========================
            var colTenTheLoai =
                new DataGridViewTextBoxColumn();

            colTenTheLoai.Name = "colTenTheLoai";
            colTenTheLoai.HeaderText = "Tên thể loại";
            colTenTheLoai.DataPropertyName = "TenTheLoai";
            colTenTheLoai.Width = 180;

            // =========================
            // Cột Mô tả
            // =========================
            var colMoTa =
                new DataGridViewTextBoxColumn();

            colMoTa.Name = "colMoTa";
            colMoTa.HeaderText = "Mô tả";
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.Width = 250;

            // =========================
            // Cột Số lượng
            // =========================
            var colSoLuong =
                new DataGridViewTextBoxColumn();

            colSoLuong.Name = "colSoLuong";
            colSoLuong.HeaderText = "Số lượng sách";
            colSoLuong.DataPropertyName = "SoLuongSach";
            colSoLuong.Width = 110;

            // =========================
            // Cột Ngày tạo
            // =========================
            var colNgayTao =
                new DataGridViewTextBoxColumn();

            colNgayTao.Name = "colNgayTao";
            colNgayTao.HeaderText = "Ngày tạo";
            colNgayTao.DataPropertyName = "NgayTao";
            colNgayTao.Width = 130;

            dgvTheLoai.Columns.AddRange(
                colMaTL,
                colTenTheLoai,
                colMoTa,
                colSoLuong,
                colNgayTao
            );

            // =========================
            // FORM
            // =========================
            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(850, 650);

            Controls.Add(lblMaTL);
            Controls.Add(txtMaTL);

            Controls.Add(lblTenTheLoai);
            Controls.Add(txtTenTheLoai);

            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);

            Controls.Add(lblNgayTao);
            Controls.Add(lblNgayTaoValue);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);

            Controls.Add(dgvTheLoai);

            Name = "Form1";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Quản lý Thể loại Sách - Tri Thức Books";

            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dgvTheLoai)
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}