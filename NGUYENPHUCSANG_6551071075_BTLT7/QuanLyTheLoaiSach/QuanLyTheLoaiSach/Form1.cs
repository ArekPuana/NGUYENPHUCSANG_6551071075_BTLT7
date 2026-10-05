using Microsoft.EntityFrameworkCore;
using QuanLyTheLoaiSach.Models;

namespace QuanLyTheLoaiSach
{
    public partial class Form1 : Form
    {
        private bool _isLoading = false;

        public Form1()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        // ==========================================
        // TẢI DỮ LIỆU
        // ==========================================
        private async Task LoadData(string keyword = "")
        {
            if (_isLoading)
                return;

            _isLoading = true;

            try
            {
                using var context = new TriThucBooksContext();

                var query = context.TheLoaiSaches
                    .AsNoTracking()
                    .AsQueryable();

                // Tìm kiếm theo Tên thể loại
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(x =>
                        x.TenTheLoai.Contains(keyword));
                }

                var data = await query
                    .OrderBy(x => x.MaTl)
                    .ToListAsync();

                dgvTheLoai.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        // ==========================================
        // SELECTIONCHANGED
        // Chọn dòng -> đổ dữ liệu lên Control
        // ==========================================
        private void dgvTheLoai_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvTheLoai.CurrentRow == null)
                return;

            if (dgvTheLoai.CurrentRow.DataBoundItem is not TheLoaiSach item)
                return;

            txtMaTL.Text = item.MaTl.ToString();

            txtTenTheLoai.Text = item.TenTheLoai;

            txtMoTa.Text = item.MoTa ?? "";

            lblNgayTaoValue.Text =
                item.NgayTao.ToString("dd/MM/yyyy HH:mm");
        }

        // ==========================================
        // THÊM
        // ==========================================
        private async void btnThem_Click(
            object sender,
            EventArgs e)
        {
            string ten = txtTenTheLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            // Validate không bỏ trống
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(
                    "Tên thể loại không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                using var context = new TriThucBooksContext();

                // Kiểm tra trùng tên
                bool trungTen = await context.TheLoaiSaches
                    .AnyAsync(x => x.TenTheLoai == ten);

                if (trungTen)
                {
                    MessageBox.Show(
                        "Tên thể loại đã tồn tại.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtTenTheLoai.Focus();
                    return;
                }

                var item = new TheLoaiSach
                {
                    TenTheLoai = ten,
                    MoTa = string.IsNullOrWhiteSpace(moTa)
                        ? null
                        : moTa
                };

                // Theo đúng đề: Add + SaveChangesAsync
                context.TheLoaiSaches.Add(item);

                await context.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm thể loại thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();

                // Cập nhật lại DataGridView
                await LoadData();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể thêm. Tên thể loại có thể đã tồn tại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm dữ liệu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // SỬA
        // ==========================================
        private async void btnSua_Click(
            object sender,
            EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string ten = txtTenTheLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(
                    "Tên thể loại không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                using var context = new TriThucBooksContext();

                var item = await context.TheLoaiSaches
                    .FirstOrDefaultAsync(x => x.MaTl == maTL);

                if (item == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy thể loại.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Không cho trùng tên với bản ghi khác
                bool trungTen = await context.TheLoaiSaches
                    .AnyAsync(x =>
                        x.MaTl != maTL &&
                        x.TenTheLoai == ten);

                if (trungTen)
                {
                    MessageBox.Show(
                        "Tên thể loại đã tồn tại.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                item.TenTheLoai = ten;

                item.MoTa = string.IsNullOrWhiteSpace(moTa)
                    ? null
                    : moTa;

                await context.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();

                await LoadData();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể cập nhật dữ liệu.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa dữ liệu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // XÓA
        // ==========================================
        private async void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // MessageBox YesNo theo đúng đề
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa thể loại này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using var context = new TriThucBooksContext();

                var item = await context.TheLoaiSaches
                    .FirstOrDefaultAsync(x => x.MaTl == maTL);

                if (item == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy thể loại.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                context.TheLoaiSaches.Remove(item);

                await context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa thể loại thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();

                await LoadData();
            }
            catch (DbUpdateException)
            {
                // Theo đúng đề: bắt lỗi DbUpdateException
                MessageBox.Show(
                    "Không thể xóa thể loại này vì đang được sách khác tham chiếu.",
                    "Lỗi ràng buộc",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa dữ liệu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // TÌM KIẾM
        // ==========================================
        private async void txtTimKiem_TextChanged(
            object sender,
            EventArgs e)
        {
            await LoadData(txtTimKiem.Text.Trim());
        }

        // ==========================================
        // LÀM MỚI
        // ==========================================
        private async void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            ClearForm();

            txtTimKiem.Clear();

            await LoadData();
        }

        // ==========================================
        // XÓA TRẮNG CONTROL
        // ==========================================
        private void ClearForm()
        {
            txtMaTL.Clear();
            txtTenTheLoai.Clear();
            txtMoTa.Clear();

            lblNgayTaoValue.Text = "";

            txtTenTheLoai.Focus();
        }
    }
}