using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DTO
{
    public class Category
    {
        public Category(int maNH, string tenNH)
        {
            MaNH = maNH;
            TenNH = tenNH;
        }

        public Category(DataRow row)
        {
            MaNH = (int)row["maNH"];
            TenNH = row["tenNH"].ToString();
        }
        
        private int _MaNH;
        private string _TenNH;

        public int MaNH { get => _MaNH; set => _MaNH = value; }
        public string TenNH { get => _TenNH; set => _TenNH = value; }
    }
}
