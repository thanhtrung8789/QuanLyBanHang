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
    public partial class FEdit_HH_NH : Form
    {
        public FEdit_HH_NH(object doiTuongEdit)
        {
            InitializeComponent();
            _DoiTuongEdit = doiTuongEdit;
        }
        #region Properties
        private object _DoiTuongEdit;
        #endregion

        #region Events
        private void FEdit_HH_NH_Load(object sender, EventArgs e)
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
                    case "THÊM HÀNG HÓA":
                        GoodsDAO.Instance.ThemHangHoa(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDonViTinh.Text, Convert.ToSingle(txtGiaNhap.Text), Convert.ToSingle(txtGiaBan.Text), Convert.ToSingle(txtSoLuongTon.Text), Convert.ToInt32(cbbNhomHang.SelectedValue));
                        break;
                    case "THÊM NHÓM HÀNG":
                        CategoryDAO.Instance.ThemNhomHang(Convert.ToInt32(txtMa.Text), txtTen.Text);
                        break;
                    case "SỬA THÔNG TIN HÀNG HÓA":
                        GoodsDAO.Instance.SuaHangHoa(Convert.ToInt32(txtMa.Text), txtTen.Text, txtDonViTinh.Text, Convert.ToSingle(txtGiaNhap.Text), Convert.ToSingle(txtGiaBan.Text), Convert.ToSingle(txtSoLuongTon.Text), Convert.ToInt32(cbbNhomHang.SelectedValue));
                        break;
                    case "SỬA THÔNG TIN NHÓM HÀNG":
                        CategoryDAO.Instance.SuaNhomHang(Convert.ToInt32(txtMa.Text), txtTen.Text);
                        break;
                    case "XÓA HÀNG HÓA":
                        GoodsDAO.Instance.XoaHangHoa(Convert.ToInt32(txtMa.Text));
                        break;
                    case "XÓA NHÓM HÀNG":
                        CategoryDAO.Instance.XoaNhomHang(Convert.ToInt32(txtMa.Text));
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
                case "THÊM NHÓM HÀNG":
                case "SỬA THÔNG TIN NHÓM HÀNG":
                case "XÓA NHÓM HÀNG":
                    grbDonViTinh.Visible = false;
                    grbGiaNhap.Visible = false;
                    grbGiaBan.Visible = false;
                    grbSoLuongTon.Visible = false;
                    grbNhomHang.Visible = false;
                    break;
                default:
                    cbbNhomHang.DataSource = CategoryDAO.Instance.TimNhomHangTheoTen("");
                    cbbNhomHang.DisplayMember = "tenNH";
                    cbbNhomHang.ValueMember = "maNH";
                    break;
            }
            switch (this.Text)
            {
                case "THÊM HÀNG HÓA":
                case "THÊM NHÓM HÀNG":
                    txtMa.Text = _DoiTuongEdit.ToString();
                    break;
                case "SỬA THÔNG TIN HÀNG HÓA":
                case "XÓA HÀNG HÓA":
                    Goods _hangHoa = new Goods((DataRow)_DoiTuongEdit);
                    txtMa.Text = _hangHoa.MaHH.ToString();
                    txtTen.Text = _hangHoa.TenHH;
                    txtDonViTinh.Text = _hangHoa.DonViTinh;
                    txtGiaNhap.Text = _hangHoa.GiaNhap.ToString();
                    txtGiaBan.Text = _hangHoa.GiaBan.ToString();
                    txtSoLuongTon.Text = _hangHoa.SoLuongTon.ToString();
                    cbbNhomHang.SelectedValue = _hangHoa.MaNH;
                    break;
                case "SỬA THÔNG TIN NHÓM HÀNG":
                case "XÓA NHÓM HÀNG":
                    Category _nhomHang = new Category((DataRow)_DoiTuongEdit);
                    txtMa.Text = _nhomHang.MaNH.ToString();
                    txtTen.Text = _nhomHang.TenNH;
                    break;
                default:
                    break;
            }
            if (this.Text.Contains("XÓA"))
            {
                grbTen.Enabled = false;
                grbDonViTinh.Enabled = false;
                grbGiaNhap.Enabled = false;
                grbGiaBan.Enabled = false;
                grbSoLuongTon.Enabled = false;
                grbNhomHang.Enabled = false;
            }
        }
        #endregion
    }
}
