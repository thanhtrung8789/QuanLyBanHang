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
    public partial class FEdit_KH_NV_NCC : Form
    {
        public FEdit_KH_NV_NCC(object doiTuongEdit)
        {
            InitializeComponent();
            _DoiTuongEdit = doiTuongEdit;
        }

        #region Properties
        private object _DoiTuongEdit;
        #endregion

        #region Events
        private void FEdit_KH_NV_NCC_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thực hiện không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                switch (this.Text)
                {
                    case "THÊM KHÁCH HÀNG":
                        ClientDAO.Instance.ThemKhachHang(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                        break;
                    case "THÊM NHÀ CUNG CẤP":
                        SupplierDAO.Instance.ThemNhaCungCap(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                        break;
                    case "THÊM NHÂN VIÊN":
                        StaffDAO.Instance.ThemNhanVien(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                        break;
                    case "SỬA THÔNG TIN KHÁCH HÀNG":
                        ClientDAO.Instance.SuaKhachHang(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                        break;
                    case "SỬA THÔNG TIN NHÀ CUNG CẤP":
                        SupplierDAO.Instance.SuaNhaCungCap(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                        break;
                    case "SỬA THÔNG TIN NHÂN VIÊN":
                        StaffDAO.Instance.SuaNhanVien(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                        break;
                    case "XÓA KHÁCH HÀNG":
                        ClientDAO.Instance.XoaKhachHang(Convert.ToInt32(txtMa.Text));
                        break;
                    case "XÓA NHÀ CUNG CẤP":
                        SupplierDAO.Instance.XoaNhaCungCap(Convert.ToInt32(txtMa.Text));
                        break;
                    case "XÓA NHÂN VIÊN":
                        StaffDAO.Instance.XoaNhanVien(Convert.ToInt32(txtMa.Text));
                        break;
                    default:
                        break;
                }
                MessageBox.Show("Thành công !", "Thông báo");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            this.Close();
        }
        #endregion

        #region Methods
        private void LoadThongTin()
        {
            switch (this.Text)
            {
                case "THÊM KHÁCH HÀNG":
                case "THÊM NHÀ CUNG CẤP":
                case "THÊM NHÂN VIÊN":
                    txtMa.Text = _DoiTuongEdit.ToString();
                    break;
                case "SỬA THÔNG TIN KHÁCH HÀNG":
                case "XÓA KHÁCH HÀNG":
                    Client _khachHang = new Client((DataRow)_DoiTuongEdit);
                    txtMa.Text = _khachHang.MaKH.ToString();
                    txtTen.Text = _khachHang.TenKH;
                    txtDiaChi.Text = _khachHang.DiaChi;
                    txtSoDienThoai.Text = _khachHang.SoDienThoai;
                    txtEmail.Text = _khachHang.Email;
                    break;
                case "SỬA THÔNG TIN NHÀ CUNG CẤP":
                case "XÓA NHÀ CUNG CẤP":
                    Supplier _nhaCungCap = new Supplier((DataRow)_DoiTuongEdit);
                    txtMa.Text = _nhaCungCap.MaNCC.ToString();
                    txtTen.Text = _nhaCungCap.TenNCC;
                    txtDiaChi.Text = _nhaCungCap.DiaChi;
                    txtSoDienThoai.Text = _nhaCungCap.SoDienThoai;
                    txtEmail.Text = _nhaCungCap.Email;
                    break;
                case "SỬA THÔNG TIN NHÂN VIÊN":
                case "XÓA NHÂN VIÊN":
                    Staff _nhanVien = new Staff((DataRow)_DoiTuongEdit);
                    txtMa.Text = _nhanVien.MaNV.ToString();
                    txtTen.Text = _nhanVien.TenNV;
                    txtDiaChi.Text = _nhanVien.DiaChi;
                    txtSoDienThoai.Text = _nhanVien.SoDienThoai;
                    txtEmail.Text = _nhanVien.Email;
                    break;
                default:
                    break;
            }
            if (this.Text.Contains("XÓA"))
            {
                grbTen.Enabled = false;
                grbDiaChi.Enabled = false;
                grbSoDienThoai.Enabled = false;
                grbEmail.Enabled = false;
            }
        }
        #endregion
    }
}
