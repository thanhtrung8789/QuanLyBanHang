using Quan_Ly_Ban_Hang.DAO;
using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Ban_Hang
{
    public partial class FAdmin : Form
    {
        public FAdmin()
        {
            InitializeComponent();
            CauHinhHienThi();
            LoadTatCa();
        }

        #region Events
        //đã xong
        private void Edit_HH_NH_Click(object sender, EventArgs e)
        {
            FEdit_HH_NH _form;
            string _buttonName = ((Button)sender).Name.Substring(3, 3);
            if (_buttonName == "The")
            {
                if (tbcManager.SelectedTab == tpgHangHoa)
                {
                    int _maMoi = GoodsDAO.Instance.LayMaHangHoa();
                    _form = new FEdit_HH_NH(_maMoi);
                    _form.Text = "THÊM HÀNG HÓA";
                    _form.ShowDialog();
                }
                else if (tbcManager.SelectedTab == tpgNhomHang)
                {
                    int _maMoi = CategoryDAO.Instance.LayMaNhomHang();
                    _form = new FEdit_HH_NH(_maMoi);
                    _form.Text = "THÊM NHÓM HÀNG";
                    _form.ShowDialog();
                }
            }
            else if (tbcManager.SelectedTab == tpgHangHoa)
            {
                if (dgvHangHoa.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                    return;
                }
                DataGridViewRow _dgvRow = dgvHangHoa.CurrentRow;
                DataRow _tableRow = ((DataRowView)_dgvRow.DataBoundItem).Row;
                if (_buttonName == "Sua")
                {
                    _form = new FEdit_HH_NH(_tableRow);
                    _form.Text = "SỬA THÔNG TIN HÀNG HÓA";
                    _form.ShowDialog();
                }
                else if (_buttonName == "Xoa")
                {
                    _form = new FEdit_HH_NH(_tableRow);
                    _form.Text = "XÓA HÀNG HÓA";
                    _form.ShowDialog();
                }
            }
            else if (tbcManager.SelectedTab == tpgNhomHang)
            {
                if (dgvNhomHang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                    return;
                }
                DataGridViewRow _dgvRow = dgvNhomHang.CurrentRow;
                DataRow _tableRow = ((DataRowView)_dgvRow.DataBoundItem).Row;
                if (_buttonName == "Sua")
                {
                    _form = new FEdit_HH_NH(_tableRow);
                    _form.Text = "SỬA THÔNG TIN NHÓM HÀNG";
                    _form.ShowDialog();
                }
                else if (_buttonName == "Xoa")
                {
                    _form = new FEdit_HH_NH(_tableRow);
                    _form.Text = "XÓA NHÓM HÀNG";
                    _form.ShowDialog();
                }
            }
            LoadTatCa();
        }

        //đã xong
        private void Edit_KH_NV_NCC_Click(object sender, EventArgs e)
        {
            FEdit_KH_NV_NCC _form;
            string _buttonName = ((Button)sender).Name.Substring(3, 3);
            if (_buttonName == "The")
            {
                if (tbcManager.SelectedTab == tpgKhachHang)
                {
                    int _maMoi = ClientDAO.Instance.LayMaKhachHang();
                    _form = new FEdit_KH_NV_NCC(_maMoi);
                    _form.Text = "THÊM KHÁCH HÀNG";
                    _form.ShowDialog();
                }
                else if (tbcManager.SelectedTab == tpgNhanVien)
                {
                    int _maMoi = StaffDAO.Instance.LayMaNhanVien();
                    _form = new FEdit_KH_NV_NCC(_maMoi);
                    _form.Text = "THÊM NHÂN VIÊN";
                    _form.ShowDialog();
                }
                else if (tbcManager.SelectedTab == tpgNhaCungCap)
                {
                    int _maMoi = SupplierDAO.Instance.LayMaNhaCungCap();
                    _form = new FEdit_KH_NV_NCC(_maMoi);
                    _form.Text = "THÊM NHÀ CUNG CẤP";
                    _form.ShowDialog();
                }
            }
            else if (tbcManager.SelectedTab == tpgKhachHang)
            {
                if (dgvKhachHang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                    return;
                }
                DataGridViewRow _dgvRow = dgvKhachHang.CurrentRow;
                DataRow _tableRow = ((DataRowView)_dgvRow.DataBoundItem).Row;
                if (_buttonName == "Sua")
                {
                    _form = new FEdit_KH_NV_NCC(_tableRow);
                    _form.Text = "SỬA THÔNG TIN KHÁCH HÀNG";
                    _form.ShowDialog();
                }
                else if (_buttonName == "Xoa")
                {
                    _form = new FEdit_KH_NV_NCC(_tableRow);
                    _form.Text = "XÓA KHÁCH HÀNG";
                    _form.ShowDialog();
                }
            }
            else if (tbcManager.SelectedTab == tpgNhanVien)
            {
                if (dgvNhanVien.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                    return;
                }
                DataGridViewRow _dgvRow = dgvNhanVien.CurrentRow;
                DataRow _tableRow = ((DataRowView)_dgvRow.DataBoundItem).Row;
                if (_buttonName == "Sua")
                {
                    _form = new FEdit_KH_NV_NCC(_tableRow);
                    _form.Text = "SỬA THÔNG TIN NHÂN VIÊN";
                    _form.ShowDialog();
                }
                else if (_buttonName == "Xoa")
                {
                    _form = new FEdit_KH_NV_NCC(_tableRow);
                    _form.Text = "XÓA NHÂN VIÊN";
                    _form.ShowDialog();
                }
            }
            else if (tbcManager.SelectedTab == tpgNhaCungCap)
            {
                if (dgvNhaCungCap.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                    return;
                }
                DataGridViewRow _dgvRow = dgvNhaCungCap.CurrentRow;
                DataRow _tableRow = ((DataRowView)_dgvRow.DataBoundItem).Row;
                if (_buttonName == "Sua")
                {
                    _form = new FEdit_KH_NV_NCC(_tableRow);
                    _form.Text = "SỬA THÔNG TIN NHÀ CUNG CẤP";
                    _form.ShowDialog();
                }
                else if (_buttonName == "Xoa")
                {
                    _form = new FEdit_KH_NV_NCC(_tableRow);
                    _form.Text = "XÓA NHÀ CUNG CẤP";
                    _form.ShowDialog();
                }
            }
            LoadTatCa();
        }

        //đã xong
        private void Edit_TK_Click(object sender, EventArgs e)
        {
            FEdit_TK _form;
            string _buttonName = ((Button)sender).Name.Substring(3, 3);
            if (_buttonName == "The")
            {
                _form = new FEdit_TK(null);
                _form.Text = "THÊM TÀI KHOẢN";
                _form.ShowDialog();
            }
            else
            {
                if (dgvTaiKhoan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                    return;
                }
                DataGridViewRow _dgvRow = dgvTaiKhoan.CurrentRow;
                DataRow _tableRow = ((DataRowView)_dgvRow.DataBoundItem).Row;
                if (_buttonName == "Sua")
                {
                    _form = new FEdit_TK(_tableRow);
                    _form.Text = "SỬA THÔNG TIN TÀI KHOẢN";
                    _form.ShowDialog();
                }
                else if (_buttonName == "Xoa")
                {
                    _form = new FEdit_TK(_tableRow);
                    _form.Text = "XÓA TÀI KHOẢN";
                    _form.ShowDialog();
                }
            }
            LoadTatCa();
        }

        //đã xong
        private void Xoa_HD_PN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thực hiện không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                if (tbcManager.SelectedTab == tpgHoaDon)
                {
                    if (dgvHoaDon.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                        return;
                    }
                    DataGridViewRow _dgvRow = dgvHoaDon.CurrentRow;
                    int _maHD = Convert.ToInt32(_dgvRow.Cells["maHD_HD"].Value);
                    BillDAO.Instance.XoaHoaDon(_maHD);
                }
                else if (tbcManager.SelectedTab == tpgPhieuNhap)
                {
                    if (dgvPhieuNhap.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Chọn vào đầu dòng để thực hiện !", "Thông báo");
                        return;
                    }
                    DataGridViewRow _dgvRow = dgvPhieuNhap.CurrentRow;
                    int _maPN = Convert.ToInt32(_dgvRow.Cells["maPN_PN"].Value);
                    ReceiptDAO.Instance.XoaPhieuNhap(_maPN);
                }
                MessageBox.Show("Thành công !", "Thông báo");
                LoadTatCa();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
        }

        //đã xong
        private void Loc_HH_NH_NV_KH_NCC_Click(object sender, EventArgs e)
        {
            if (tbcManager.SelectedTab == tpgHangHoa)
            {
                try
                {
                    if (txtMaHH.Text == null || txtMaHH.Text == "")
                        LoadHangHoa(0, txtTenHH.Text);
                    else
                        LoadHangHoa(Convert.ToInt32(txtMaHH.Text));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
            }
            else if (tbcManager.SelectedTab == tpgNhomHang)
            {
                try
                {
                    if (txtMaNH.Text == null || txtMaNH.Text == "")
                        LoadNhomHang(0, txtTenNH.Text);
                    else
                        LoadNhomHang(Convert.ToInt32(txtMaNH.Text));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
            }
            else if (tbcManager.SelectedTab == tpgNhanVien)
            {
                try
                {
                    if (txtMaNV.Text == null || txtMaNV.Text == "")
                        LoadNhanVien(0, txtTenNV.Text);
                    else
                        LoadNhanVien(Convert.ToInt32(txtMaNV.Text));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
            }
            else if (tbcManager.SelectedTab == tpgKhachHang)
            {
                try
                {
                    if (txtMaKH.Text == null || txtMaKH.Text == "")
                        LoadKhachHang(0, txtTenKH.Text);
                    else
                        LoadKhachHang(Convert.ToInt32(txtMaKH.Text));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
            }
            else if (tbcManager.SelectedTab == tpgNhaCungCap)
            {
                try
                {
                    if (txtMaNCC.Text == null || txtMaNCC.Text == "")
                        LoadNhaCungCap(0, txtTenNCC.Text);
                    else
                        LoadNhaCungCap(Convert.ToInt32(txtMaNCC.Text));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
            }
        }

        //đã xong
        private void Loc_TK_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTaiKhoan(txtTenTK.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
        }

        //đã xong
        private void Loc_HD_PN_CTHD_CTPN_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbcManager.SelectedTab == tpgHoaDon)
                {
                    LoadHoaDon(txtMaHD.Text, txtTenKhachHangHD.Text, txtTenNhanVienHD.Text, dtpTuNgayHD.Value, dtpDenNgayHD.Value);
                }
                else if (tbcManager.SelectedTab == tpgPhieuNhap)
                {
                    LoadPhieuNhap(txtMaPN.Text, txtTenNhaCungCapPN.Text, txtTenNhanVienPN.Text, dtpTuNgayPN.Value, dtpDenNgayPN.Value);
                }
                else if (tbcManager.SelectedTab == tpgBaoCaoChiTietBanHang)
                {
                    LoadCTHoaDon(txtMaCTHD.Text, txtTenKhachHangCTHD.Text, txtTenNhanVienCTHD.Text, dtpTuNgayCTHD.Value, dtpDenNgayCTHD.Value);
                }
                else if (tbcManager.SelectedTab == tpgBaoCaoChiTietMuaHang)
                {
                    LoadCTPhieuNhap(txtMaCTPN.Text, txtTenNhaCungCapCTPN.Text, txtTenNhanVienCTPN.Text, dtpTuNgayCTPN.Value, dtpDenNgayCTPN.Value);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
        }

        //đã xong
        private void btnXemBCTH_Click(object sender, EventArgs e)
        {
            switch (cbbLoaiBaoCaoBCTH.SelectedValue)
            {
                case "1":
                    dgvBaoCaoTongHop.DataSource = ReportDAO.Instance.BaoCaoDoanhThuTheoNhanVien(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value);
                    txtTongTienBCTH.Text = ReportDAO.Instance.TongDoanhThu(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value).ToString();
                    break;
                case "2":
                    dgvBaoCaoTongHop.DataSource = ReportDAO.Instance.BaoCaoDoanhThuTheoKhachHang(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value);
                    txtTongTienBCTH.Text = ReportDAO.Instance.TongDoanhThu(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value).ToString();
                    break;
                case "3":
                    dgvBaoCaoTongHop.DataSource = ReportDAO.Instance.BaoCaoDoanhThuTheoHangHoa(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value);
                    txtTongTienBCTH.Text = ReportDAO.Instance.TongDoanhThu(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value).ToString();
                    break;
                case "4":
                    dgvBaoCaoTongHop.DataSource = ReportDAO.Instance.BaoCaoDoanhThuTheoNhomHang(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value);
                    txtTongTienBCTH.Text = ReportDAO.Instance.TongDoanhThu(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value).ToString();
                    break;
                case "5":
                    dgvBaoCaoTongHop.DataSource = ReportDAO.Instance.BaoCaoLoiNhuanTheoHangHoa(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value);
                    txtTongTienBCTH.Text = ReportDAO.Instance.TongLoiNhuan(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value).ToString();
                    break;
                case "6":
                    dgvBaoCaoTongHop.DataSource = ReportDAO.Instance.BaoCaoLoiNhuanTheoNhomHang(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value);
                    txtTongTienBCTH.Text = ReportDAO.Instance.TongLoiNhuan(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value).ToString();
                    break;
                case "7":
                    dgvBaoCaoTongHop.DataSource = ReportDAO.Instance.BaoCaoChiPhiTheoNhaCungCap(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value);
                    txtTongTienBCTH.Text = ReportDAO.Instance.TongChiPhi(dtpTuNgayBCTH.Value, dtpDenNgayBCTH.Value).ToString();
                    break;
                default:
                    break;
            }
            Single value;
            if (Single.TryParse(txtTongTienBCTH.Text, out value))
                txtTongTienBCTH.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C0}", value);
            else
                txtTongTienBCTH.Text = String.Empty;

        }
        #endregion

        #region Methods
        private void CauHinhHienThi()
        {
            dgvHangHoa.Columns["giaNhap_HH"].DefaultCellStyle.Format = "c0";
            dgvHangHoa.Columns["giaNhap_HH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHangHoa.Columns["giaBan_HH"].DefaultCellStyle.Format = "c0";
            dgvHangHoa.Columns["giaBan_HH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHangHoa.Columns["soLuongTon_HH"].DefaultCellStyle.Format = "n2";
            dgvHangHoa.Columns["soLuongTon_HH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHoaDon.Columns["thanhTien_HD"].DefaultCellStyle.Format = "c0";
            dgvHoaDon.Columns["thanhTien_HD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPhieuNhap.Columns["thanhTien_PN"].DefaultCellStyle.Format = "c0";
            dgvPhieuNhap.Columns["thanhTien_PN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCTHD.Columns["giaBan_CTHD"].DefaultCellStyle.Format = "c0";
            dgvCTHD.Columns["giaBan_CTHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTHD.Columns["thanhTien_CTHD"].DefaultCellStyle.Format = "c0";
            dgvCTHD.Columns["thanhTien_CTHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTHD.Columns["soLuong_CTHD"].DefaultCellStyle.Format = "n2";
            dgvCTHD.Columns["soLuong_CTHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCTPN.Columns["giaNhap_CTPN"].DefaultCellStyle.Format = "c0";
            dgvCTPN.Columns["giaNhap_CTPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTPN.Columns["thanhTien_CTPN"].DefaultCellStyle.Format = "c0";
            dgvCTPN.Columns["thanhTien_CTPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTPN.Columns["soLuong_CTPN"].DefaultCellStyle.Format = "n2";
            dgvCTPN.Columns["soLuong_CTPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBaoCaoTongHop.Columns["tongTien_BCTH"].DefaultCellStyle.Format = "c0";
            dgvBaoCaoTongHop.Columns["tongTien_BCTH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private DateTime DauThang()
        {
            DateTime _today = DateTime.Today;
            return new DateTime(_today.Year, _today.Month, 1);
        }

        private DateTime CuoiThang()
        {
            return DauThang().AddMonths(1).AddDays(-1);
        }

        private void LoadTatCa()
        {
            LoadDateTimePicker();
            LoadHangHoa(0, "");
            LoadNhomHang(0, "");
            LoadNhanVien(0, "");
            LoadNhaCungCap(0, "");
            LoadKhachHang(0, "");
            LoadTaiKhoan("");
            LoadHoaDon("", "", "", DauThang(), CuoiThang());
            LoadPhieuNhap("", "", "", DauThang(), CuoiThang());
            LoadCTHoaDon("", "", "", DauThang(), CuoiThang());
            LoadCTPhieuNhap("", "", "", DauThang(), CuoiThang());
            LoadLoaiBaoCao();
        }

        private void LoadDateTimePicker()
        {
            dtpTuNgayCTHD.Value = DauThang();
            dtpTuNgayCTPN.Value = DauThang();
            dtpTuNgayHD.Value = DauThang();
            dtpTuNgayPN.Value = DauThang();
            dtpTuNgayBCTH.Value = DauThang();
            dtpDenNgayCTHD.Value = CuoiThang();
            dtpDenNgayCTPN.Value = CuoiThang();
            dtpDenNgayHD.Value = CuoiThang();
            dtpDenNgayPN.Value = CuoiThang();
            dtpDenNgayBCTH.Value = CuoiThang();
        }

        private void LoadHangHoa(int maHH, string tenHH = null)
        {
            if (tenHH == null)
                dgvHangHoa.DataSource = GoodsDAO.Instance.TimHangHoaTheoMa(maHH);
            else
                dgvHangHoa.DataSource = GoodsDAO.Instance.TimHangHoaTheoTen(tenHH);
        }

        private void LoadNhomHang(int maNH, string tenNH = null)
        {
            if (tenNH == null)
                dgvNhomHang.DataSource = CategoryDAO.Instance.TimNhomHangTheoMa(maNH);
            else
                dgvNhomHang.DataSource = CategoryDAO.Instance.TimNhomHangTheoTen(tenNH);
        }

        private void LoadNhanVien(int maNV, string tenNV = null)
        {
            if (tenNV == null)
                dgvNhanVien.DataSource = StaffDAO.Instance.TimNhanVienTheoMa(maNV);
            else
                dgvNhanVien.DataSource = StaffDAO.Instance.TimNhanVienTheoTen(tenNV);
        }

        private void LoadKhachHang(int maKH, string tenKH = null)
        {
            if (tenKH == null)
                dgvKhachHang.DataSource = ClientDAO.Instance.TimKhachHangTheoMa(maKH);
            else
                dgvKhachHang.DataSource = ClientDAO.Instance.TimKhachHangTheoTen(tenKH);
        }

        private void LoadNhaCungCap(int maNCC, string tenNCC = null)
        {
            if (tenNCC == null)
                dgvNhaCungCap.DataSource = SupplierDAO.Instance.TimNhaCungCapTheoMa(maNCC);
            else
                dgvNhaCungCap.DataSource = SupplierDAO.Instance.TimNhaCungCapTheoTen(tenNCC);
        }

        private void LoadTaiKhoan(string userName)
        {
            dgvTaiKhoan.DataSource = AccountDAO.Instance.TimTaiKhoan(userName);
        }

        private void LoadHoaDon(string maHD, string tenKH, string tenNV, DateTime tuNgay, DateTime denNgay)
        {
            if (maHD != "")
            {
                dgvHoaDon.DataSource = BillDAO.Instance.TimHoaDonTheoMa(Convert.ToInt32(maHD));
            }
            else
            {
                dgvHoaDon.DataSource = BillDAO.Instance.TimHoaDonMix(tenNV, tenKH, tuNgay, denNgay);
            }
        }

        private void LoadPhieuNhap(string maPN, string tenNCC, string tenNV, DateTime tuNgay, DateTime denNgay)
        {
            if (maPN != "")
            {
                dgvPhieuNhap.DataSource = ReceiptDAO.Instance.TimPhieuNhapTheoMa(Convert.ToInt32(maPN));
            }
            else
            {
                dgvPhieuNhap.DataSource = ReceiptDAO.Instance.TimPhieuNhapMix(tenNV, tenNCC, tuNgay, denNgay);
            }
        }

        private void LoadCTHoaDon(string maHD, string tenKH, string tenNV, DateTime tuNgay, DateTime denNgay)
        {
            if (maHD != "")
            {
                dgvCTHD.DataSource = BillInfoDAO.Instance.TimCTHoaDonTheoMa(Convert.ToInt32(maHD));
            }
            else
            {
                dgvCTHD.DataSource = BillInfoDAO.Instance.TimCTHoaDonMix(tenNV, tenKH, tuNgay, denNgay);
            }
        }

        private void LoadCTPhieuNhap(string maPN, string tenNCC, string tenNV, DateTime tuNgay, DateTime denNgay)
        {
            if (maPN != "")
            {
                dgvCTPN.DataSource = ReceiptInfoDAO.Instance.TimCTPhieuNhapTheoMa(Convert.ToInt32(maPN));
            }
            else
            {
                dgvCTPN.DataSource = ReceiptInfoDAO.Instance.TimCTPhieuNhapMix(tenNV, tenNCC, tuNgay, denNgay);
            }
        }

        private void LoadLoaiBaoCao()
        {
            DataTable _table = new DataTable();
            _table.Columns.Add("maLoai");
            _table.Columns.Add("tenLoai");

            DataRow _one = _table.NewRow();
            _one["maLoai"] = 1; _one["tenLoai"] = "Doanh thu theo nhân viên";
            DataRow _two = _table.NewRow();
            _two["maLoai"] = 2; _two["tenLoai"] = "Doanh thu theo khách hàng";
            DataRow _three = _table.NewRow();
            _three["maLoai"] = 3; _three["tenLoai"] = "Doanh thu theo hàng hóa";
            DataRow _four = _table.NewRow();
            _four["maLoai"] = 4; _four["tenLoai"] = "Doanh thu theo nhóm hàng";
            DataRow _five = _table.NewRow();
            _five["maLoai"] = 5; _five["tenLoai"] = "Lợi nhuận theo hàng hóa";
            DataRow _six = _table.NewRow();
            _six["maLoai"] = 6; _six["tenLoai"] = "Lợi nhuận theo nhóm hàng";
            DataRow _seven = _table.NewRow();
            _seven["maLoai"] = 7; _seven["tenLoai"] = "Chi nhập theo nhà cung cấp";

            _table.Rows.Add(_one);
            _table.Rows.Add(_two);
            _table.Rows.Add(_three);
            _table.Rows.Add(_four);
            _table.Rows.Add(_five);
            _table.Rows.Add(_six);
            _table.Rows.Add(_seven);

            cbbLoaiBaoCaoBCTH.DataSource = _table;
            cbbLoaiBaoCaoBCTH.DisplayMember = "tenLoai";
            cbbLoaiBaoCaoBCTH.ValueMember = "maLoai";
        }
        #endregion
    }
}
