using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class SupplierDAO
    {
        private static SupplierDAO _Instance;

        private SupplierDAO() { }

        public static SupplierDAO Instance { get { if (_Instance == null) _Instance = new SupplierDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemNhaCungCap(int maNCC, string tenNCC, string diaChi, string soDienThoai, string email)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemNCC @maNCC , @tenNCC , @diaChi , @soDienThoai , @email", new object[] { maNCC, tenNCC, diaChi, soDienThoai, email }) > 0;
        }

        public bool SuaNhaCungCap(int maNCC, string tenNCC, string diaChi, string soDienThoai, string email)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaNCC @maNCC , @tenNCC , @diaChi , @soDienThoai , @email", new object[] { maNCC, tenNCC, diaChi, soDienThoai, email }) > 0;
        }

        public bool XoaNhaCungCap(int maNCC)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaNCC @maNCC", new object[] { maNCC }) > 0;
        }

        public DataTable TimNhaCungCapMix(string first, string second)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNCC_mix @first , @second", new object[] { first, second });
        }

        public DataTable TimNhaCungCapTheoMa(int maNCC)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNCC_ma @maNCC", new object[] { maNCC });
        }

        public DataTable TimNhaCungCapTheoTen(string tenNCC)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNCC_ten @tenNCC", new object[] { tenNCC });
        }

        public Supplier LayNhaCungCapTheoMa(int maNCC)
        {
            DataTable _table = TimNhaCungCapTheoMa(maNCC);
            return new Supplier(_table.Rows[0]);
        }

        public Supplier LayNhaCungCapTheoTen(string tenNCC)
        {
            DataTable _table = TimNhaCungCapTheoTen(tenNCC);
            return new Supplier(_table.Rows[0]);
        }

        public int LayMaNhaCungCap()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("exec SP_LayMaNCC"); }
            catch { return 1; }
        }
    }
}
