using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class GoodsDAO
    {
        private static GoodsDAO _Instance;

        private GoodsDAO() { }

        public static GoodsDAO Instance { get { if (_Instance == null) _Instance = new GoodsDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemHangHoa(int maHH, string tenHH, string donViTinh, Single giaNhap, Single giaBan, Single soLuongTon, int maNH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemHH @maHH , @tenHH , @donViTinh , @giaNhap , @giaBan , @soLuongTon , @maNH", new object[] { maHH, tenHH, donViTinh, giaNhap, giaBan, soLuongTon, maNH }) > 0;
        }

        public bool SuaHangHoa(int maHH, string tenHH, string donViTinh, Single giaNhap, Single giaBan, Single soLuongTon, int maNH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaHH @maHH , @tenHH , @donViTinh , @giaNhap , @giaBan , @soLuongTon , @maNH", new object[] { maHH, tenHH, donViTinh, giaNhap, giaBan, soLuongTon, maNH }) > 0;
        }

        public bool XoaHangHoa(int maHH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaHH @maHH", new object[] { maHH }) > 0;
        }

        public DataTable TimHangHoaMix(string first, string second)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimHH_mix @first , @second", new object[] { first, second });
        }

        public DataTable TimHangHoaTheoMa(int maHH)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimHH_ma @maHH", new object[] { maHH });
        }

        public DataTable TimHangHoaTheoTen(string tenHH)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimHH_ten @tenHH", new object[] { tenHH });
        }

        public Goods LayHangHoaTheoMa(int maHH)
        {
            DataTable _table = TimHangHoaTheoMa(maHH);
            return new Goods(_table.Rows[0]);
        }

        public Goods LayHangHoaTheoTen(string tenHH)
        {
            DataTable _table = TimHangHoaTheoTen(tenHH);
            return new Goods(_table.Rows[0]);
        }

        public int LayMaHangHoa()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("exec SP_LayMaHH"); }
            catch { return 1; }
        }
    }
}
