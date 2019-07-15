using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class ReceiptInfo
    {
        public ReceiptInfo(int maPN, DateTime ngayNhap, int maNCC, string tenNCC, int maNV, string tenNV,
            int maHH, string tenHH, int soLuong, string donViTinh, Single giaNhap, Single thanhTien, int maNH, string tenNH)
        {
            MaPN = maPN;
            NgayNhap = ngayNhap;
            MaNCC = maNCC;
            TenNCC = tenNCC;
            MaNV = maNV;
            TenNV = tenNV;
            MaHH = maHH;
            TenHH = tenHH;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
            GiaNhap = giaNhap;
            ThanhTien = thanhTien;
            MaNH = maNH;
            TenNH = tenNH;
        }

        public ReceiptInfo(DataRow row)
        {
            MaPN = (int)row["maPN"];
            NgayNhap = (DateTime)row["ngayNhap"];
            MaNCC = (int)row["maNCC"];
            TenNCC = row["tenNCC"].ToString();
            MaNV = (int)row["maNV"];
            TenNV = row["tenNV"].ToString();
            MaHH = (int)row["maHH"];
            TenHH = row["tenHH"].ToString();
            SoLuong = Convert.ToSingle(row["soLuong"]);
            DonViTinh = row["donViTinh"].ToString();
            GiaNhap = Convert.ToSingle(row["giaNhap"]);
            ThanhTien = Convert.ToSingle(row["thanhTien"]);
            MaNH = (int)row["maNH"];
            TenNH = row["tenNH"].ToString();
        }

        private int _MaPN;
        private DateTime _NgayNhap;
        private int _MaNCC;
        private string _TenNCC;
        private int _MaNV;
        private string _TenNV;
        private int _MaHH;
        private string _TenHH;
        private Single _SoLuong;
        private string _DonViTinh;
        private Single _GiaNhap;
        private Single _ThanhTien;
        private int _MaNH;
        private string _TenNH;

        public int MaPN { get => _MaPN; set => _MaPN = value; }
        public DateTime NgayNhap { get => _NgayNhap; set => _NgayNhap = value; }
        public string TenNCC { get => _TenNCC; set => _TenNCC = value; }
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public float ThanhTien { get => _ThanhTien; set => _ThanhTien = value; }
        public int MaNCC { get => _MaNCC; set => _MaNCC = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public int MaHH { get => _MaHH; set => _MaHH = value; }
        public string TenHH { get => _TenHH; set => _TenHH = value; }
        public float SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public string DonViTinh { get => _DonViTinh; set => _DonViTinh = value; }
        public float GiaNhap { get => _GiaNhap; set => _GiaNhap = value; }
        public int MaNH { get => _MaNH; set => _MaNH = value; }
        public string TenNH { get => _TenNH; set => _TenNH = value; }
    }
}
