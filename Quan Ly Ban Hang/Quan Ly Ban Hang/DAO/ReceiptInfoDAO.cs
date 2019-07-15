using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class ReceiptInfoDAO
    {
        private static ReceiptInfoDAO _Instance;

        private ReceiptInfoDAO() { }

        public static ReceiptInfoDAO Instance { get { if (_Instance == null) _Instance = new ReceiptInfoDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemCTPhieuNhap(int maPN, int maHH, Single soLuong, Single giaNhap)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemCTPN @maPN , @maHH , @soLuong , @giaNhap", new object[] { maPN, maHH, soLuong, giaNhap }) > 0;
        }

        public bool SuaCTPhieuNhap(int maPN, int maHH, Single soLuong, Single giaNhap)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaCTPN @maPN , @maHH , @soLuong , @giaNhap", new object[] { maPN, maHH, soLuong, giaNhap }) > 0;
        }

        public bool XoaCTPhieuNhap(int maPN, int maHH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaCTPN @maPN , @maHH", new object[] { maPN, maHH }) > 0;
        }

        public bool XoaCTPhieuNhap(int maPN)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaCTPN_1ma @maPN", new object[] { maPN }) > 0;
        }

        public DataTable TimCTPhieuNhapMix(string tenNV, string tenNCC, DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimCTPN_mix @tenNV , @tenNCC , @tuNgay , @denNgay", new object[] { tenNV, tenNCC, tuNgay, denNgay });
        }

        public DataTable TimCTPhieuNhapTheoMa(int maPN)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimCTPN_ma @maPN", new object[] { maPN });
        }
    }
}
