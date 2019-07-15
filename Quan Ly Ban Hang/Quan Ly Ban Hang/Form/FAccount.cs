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
    public partial class FAccount : Form
    {
        public FAccount(object doiTuongEdit)
        {
            InitializeComponent();
            _DoiTuongEdit = doiTuongEdit;
        }

        #region Properties
        private object _DoiTuongEdit;
        #endregion

        #region Events
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thực hiện không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (txtMatKhauMoi.Text == txtNhapLai.Text)
            {
                Account _taiKhoan = (Account)_DoiTuongEdit;
                if (txtTenDangNhap.Text == _taiKhoan.UserName && txtMatKhauCu.Text == _taiKhoan.PassWord)
                {
                    AccountDAO.Instance.SuaTaiKhoan(_taiKhoan.MaNV, _taiKhoan.UserName, txtMatKhauMoi.Text, _taiKhoan.Type);
                    MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp !", "Thông báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            this.Close();
        }
        #endregion
    }
}
