using Microsoft.EntityFrameworkCore;
using QuanLyLichKham.Models;

namespace QuanLyLichKham
{
    public partial class Form1 : Form
    {
        private int maLichDangChon = 0;

        public Form1()
        {
            InitializeComponent();

            cboTrangThai.Items.Add("Chờ khám");
            cboTrangThai.Items.Add("Đã khám");
            cboTrangThai.Items.Add("Đã hủy");

            cboTrangThai.SelectedIndex = 0;

            dtpNgayKham.Format = DateTimePickerFormat.Short;

            dtpGioKham.Format = DateTimePickerFormat.Time;
            dtpGioKham.ShowUpDown = true;

            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Format = DateTimePickerFormat.Short;

            LoadBacSi();
            LoadData();
        }

        // =========================
        // LOAD BÁC SĨ
        // =========================

        private void LoadBacSi()
        {
            using var context = CreateContext();

            var danhSach = context.BacSis
                .OrderBy(x => x.HoTen)
                .ToList();

            cboBacSi.DataSource = null;

            cboBacSi.DataSource = danhSach;
            cboBacSi.DisplayMember = "HienThi";
            cboBacSi.ValueMember = "MaBs";
        }

        private void LoadBacSiTimKiem()
        {
            using var context = CreateContext();

            var danhSach = context.BacSis
                .OrderBy(x => x.HoTen)
                .ToList();

            cboTimBacSi.Items.Clear();

            cboTimBacSi.Items.Add("Tất cả");

            foreach (var bs in danhSach)
            {
                cboTimBacSi.Items.Add(
                    "BS. " + bs.HoTen + " - " + bs.ChuyenKhoa
                );
            }

            cboTimBacSi.SelectedIndex = 0;
        }

        // =========================
        // LOAD DATA
        // =========================

        private void LoadData()
        {
            using var context = CreateContext();

            var danhSach = context.LichKhams
                .Include(x => x.MaBsNavigation)
                .OrderBy(x => x.NgayKham)
                .ThenBy(x => x.GioKham)
                .ToList();

            dgvLichKham.Rows.Clear();

            foreach (var item in danhSach)
            {
                dgvLichKham.Rows.Add(
                    item.MaLich,
                    item.TenBenhNhan,
                    item.Sdt,
                    item.NgayKham?.ToString("dd/MM/yyyy"),
                    item.GioKham?.ToString("HH:mm"),
                    item.MaBsNavigation?.HoTen,
                    item.MaBsNavigation?.ChuyenKhoa,
                    item.TrangThai
                );
            }

            LoadBacSiTimKiem();
        }

        // =========================
        // CREATE CONTEXT
        // =========================

        private AnKhangClinicContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AnKhangClinicContext>()
                .UseSqlServer(
                    @"Server=desktop-maetija\sqlexpress;Database=AnKhangClinic;Trusted_Connection=True;TrustServerCertificate=True;"
                )
                .Options;

            return new AnKhangClinicContext(options);
        }

