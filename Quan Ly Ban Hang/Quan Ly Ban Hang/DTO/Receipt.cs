using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Receipt
    {
        public Receipt(int maPN, DateTime ngayNhap, int maNCC, string tenNCC, int maNV, string tenNV, Single thanhTien)
        {
            MaPN = maPN;
            NgayNhap = ngayNhap;
            MaNCC = maNCC;
            TenNCC = tenNCC;
            MaNV = maNV;
            TenNV = tenNV;
            ThanhTien = thanhTien;
        }

        public Receipt(DataRow row)
        {
            MaPN = (int)row["maPN"];
            NgayNhap = (DateTime)row["ngayNhap"];
            MaNCC = (int)row["maNCC"];
            TenNCC = row["tenNCC"].ToString();
            MaNV = (int)row["maNV"];
            TenNV = row["tenNV"].ToString();
            ThanhTien = (Single)row["thanhTien"];
        }

        private int _MaPN;
        private DateTime _NgayNhap;
        private int _MaNCC;
        private string _TenNCC;
        private int _MaNV;
        private string _TenNV;
        private Single _ThanhTien;

        public int MaPN { get => _MaPN; set => _MaPN = value; }
        public DateTime NgayNhap { get => _NgayNhap; set => _NgayNhap = value; }
        public string TenNCC { get => _TenNCC; set => _TenNCC = value; }
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public float ThanhTien { get => _ThanhTien; set => _ThanhTien = value; }
        public int MaNCC { get => _MaNCC; set => _MaNCC = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
    }
}
