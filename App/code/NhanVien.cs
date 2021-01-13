using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    class NhanVien : Nguoi
    {
        //field:
        private string maNV;

        // properties:
        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        // constructor:
        /// <summary>
        /// Khai bao khong tham so!
        /// </summary>
        public NhanVien() : base()
        {
            this.MaNV = "000";
        }
        /// <summary>
        /// Khai bao day du tham so!
        /// </summary>
        /// <param name="maNV"></param>
        /// <param name="hoTen"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="sCMND"></param>
        /// <param name="sDT"></param>
        /// <param name="diaChi"></param>
        public NhanVien(string maNV, string hoTen, DateTime ngaySinh, string sCMND, string sDT, DiaChi diaChi) : base(hoTen, ngaySinh, sCMND, sDT, diaChi)
        {
            this.MaNV = maNV;
        }

        //method:
        public override string toString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string tr;
            tr = $"- Ma nhan vien: {this.MaNV}. \n{ base.toString()}";
            Console.ForegroundColor = ConsoleColor.White;
            return tr;
        }
    }
}
