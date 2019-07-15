using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class ReceiptDAO
    {
        private static ReceiptDAO _Instance;

        private ReceiptDAO() { }

        public static ReceiptDAO Instance { get { if (_Instance == null) _Instance = new ReceiptDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemPhieuNhap(int maPN, int maNCC, int maNV, DateTime ngayNhap)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemPN @maPN , @maNCC , @maNV , @ngayNhap", new object[] { maPN, maNCC, maNV, ngayNhap }) > 0;
        }

        public bool SuaPhieuNhap(int maPN, int maNCC, int maNV, DateTime ngayNhap)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaPN @maPN , @maNCC , @maNV , @ngayNhap", new object[] { maPN, maNCC, maNV, ngayNhap }) > 0;
        }

        public bool XoaPhieuNhap(int maPN)
        {
            ReceiptInfoDAO.Instance.XoaCTPhieuNhap(maPN);
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaPN @maPN", new object[] { maPN }) > 0;
        }

        public DataTable TimPhieuNhapMix(string tenNV, string tenNCC, DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimPN_mix @tenNV , @tenNCC , @tuNgay , @denNgay", new object[] { tenNV, tenNCC, tuNgay, denNgay });
        }

        public DataTable TimPhieuNhapTheoMa(int maPN)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimPN_ma @maPN", new object[] { maPN });
        }

        public int LayMaPhieuNhap()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("exec SP_LayMaPN"); }
            catch { return 1; }
        }
    }
}
