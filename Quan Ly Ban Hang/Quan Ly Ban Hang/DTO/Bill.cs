using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Bill
    {
        public Bill(int maHD, DateTime ngayBan, int maKH, string tenKH, int maNV, string tenNV, Single thanhTien)
        {
            MaHD = maHD;
            NgayBan = ngayBan;
            MaKH = maKH;
            TenKH = tenKH;
            MaNV = maNV;
            TenNV = tenNV;
            ThanhTien = thanhTien;
        }

        public Bill(DataRow row)
        {
            MaHD = (int)row["maHD"];
            NgayBan = (DateTime)row["ngayBan"];
            MaKH = (int)row["maKH"];
            TenKH = row["tenKH"].ToString();
            MaNV = (int)row["maNV"];
            TenNV = row["tenNV"].ToString();
            ThanhTien = (Single)row["thanhTien"];
        }

        private int _MaHD;
        private DateTime _NgayBan;
        private int _MaKH;
        private string _TenKH;
        private int _MaNV;
        private string _TenNV;
        private Single _ThanhTien;

        public int MaHD { get => _MaHD; set => _MaHD = value; }
        public DateTime NgayBan { get => _NgayBan; set => _NgayBan = value; }
        public string TenKH { get => _TenKH; set => _TenKH = value; }
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public float ThanhTien { get => _ThanhTien; set => _ThanhTien = value; }
        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
    }
}
