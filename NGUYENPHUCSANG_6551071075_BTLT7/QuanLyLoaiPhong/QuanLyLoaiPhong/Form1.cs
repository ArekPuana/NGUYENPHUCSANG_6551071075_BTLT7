using Microsoft.EntityFrameworkCore;
using QuanLyLoaiPhong.Models;
using System.Drawing;

namespace QuanLyLoaiPhong;

public partial class Form1 : Form
{
    private string? selectedImageName;

    public Form1()
    {
        InitializeComponent();

        Directory.CreateDirectory(
            Path.Combine(AppContext.BaseDirectory, "Images"));

        cboTinhTrang.Items.Add("Trống");
        cboTinhTrang.Items.Add("Đang ở");
        cboTinhTrang.Items.Add("Đang dọn");

        cboTimTinhTrang.Items.Add("Tất cả");
        cboTimTinhTrang.Items.Add("Trống");
        cboTimTinhTrang.Items.Add("Đang ở");
        cboTimTinhTrang.Items.Add("Đang dọn");

        cboTinhTrang.SelectedIndex = 0;
        cboTimTinhTrang.SelectedIndex = 0;

        nudTangSo.Minimum = 0;
        nudTangSo.Maximum = 100;
    }

    // =========================================================
    // TẠO CONTEXT
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
    // LOAD FORM
    // =========================================================

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadLoaiPhongAsync();
        await LoadDataAsync();
        ClearInput();
    }

    // =========================================================
    // LOAD LOẠI PHÒNG VÀO COMBOBOX
    // =========================================================

    private async Task LoadLoaiPhongAsync()
    {
        try
        {
            using var db = CreateContext();

            var loaiPhongs = await db.LoaiPhongs
                .AsNoTracking()
                .OrderBy(x => x.MaLoai)
                .ToListAsync();

            cboLoaiPhong.DataSource = null;
            cboLoaiPhong.DataSource = loaiPhongs;
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";

            cboTimLoaiPhong.DataSource = null;

            var danhSachTimKiem =
                new List<LoaiPhong>();

            danhSachTimKiem.Add(new LoaiPhong
            {
                MaLoai = 0,
                TenLoai = "Tất cả"
            });

            danhSachTimKiem.AddRange(loaiPhongs);

            cboTimLoaiPhong.DataSource =
                danhSachTimKiem;

            cboTimLoaiPhong.DisplayMember =
                "TenLoai";

            cboTimLoaiPhong.ValueMember =
                "MaLoai";

            if (cboLoaiPhong.Items.Count > 0)
                cboLoaiPhong.SelectedIndex = 0;

            cboTimLoaiPhong.SelectedIndex = 0;
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
    // LOAD DANH SÁCH PHÒNG
    // =========================================================

    private async Task LoadDataAsync()
    {
        try
        {
            using var db = CreateContext();

            var data = await db.Phongs
                .Include(x => x.MaLoaiNavigation)
                .AsNoTracking()
                .OrderBy(x => x.MaPhong)
                .ToListAsync();

            dgvPhong.DataSource = data;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi tải danh sách phòng:\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================================
    // CHỌN DÒNG
    // =========================================================

    private void dgvPhong_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvPhong.CurrentRow == null)
            return;

        try
        {
            var row = dgvPhong.CurrentRow;

            if (row.Cells["SoPhong"].Value != null)
            {
                txtSoPhong.Text =
                    row.Cells["SoPhong"].Value.ToString();
            }

            if (row.Cells["TangSo"].Value != null)
            {
                nudTangSo.Value =
                    Convert.ToDecimal(
                        row.Cells["TangSo"].Value);
            }

            if (row.Cells["MaLoai"].Value != null)
            {
                int maLoai =
                    Convert.ToInt32(
                        row.Cells["MaLoai"].Value);

                cboLoaiPhong.SelectedValue = maLoai;
            }

            if (row.Cells["TinhTrang"].Value != null)
            {
                cboTinhTrang.SelectedItem =
                    row.Cells["TinhTrang"].Value.ToString();
            }

            selectedImageName =
                row.Cells["HinhAnh"].Value?.ToString();

            LoadPicture(selectedImageName);
        }
        catch
        {
            // Bỏ qua khi DataGridView đang thay đổi dữ liệu
        }
    }

    // =========================================================
    // CHỌN ẢNH
    // =========================================================

    private void btnChonAnh_Click(
        object sender,
        EventArgs e)
    {
        using OpenFileDialog dialog =
            new OpenFileDialog();

        dialog.Title = "Chọn ảnh phòng";

        dialog.Filter =
            "File ảnh|*.jpg;*.jpeg;*.png;*.bmp";

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        try
        {
            string imagesFolder =
                Path.Combine(
                    AppContext.BaseDirectory,
                    "Images");

            Directory.CreateDirectory(imagesFolder);

            string extension =
                Path.GetExtension(dialog.FileName);

            string fileName =
                "Phong_" +
                DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                extension;

            string destination =
                Path.Combine(
                    imagesFolder,
                    fileName);

            File.Copy(
                dialog.FileName,
                destination,
                true);

            selectedImageName = fileName;

            LoadPicture(selectedImageName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể chọn ảnh:\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================================
    // HIỂN THỊ ẢNH PICTUREBOX
    // =========================================================

    private void LoadPicture(string? fileName)
    {
        pictureBoxPhong.Image = null;

        if (string.IsNullOrWhiteSpace(fileName))
            return;

        string imagePath =
            Path.Combine(
                AppContext.BaseDirectory,
                "Images",
                fileName);

        if (!File.Exists(imagePath))
            return;

        try
        {
            using var temp =
                Image.FromFile(imagePath);

            pictureBoxPhong.Image =
                new Bitmap(temp);
        }
        catch
        {
            pictureBoxPhong.Image = null;
        }
    }

    // =========================================================
    // HIỂN THỊ ẢNH TRÊN DATAGRIDVIEW
    // =========================================================

    private void dgvPhong_CellFormatting(
        object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        if (dgvPhong.Columns[e.ColumnIndex].Name !=
            "HinhAnh")
            return;

        string? fileName =
            e.Value?.ToString();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            e.Value = null;
            return;
        }

        string imagePath =
            Path.Combine(
                AppContext.BaseDirectory,
                "Images",
                fileName);

        if (!File.Exists(imagePath))
        {
            e.Value = null;
            return;
        }

        try
        {
            using var temp =
                Image.FromFile(imagePath);

            e.Value =
                new Bitmap(temp);

            e.FormattingApplied = true;
        }
        catch
        {
            e.Value = null;
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

            string soPhong =
                txtSoPhong.Text.Trim();

            bool exists =
                await db.Phongs.AnyAsync(
                    x => x.SoPhong == soPhong);

            if (exists)
            {
                MessageBox.Show(
                    "Số phòng đã tồn tại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSoPhong.Focus();
                return;
            }

            var phong = new Phong
            {
                SoPhong = soPhong,
                TangSo = (int)nudTangSo.Value,

                MaLoai =
                    Convert.ToInt32(
                        cboLoaiPhong.SelectedValue),

                TinhTrang =
                    cboTinhTrang.SelectedItem!.ToString()!,

                HinhAnh =
                    selectedImageName
            };

            db.Phongs.Add(phong);

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Thêm phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearInput();

            await LoadDataAsync();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể thêm phòng:\n" +
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
        if (dgvPhong.CurrentRow == null)
        {
            MessageBox.Show(
                "Vui lòng chọn phòng cần sửa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!ValidateInput())
            return;

        try
        {
            int maPhong =
                Convert.ToInt32(
                    dgvPhong.CurrentRow
                        .Cells["MaPhong"].Value);

            using var db = CreateContext();

            var phong =
                await db.Phongs
                    .FirstOrDefaultAsync(
                        x => x.MaPhong == maPhong);

            if (phong == null)
            {
                MessageBox.Show(
                    "Không tìm thấy phòng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string soPhong =
                txtSoPhong.Text.Trim();

            bool exists =
                await db.Phongs.AnyAsync(
                    x => x.SoPhong == soPhong &&
                         x.MaPhong != maPhong);

            if (exists)
            {
                MessageBox.Show(
                    "Số phòng đã tồn tại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            phong.SoPhong =
                soPhong;

            phong.TangSo =
                (int)nudTangSo.Value;

            phong.MaLoai =
                Convert.ToInt32(
                    cboLoaiPhong.SelectedValue);

            phong.TinhTrang =
                cboTinhTrang.SelectedItem!
                    .ToString()!;

            phong.HinhAnh =
                selectedImageName;

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể cập nhật:\n" +
                (ex.InnerException?.Message ??
                 ex.Message),
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
        if (dgvPhong.CurrentRow == null)
        {
            MessageBox.Show(
                "Vui lòng chọn phòng cần xóa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult result =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phòng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            int maPhong =
                Convert.ToInt32(
                    dgvPhong.CurrentRow
                        .Cells["MaPhong"].Value);

            using var db = CreateContext();

            var phong =
                await db.Phongs
                    .FirstOrDefaultAsync(
                        x => x.MaPhong == maPhong);

            if (phong == null)
                return;

            db.Phongs.Remove(phong);

            await db.SaveChangesAsync();

            MessageBox.Show(
                "Xóa phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearInput();

            await LoadDataAsync();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể xóa phòng:\n" +
                (ex.InnerException?.Message ??
                 ex.Message),
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
    // TÌM KIẾM
    // =========================================================

    private async void btnTimKiem_Click(
        object sender,
        EventArgs e)
    {
        try
        {
            using var db = CreateContext();

            var query =
                db.Phongs
                    .Include(x => x.MaLoaiNavigation)
                    .AsNoTracking()
                    .AsQueryable();

            // Lọc theo loại phòng
            if (cboTimLoaiPhong.SelectedValue != null)
            {
                int maLoai =
                    Convert.ToInt32(
                        cboTimLoaiPhong.SelectedValue);

                if (maLoai != 0)
                {
                    query =
                        query.Where(x =>
                            x.MaLoai == maLoai);
                }
            }

            // Lọc theo tình trạng
            string? tinhTrang =
                cboTimTinhTrang.SelectedItem
                    ?.ToString();

            if (!string.IsNullOrEmpty(tinhTrang) &&
                tinhTrang != "Tất cả")
            {
                query =
                    query.Where(x =>
                        x.TinhTrang == tinhTrang);
            }

            var data =
                await query
                    .OrderBy(x => x.MaPhong)
                    .ToListAsync();

            dgvPhong.DataSource = data;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Lỗi khi tìm kiếm:\n" +
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

        await LoadLoaiPhongAsync();
        await LoadDataAsync();
    }

    // =========================================================
    // MỞ FORM LOẠI PHÒNG
    // =========================================================

    private async void btnQuanLyLoaiPhong_Click(
        object sender,
        EventArgs e)
    {
        using var form =
            new FormLoaiPhong();

        form.ShowDialog();

        await LoadLoaiPhongAsync();
        await LoadDataAsync();
    }

    // =========================================================
    // VALIDATE
    // =========================================================

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(
            txtSoPhong.Text))
        {
            MessageBox.Show(
                "Số phòng không được để trống!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSoPhong.Focus();
            return false;
        }

        if (cboLoaiPhong.SelectedIndex < 0)
        {
            MessageBox.Show(
                "Vui lòng chọn loại phòng!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cboLoaiPhong.Focus();
            return false;
        }

        if (cboTinhTrang.SelectedIndex < 0)
        {
            MessageBox.Show(
                "Vui lòng chọn tình trạng phòng!",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cboTinhTrang.Focus();
            return false;
        }

        return true;
    }

    // =========================================================
    // CLEAR
    // =========================================================

    private void ClearInput()
    {
        txtSoPhong.Clear();

        nudTangSo.Value = 0;

        if (cboLoaiPhong.Items.Count > 0)
            cboLoaiPhong.SelectedIndex = 0;

        if (cboTinhTrang.Items.Count > 0)
            cboTinhTrang.SelectedIndex = 0;

        selectedImageName = null;

        pictureBoxPhong.Image = null;
    }
}