using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Account
    {
        public Account(int maNV, string userName, string passWord, int type)
        {
            MaNV = maNV;
            UserName = userName;
            PassWord = passWord;
            Type = type;
        }

        public Account(DataRow row)
        {
            MaNV = (int)row["maNV"];
            UserName = row["userName"].ToString();
            PassWord = row["passWord"].ToString();
            Type = (int)row["type"];
        }

        private int _MaNV;
        private string _UserName;
        private string _PassWord;
        private int _Type;

        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string PassWord { get => _PassWord; set => _PassWord = value; }
        public int Type { get => _Type; set => _Type = value; }
    }
}
