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
    public partial class FProfile : Form
    {
        public FProfile(Account taiKhoan, Staff nhanVien)
        {
            InitializeComponent();
            _TaiKhoan = taiKhoan;
            _NhanVien = nhanVien;
            LoadThongTin();
        }
        #region Properties
        private Account _TaiKhoan;

        private Staff _NhanVien;
        #endregion

        #region Events
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            FAccount _fAccount = new FAccount(_TaiKhoan);
            _fAccount.ShowDialog();
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thực hiện không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                StaffDAO.Instance.SuaNhanVien(Convert.ToInt32(txtMaNhanVien.Text), txtHovaTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
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
            txtMaNhanVien.Text = _NhanVien.MaNV.ToString();
            txtHovaTen.Text = _NhanVien.TenNV;
            txtDiaChi.Text = _NhanVien.DiaChi;
            txtSoDienThoai.Text = _NhanVien.SoDienThoai;
            txtEmail.Text = _NhanVien.Email;
        }
        #endregion
    }
}
