namespace QuanLyLichKham
{
    partial class FormBacSi
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblChuyenKhoa;
        private System.Windows.Forms.Label lblSDT;

        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtChuyenKhoa;
        private System.Windows.Forms.TextBox txtSDT;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.DataGridView dgvBacSi;

        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuyenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHoTen = new Label();
            lblChuyenKhoa = new Label();
            lblSDT = new Label();

            txtHoTen = new TextBox();
            txtChuyenKhoa = new TextBox();
            txtSDT = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            dgvBacSi = new DataGridView();

            colMaBS = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colChuyenKhoa = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            SuspendLayout();

            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 30);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(60, 15);
            lblHoTen.Text = "Họ tên:";

            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(110, 27);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(250, 23);

            // 
            // lblChuyenKhoa
            // 
            lblChuyenKhoa.AutoSize = true;
            lblChuyenKhoa.Location = new Point(30, 70);
            lblChuyenKhoa.Name = "lblChuyenKhoa";
            lblChuyenKhoa.Size = new Size(75, 15);
            lblChuyenKhoa.Text = "Chuyên khoa:";

            // 
            // txtChuyenKhoa
            // 
            txtChuyenKhoa.Location = new Point(110, 67);
            txtChuyenKhoa.Name = "txtChuyenKhoa";
            txtChuyenKhoa.Size = new Size(250, 23);

            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(30, 110);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(75, 15);
            lblSDT.Text = "Số điện thoại:";

            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(110, 107);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 23);

            // 
            // btnThem
            // 
            btnThem.Location = new Point(420, 25);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 35);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;

            // 
            // btnSua
            // 
            btnSua.Location = new Point(520, 25);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 35);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;

            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(620, 25);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 35);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;

            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(720, 25);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;

            // 
            // dgvBacSi
            // 
            dgvBacSi.AllowUserToAddRows = false;
            dgvBacSi.AllowUserToDeleteRows = false;
            dgvBacSi.AutoGenerateColumns = false;
            dgvBacSi.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvBacSi.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colMaBS,
                    colHoTen,
                    colChuyenKhoa,
                    colSDT
                });

            dgvBacSi.Location = new Point(30, 160);
            dgvBacSi.MultiSelect = false;
            dgvBacSi.Name = "dgvBacSi";
            dgvBacSi.ReadOnly = true;
            dgvBacSi.RowHeadersWidth = 51;
            dgvBacSi.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvBacSi.Size = new Size(780, 300);

            // 
            // colMaBS
            // 
            colMaBS.HeaderText = "Mã BS";
            colMaBS.Name = "colMaBS";
            colMaBS.ReadOnly = true;
            colMaBS.Width = 80;

            // 
            // colHoTen
            // 
            colHoTen.HeaderText = "Họ tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            colHoTen.Width = 220;

            // 
            // colChuyenKhoa
            // 
            colChuyenKhoa.HeaderText = "Chuyên khoa";
            colChuyenKhoa.Name = "colChuyenKhoa";
            colChuyenKhoa.ReadOnly = true;
            colChuyenKhoa.Width = 220;

            // 
            // colSDT
            // 
            colSDT.HeaderText = "Số điện thoại";
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            colSDT.Width = 150;

            // 
            // FormBacSi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(850, 500);

            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);

            Controls.Add(lblChuyenKhoa);
            Controls.Add(txtChuyenKhoa);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(dgvBacSi);

            Name = "FormBacSi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Bác sĩ - An Khang Clinic";

            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}