using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class BillDAO
    {
        private static BillDAO _Instance;

        private BillDAO() { }

        public static BillDAO Instance { get { if (_Instance == null) _Instance = new BillDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemHoaDon(int maHD, int maKH, int maNV, DateTime ngayBan)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemHD @maHD , @maKH , @maNV , @ngayBan", new object[] { maHD, maKH, maNV, ngayBan }) > 0;
        }

        public bool SuaHoaDon(int maHD, int maKH, int maNV, DateTime ngayBan)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaHD @maHD , @maKH , @maNV , @ngayBan", new object[] { maHD, maKH, maNV, ngayBan }) > 0;
        }

        public bool XoaHoaDon(int maHD)
        {
            BillInfoDAO.Instance.XoaCTHoaDon(maHD);
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaHD @maHD", new object[] { maHD }) > 0;
        }

        public DataTable TimHoaDonMix(string tenNV, string tenKH, DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimHD_mix @tenNV , @tenKH , @tuNgay , @denNgay", new object[] { tenNV, tenKH, tuNgay, denNgay });
        }

        public DataTable TimHoaDonTheoMa(int maHD)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimHD_ma @maHD", new object[] { maHD });
        }

        public int LayMaHoaDon()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("exec SP_LayMaHD"); }
            catch { return 1; }
        }
    }
}