        // =========================
        // VALIDATE
        // =========================

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show(
                    "Tên bệnh nhân không được bỏ trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenBenhNhan.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                if (!txtSDT.Text.All(char.IsDigit))
                {
                    MessageBox.Show(
                        "Số điện thoại chỉ được chứa chữ số!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSDT.Focus();
                    return false;
                }
            }

            if (cboBacSi.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn bác sĩ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cboBacSi.Focus();
                return false;
            }

            DateTime ngayKham =
                dtpNgayKham.Value.Date;

            if (ngayKham < DateTime.Today)
            {
                MessageBox.Show(
                    "Không được đặt lịch khám vào ngày trong quá khứ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpNgayKham.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // THÊM
        // =========================

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using var context = CreateContext();

                var lich = new LichKham
                {
                    TenBenhNhan = txtTenBenhNhan.Text.Trim(),
                    Sdt = txtSDT.Text.Trim(),

                    NgayKham = DateOnly.FromDateTime(
                        dtpNgayKham.Value.Date),

                    GioKham = TimeOnly.FromDateTime(
                        dtpGioKham.Value),

                    MaBs = Convert.ToInt32(cboBacSi.SelectedValue),

                    TrangThai = cboTrangThai.Text
                };

                context.LichKhams.Add(lich);

                await context.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm lịch khám thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thêm:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // SỬA
        // =========================

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (maLichDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần sửa!");
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                using var context = CreateContext();

                var lich = await context.LichKhams
                    .FirstOrDefaultAsync(x =>
                        x.MaLich == maLichDangChon);

                if (lich == null)
                {
                    MessageBox.Show("Không tìm thấy lịch khám!");
                    return;
                }

                lich.TenBenhNhan = txtTenBenhNhan.Text.Trim();
                lich.Sdt = txtSDT.Text.Trim();

                lich.NgayKham =
                    DateOnly.FromDateTime(
                        dtpNgayKham.Value.Date);

                lich.GioKham =
                    TimeOnly.FromDateTime(
                        dtpGioKham.Value);

                lich.MaBs =
                    Convert.ToInt32(cboBacSi.SelectedValue);

                lich.TrangThai =
                    cboTrangThai.Text;

                await context.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi sửa:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // XÓA
        // =========================

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (maLichDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa lịch khám này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using var context = CreateContext();

                var lich = await context.LichKhams
                    .FirstOrDefaultAsync(x =>
                        x.MaLich == maLichDangChon);

                if (lich == null)
                {
                    MessageBox.Show("Không tìm thấy lịch khám!");
                    return;
                }

                context.LichKhams.Remove(lich);

                await context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa lịch khám thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi xóa:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // CHỌN DÒNG
        // =========================

        private void dgvLichKham_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvLichKham.SelectedRows.Count == 0)
                return;

            DataGridViewRow row =
                dgvLichKham.SelectedRows[0];

            if (row.Cells[0].Value == null)
                return;

            maLichDangChon =
                Convert.ToInt32(row.Cells[0].Value);

            txtTenBenhNhan.Text =
                row.Cells[1].Value?.ToString();

            txtSDT.Text =
                row.Cells[2].Value?.ToString();

            if (DateTime.TryParse(
                row.Cells[3].Value?.ToString(),
                out DateTime ngay))
            {
                dtpNgayKham.Value = ngay;
            }

            if (DateTime.TryParse(
                row.Cells[4].Value?.ToString(),
                out DateTime gio))
            {
                dtpGioKham.Value = DateTime.Today.Add(
                    gio.TimeOfDay);
            }

            string tenBacSi =
                row.Cells[5].Value?.ToString();

            if (!string.IsNullOrEmpty(tenBacSi))
            {
                for (int i = 0;
                     i < cboBacSi.Items.Count;
                     i++)
                {
                    if (cboBacSi.Items[i] is BacSi bs &&
                        bs.HoTen == tenBacSi)
                    {
                        cboBacSi.SelectedIndex = i;
                        break;
                    }
                }
            }

            cboTrangThai.Text =
                row.Cells[7].Value?.ToString();
        }

        // =========================
        // TÌM KIẾM
        // =========================

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using var context = CreateContext();

                DateOnly tuNgay =
                    DateOnly.FromDateTime(
                        dtpTuNgay.Value.Date);

                DateOnly denNgay =
                    DateOnly.FromDateTime(
                        dtpDenNgay.Value.Date);

                var query = context.LichKhams
                    .Include(x => x.MaBsNavigation)
                    .Where(x =>
                        x.NgayKham >= tuNgay &&
                        x.NgayKham <= denNgay);

                // Nếu đã chọn bác sĩ
                if (cboTimBacSi.SelectedIndex > 0)
                {
                    int index =
                        cboTimBacSi.SelectedIndex - 1;

                    var dsBacSi = context.BacSis
                        .OrderBy(x => x.HoTen)
                        .ToList();

                    if (index < dsBacSi.Count)
                    {
                        int maBS =
                            dsBacSi[index].MaBs;

                        query = query.Where(x =>
                            x.MaBs == maBS);
                    }
                }

                var danhSach = query
                    .OrderBy(x => x.NgayKham)
                    .ThenBy(x => x.GioKham)
                    .ToList();

                dgvLichKham.Rows.Clear();

                foreach (var item in danhSach)
                {
                    dgvLichKham.Rows.Add(
                        item.MaLich,
                        item.TenBenhNhan,
                        item.Sdt,
                        item.NgayKham?.ToString("dd/MM/yyyy"),
                        item.GioKham?.ToString("HH:mm"),
                        item.MaBsNavigation?.HoTen,
                        item.MaBsNavigation?.ChuyenKhoa,
                        item.TrangThai
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm:\n" + ex.Message);
            }
        }

        // =========================
        // LÀM MỚI
        // =========================

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void ClearForm()
        {
            maLichDangChon = 0;

            txtTenBenhNhan.Clear();
            txtSDT.Clear();

            dtpNgayKham.Value = DateTime.Today;
            dtpGioKham.Value =
                DateTime.Today.AddHours(8);

            if (cboBacSi.Items.Count > 0)
                cboBacSi.SelectedIndex = 0;

            cboTrangThai.SelectedIndex = 0;

            dgvLichKham.ClearSelection();
        }

        // =========================
        // QUẢN LÝ BÁC SĨ
        // =========================

        private void btnQuanLyBacSi_Click(
            object sender,
            EventArgs e)
        {
            using FormBacSi form =
                new FormBacSi();

            form.ShowDialog();

            LoadBacSi();
            LoadData();
        }
    }
}