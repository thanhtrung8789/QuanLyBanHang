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
    public partial class FEdit_TK : Form
    {
        public FEdit_TK(object doiTuongEdit)
        {
            InitializeComponent();
            _DoiTuongEdit = doiTuongEdit;
            _LoaiTaiKhoan = TaoBangLoaiTaiKhoan();
        }

        #region Properties
        private object _DoiTuongEdit;

        private DataTable _LoaiTaiKhoan;
        #endregion

        #region Events
        private void FEdit_TK_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                AccountDAO.Instance.SuaTaiKhoan(Convert.ToInt32(cbbNhanVien.SelectedValue), txtTenDangNhap.Text, "1", Convert.ToInt32(cbbLoaiTaiKhoan.SelectedValue));
                MessageBox.Show("Thành công !", "Thông báo");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thực hiện không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                switch (this.Text)
                {
                    case "THÊM TÀI KHOẢN":
                        if (AccountDAO.Instance.LayTaiKhoanTheoUser(txtTenDangNhap.Text) != null)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại !", "Thông báo");
                            return;
                        }
                        if (txtMatKhau.Text == txtNhapLai.Text)
                        {
                            AccountDAO.Instance.ThemTaiKhoan(Convert.ToInt32(cbbNhanVien.SelectedValue), txtTenDangNhap.Text, txtMatKhau.Text, Convert.ToInt32(cbbLoaiTaiKhoan.SelectedValue));
                            MessageBox.Show("Thành công !", "Thông báo");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu nhập lại không trùng khớp !", "Thông báo");
                        }
                        break;
                    case "SỬA THÔNG TIN TÀI KHOẢN":
                        AccountDAO.Instance.SuaTaiKhoan(Convert.ToInt32(cbbNhanVien.SelectedValue), txtTenDangNhap.Text, txtMatKhau.Text, Convert.ToInt32(cbbLoaiTaiKhoan.SelectedValue));
                        MessageBox.Show("Thành công !", "Thông báo");
                        this.Close();
                        break;
                    case "XÓA TÀI KHOẢN":
                        AccountDAO.Instance.XoaTaiKhoan(Convert.ToInt32(cbbNhanVien.SelectedValue));
                        MessageBox.Show("Thành công !", "Thông báo");
                        this.Close();
                        break;
                    default:
                        break;
                }
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
            cbbNhanVien.DataSource = StaffDAO.Instance.TimNhanVienTheoTen("");
            cbbNhanVien.DisplayMember = "tenNV";
            cbbNhanVien.ValueMember = "maNV";
            cbbLoaiTaiKhoan.DataSource = _LoaiTaiKhoan;
            cbbLoaiTaiKhoan.DisplayMember = "ten";
            cbbLoaiTaiKhoan.ValueMember = "ma";
            switch (this.Text)
            {
                case "THÊM TÀI KHOẢN":
                    cbbNhanVien.DataSource = StaffDAO.Instance.TimNhanVienNoAccount();
                    cbbNhanVien.DisplayMember = "tenNV";
                    cbbNhanVien.ValueMember = "maNV";
                    btnReset.Visible = false;
                    break;
                case "SỬA THÔNG TIN TÀI KHOẢN":
                    grbMatKhau.Visible = false;
                    grbNhapLai.Visible = false;
                    txtTenDangNhap.ReadOnly = true;
                    cbbNhanVien.Enabled = false;
                    Account _taiKhoanSua = new Account((DataRow)_DoiTuongEdit);
                    cbbNhanVien.SelectedValue = _taiKhoanSua.MaNV;
                    txtTenDangNhap.Text = _taiKhoanSua.UserName;
                    txtMatKhau.Text = _taiKhoanSua.PassWord;
                    cbbLoaiTaiKhoan.SelectedValue = _taiKhoanSua.Type;
                    break;
                case "XÓA TÀI KHOẢN":
                    btnReset.Visible = false;
                    grbMatKhau.Visible = false;
                    grbNhapLai.Visible = false;
                    grbTenDangNhap.Enabled = false;
                    grbLoaiTaiKhoan.Enabled = false;
                    cbbNhanVien.Enabled = false;
                    Account _taiKhoanXoa = new Account((DataRow)_DoiTuongEdit);
                    cbbNhanVien.SelectedValue = _taiKhoanXoa.MaNV;
                    txtTenDangNhap.Text = _taiKhoanXoa.UserName;
                    txtMatKhau.Text = _taiKhoanXoa.PassWord;
                    cbbLoaiTaiKhoan.SelectedValue = _taiKhoanXoa.Type;
                    break;
                default:
                    break;
            }
        }

        private DataTable TaoBangLoaiTaiKhoan()
        {
            DataTable _result = new DataTable();
            _result.Columns.Add("ma");
            _result.Columns.Add("ten");
            DataRow _rowNV = _result.NewRow();
            DataRow _rowAD = _result.NewRow();
            _rowNV["ma"] = 0;
            _rowNV["ten"] = "Nhân viên";
            _result.Rows.Add(_rowNV);
            _rowAD["ma"] = 1;
            _rowAD["ten"] = "Admin";
            _result.Rows.Add(_rowAD);
            return _result;
        }
        #endregion
    }
}
