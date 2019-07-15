using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO _Instance;

        private CategoryDAO() { }

        public static CategoryDAO Instance { get { if (_Instance == null) _Instance = new CategoryDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemNhomHang(int maNH, string tenNH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemNH @maNH , @tenNH", new object[] { maNH, tenNH }) > 0;
        }

        public bool SuaNhomHang(int maNH, string tenNH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaNH @maNH , @tenNH", new object[] { maNH, tenNH }) > 0;
        }

        public bool XoaNhomHang(int maNH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaNH @maNH", new object[] { maNH }) > 0;
        }

        public DataTable TimNhomHangTheoMa(int maNH)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNH_ma @maNH", new object[] { maNH });
        }

        public DataTable TimNhomHangTheoTen(string tenNH)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNH_ten @tenNH", new object[] { tenNH });
        }

        public Category LayNhomHangTheoMa(int maNH)
        {
            DataTable _table = TimNhomHangTheoMa(maNH);
            return new Category(_table.Rows[0]);
        }

        public Category LayNhomHangTheoTen(string tenNH)
        {
            DataTable _table = TimNhomHangTheoTen(tenNH);
            return new Category(_table.Rows[0]);
        }

        public int LayMaNhomHang()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("exec SP_LayMaNH"); }
            catch { return 1; }
        }
    }
}
