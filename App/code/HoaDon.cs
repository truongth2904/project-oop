using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLyBanHang
{
    class HoaDon
    {
        // fields:
        private string maHD;
        private DateTime ngayMua;
        private int soLuongMua;
        private LinkedList<HangHoa> sanPham;
        private NhanVien nhanVien;
        private KhachHang khachHang;

        // properties:
        public string MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }

        public DateTime NgayMua
        {
            get
            {
                return ngayMua;
            }

            set
            {
                ngayMua = value;
            }
        }

        public int SoLuongMua
        {
            get
            {
                return soLuongMua;
            }

            set
            {
                soLuongMua = value;
            }
        }

        internal NhanVien NhanVien
        {
            get
            {
                return nhanVien;
            }

            set
            {
                nhanVien = value;
            }
        }

        internal KhachHang KhachHang
        {
            get
            {
                return khachHang;
            }

            set
            {
                khachHang = value;
            }
        }

        internal LinkedList<HangHoa> SanPham { get => sanPham; set => sanPham = value; }

        // constructor:
        /// <summary>
        /// Khai bao khong tham so!
        /// </summary>
        public HoaDon()
        {
            this.MaHD = "00000";
            this.NgayMua = new DateTime();
            this.SanPham = new LinkedList<HangHoa>();
            this.NhanVien = new NhanVien();
        }
        /// <summary>
        /// Khai bao day du tham so!
        /// </summary>
        /// <param name="maHD"></param>
        /// <param name="ngayMua"></param>
        /// <param name="soLuongMua"></param>
        /// <param name="sanPham"></param>
        /// <param name="nhanVien"></param>
        /// <param name="khachHang"></param>
        public HoaDon(string maHD, DateTime ngayMua, int soLuongMua, LinkedList<HangHoa> sanPham, NhanVien nhanVien, KhachHang khachHang)
        {
            this.MaHD = maHD;
            this.NgayMua = ngayMua;
            this.SoLuongMua = soLuongMua;
            this.SanPham = sanPham;
            this.NhanVien = nhanVien;
            this.KhachHang = khachHang;
        }

        // methods
        public void toString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"- Ten Khach Hang: {this.KhachHang.HoTen}\t- Ma Khach Hang: {this.KhachHang.MaKH}");
            Console.WriteLine($"- Ma Hoa Don: {this.MaHD}");
            Console.WriteLine($"- Ngay Mua: {this.NgayMua.Date}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Cac san pham mua: ");
            int i = 0;
            for (LinkedListNode<HangHoa> p = sanPham.First;p!=null;p=p.Next,i++)
            {
                Console.WriteLine($"+ San pham {i + 1}: {p.Value.SanPham}.");
                Console.WriteLine($"\tGia tien: {p.Value.GiaBan}.");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Gia tien cua hoa don: {getTinhTien()}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"- Nhan Vien Lap Hoa Don: {this.NhanVien.HoTen}\t- Ma Nhan Vien:{this.NhanVien.MaNV}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Tinh gia tien cho hoa don:
        public double getTinhTien()
        {
            double tong = 0;
            for (LinkedListNode<HangHoa> p = sanPham.First; p != null; p = p.Next)
            {
                tong += p.Value.GiaBan;
            }
            return tong;
        }
    }
}
