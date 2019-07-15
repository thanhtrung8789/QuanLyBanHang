using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Goods
    {
        public Goods(int maHH, string tenHH, string donViTinh, Single giaNhap, Single giaBan, Single soLuongTon, int maNH, string tenNH)
        {
            MaHH = maHH;
            TenHH = tenHH;
            DonViTinh = donViTinh;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
            MaNH = maNH;
            TenNH = tenNH;
        }

        public Goods(DataRow row)
        {
            MaHH = (int)row["maHH"];
            TenHH = row["tenHH"].ToString();
            DonViTinh = row["donViTinh"].ToString();
            GiaNhap = Convert.ToSingle(row["giaNhap"]);
            GiaBan = Convert.ToSingle(row["giaBan"]);
            SoLuongTon = Convert.ToSingle(row["soLuongTon"]);
            MaNH = (int)row["maNH"];
            TenNH = row["tenNH"].ToString();
        }

        private int _MaHH;
        private string _TenHH;
        private string _DonViTinh;
        private Single _GiaNhap;
        private Single _GiaBan;
        private Single _SoLuongTon;
        private int _MaNH;
        private string _TenNH;

        public int MaHH { get => _MaHH; set => _MaHH = value; }
        public string TenHH { get => _TenHH; set => _TenHH = value; }
        public string DonViTinh { get => _DonViTinh; set => _DonViTinh = value; }
        public Single GiaNhap { get => _GiaNhap; set => _GiaNhap = value; }
        public Single GiaBan { get => _GiaBan; set => _GiaBan = value; }
        public Single SoLuongTon { get => _SoLuongTon; set => _SoLuongTon = value; }
        public int MaNH { get => _MaNH; set => _MaNH = value; }
        public string TenNH { get => _TenNH; set => _TenNH = value; }
    }
}
