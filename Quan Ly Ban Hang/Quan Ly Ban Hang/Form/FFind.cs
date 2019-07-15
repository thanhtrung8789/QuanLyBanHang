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
    public partial class FFind : Form
    {
        public FFind(string keyword, FSell fSellParrent, FBuy fBuyParrent)
        {
            InitializeComponent();
            _Keyword = keyword;
            _FBuyParrent = fBuyParrent;
            _FSellParrent = fSellParrent;
            _Data = TaoBang();
        }

        #region Properties
        private string _Keyword;

        private DataTable _Data;

        private FSell _FSellParrent;

        private FBuy _FBuyParrent;
        #endregion

        #region Events

        private void FFind_Load(object sender, EventArgs e)
        {
            LoadData(_Keyword, "");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData(_Keyword, txtTim.Text);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                string _formText = this.Text;
                if (_formText.Contains("HÀNG HÓA"))
                {
                    if (_FSellParrent == null)
                    {
                        _FBuyParrent.UpdateCbbHangHoa(Convert.ToInt32(dgvData.CurrentRow.Cells["ma"].Value));
                    }
                    else
                    {
                        _FSellParrent.UpdateCbbHangHoa(Convert.ToInt32(dgvData.CurrentRow.Cells["ma"].Value));
                    }
                }
                else if (_formText.Contains("KHÁCH HÀNG"))
                {
                    _FSellParrent.UpdateCbbKhachHang(Convert.ToInt32(dgvData.CurrentRow.Cells["ma"].Value));
                }
                else if (_formText.Contains("NHÀ CUNG CẤP"))
                {
                    _FBuyParrent.UpdateCbbNhaCungCap(Convert.ToInt32(dgvData.CurrentRow.Cells["ma"].Value));
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa chọn" + this.Text.Substring(3));
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            LoadData(_Keyword, txtTim.Text);
        }
        #endregion

        #region Methods
        private void LoadData(string first, string second)
        {
            _Data.Rows.Clear();
            string _formText = this.Text;
            if (_formText.Contains("HÀNG HÓA"))
            {
                DataTable _table = GoodsDAO.Instance.TimHangHoaMix(first, second);
                DataRow _newrow;
                foreach (DataRow _row in _table.Rows)
                {
                    _newrow = _Data.NewRow();
                    _newrow["ma"] = _row["maHH"];
                    _newrow["ten"] = _row["tenHH"];
                    _Data.Rows.Add(_newrow);
                }
                dgvData.DataSource = _Data;
            }
            else if(_formText.Contains("KHÁCH HÀNG"))
            {
                DataTable _table = ClientDAO.Instance.TimKhachHangMix(first, second);
                DataRow _newrow;
                foreach (DataRow _row in _table.Rows)
                {
                    _newrow = _Data.NewRow();
                    _newrow["ma"] = _row["maKH"];
                    _newrow["ten"] = _row["tenKH"];
                    _Data.Rows.Add(_newrow);
                }
                dgvData.DataSource = _Data;
            }
            else if (_formText.Contains("NHÀ CUNG CẤP"))
            {
                DataTable _table = SupplierDAO.Instance.TimNhaCungCapMix(first, second);
                DataRow _newrow;
                foreach (DataRow _row in _table.Rows)
                {
                    _newrow = _Data.NewRow();
                    _newrow["ma"] = _row["maNCC"];
                    _newrow["ten"] = _row["tenNCC"];
                    _Data.Rows.Add(_newrow);
                }
                dgvData.DataSource = _Data;
            }
        }

        private DataTable TaoBang()
        {
            DataTable _result = new DataTable();
            _result.Columns.Add("ma");
            _result.Columns.Add("ten");
            return _result;
        }
        #endregion
    }
}
