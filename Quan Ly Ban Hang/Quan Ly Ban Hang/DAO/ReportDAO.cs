using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class ReportDAO
    {
        private static ReportDAO _Instance;

        private ReportDAO() { }

        public static ReportDAO Instance { get { if (_Instance == null) _Instance = new ReportDAO(); return _Instance; } private set { _Instance = value; } }

        public DataTable BaoCaoDoanhThuTheoNhanVien(DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_BCDoanhThu_nhanvien @tuNgay , @denNgay", new object[] { tuNgay, denNgay });
        }

        public DataTable BaoCaoDoanhThuTheoKhachHang(DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_BCDoanhThu_khachhang @tuNgay , @denNgay", new object[] { tuNgay, denNgay });
        }

        public DataTable BaoCaoDoanhThuTheoHangHoa(DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_BCDoanhThu_hanghoa @tuNgay , @denNgay", new object[] { tuNgay, denNgay });
        }

        public DataTable BaoCaoDoanhThuTheoNhomHang(DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_BCDoanhThu_nhomhang @tuNgay , @denNgay", new object[] { tuNgay, denNgay });
        }

        public DataTable BaoCaoChiPhiTheoNhaCungCap(DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_BCChiPhi_nhacungcap @tuNgay , @denNgay", new object[] { tuNgay, denNgay });
        }

        public DataTable BaoCaoLoiNhuanTheoHangHoa(DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_BCLoiNhuan_hanghoa @tuNgay , @denNgay", new object[] { tuNgay, denNgay });
        }

        public DataTable BaoCaoLoiNhuanTheoNhomHang(DateTime tuNgay, DateTime denNgay)
        {
            return DataProvider.Instance.ExecuteQuery("exec SP_BCLoiNhuan_nhomhang @tuNgay , @denNgay", new object[] { tuNgay, denNgay });
        }

        public Single TongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return Convert.ToSingle(DataProvider.Instance.ExecuteScalar("exec SP_TongDoanhThu @tuNgay , @denNgay", new object[] { tuNgay, denNgay }));
            }
            catch { return 0; }
        }

        public Single TongChiPhi(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return Convert.ToSingle(DataProvider.Instance.ExecuteScalar("exec SP_TongChiPhi @tuNgay , @denNgay", new object[] { tuNgay, denNgay }));
            }
            catch { return 0; }
        }

        public Single TongLoiNhuan(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return Convert.ToSingle(DataProvider.Instance.ExecuteScalar("exec SP_TongLoiNhuan @tuNgay , @denNgay", new object[] { tuNgay, denNgay }));
            }
            catch { return 0; }
        }
    }
}
