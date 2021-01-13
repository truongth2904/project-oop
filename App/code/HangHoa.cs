using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    class HangHoa
    {
        // field:
        private string sanPham;
        private string maHH;
        private int soLuong;
        private DateTime ngayNhapKho;
        private double giaBan;
        private double giaNhapKho;
        // properties:
        public string SanPham
        {
            get
            {
                return sanPham;
            }

            set
            {
                sanPham = value;
            }
        }

        public string MaHH
        {
            get
            {
                return maHH;
            }

            set
            {
                maHH = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public DateTime NgayNhapKho
        {
            get
            {
                return ngayNhapKho;
            }

            set
            {
                ngayNhapKho = value;
            }
        }

        public double GiaBan
        {
            get
            {
                return giaBan;
            }

            set
            {
                giaBan = value;
            }
        }

        public double GiaNhapKho
        {
            get
            {
                return giaNhapKho;
            }

            set
            {
                giaNhapKho = value;
            }
        }
        // constructor:
        /// <summary>
        /// Khai bao khong tham so!
        /// </summary>
        public HangHoa()
        {
            this.SanPham = "Iphone";
            this.MaHH = "00000";
            this.SoLuong = 10;
            this.NgayNhapKho = new DateTime();
            this.GiaBan = 10000000;
            this.GiaNhapKho = 9000000;
        }
        /// <summary>
        /// Khai bao day du tham so!
        /// </summary>
        /// <param name="sanPham"></param>
        /// <param name="maHH"></param>
        /// <param name="soLuong"></param>
        /// <param name="ngayNhapKho"></param>
        /// <param name="giaBan"></param>
        /// <param name="giaNhapKho"></param>
        public HangHoa(string sanPham, string maHH, int soLuong, DateTime ngayNhapKho, double giaBan, double giaNhapKho)
        {
            this.SanPham = sanPham;
            this.MaHH = maHH;
            this.SoLuong = soLuong;
            this.NgayNhapKho = ngayNhapKho;
            this.GiaBan = giaBan;
            this.GiaNhapKho = giaNhapKho;
        }
        // methods:
        public string toString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string tr = "";
            tr = $"- Ten: {this.SanPham}\n- So Luong Con: {this.SoLuong}\n- Ngay Nhap Kho: {this.NgayNhapKho.Date}\n- Gia Nhap Kho: {this.GiaNhapKho}\n- Gia Ban: {this.GiaBan}";
            Console.ForegroundColor = ConsoleColor.White;
            return tr;
        }
    }
}
