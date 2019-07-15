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
using System.Globalization;
using System.Windows.Forms;

namespace Quan_Ly_Ban_Hang
{
    public partial class FSell : Form
    {
        public FSell(int maHoaDon, Staff nhanVien, FMain mainForm)
        {
            InitializeComponent();
            CauHinhHienThi();
            _MaHoaDon = maHoaDon;
            _NhanVien = nhanVien;
            _CTHoaDon = TaoBangCTHD();
            _MainForm = mainForm;
            LoadTatCa();
        }

        #region Properties
        private int _MaHoaDon;

        private Staff _NhanVien;

        private DataTable _CTHoaDon;

        private FMain _MainForm;
        #endregion

        #region Events
        private void cbb_KH_HH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string _cbbName = ((ComboBox)sender).Name;
                if (_cbbName.Contains("HangHoa"))
                {
                    DataTable _table = GoodsDAO.Instance.TimHangHoaTheoTen(cbbHangHoa.Text);
                    if (_table.Rows.Count == 1)
                    {
                        Goods _hangHoa = new Goods(_table.Rows[0]);
                        cbbHangHoa.SelectedValue = _hangHoa.MaHH;
                        this.ActiveControl = txtSoLuong;
                    }
                    else
                    {
                        FFind _fFind = new FFind(cbbHangHoa.Text, this, null);
                        _fFind.Text = "TÌM HÀNG HÓA";
                        _fFind.ShowDialog();
                    }
                }
                else if (_cbbName.Contains("KhachHang"))
                {
                    DataTable _table = ClientDAO.Instance.TimKhachHangTheoTen(cbbKhachHang.Text);
                    if (_table.Rows.Count == 1)
                    {
                        Client _khachHang = new Client(_table.Rows[0]);
                        cbbKhachHang.SelectedValue = _khachHang.MaKH;
                    }
                    else
                    {
                        FFind _fFind = new FFind(cbbKhachHang.Text, this, null);
                        _fFind.Text = "TÌM KHÁCH HÀNG";
                        _fFind.ShowDialog();
                    }
                }
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnThem_Click(null, null);
                this.ActiveControl = cbbHangHoa;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbHangHoa.SelectedValue != null)
            {
                int _maHH = Convert.ToInt32(cbbHangHoa.SelectedValue);
                if (!_CTHoaDon.Rows.Contains(_maHH))
                {
                    Goods _hangHoa = GoodsDAO.Instance.LayHangHoaTheoMa(_maHH);
                    DataRow _row = _CTHoaDon.NewRow();
                    _row["maHH"] = _hangHoa.MaHH;
                    _row["tenHH"] = _hangHoa.TenHH;
                    _row["donViTinh"] = _hangHoa.DonViTinh;
                    _row["giaBan"] = _hangHoa.GiaBan;
                    _row["soLuong"] = Convert.ToSingle(txtSoLuong.Text);
                    _row["thanhTien"] = Convert.ToSingle(_row["soLuong"]) * Convert.ToSingle(_row["giaBan"]);
                    _CTHoaDon.Rows.Add(_row);
                    LoadCTHD();
                }
                else
                {
                    DataRow _row = _CTHoaDon.Rows.Find(_maHH);
                    _row["soLuong"] = Convert.ToSingle(txtSoLuong.Text) + Convert.ToSingle(_row["soLuong"]);
                    _row["thanhTien"] = Convert.ToSingle(_row["soLuong"]) * Convert.ToSingle(_row["giaBan"]);
                    LoadCTHD();
                }
            }
        }

        private void dgvThongTinCTHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThongTinCTHD.CurrentRow != null)
            {
                if (dgvThongTinCTHD.CurrentCellAddress.X == dgvThongTinCTHD.Columns.IndexOf(dgvThongTinCTHD.Columns["soLuong"]) ||
                    dgvThongTinCTHD.CurrentCellAddress.X == dgvThongTinCTHD.Columns.IndexOf(dgvThongTinCTHD.Columns["giaBan"]))
                {
                    DataGridViewRow _row = dgvThongTinCTHD.CurrentRow;
                    _row.Cells["thanhTien"].Value = (Convert.ToSingle(_row.Cells["soLuong"].Value) * Convert.ToSingle(_row.Cells["giaBan"].Value)).ToString();
                }

            }
            Single _tongTien = 0;
            foreach (DataGridViewRow _row in dgvThongTinCTHD.Rows)
            {
                _tongTien += Convert.ToSingle(_row.Cells["thanhTien"].Value);
            }
            txtTongTien.Text = _tongTien.ToString();
        }

        private void dgvThongTinCTHD_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LoadCTHD();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thực hiện không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (cbbKhachHang.SelectedValue != null)
            {
                BillDAO.Instance.ThemHoaDon(_MaHoaDon, Convert.ToInt32(cbbKhachHang.SelectedValue), Convert.ToInt32(cbbNhanVien.SelectedValue), dtpNgayBan.Value);
                foreach (DataRow _row in _CTHoaDon.Rows)
                {
                    BillInfoDAO.Instance.ThemCTHoaDon(_MaHoaDon, Convert.ToInt32(_row["maHH"]), Convert.ToSingle(_row["soLuong"]), Convert.ToSingle(_row["giaBan"]));
                }
                _MainForm.LoadTatCa();
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa chọn khách hàng !", "Thông báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            this.Close();
        }
        #endregion

        #region Methods
        private void CauHinhHienThi()
        {
            dgvThongTinCTHD.Columns["soLuong"].DefaultCellStyle.Format = "n2";
            dgvThongTinCTHD.Columns["soLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongTinCTHD.Columns["giaBan"].DefaultCellStyle.Format = "n0";
            dgvThongTinCTHD.Columns["giaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongTinCTHD.Columns["thanhTien"].DefaultCellStyle.Format = "n0";
            dgvThongTinCTHD.Columns["thanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Single value;
            if (Single.TryParse(txtTongTien.Text, out value))
                txtTongTien.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C0}", value);
            else
                txtTongTien.Text = String.Empty;
        }

        private void LoadTatCa()
        {
            LoadThongTinHD();
            LoadHangHoa();
        }

        private void LoadHangHoa()
        {
            cbbHangHoa.DataSource = GoodsDAO.Instance.TimHangHoaTheoTen("");
            cbbHangHoa.DisplayMember = "tenHH";
            cbbHangHoa.ValueMember = "maHH";
        }

        private void LoadCTHD()
        {
            dgvThongTinCTHD.DataSource = _CTHoaDon;
            Single _tongTien = 0;
            foreach (DataGridViewRow _row in dgvThongTinCTHD.Rows)
            {
                _tongTien += Convert.ToSingle(_row.Cells["thanhTien"].Value);
            }
            txtTongTien.Text = _tongTien.ToString();
            CauHinhHienThi();
        }

        private void LoadThongTinHD()
        {
            txtMaHoaDon.Text = _MaHoaDon.ToString();
            cbbKhachHang.DataSource = ClientDAO.Instance.TimKhachHangTheoTen("");
            cbbKhachHang.DisplayMember = "tenKH";
            cbbKhachHang.ValueMember = "maKH";
            cbbNhanVien.DataSource = StaffDAO.Instance.TimNhanVienTheoTen("");
            cbbNhanVien.DisplayMember = "tenNV";
            cbbNhanVien.ValueMember = "maNV";
            cbbNhanVien.SelectedValue = _NhanVien.MaNV;
            dtpNgayBan.Value = DateTime.Today;
        }

        private DataTable TaoBangCTHD()
        {
            DataTable _table = new DataTable();
            _table.Columns.Add("maHH");
            _table.Columns.Add("tenHH");
            _table.Columns.Add("donViTinh");
            _table.Columns.Add("soLuong");
            _table.Columns.Add("giaBan");
            _table.Columns.Add("thanhTien");
            _table.PrimaryKey = new DataColumn[] { _table.Columns["maHH"] };
            return _table;
        }

        internal void UpdateCbbHangHoa(int maHH)
        {
            cbbHangHoa.SelectedValue = maHH;
        }

        internal void UpdateCbbKhachHang(int maKH)
        {
            cbbKhachHang.SelectedValue = maKH;
        }
        #endregion
    }
}
