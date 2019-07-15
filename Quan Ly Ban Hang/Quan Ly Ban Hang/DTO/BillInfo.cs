using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class BillInfo
    {
        public BillInfo(int maHD, DateTime ngayBan, int maKH, string tenKH, int maNV, string tenNV,
            int maHH, string tenHH, int soLuong, string donViTinh, Single giaBan, Single thanhTien, int maNH, string tenNH)
        {
            MaHD = maHD;
            NgayBan = ngayBan;
            MaKH = maKH;
            TenKH = tenKH;
            MaNV = maNV;
            TenNV = tenNV;
            MaHH = maHH;
            TenHH = tenHH;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
            GiaBan = giaBan;
            ThanhTien = thanhTien;
            MaNH = maNH;
            TenNH = tenNH;
        }

        public BillInfo(DataRow row)
        {
            MaHD = (int)row["maHD"];
            NgayBan = (DateTime)row["ngayBan"];
            MaKH = (int)row["maKH"];
            TenKH = row["tenKH"].ToString();
            MaNV = (int)row["maNV"];
            TenNV = row["tenNV"].ToString();
            MaHH = (int)row["maHH"];
            TenHH = row["tenHH"].ToString();
            SoLuong = Convert.ToSingle(row["soLuong"]);
            DonViTinh = row["donViTinh"].ToString();
            GiaBan = Convert.ToSingle(row["giaBan"]);
            ThanhTien = Convert.ToSingle(row["thanhTien"]);
            MaNH = (int)row["maNH"];
            TenNH = row["tenNH"].ToString();
        }

        private int _MaHD;
        private DateTime _NgayBan;
        private int _MaKH;
        private string _TenKH;
        private int _MaNV;
        private string _TenNV;
        private int _MaHH;
        private string _TenHH;
        private Single _SoLuong;
        private string _DonViTinh;
        private Single _GiaBan;
        private Single _ThanhTien;
        private int _MaNH;
        private string _TenNH;

        public int MaHD { get => _MaHD; set => _MaHD = value; }
        public DateTime NgayBan { get => _NgayBan; set => _NgayBan = value; }
        public string TenKH { get => _TenKH; set => _TenKH = value; }
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public float ThanhTien { get => _ThanhTien; set => _ThanhTien = value; }
        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public int MaHH { get => _MaHH; set => _MaHH = value; }
        public string TenHH { get => _TenHH; set => _TenHH = value; }
        public float SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public string DonViTinh { get => _DonViTinh; set => _DonViTinh = value; }
        public float GiaBan { get => _GiaBan; set => _GiaBan = value; }
        public int MaNH { get => _MaNH; set => _MaNH = value; }
        public string TenNH { get => _TenNH; set => _TenNH = value; }
    }
}
