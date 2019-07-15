using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Staff
    {
        public Staff(int maNV, string tenNV, string soDienThoai, string diaChi, string email)
        {
            MaNV = maNV;
            TenNV = tenNV;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            Email = email;
        }

        public Staff(DataRow row)
        {
            MaNV = (int)row["maNV"];
            TenNV = row["tenNV"].ToString();
            SoDienThoai = row["soDienThoai"].ToString();
            DiaChi = row["diaChi"].ToString();
            Email = row["email"].ToString();
        }

        private int _MaNV;
        private string _TenNV;
        private string _SoDienThoai;
        private string _DiaChi;
        private string _Email;

        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public string SoDienThoai { get => _SoDienThoai; set => _SoDienThoai = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string Email { get => _Email; set => _Email = value; }
    }
}
