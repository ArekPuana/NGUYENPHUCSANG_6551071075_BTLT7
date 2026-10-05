using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLichKham.Models;

namespace QuanLyLichKham
{
    public partial class FormBacSi : Form
    {
        private readonly AnKhangClinicContext _context;

        private int maBS = 0;

        public FormBacSi()
        {
            InitializeComponent();

            _context = new AnKhangClinicContext();

            Load += FormBacSi_Load;
            dgvBacSi.SelectionChanged += dgvBacSi_SelectionChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private async void FormBacSi_Load(object? sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var danhSach = await Task.Run(() =>
                    _context.BacSis
                        .OrderBy(x => x.MaBs)
                        .ToList());

                dgvBacSi.Rows.Clear();

                foreach (var bs in danhSach)
                {
                    dgvBacSi.Rows.Add(
                        bs.MaBs,
                        bs.HoTen ?? "",
                        bs.ChuyenKhoa ?? "",
                        bs.Sdt ?? ""
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvBacSi_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvBacSi.CurrentRow == null ||
                dgvBacSi.CurrentRow.IsNewRow)
                return;

            var row = dgvBacSi.CurrentRow;

            if (row.Cells["colMaBS"].Value == null)
                return;

            maBS = Convert.ToInt32(row.Cells["colMaBS"].Value);

            txtHoTen.Text = row.Cells["colHoTen"].Value?.ToString() ?? "";
            txtChuyenKhoa.Text = row.Cells["colChuyenKhoa"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["colSDT"].Value?.ToString() ?? "";
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string hoTen = txtHoTen.Text.Trim();

            try
            {
                var bacSi = new BacSi
                {
                    HoTen = hoTen,
                    ChuyenKhoa = txtChuyenKhoa.Text.Trim(),
                    Sdt = txtSDT.Text.Trim()
                };

                _context.BacSis.Add(bacSi);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm bác sĩ thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadData();
                ClearInput();
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

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (maBS == 0)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần sửa!");
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                var bacSi = await _context.BacSis
                    .FindAsync(maBS);

                if (bacSi == null)
                {
                    MessageBox.Show("Không tìm thấy bác sĩ!");
                    return;
                }

                bacSi.HoTen = txtHoTen.Text.Trim();
                bacSi.ChuyenKhoa = txtChuyenKhoa.Text.Trim();
                bacSi.Sdt = txtSDT.Text.Trim();

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật bác sĩ thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadData();
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

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (maBS == 0)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa bác sĩ này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var bacSi = await _context.BacSis
                    .FindAsync(maBS);

                if (bacSi == null)
                {
                    MessageBox.Show("Không tìm thấy bác sĩ!");
                    return;
                }

                _context.BacSis.Remove(bacSi);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa bác sĩ thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa bác sĩ.\nCó thể bác sĩ đang được sử dụng trong lịch khám.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInput();
            await LoadData();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên bác sĩ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHoTen.Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            maBS = 0;

            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtSDT.Clear();

            dgvBacSi.ClearSelection();
        }
    }
}