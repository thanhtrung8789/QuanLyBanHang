using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class StaffDAO
    {
        private static StaffDAO _Instance;

        private StaffDAO() { }

        public static StaffDAO Instance { get { if (_Instance == null) _Instance = new StaffDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemNhanVien(int maNV, string tenNV, string diaChi, string soDienThoai, string email)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemNV @maNV , @tenNV , @diaChi , @soDienThoai , @email", new object[] { maNV, tenNV, diaChi, soDienThoai, email }) > 0;
        }

        public bool SuaNhanVien(int maNV, string tenNV, string diaChi, string soDienThoai, string email)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaNV @maNV , @tenNV , @diaChi , @soDienThoai , @email", new object[] { maNV, tenNV, diaChi, soDienThoai, email }) > 0;
        }

        public bool XoaNhanVien(int maNV)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaNV @maNV", new object[] { maNV }) > 0;
        }

        public DataTable TimNhanVienNoAccount()
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNV_noaccount");
        }

        public DataTable TimNhanVienTheoMa(int maNV)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNV_ma @maNV", new object[] { maNV });
        }

        public DataTable TimNhanVienTheoTen(string tenNV)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimNV_ten @tenNV", new object[] { tenNV });
        }

        public Staff LayNhanVienTheoMa(int maNV)
        {
            DataTable _table = TimNhanVienTheoMa(maNV);
            return new Staff(_table.Rows[0]);
        }

        public Staff LayNhanVienTheoTen(string tenNV)
        {
            DataTable _table = TimNhanVienTheoTen(tenNV);
            return new Staff(_table.Rows[0]);
        }

        public int LayMaNhanVien()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("exec SP_LayMaNV"); }
            catch { return 1; }
        }
    }
}
