using Microsoft.EntityFrameworkCore;
using QuanLyHoiVien.Models;

namespace QuanLyHoiVien;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Nạp hạng thành viên
        cboHangThanhVien.Items.Add("Basic");
        cboHangThanhVien.Items.Add("VIP");
        cboHangThanhVien.Items.Add("Premium");

        // Nạp bộ lọc hạng
        cboTimHang.Items.Add("Tất cả");
        cboTimHang.Items.Add("Basic");
        cboTimHang.Items.Add("VIP");
        cboTimHang.Items.Add("Premium");

        cboHangThanhVien.SelectedIndex = 0;
        cboTimHang.SelectedIndex = 0;

        // Ngày sinh không được lớn hơn hôm nay
        dtpNgaySinh.MaxDate = DateTime.Today;
        dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
    }

    // =========================================================
    // TẠO DB CONTEXT
    // =========================================================

    private FitZoneContext CreateContext()
    {
        var options =
            new DbContextOptionsBuilder<FitZoneContext>()
                .UseSqlServer(
                    @"Server=DESKTOP-MAETIJA\SQLEXPRESS;Database=FitZone;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

        return new FitZoneContext(options);
    }

    // =========================================================
    // LOAD FORM
    // =========================================================

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    // =========================================================
    // LOAD DATA
    // =========================================================

    private async Task LoadDataAsync(
        string hoTen = "",
        string hang = "Tất cả")
    {
        try
        {
            using var db = CreateContext();

            var query = db.Set<HoiVien>()
                .AsNoTracking()
                .AsQueryable();

            // Tìm theo họ tên
            if (!string.IsNullOrWhiteSpace(hoTen))
            {
                query = query.Where(x =>
                    x.HoTen.Contains(hoTen));
            }

            // Tìm theo hạng thành viên
            if (hang != "Tất cả")
            {
                query = query.Where(x =>
                    x.HangThanhVien == hang);
            }

            var data = await query
                .OrderBy(x => x.MaHv)
                .ToListAsync();

            dgvHoiVien.DataSource = data;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi tải dữ liệu:\n" + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================================
    // CHỌN DÒNG DATAGRIDVIEW
    // =========================================================

    private void dgvHoiVien_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvHoiVien.CurrentRow == null)
            return;

        try
        {
            var row = dgvHoiVien.CurrentRow;

            // Họ tên
            txtHoTen.Text =
                row.Cells["HoTen"].Value?.ToString() ?? "";

            // Giới tính
            if (row.Cells["GioiTinh"].Value != null)
            {
                bool gioiTinh =
                    Convert.ToBoolean(
                        row.Cells["GioiTinh"].Value);

                rdoNam.Checked = gioiTinh;
                rdoNu.Checked = !gioiTinh;
            }

            // Ngày sinh
            if (row.Cells["NgaySinh"].Value != null)
            {
                DateOnly ngaySinh =
                    (DateOnly)row.Cells["NgaySinh"].Value;

                DateTime ngaySinhDateTime =
                    ngaySinh.ToDateTime(TimeOnly.MinValue);

                if (ngaySinhDateTime <= DateTime.Today)
                {
                    dtpNgaySinh.Value =
                        ngaySinhDateTime;
                }
            }

            // Số điện thoại
            txtSDT.Text =
                row.Cells["Sdt"].Value?.ToString() ?? "";

            // Email
            txtEmail.Text =
                row.Cells["Email"].Value?.ToString() ?? "";

            // Hạng thành viên
            string hang =
                row.Cells["HangThanhVien"]
                    .Value?.ToString() ?? "";

            if (!string.IsNullOrEmpty(hang))
            {
                cboHangThanhVien.SelectedItem = hang;
            }

            // Trạng thái
            if (row.Cells["TrangThai"].Value != null)
            {
                chkTrangThai.Checked =
                    Convert.ToBoolean(
                        row.Cells["TrangThai"].Value);
            }
        }
        catch
        {
            // Bỏ qua khi DataGridView đang cập nhật dữ liệu
        }
    }

    // =========================================================
    // HIỂN THỊ GIỚI TÍNH / TRẠNG THÁI
    // =========================================================

    private void dgvHoiVien_CellFormatting(
        object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        // Giới tính
        if (dgvHoiVien.Columns[e.ColumnIndex].Name == "GioiTinh")
        {
            if (e.Value != null)
            {
                bool gioiTinh =
                    Convert.ToBoolean(e.Value);

                e.Value = gioiTinh
                    ? "Nam"
                    : "Nữ";

                e.FormattingApplied = true;
            }
        }

        // Trạng thái
        if (dgvHoiVien.Columns[e.ColumnIndex].Name == "TrangThai")
        {
            if (e.Value != null)
            {
                bool trangThai =
                    Convert.ToBoolean(e.Value);

                e.Value = trangThai
                    ? "Đang hoạt động"
                    : "Tạm ngưng";

                e.FormattingApplied = true;
            }
        }
    }

    // =========================================================
    // THÊM
    // =========================================================

    private async void btnThem_Click(
        object sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            using var db = CreateContext();

            var hoiVien = new HoiVien
            {
                HoTen = txtHoTen.Text.Trim(),

                GioiTinh = rdoNam.Checked,

                NgaySinh =
                    DateOnly.FromDateTime(
                        dtpNgaySinh.Value.Date),

                Sdt = txtSDT.Text.Trim(),

                Email = txtEmail.Text.Trim(),

                HangThanhVien =
                    cboHangThanhVien.SelectedItem!
                        .ToString()!,

                TrangThai =
                    chkTrangThai.Checked
            };

            db.Set<HoiVien>().Add(hoiVien);

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Thêm hội viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearInput();

            await LoadDataAsync();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể thêm hội viên:\n" +
                ex.InnerException?.Message ??
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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

    // =========================================================
    // SỬA
    // =========================================================

    private async void btnSua_Click(
        object sender,
        EventArgs e)
    {
        if (dgvHoiVien.CurrentRow == null)
        {
            MessageBox.Show(
                "Vui lòng chọn hội viên cần sửa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!ValidateInput())
            return;

        try
        {
            int maHV =
                Convert.ToInt32(
                    dgvHoiVien.CurrentRow
                        .Cells["MaHv"].Value);

            using var db = CreateContext();

            var hoiVien =
                await db.Set<HoiVien>()
                    .FirstOrDefaultAsync(
                        x => x.MaHv == maHV);

            if (hoiVien == null)
            {
                MessageBox.Show(
                    "Không tìm thấy hội viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            hoiVien.HoTen =
                txtHoTen.Text.Trim();

            hoiVien.GioiTinh =
                rdoNam.Checked;

            hoiVien.NgaySinh =
                DateOnly.FromDateTime(
                    dtpNgaySinh.Value.Date);

            hoiVien.Sdt =
                txtSDT.Text.Trim();

            hoiVien.Email =
                txtEmail.Text.Trim();

            hoiVien.HangThanhVien =
                cboHangThanhVien.SelectedItem!
                    .ToString()!;

            hoiVien.TrangThai =
                chkTrangThai.Checked;

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật hội viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể cập nhật:\n" +
                (ex.InnerException?.Message ?? ex.Message),
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi cập nhật:\n" + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================================
    // XÓA
    // =========================================================

    private async void btnXoa_Click(
        object sender,
        EventArgs e)
    {
        if (dgvHoiVien.CurrentRow == null)
        {
            MessageBox.Show(
                "Vui lòng chọn hội viên cần xóa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult result =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa hội viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            int maHV =
                Convert.ToInt32(
                    dgvHoiVien.CurrentRow
                        .Cells["MaHv"].Value);

            using var db = CreateContext();

            var hoiVien =
                await db.Set<HoiVien>()
                    .FirstOrDefaultAsync(
                        x => x.MaHv == maHV);

            if (hoiVien == null)
            {
                MessageBox.Show(
                    "Không tìm thấy hội viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            db.Set<HoiVien>().Remove(hoiVien);

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Xóa hội viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearInput();

            await LoadDataAsync();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể xóa hội viên.\n" +
                "Dữ liệu có thể đang bị ràng buộc bởi bảng khác.\n\n" +
                (ex.InnerException?.Message ?? ex.Message),
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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

    // =========================================================
    // TÌM KIẾM
    // =========================================================

    private async void btnTimKiem_Click(
        object sender,
        EventArgs e)
    {
        string hoTen =
            txtTimHoTen.Text.Trim();

        string hang =
            cboTimHang.SelectedItem?.ToString()
            ?? "Tất cả";

        await LoadDataAsync(
            hoTen,
            hang);
    }

    // =========================================================
    // LÀM MỚI
    // =========================================================

    private async void btnLamMoi_Click(
        object sender,
        EventArgs e)
    {
        ClearInput();

        txtTimHoTen.Clear();

        cboTimHang.SelectedIndex = 0;

        await LoadDataAsync();
    }

    // =========================================================
    // VALIDATE
    // =========================================================

    private bool ValidateInput()
    {
        // -------------------------
        // HỌ TÊN
        // -------------------------

        if (string.IsNullOrWhiteSpace(
            txtHoTen.Text))
        {
            MessageBox.Show(
                "Họ tên không được để trống!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtHoTen.Focus();

            return false;
        }

        // -------------------------
        // GIỚI TÍNH
        // -------------------------

        if (!rdoNam.Checked &&
            !rdoNu.Checked)
        {
            MessageBox.Show(
                "Vui lòng chọn giới tính!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        // -------------------------
        // TUỔI
        // -------------------------

        int tuoi =
            TinhTuoi(dtpNgaySinh.Value.Date);

        if (tuoi < 15)
        {
            MessageBox.Show(
                "Hội viên phải từ 15 tuổi trở lên!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            dtpNgaySinh.Focus();

            return false;
        }

        // -------------------------
        // SĐT
        // -------------------------

        string sdt =
            txtSDT.Text.Trim();

        if (string.IsNullOrWhiteSpace(sdt))
        {
            MessageBox.Show(
                "Số điện thoại không được để trống!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSDT.Focus();

            return false;
        }

        if (!sdt.All(char.IsDigit))
        {
            MessageBox.Show(
                "Số điện thoại chỉ được chứa chữ số!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSDT.Focus();

            return false;
        }

        if (sdt.Length < 9 ||
            sdt.Length > 11)
        {
            MessageBox.Show(
                "Số điện thoại phải có từ 9 đến 11 chữ số!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSDT.Focus();

            return false;
        }

        // -------------------------
        // EMAIL
        // -------------------------

        string email =
            txtEmail.Text.Trim();

        if (string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show(
                "Email không được để trống!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtEmail.Focus();

            return false;
        }

        if (!email.Contains("@"))
        {
            MessageBox.Show(
                "Email phải chứa ký tự '@'!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtEmail.Focus();

            return false;
        }

        // -------------------------
        // HẠNG THÀNH VIÊN
        // -------------------------

        if (cboHangThanhVien.SelectedIndex == -1)
        {
            MessageBox.Show(
                "Vui lòng chọn hạng thành viên!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cboHangThanhVien.Focus();

            return false;
        }

        return true;
    }

    // =========================================================
    // TÍNH TUỔI
    // =========================================================

    private int TinhTuoi(DateTime ngaySinh)
    {
        DateTime homNay =
            DateTime.Today;

        int tuoi =
            homNay.Year - ngaySinh.Year;

        if (ngaySinh.Date >
            homNay.AddYears(-tuoi))
        {
            tuoi--;
        }

        return tuoi;
    }

    // =========================================================
    // XÓA TRẮNG FORM
    // =========================================================

    private void ClearInput()
    {
        txtHoTen.Clear();
        txtSDT.Clear();
        txtEmail.Clear();

        rdoNam.Checked = true;
        rdoNu.Checked = false;

        dtpNgaySinh.Value =
            DateTime.Today.AddYears(-18);

        cboHangThanhVien.SelectedIndex = 0;

        chkTrangThai.Checked = true;
    }
}