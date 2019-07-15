using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Supplier
    {
        public Supplier(int maNCC, string tenNCC, string soDienThoai, string diaChi, string email)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            Email = email;
        }

        public Supplier(DataRow row)
        {
            MaNCC = (int)row["maNCC"];
            TenNCC = row["tenNCC"].ToString();
            SoDienThoai = row["soDienThoai"].ToString();
            DiaChi = row["diaChi"].ToString();
            Email = row["email"].ToString();
        }

        private int _MaNCC;
        private string _TenNCC;
        private string _SoDienThoai;
        private string _DiaChi;
        private string _Email;

        public int MaNCC { get => _MaNCC; set => _MaNCC = value; }
        public string TenNCC { get => _TenNCC; set => _TenNCC = value; }
        public string SoDienThoai { get => _SoDienThoai; set => _SoDienThoai = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string Email { get => _Email; set => _Email = value; }
    }
}
