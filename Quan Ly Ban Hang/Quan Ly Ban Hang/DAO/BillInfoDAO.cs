using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO _Instance;

        private BillInfoDAO() { }

        public static BillInfoDAO Instance { get { if (_Instance == null) _Instance = new BillInfoDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemCTHoaDon(int maHD, int maHH, Single soLuong, Single giaBan)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemCTHD @maHD , @maHH , @soLuong , @giaBan", new object[] { maHD, maHH, soLuong, giaBan }) > 0;
        }

        public bool SuaCTHoaDon(int maHD, int maHH, Single soLuong, Single giaBan)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaCTHD @maHD , @maHH , @soLuong , @giaBan", new object[] { maHD, maHH, soLuong, giaBan }) > 0;
        }

        public bool XoaCTHoaDon(int maHD, int maHH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaCTHD @maHD , @maHH", new object[] { maHD, maHH }) > 0;
        }

        public bool XoaCTHoaDon(int maHD)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaCTHD_1ma @maHD", new object[] { maHD }) > 0;
        }

        public DataTable TimCTHoaDonMix(string tenNV, string tenKH, DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimCTHD_mix @tenNV , @tenKH , @tuNgay , @denNgay", new object[] { tenNV, tenKH, tuNgay, denNgay });
        }

        public DataTable TimCTHoaDonTheoMa(int maHD)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimCTHD_ma @maHD", new object[] { maHD });
        }
    }
}
