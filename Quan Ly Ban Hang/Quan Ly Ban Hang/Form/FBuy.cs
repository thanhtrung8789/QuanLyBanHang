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
    public partial class FBuy : Form
    {
        public FBuy(int maPhieuNhap, Staff nhanVien, FMain mainForm)
        {
            InitializeComponent();
            CauHinhHienThi();
            _MaPhieuNhap = maPhieuNhap;
            _NhanVien = nhanVien;
            _CTPhieuNhap = TaoBangCTPN();
            _MainForm = mainForm;
            LoadTatCa();
        }

        #region Properties
        private int _MaPhieuNhap;

        private Staff _NhanVien;

        private DataTable _CTPhieuNhap;

        private FMain _MainForm;
        #endregion

        #region Events

        private void cbb_NCC_HH_KeyDown(object sender, KeyEventArgs e)
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
                        FFind _fFind = new FFind(cbbHangHoa.Text, null, this);
                        _fFind.Text = "TÌM HÀNG HÓA";
                        _fFind.ShowDialog();
                    }
                }
                else if (_cbbName.Contains("NhaCungCap"))
                {
                    DataTable _table = SupplierDAO.Instance.TimNhaCungCapTheoTen(cbbNhaCungCap.Text);
                    if (_table.Rows.Count == 1)
                    {
                        Supplier _nhaCungCap = new Supplier(_table.Rows[0]);
                        cbbNhaCungCap.SelectedValue = _nhaCungCap.MaNCC;
                    }
                    else
                    {
                        FFind _fFind = new FFind(cbbNhaCungCap.Text, null, this);
                        _fFind.Text = "TÌM NHÀ CUNG CẤP";
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
                if (!_CTPhieuNhap.Rows.Contains(_maHH))
                {
                    Goods _hangHoa = GoodsDAO.Instance.LayHangHoaTheoMa(_maHH);
                    DataRow _row = _CTPhieuNhap.NewRow();
                    _row["maHH"] = _hangHoa.MaHH;
                    _row["tenHH"] = _hangHoa.TenHH;
                    _row["donViTinh"] = _hangHoa.DonViTinh;
                    _row["giaNhap"] = _hangHoa.GiaNhap;
                    _row["soLuong"] = Convert.ToSingle(txtSoLuong.Text);
                    _row["thanhTien"] = Convert.ToSingle(_row["soLuong"]) * Convert.ToSingle(_row["giaNhap"]);
                    _CTPhieuNhap.Rows.Add(_row);
                    LoadCTPN();
                }
                else
                {
                    DataRow _row = _CTPhieuNhap.Rows.Find(_maHH);
                    _row["soLuong"] = Convert.ToSingle(txtSoLuong.Text) + Convert.ToSingle(_row["soLuong"]);
                    _row["thanhTien"] = Convert.ToSingle(_row["soLuong"]) * Convert.ToSingle(_row["giaNhap"]);
                    LoadCTPN();
                }
            }
        }

        private void dgvThongTinCTPN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThongTinCTPN.CurrentRow != null)
            {
                if (dgvThongTinCTPN.CurrentCellAddress.X == dgvThongTinCTPN.Columns.IndexOf(dgvThongTinCTPN.Columns["soLuong"]) ||
                    dgvThongTinCTPN.CurrentCellAddress.X == dgvThongTinCTPN.Columns.IndexOf(dgvThongTinCTPN.Columns["giaNhap"]))
                {
                    DataGridViewRow _row = dgvThongTinCTPN.CurrentRow;
                    _row.Cells["thanhTien"].Value = (Convert.ToSingle(_row.Cells["soLuong"].Value) * Convert.ToSingle(_row.Cells["giaNhap"].Value)).ToString();
                }

            }
            Single _tongTien = 0;
            foreach (DataGridViewRow _row in dgvThongTinCTPN.Rows)
            {
                _tongTien += Convert.ToSingle(_row.Cells["thanhTien"].Value);
            }
            txtTongTien.Text = _tongTien.ToString();
        }

        private void dgvThongTinCTPN_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LoadCTPN();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thực hiện không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (cbbNhaCungCap.SelectedValue != null)
            {
                ReceiptDAO.Instance.ThemPhieuNhap(_MaPhieuNhap, Convert.ToInt32(cbbNhaCungCap.SelectedValue), Convert.ToInt32(cbbNhanVien.SelectedValue), dtpNgayNhap.Value);
                foreach (DataRow _row in _CTPhieuNhap.Rows)
                {
                    ReceiptInfoDAO.Instance.ThemCTPhieuNhap(_MaPhieuNhap, Convert.ToInt32(_row["maHH"]), Convert.ToSingle(_row["soLuong"]), Convert.ToSingle(_row["giaNhap"]));
                }
                _MainForm.LoadTatCa();
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa chọn nhà cung cấp !", "Thông báo");
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
            dgvThongTinCTPN.Columns["soLuong"].DefaultCellStyle.Format = "n2";
            dgvThongTinCTPN.Columns["soLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongTinCTPN.Columns["giaNhap"].DefaultCellStyle.Format = "n0";
            dgvThongTinCTPN.Columns["giaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongTinCTPN.Columns["thanhTien"].DefaultCellStyle.Format = "n0";
            dgvThongTinCTPN.Columns["thanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Single value;
            if (Single.TryParse(txtTongTien.Text, out value))
                txtTongTien.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C0}", value);
            else
                txtTongTien.Text = String.Empty;
        }

        private void LoadTatCa()
        {
            LoadThongTinPN();
            LoadHangHoa();
        }

        private void LoadHangHoa()
        {
            cbbHangHoa.DataSource = GoodsDAO.Instance.TimHangHoaTheoTen("");
            cbbHangHoa.DisplayMember = "tenHH";
            cbbHangHoa.ValueMember = "maHH";
        }

        private void LoadCTPN()
        {
            dgvThongTinCTPN.DataSource = _CTPhieuNhap;
            Single _tongTien = 0;
            foreach (DataGridViewRow _row in dgvThongTinCTPN.Rows)
            {
                _tongTien += Convert.ToSingle(_row.Cells["thanhTien"].Value);
            }
            txtTongTien.Text = _tongTien.ToString();
            CauHinhHienThi();
        }

        private void LoadThongTinPN()
        {
            txtMaPhieuNhap.Text = _MaPhieuNhap.ToString();
            cbbNhaCungCap.DataSource = SupplierDAO.Instance.TimNhaCungCapTheoTen("");
            cbbNhaCungCap.DisplayMember = "tenNCC";
            cbbNhaCungCap.ValueMember = "maNCC";
            cbbNhanVien.DataSource = StaffDAO.Instance.TimNhanVienTheoTen("");
            cbbNhanVien.DisplayMember = "tenNV";
            cbbNhanVien.ValueMember = "maNV";
            cbbNhanVien.SelectedValue = _NhanVien.MaNV;
            dtpNgayNhap.Value = DateTime.Today;
        }

        private DataTable TaoBangCTPN()
        {
            DataTable _table = new DataTable();
            _table.Columns.Add("maHH");
            _table.Columns.Add("tenHH");
            _table.Columns.Add("donViTinh");
            _table.Columns.Add("soLuong");
            _table.Columns.Add("giaNhap");
            _table.Columns.Add("thanhTien");
            _table.PrimaryKey = new DataColumn[] { _table.Columns["maHH"] };
            return _table;
        }

        internal void UpdateCbbHangHoa(int maHH)
        {
            cbbHangHoa.SelectedValue = maHH;
        }

        internal void UpdateCbbNhaCungCap(int maNCC)
        {
            cbbNhaCungCap.SelectedValue = maNCC;
        }
        #endregion
    }
}
