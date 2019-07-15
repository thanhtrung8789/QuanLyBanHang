using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class ClientDAO
    {
        private static ClientDAO _Instance;

        private ClientDAO() { }

        public static ClientDAO Instance { get { if (_Instance == null) _Instance = new ClientDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemKhachHang(int maKH, string tenKH, string diaChi, string soDienThoai, string email)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemKH @maKH , @tenKH , @diaChi , @soDienThoai , @email", new object[] { maKH, tenKH, diaChi, soDienThoai, email }) > 0;
        }

        public bool SuaKhachHang(int maKH, string tenKH, string diaChi, string soDienThoai, string email)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaKH @maKH , @tenKH , @diaChi , @soDienThoai , @email", new object[] { maKH, tenKH, diaChi, soDienThoai, email }) > 0;
        }

        public bool XoaKhachHang(int maKH)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaKH @maKH", new object[] { maKH }) > 0;
        }

        public DataTable TimKhachHangMix(string first, string second)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimKH_mix @first , @second", new object[] { first, second });
        }

        public DataTable TimKhachHangTheoMa(int maKH)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimKH_ma @maKH", new object[] { maKH });
        }

        public DataTable TimKhachHangTheoTen(string tenKH)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimKH_ten @tenKH", new object[] { tenKH });
        }

        public Client LayKhachHangTheoMa(int maKH)
        {
            DataTable _table = TimKhachHangTheoMa(maKH);
            return new Client(_table.Rows[0]);
        }

        public Client LayKhachHangTheoTen(string tenKH)
        {
            DataTable _table = TimKhachHangTheoTen(tenKH);
            return new Client(_table.Rows[0]);
        }

        public int LayMaKhachHang()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("exec SP_LayMaKH"); }
            catch { return 1; }
        }
    }
}
