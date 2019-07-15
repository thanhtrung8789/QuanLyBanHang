using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Client
    {
        public Client(int maKH, string tenKH, string soDienThoai, string diaChi, string email)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            Email = email;
        }

        public Client(DataRow row)
        {
            MaKH = (int)row["maKH"];
            TenKH = row["tenKH"].ToString();
            SoDienThoai = row["soDienThoai"].ToString();
            DiaChi = row["diaChi"].ToString();
            Email = row["email"].ToString();
        }

        private int _MaKH;
        private string _TenKH;
        private string _SoDienThoai;
        private string _DiaChi;
        private string _Email;

        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public string TenKH { get => _TenKH; set => _TenKH = value; }
        public string SoDienThoai { get => _SoDienThoai; set => _SoDienThoai = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string Email { get => _Email; set => _Email = value; }
    }
}
