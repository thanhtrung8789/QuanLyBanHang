using Quan_Ly_Ban_Hang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class AccountDAO
    {
        private static AccountDAO _Instance;

        private AccountDAO() { }

        public static AccountDAO Instance { get { if (_Instance == null) _Instance = new AccountDAO(); return _Instance; } private set { _Instance = value; } }

        public bool ThemTaiKhoan(int maNV, string userName, string passWord, int type)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_ThemTK @maNV , @userName , @passWord , @type", new object[] { maNV, userName, passWord, type }) > 0;
        }

        public bool SuaTaiKhoan(int maNV, string userName, string passWord, int type)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_SuaTK @maNV , @userName , @passWord , @type", new object[] { maNV, userName, passWord, type }) > 0;
        }

        public bool XoaTaiKhoan(int maNV)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec SP_XoaTK @maNV", new object[] { maNV }) > 0;
        }

        public DataTable TimTaiKhoan(string userName)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimTK_likeuser @userName", new object[] { userName });
        }

        public DataTable TimTaiKhoanTheoUser(string userName)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_TimTK_user @userName", new object[] { userName });
        }

        public Account LayTaiKhoanTheoUser(string userName)
        {
            DataTable _table = TimTaiKhoanTheoUser(userName);
            if (_table.Rows.Count != 0)
                return new Account(_table.Rows[0]);
            else
                return null;
        }
    }
}
