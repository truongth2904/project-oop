using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    class Nguoi
    {
        // fields:
        private string hoTen;
        private DateTime ngaySinh;
        private string sCMND;
        private string sDT;
        private DiaChi diaChi;

        // properties
        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public string SCMND
        {
            get
            {
                return sCMND;
            }

            set
            {
                sCMND = value;
            }
        }

        public string SDT
        {
            get
            {
                return sDT;
            }

            set
            {
                sDT = value;
            }
        }

        internal DiaChi DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        // constructor:
        /// <summary>
        /// Khai bao khong tham so!
        /// </summary>
        public Nguoi()
        {
            this.HoTen = "Nguyen Van A";
            this.SDT = "0000000000";
            this.SCMND = "000000000";
            this.DiaChi = new DiaChi();
            this.NgaySinh = new DateTime();
        }
        /// <summary>
        /// Khai bao day du tham so!
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="sCMND"></param>
        /// <param name="sDT"></param>
        /// <param name="diaChi"></param>
        public Nguoi(string hoTen,DateTime ngaySinh,string sCMND,string sDT, DiaChi diaChi)
        {
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.SCMND = sCMND;
            this.SDT = sDT;
            this.DiaChi = diaChi;
        }

        // methods:
        public virtual string toString()
        {
            string tr;
            tr = $"- Ho ten: {this.HoTen}.\n- Ngay sinh: {this.NgaySinh.Date}.\n- CMND: {this.SCMND}.\n- SDT: {this.SDT}.\n- Dia chi: {DiaChi.toString()}";
            return tr;
        }
    }
}
