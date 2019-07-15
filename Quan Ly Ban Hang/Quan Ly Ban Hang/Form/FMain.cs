using Quan_Ly_Ban_Hang.DAO;
using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Ban_Hang
{
    public partial class FMain : Form
    {
        public FMain(Account account)
        {
            InitializeComponent();
            CauHinhHienThi();
            _Account = account;
            if (_Account.Type == 0)
            {
                tsmiAdmin.Visible = false;
                btnQuanLy.Visible = false;
            }
            _MaHoaDonHienTai = BillDAO.Instance.LayMaHoaDon();
            _MaPhieuNhapHienTai = ReceiptDAO.Instance.LayMaPhieuNhap();
            LoadTatCa();
        }

        #region Properties
        private Account _Account;

        private int _MaHoaDonHienTai;

        private int _MaPhieuNhapHienTai;
        #endregion

        #region Events
        //đã xong
        private void tsmiAdmin_Click(object sender, EventArgs e)
        {
            FAdmin _fAdmin = new FAdmin();
            this.Hide();
            _fAdmin.ShowDialog();
            LoadTatCa();
            this.Show();
        }

        //đã xong
        private void tsmiProfile_Click(object sender, EventArgs e)
        {
            Staff _nhanVien = StaffDAO.Instance.LayNhanVienTheoMa(_Account.MaNV);
            FProfile _fProfile = new FProfile(_Account, _nhanVien);
            _fProfile.ShowDialog();
        }

        // đã xong
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //đã xong
        private void tsmiSell_Click(object sender, EventArgs e)
        {
            int _maHoaDon = _MaHoaDonHienTai++;
            Staff _nhanVien = StaffDAO.Instance.LayNhanVienTheoMa(_Account.MaNV);
            FSell _fSell = new FSell(_maHoaDon, _nhanVien, this);
            _fSell.Show();
        }

        //đã xong
        private void tsmiBuy_Click(object sender, EventArgs e)
        {
            int _maPhieuNhap = _MaPhieuNhapHienTai++;
            Staff _nhanVien = StaffDAO.Instance.LayNhanVienTheoMa(_Account.MaNV);
            FBuy _fBuy = new FBuy(_maPhieuNhap, _nhanVien, this);
            _fBuy.Show();
        }

        //đã xong
        private void tsmiFind_Click(object sender, EventArgs e)
        {
            tbcManager.Visible = !tbcManager.Visible;
            pnlManager.Visible = !pnlManager.Visible;
            if (tbcManager.Visible == true)
            {
                tsmiFind.Text = "ĐÓNG TÌM KIẾM";
            }
            else
            {
                tsmiFind.Text = "TÌM KIẾM";
            }
        }

        //đã xong
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            FAbout _form = new FAbout();
            _form.ShowDialog();
        }

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
            LoadTatCa();
        }

        //đã xong
        private void Edit_KH_NCC_Click(object sender, EventArgs e)
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
                else if (tbcManager.SelectedTab == tpgNhaCungCap)
                {
                    int _maMoi = SupplierDAO.Instance.LayMaNhaCungCap();
                    _form = new FEdit_KH_NV_NCC(_maMoi);
                    _form.Text = "THÊM NHÀ CUNG CẤP";
                    _form.ShowDialog();
                }
            }
            LoadTatCa();
        }

        //đã xong
        private void Loc_HH_NH_KH_NCC_Click(object sender, EventArgs e)
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
        private void Loc_HD_PN_Click(object sender, EventArgs e)
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
        }

        private void btnTacVu_Click(object sender, EventArgs e)
        {
            string _buttonName = ((Button)sender).Name;
            if (_buttonName.Contains("QuanLy"))
            {
                tsmiAdmin_Click(null, null);
            }
            else if (_buttonName.Contains("NhapHang"))
            {
                tsmiBuy_Click(null, null);
            }
            else if (_buttonName.Contains("BanHang"))
            {
                tsmiSell_Click(null, null);
            }
            else if (_buttonName.Contains("ThongTinCaNhan"))
            {
                tsmiProfile_Click(null, null);
            }
            else if (_buttonName.Contains("TimKiem"))
            {
                tsmiFind_Click(null, null);
            }
            else if (_buttonName.Contains("GioiThieu"))
            {
                tsmiAbout_Click(null, null);
            }
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

        internal void LoadTatCa()
        {
            LoadDateTimePicker();
            LoadHangHoa(0, "");
            LoadNhomHang(0, "");
            LoadNhaCungCap(0, "");
            LoadKhachHang(0, "");
            LoadHoaDon("", "", "", DauThang(), CuoiThang());
            LoadPhieuNhap("", "", "", DauThang(), CuoiThang());
        }

        private void LoadDateTimePicker()
        {
            dtpTuNgayHD.Value = DauThang();
            dtpTuNgayPN.Value = DauThang();
            dtpDenNgayHD.Value = CuoiThang();
            dtpDenNgayPN.Value = CuoiThang();
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
        #endregion
    }
}
