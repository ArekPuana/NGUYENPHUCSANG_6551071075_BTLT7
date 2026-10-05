using Microsoft.EntityFrameworkCore;
using QuanLyLoaiPhong.Models;

namespace QuanLyLoaiPhong;

public partial class FormLoaiPhong : Form
{
    public FormLoaiPhong()
    {
        InitializeComponent();
    }

    // =========================================================
    // CONTEXT
    // =========================================================

    private SunriseHomestayContext CreateContext()
    {
        var options =
            new DbContextOptionsBuilder<SunriseHomestayContext>()
            .UseSqlServer(
                @"Server=DESKTOP-MAETIJA\SQLEXPRESS;Database=SunriseHomestay;Trusted_Connection=True;TrustServerCertificate=True;")
            .Options;

        return new SunriseHomestayContext(options);
    }

    // =========================================================
    // LOAD
    // =========================================================

    private async void FormLoaiPhong_Load(
        object sender,
        EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            using var db = CreateContext();

            var data =
                await db.LoaiPhongs
                    .AsNoTracking()
                    .OrderBy(x => x.MaLoai)
                    .ToListAsync();

            dgvLoaiPhong.DataSource = data;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi tải loại phòng:\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================================
    // CHỌN DÒNG
    // =========================================================

    private void dgvLoaiPhong_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvLoaiPhong.CurrentRow == null)
            return;

        try
        {
            var row =
                dgvLoaiPhong.CurrentRow;

            txtTenLoai.Text =
                row.Cells["TenLoai"]
                    .Value?.ToString() ?? "";

            if (row.Cells["GiaMoiDem"].Value != null)
            {
                nudGiaMoiDem.Value =
                    Convert.ToDecimal(
                        row.Cells["GiaMoiDem"].Value);
            }

            txtMoTa.Text =
                row.Cells["MoTa"]
                    .Value?.ToString() ?? "";
        }
        catch
        {
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

            string tenLoai =
                txtTenLoai.Text.Trim();

            bool exists =
                await db.LoaiPhongs.AnyAsync(
                    x => x.TenLoai == tenLoai);

            if (exists)
            {
                MessageBox.Show(
                    "Tên loại phòng đã tồn tại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenLoai.Focus();
                return;
            }

            var loaiPhong = new LoaiPhong
            {
                TenLoai = tenLoai,

                GiaMoiDem =
                    nudGiaMoiDem.Value,

                MoTa =
                    string.IsNullOrWhiteSpace(txtMoTa.Text)
                        ? null
                        : txtMoTa.Text.Trim()
            };

            db.LoaiPhongs.Add(loaiPhong);

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Thêm loại phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearInput();

            await LoadDataAsync();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể thêm loại phòng:\n" +
                (ex.InnerException?.Message ??
                 ex.Message),
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi thêm:\n" +
                ex.Message,
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
        if (dgvLoaiPhong.CurrentRow == null)
        {
            MessageBox.Show(
                "Vui lòng chọn loại phòng cần sửa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!ValidateInput())
            return;

        try
        {
            int maLoai =
                Convert.ToInt32(
                    dgvLoaiPhong.CurrentRow
                        .Cells["MaLoai"].Value);

            using var db = CreateContext();

            var loaiPhong =
                await db.LoaiPhongs
                    .FirstOrDefaultAsync(
                        x => x.MaLoai == maLoai);

            if (loaiPhong == null)
                return;

            string tenLoai =
                txtTenLoai.Text.Trim();

            bool exists =
                await db.LoaiPhongs.AnyAsync(
                    x => x.TenLoai == tenLoai &&
                         x.MaLoai != maLoai);

            if (exists)
            {
                MessageBox.Show(
                    "Tên loại phòng đã tồn tại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            loaiPhong.TenLoai =
                tenLoai;

            loaiPhong.GiaMoiDem =
                nudGiaMoiDem.Value;

            loaiPhong.MoTa =
                string.IsNullOrWhiteSpace(txtMoTa.Text)
                    ? null
                    : txtMoTa.Text.Trim();

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật loại phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi cập nhật:\n" +
                ex.Message,
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
        if (dgvLoaiPhong.CurrentRow == null)
        {
            MessageBox.Show(
                "Vui lòng chọn loại phòng cần xóa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult result =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa loại phòng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            int maLoai =
                Convert.ToInt32(
                    dgvLoaiPhong.CurrentRow
                        .Cells["MaLoai"].Value);

            using var db = CreateContext();

            var loaiPhong =
                await db.LoaiPhongs
                    .FirstOrDefaultAsync(
                        x => x.MaLoai == maLoai);

            if (loaiPhong == null)
                return;

            db.LoaiPhongs.Remove(loaiPhong);

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Xóa loại phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearInput();

            await LoadDataAsync();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show(
                "Không thể xóa loại phòng này vì đang có phòng sử dụng loại phòng này!",
                "Lỗi ràng buộc",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi xóa:\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================================
    // LÀM MỚI
    // =========================================================

    private async void btnLamMoi_Click(
        object sender,
        EventArgs e)
    {
        ClearInput();

        await LoadDataAsync();
    }

    // =========================================================
    // VALIDATE
    // =========================================================

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(
            txtTenLoai.Text))
        {
            MessageBox.Show(
                "Tên loại phòng không được để trống!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtTenLoai.Focus();

            return false;
        }

        if (nudGiaMoiDem.Value <= 0)
        {
            MessageBox.Show(
                "Giá mỗi đêm phải lớn hơn 0!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nudGiaMoiDem.Focus();

            return false;
        }

        return true;
    }

    // =========================================================
    // CLEAR
    // =========================================================

    private void ClearInput()
    {
        txtTenLoai.Clear();

        nudGiaMoiDem.Value = 0;

        txtMoTa.Clear();
    }
}