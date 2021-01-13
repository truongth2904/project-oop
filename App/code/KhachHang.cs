using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    class KhachHang:Nguoi
    {
        // fields:
        private string maKH;

        // properties
        public string MaKH
        {
            get
            {
                return maKH;
            }

            set
            {
                maKH = value;
            }
        }

        // constructor
        /// <summary>
        /// Khai bao khong tham so!
        /// </summary>
        public KhachHang() : base()
        {
            this.MaKH = "0000";
            
        }
        /// <summary>
        /// Khai bao day du tham so!
        /// </summary>
        /// <param name="maKH"></param>
        /// <param name="hoTen"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="sCMND"></param>
        /// <param name="sDT"></param>
        /// <param name="diaChi"></param>
        public KhachHang(string maKH,string hoTen, DateTime ngaySinh,string sCMND, string sDT, DiaChi diaChi):base(hoTen, ngaySinh,sCMND, sDT, diaChi)
        {
            this.MaKH = maKH;
        }

        // methods
        public override string toString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string tr;
            tr = $"- Ma khach hang: {this.MaKH}. \n{base.toString()}";
            Console.ForegroundColor = ConsoleColor.White;
            return tr;
        }
    }
}
