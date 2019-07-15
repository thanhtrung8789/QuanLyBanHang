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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        #region Events
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Account _account = AccountDAO.Instance.LayTaiKhoanTheoUser(txtUserName.Text);
                if (_account != null && _account.PassWord == txtPassWord.Text)
                {
                    FMain _fMain = new FMain(_account);
                    txtPassWord.Text = "";
                    this.Hide();
                    _fMain.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu !", "Thông báo");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo lỗi"); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            this.Close();
        }
        #endregion
    }
}
