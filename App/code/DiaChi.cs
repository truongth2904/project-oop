using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    class DiaChi
    {
        // field:
        private int soNha;
        private string tenDuong;
        private string tenPhuong;
        private string tenQuan;
        private string tenTP;

        // properties:
        public int SoNha
        {
            get
            {
                return soNha;
            }

            set
            {
                soNha = value;
            }
        }

        public string TenDuong
        {
            get
            {
                return tenDuong;
            }

            set
            {
                tenDuong = value;
            }
        }

        public string TenPhuong
        {
            get
            {
                return tenPhuong;
            }

            set
            {
                tenPhuong = value;
            }
        }

        public string TenQuan
        {
            get
            {
                return tenQuan;
            }

            set
            {
                tenQuan = value;
            }
        }

        public string TenTP
        {
            get
            {
                return tenTP;
            }

            set
            {
                tenTP = value;
            }
        }

        // constructor:
        /// <summary>
        /// Khai bao khong tham so!
        /// </summary>
        public DiaChi()
        {
            this.SoNha = 53;
            this.TenDuong = "Vo Van Ngan";
            this.TenPhuong = "Linh Chieu";
            this.TenQuan = "Thu Duc";
            this.TenTP = "TP HCM";
        }
        /// <summary>
        /// Khai bao day du tham so!
        /// </summary>
        /// <param name="soNha"></param>
        /// <param name="tenDuong"></param>
        /// <param name="tenPhuong"></param>
        /// <param name="tenQuan"></param>
        /// <param name="tenTP"></param>
        public DiaChi(int soNha, string tenDuong, string tenPhuong, string tenQuan, string tenTP)
        {
            this.SoNha = soNha;
            this.TenDuong = tenDuong;
            this.TenPhuong = tenPhuong;
            this.TenQuan = tenQuan;
            this.TenTP = tenTP;
        }
        // methods:
        public string toString()
        {
            string tr = "";
            tr = $"- {this.SoNha}, {this.TenDuong}, {this.TenPhuong}, {this.TenQuan}, {this.TenTP}";
            return tr;
        }
    }
}
