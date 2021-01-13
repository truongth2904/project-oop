using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace QuanLyBanHang
{
    class Program
    {
        static void Main(string[] args)
        {
            HangHoa[] arrHH = NhapHH();
            KhachHang[] arrKH = NhapKH();
            NhanVien[] arrNV = NhapNV();
            HoaDon[] arrHD = NhapHD(arrHH, arrKH, arrNV);
            Logo();
            Console.ReadKey();
            Console.Clear();
        back:
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            centerText("TDC");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            centerText("HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN ĐIỆN THOẠI");
            centerText("_____________________________________");
            Console.WriteLine();
            Menu(arrHH, arrKH, arrNV, arrHD);
            Console.Read();
            Console.Clear();
            goto back;
        }
        // Logo:
        static void Logo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            centerText("TRƯỜNG CAO ĐẲNG CÔNG NGHỆ THỦ ĐỨC");
            centerText("KHOA CÔNG NGHỆ THÔNG TIN");
            centerText("TDC");
            centerText("-------ooo-------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            centerText("HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN ĐIỆN THOẠI");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            centerText("_._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            centerText("Giáo viên hướng dẫn:    Lâm Thị Phương Thảo");
            Console.WriteLine();
            centerText("Nhóm thực hiện(nhóm 18):  Nguyễn Ngọc Trường   -   19211TT1221");
            centerText("                          Trần Quốc Trị        -   19211TT1244");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\t\tNgày hoạt động: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Ngày {DateTime.Now.Day} Tháng {DateTime.Now.Month} Năm {DateTime.Now.Year}");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\tThông tin liên hệ: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t - Số điện thoại liên hệ:   0393534323");
            Console.WriteLine("\t\t\t - Giờ mở cửa:              7.a.m -> 9.p.m.");
            Console.WriteLine("\t\t\t - Trang web online:        https://www.dtdd.tt.com");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            centerText("_._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._._");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\t\t\t\t\t\tEnter de tiep tuc...");
        }
        // Ham can giua
        private static void centerText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
        // Menu chuong trinh:
        static void Menu(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV, HoaDon[] arrHD)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            centerText("******************************************");
            centerText("1.Xem Thong Tin.");
            centerText("2.Them Thong Tin.");
            centerText("3.Sua thong tin. ");
            centerText("4.Xoa thong tin.");
            centerText("******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            int chucnang = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out chucnang);
            } while (chucnang <= 0 || chucnang >= 5);
            ChoMotChut();
            Console.Clear();
            switch (chucnang)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    centerText("TDC");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    centerText("HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN ĐIỆN THOẠI");
                    centerText("_____________________________________");
                    Console.WriteLine();
                    XemTT(arrHH, arrKH, arrNV, arrHD);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    centerText("TDC");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    centerText("HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN ĐIỆN THOẠI");
                    centerText("_____________________________________");
                    Console.WriteLine();
                    ThemTT(arrHH, arrKH, arrNV, arrHD);
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    centerText("TDC");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    centerText("HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN ĐIỆN THOẠI");
                    centerText("_____________________________________");
                    Console.WriteLine();
                    SuaTT(arrHH, arrKH, arrNV, arrHD);
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    centerText("TDC");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    centerText("HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN ĐIỆN THOẠI");
                    centerText("_____________________________________");
                    Console.WriteLine();
                    XoaTT(arrHH, arrKH, arrNV, arrHD);
                    break;
            }
        }
        // Ham xoa thong tin:
        static void XoaTT(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV, HoaDon[] arrHD)
        {
            int chucnang = 0;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            centerText("****************************************");
            centerText("1.Xoa hoa don.");
            centerText("2.Xoa hang hoa khong co trong hoa don nao.");
            centerText("3.Xoa khach hang khong co hoa don nao.");
            centerText("****************************************");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Write("Ban chon: ");
                int.TryParse(Console.ReadLine(), out chucnang);
            } while (chucnang < 1 || chucnang > 3);
            Console.Clear();
            switch (chucnang)
            {
                case 1:
                    arrHD = XoaHoaDon(arrHD, arrHH, arrKH, arrNV);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 2:
                    arrHH = XoaHangHoa(arrHH, arrHD);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 3:
                    arrKH = XoaKhachHang(arrKH, arrHD);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
            }
        }
        // Ham sua thong tin:
        static void SuaTT(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV, HoaDon[] arrHD)
        {
            int chucnang3 = 0;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            centerText("******************************");
            centerText("1.Sua thong tin hang hoa.");
            centerText("2.Sua thong tin khach hang.");
            centerText("3.Sua thong tin nhan vien.");
            centerText("4.Sua thong tin hoa don.");
            centerText("******************************");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Write("Ban chon chuc nang: ");
                int.TryParse(Console.ReadLine(), out chucnang3);
            } while (chucnang3 <= 0 || chucnang3 >= 5);
            switch (chucnang3)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    arrHH = SuaHH(arrHH);
                    using (StreamWriter sw = new StreamWriter(@"HH.txt"))
                    {
                        sw.WriteLine(arrHH.Length);
                        for (int j = 0; j < arrHH.Length; j++)
                        {
                            sw.WriteLine($"{arrHH[j].SanPham}#{arrHH[j].MaHH}#{arrHH[j].SoLuong}#{arrHH[j].NgayNhapKho}#{arrHH[j].GiaBan}#{arrHH[j].GiaNhapKho}");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    arrKH = SuaKH(arrKH);
                    using (StreamWriter sw = new StreamWriter(@"KH.txt"))
                    {
                        sw.WriteLine(arrKH.Length);
                        for (int j = 0; j < arrKH.Length; j++)
                        {
                            sw.WriteLine($"{arrKH[j].HoTen}#{arrKH[j].MaKH}#{arrKH[j].SDT}#{arrKH[j].SCMND}#{arrKH[j].NgaySinh}#{arrKH[j].DiaChi.SoNha}#{arrKH[j].DiaChi.TenDuong}#{arrKH[j].DiaChi.TenPhuong}#{arrKH[j].DiaChi.TenQuan}#{arrKH[j].DiaChi.TenTP}");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    arrNV = SuaNV(arrNV);
                    using (StreamWriter sw = new StreamWriter(@"NV.txt"))
                    {
                        sw.WriteLine(arrNV.Length);
                        for (int j = 0; j < arrNV.Length; j++)
                        {
                            sw.WriteLine($"{arrNV[j].HoTen}#{arrNV[j].NgaySinh}#{arrNV[j].SCMND}#{arrNV[j].MaNV}#{arrNV[j].SDT}#{arrNV[j].DiaChi.SoNha}#{arrNV[j].DiaChi.TenDuong}#{arrNV[j].DiaChi.TenPhuong}#{arrNV[j].DiaChi.TenQuan}#{arrNV[j].DiaChi.TenTP}");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    arrHD = SuaHD(arrHD, arrNV, arrKH, arrHH);
                    using (StreamWriter sw = new StreamWriter(@"HD.txt"))
                    {
                        sw.WriteLine(arrHD.Length);
                        for (int j = 0; j < arrHD.Length; j++)
                        {
                            string manghh = "";
                            for (LinkedListNode<HangHoa> p = arrHD[j].SanPham.First; p != null; p = p.Next)
                            {
                                manghh += $"{p.Value.MaHH}#";
                            }
                            sw.WriteLine($"{arrHD[j].MaHD}#{arrHD[j].NgayMua}#{arrHD[j].SanPham.Count()}#{manghh}{arrHD[j].NhanVien.MaNV}#{arrHD[j].KhachHang.MaKH}");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
            }
        }
        // Ham xem thong tin:
        static void XemTT(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV, HoaDon[] arrHD)
        {

            int chucnang_1;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            centerText("*******************************");
            centerText("1.Xem thong tin hang hoa.");
            centerText("2.Xem thong tin nhan vien.");
            centerText("3.Xem thong tin hoa don.");
            centerText("4.Xem thong tin khach hang.");
            centerText("5.Xem danh sach");
            centerText("*******************************");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Write("Ban chon: ");
                int.TryParse(Console.ReadLine(), out chucnang_1);
            } while (chucnang_1 <= 0 || chucnang_1 >= 6);
            switch (chucnang_1)
            {
                case 1:
                    XemHH(arrHH);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 2:
                    XemNV(arrNV);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 3:
                    XemHD(arrHD);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 4:
                    XemKH(arrKH);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 5:
                    XemDS(arrHH, arrKH, arrNV, arrHD);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Ham them thong tin:
        static void ThemTT(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV, HoaDon[] arrHD)
        {
            int chucnang_2;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            centerText("****************************");
            centerText("1.Them hang hoa.");
            centerText("2.Them nhan vien.");
            centerText("3.Them khach hang.");
            centerText("4.Them hoa don.");
            centerText("****************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            do
            {
                Console.Write("Ban chon: ");
                int.TryParse(Console.ReadLine(), out chucnang_2);
            } while (chucnang_2 <= 0 || chucnang_2 >= 5);
            ChoMotChut();
            switch (chucnang_2)
            {
                case 1:
                    arrHH = ThemHH(arrHH);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 2:
                    arrNV = ThemNV(arrNV);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 3:
                    arrKH = ThemKH(arrKH);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
                case 4:
                    arrHD = ThemHD(arrHH, arrKH, arrNV, arrHD);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter de tiep tuc...");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Ham xem cac danh sach:
        static void XemDS(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV, HoaDon[] arrHD)
        {
            Console.Clear();
            int chucnang;
            Console.ForegroundColor = ConsoleColor.Red;
            centerText("TDC");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            centerText("*******************************");
            centerText("1.Xem danh sach cac hang hoa.");
            centerText("2.Xem danh sach cac nhan vien.");
            centerText("3.Xem danh sach cac khach hang.");
            centerText("4.Xem danh sach cac hoa don.");
            centerText("*******************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            do
            {
                Console.Write("Ban chon: ");
                int.TryParse(Console.ReadLine(), out chucnang);
            } while (chucnang <= 0 || chucnang >= 5);
            switch (chucnang)
            {
                case 1:
                    XemDSHH(arrHH);
                    break;
                case 2:
                    XemDSNV(arrNV);
                    break;
                case 3:
                    XemDSKH(arrKH);
                    break;
                case 4:
                    XemDSHD(arrHD);
                    break;
            }
        }
        // Xoa khach hang khong co hoa don nao
        static KhachHang[] XoaKhachHang(KhachHang[] arrKH, HoaDon[] arrHD)
        {
            int[] KH = new int[arrKH.Length];
            for (int k = 0; k < arrHD.Length; k++)
            {
                for (int g = 0; g < KH.Length; g++)
                {

                    if (arrHD[k].KhachHang.MaKH == $"KH0{g + 1}")
                    {
                        KH[g]++;
                    }
                    else
                    {
                        if (arrHD[k].KhachHang.MaKH == $"KH{g + 1}")
                        {
                            KH[g]++;
                        }
                    }
                }
            }
            int dem = 0;
            for (int i = 0; i < KH.Length; i++)
            {
                if (KH[i] == 0)
                {
                    dem++;
                }
            }
            ChoMotChut();
            using (StreamWriter sw = new StreamWriter(@"KH.txt"))
            {
                sw.WriteLine(arrKH.Length - dem);
                for (int j = 0; j < arrKH.Length; j++)
                {
                    if (KH[j] != 0)
                    {
                        sw.WriteLine($"{arrKH[j].HoTen}#{arrKH[j].MaKH}#{arrKH[j].SDT}#{arrKH[j].SCMND}#{arrKH[j].NgaySinh}#{arrKH[j].DiaChi.SoNha}#{arrKH[j].DiaChi.TenDuong}#{arrKH[j].DiaChi.TenPhuong}#{arrKH[j].DiaChi.TenQuan}#{arrKH[j].DiaChi.TenTP}");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Da xoa cac khach hang khong co trong hoa don nao.");
            arrKH = NhapKH();
            return arrKH;
        }
        // Xoa hang hoa khong nam trong hoa don nao
        static HangHoa[] XoaHangHoa(HangHoa[] arrHH, HoaDon[] arrHD)
        {
            int[] HH = new int[arrHH.Length];
            for (int i = 0; i < arrHD.Length; i++)
            {
                for (LinkedListNode<HangHoa> p = arrHD[i].SanPham.First; p != null; p = p.Next)
                {
                    for (int k = 0; k < HH.Length; k++)
                    {
                        if (p.Value.MaHH == $"HH0{k + 1}")
                        {
                            HH[k]++;
                        }
                        else
                        {
                            if (p.Value.MaHH == $"HH{k + 1}")
                            {
                                HH[k]++;
                            }
                        }
                    }
                }
            }
            int dem = 0;
            for (int h = 0; h < HH.Length; h++)
            {
                if (HH[h] == 0)
                {
                    dem++;
                }
            }
            ChoMotChut();
            using (StreamWriter sw = new StreamWriter(@"HH.txt"))
            {
                sw.WriteLine(arrHH.Length - dem);
                for (int j = 0; j < arrHH.Length; j++)
                {
                    if (HH[j] != 0)
                    {
                        sw.WriteLine($"{arrHH[j].SanPham}#{arrHH[j].MaHH}#{arrHH[j].SoLuong}#{arrHH[j].NgayNhapKho}#{arrHH[j].GiaBan}#{arrHH[j].GiaNhapKho}");
                    }
                }
            }
            arrHH = NhapHH();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Da xoa cac hang hoa khong co trong hoa don.");
            return arrHH;
        }
        // Xoa hoa don
        static HoaDon[] XoaHoaDon(HoaDon[] arrHD, HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV)
        {
            string mahd = "";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Nhap ma hoa don can xoa(vd:HD01,HD02,..): ");
        aa:
            mahd = Console.ReadLine();
            if (KTmaHD(mahd) == false || KTmaHD_Trung(arrHD, mahd) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma hoa don {mahd} khong co, vui long nhap ma hoa don khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            int i;
            for (i = 0; i < arrHD.Length; i++)
            {
                if (mahd == arrHD[i].MaHD)
                {
                    break;
                }
            }
            for (; i < arrHD.Length - 1; i++)
            {
                arrHD[i] = arrHD[i + 1];
            }
            using (StreamWriter sw = new StreamWriter(@"HD.txt"))
            {
                sw.WriteLine(arrHD.Length - 1);
                for (int j = 0; j < arrHD.Length - 1; j++)
                {
                    string manghh = "";
                    for (LinkedListNode<HangHoa> p = arrHD[j].SanPham.First; p != null; p = p.Next)
                    {
                        manghh += $"{p.Value.MaHH}#";
                    }
                    sw.WriteLine($"{arrHD[j].MaHD}#{arrHD[j].NgayMua}#{arrHD[j].SoLuongMua}#{manghh}{arrHD[j].NhanVien.MaNV}#{arrHD[j].KhachHang.MaKH}");
                }
            }
            arrHD = NhapHD(arrHH, arrKH, arrNV);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Da xoa thanh cong !");
            return arrHD;
        }
        // Ham sua thong tin hoa don:
        static HoaDon[] SuaHD(HoaDon[] arrHD, NhanVien[] arrNV, KhachHang[] arrKH, HangHoa[] arrHH)
        {
            string mahd = "";
            int chucnang = 0;
            Console.Write("Nhap ma hoa don can sua thong tin(vd:HD01,HD02,..): ");
        aa:
            mahd = Console.ReadLine();
            if (KTmaHD(mahd) == false || KTmaHD_Trung(arrHD, mahd) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma hoa don {mahd} khong co, vui long nhap ma hoa don khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            int i;
            for (i = 0; i < arrHD.Length; i++)
            {
                if (mahd == arrHD[i].MaHD)
                {
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            centerText("Chon thong tin muon sua.");
            centerText($"1.Sua nhan vien lap hoa don: {arrHD[i].NhanVien.HoTen}\t MaNV: {arrHD[i].NhanVien.MaNV}");
            centerText($"2.Sua khach hang mua: {arrHD[i].KhachHang.HoTen}\t MaKH: {arrHD[i].KhachHang.MaKH}");
            centerText("3.Sua cac hang hoa trong hoa don.");
            int.TryParse(Console.ReadLine(), out chucnang);
            Console.ResetColor();
            Console.Clear();
            switch (chucnang)
            {
                case 1:
                    string manv = "";
                    Console.WriteLine($"Nhan vien lap hoa don cho {arrHD[i].MaHD} la: {arrHD[i].NhanVien.HoTen}\tMaNV: {arrHD[i].NhanVien.MaNV}.");
                    Console.Write("Ban muon sua thanh(Nhap ma nhan vien:): ");
                bb:
                    manv = Console.ReadLine();
                    if (KTmaNV(manv) == false || KTmaNV_Trung(arrNV, manv) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"MaNV {manv} khong co, vui long nhap ma nhan vien khac: ");
                        goto bb;
                    }
                    Console.ResetColor();
                    for (int j = 0; j < arrNV.Length; j++)
                    {
                        if (manv == arrNV[j].MaNV)
                        {
                            arrHD[i].NhanVien = arrNV[j];
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    arrHD[i].toString();
                    break;
                case 2:
                    string makh = "";
                    Console.WriteLine($"Khach hang mua hoa don nay la {arrHD[i].KhachHang.HoTen}\tMaKH: {arrHD[i].KhachHang.MaKH}.");
                    Console.Write("Ban muon sua thanh(Nhap ma khach hang): ");
                cc:
                    makh = Console.ReadLine();
                    if (KTmaKH(makh) == false || KTmaKH_Trung(arrKH, makh) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"MaKH {makh} khong co, vui long nhap ma khach hang khac: ");
                        goto cc;
                    }
                    Console.ResetColor();
                    for (int j = 0; j < arrKH.Length; j++)
                    {
                        if (makh == arrKH[j].MaKH)
                        {
                            arrHD[i].KhachHang = arrKH[j];
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    arrHD[i].toString();
                    break;
                case 3:
                    int chucnang_3 = 0;
                    Console.WriteLine($"Hang hoa trong hoa don nay la:");
                    int a = 0;
                    for (LinkedListNode<HangHoa> p = arrHD[i].SanPham.First; p != null; p = p.Next, a++)
                    {
                        Console.WriteLine($"{a + 1}.{p.Value.SanPham}\t {p.Value.MaHH}");
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1.Ban muon them hang hoa.");
                    Console.WriteLine("2.Ban muon xoa bot hang hoa.");
                    Console.Write("Ban chon: ");
                    int.TryParse(Console.ReadLine(), out chucnang_3);
                    Console.ResetColor();
                    ChoMotChut();
                    Console.Clear();
                    switch (chucnang_3)
                    {
                        case 1:
                            int sohangthem = 0;
                            Console.Write("Nhap so hang hoa muon them: ");
                            int.TryParse(Console.ReadLine(), out sohangthem);
                            for (int j = 0; j < sohangthem; j++)
                            {
                                string mahh;
                                Console.Write($"Nhap ma hang hoa thu {j + 1}: ");
                            dd:
                                mahh = Console.ReadLine();
                                if (KTmaHH(mahh) == false || KTmaHH_Trung(arrHH, mahh) == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write($"Ma hang {mahh} khong ton tai trong kho hang, vui long nhap ma hang hoa khac: ");
                                    goto dd;
                                }
                                Console.ResetColor();
                                for (int k = 0; k < arrHH.Length; k++)
                                {
                                    if (mahh == arrHH[k].MaHH)
                                    {
                                        arrHD[i].SanPham.AddLast(arrHH[k]);
                                    }
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Da sua thanh cong !");
                            arrHD[i].toString();
                            break;
                        case 2:
                            string mahh2;
                            Console.WriteLine($"Hang hoa trong hoa don nay la:");
                            int e = 0;
                            for (LinkedListNode<HangHoa> p = arrHD[i].SanPham.First; p != null; p = p.Next, e++)
                            {
                                Console.WriteLine($"{e + 1}.{p.Value.SanPham}\t {p.Value.MaHH}");
                            }
                            Console.Write("Nhap ma hang hoa can xoa trong hoa don: ");
                        ee:
                            mahh2 = Console.ReadLine();
                            if (KiemTra_HH_HD(mahh2, arrHD[i].SanPham) == false || KTmaHH(mahh2) == false || KTmaHH_Trung(arrHH, mahh2) == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"MaHH {mahh2} khong co trong hoa don nay, vui long nhap ma hang hoa khac: ");
                                goto ee;
                            }
                            Console.ResetColor();
                            int dem = 0;
                            for (LinkedListNode<HangHoa> p = arrHD[i].SanPham.First; p != null; p = p.Next)
                            {
                                if (mahh2 == p.Value.MaHH)
                                {
                                    arrHD[i].SanPham.Remove(p.Value);
                                    dem++;
                                }
                            }
                            if (dem == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Ma hang {mahh2} khong co trong hoa don.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Da sua thanh cong !");
                                arrHD[i].toString();
                            }
                            break;
                    }
                    Console.Clear();
                    ChoMotChut();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    arrHD[i].toString();
                    break;
            }

            return arrHD;
        }
        // Ham kiem tra hang hoa co trong hoa don hay khong:
        static bool KiemTra_HH_HD(string MaHH, LinkedList<HangHoa> p)
        {
            for (LinkedListNode<HangHoa> q = p.First; q != null; q = q.Next)
            {
                if (MaHH == q.Value.MaHH)
                {
                    return true;
                }
            }
            return false;
        }
        // Ham sua thong tin nhan vien:
        static NhanVien[] SuaNV(NhanVien[] arrNV)
        {
            string manv = "";
            int chucnang = 0;
            Console.Write("Nhap ma nhan vien can sua thong tin(vd:KH01,KH02,..): ");
        aa:
            manv = Console.ReadLine();
            if (KTmaNV(manv) == false || KTmaNV_Trung(arrNV, manv) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Nhan vien {manv} khong co, vui long nhap ma nhan vien khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            int i;
            for (i = 0; i < arrNV.Length; i++)
            {
                if (manv == arrNV[i].MaNV)
                {
                    break;
                }
            }
            Console.WriteLine("Chon thong tin muon sua.");
            Console.WriteLine($"1.Ho ten nhan vien: {arrNV[i].HoTen}");
            Console.WriteLine($"2.So dien thoai: {arrNV[i].SDT}");
            Console.WriteLine($"3.Dia chi: {arrNV[i].DiaChi.toString()}");
            Console.Write("Ban chon: ");
            int.TryParse(Console.ReadLine(), out chucnang);
            switch (chucnang)
            {
                case 1:
                    string hoten = "";
                    Console.WriteLine($"Ho ten cua nhan vien {arrNV[i].MaNV} la: {arrNV[i].HoTen}.");
                    Console.Write("Ban muon sua thanh: ");
                    hoten = Console.ReadLine();
                    arrNV[i].HoTen = hoten;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    Console.WriteLine(arrNV[i].toString());
                    break;
                case 2:
                    string sdt = "";
                    Console.WriteLine($"So dien thoai cua nhan vien {arrNV[i].MaNV} la: {arrNV[i].SDT}.");
                    Console.Write("Ban muon sua thanh: ");
                    sdt = Console.ReadLine();
                    arrNV[i].SDT = sdt;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    Console.WriteLine(arrNV[i].toString());
                    break;
                case 3:
                    int sonha = 0;
                    DiaChi dc = new DiaChi();
                    string duong, phuong, quan, tp;
                    Console.WriteLine($"Dia chi cua nhan vien {arrNV[i].MaNV} la: {arrNV[i].DiaChi.toString()}.");
                    Console.WriteLine("Ban muon sua lai thanh ");
                    Console.Write("Nhap so nha: ");
                    int.TryParse(Console.ReadLine(), out sonha);
                    Console.Write("Nhap ten duong: ");
                    duong = Console.ReadLine();
                    Console.Write("Nhap ten phuong: ");
                    phuong = Console.ReadLine();
                    Console.Write("Nhap ten Quan: ");
                    quan = Console.ReadLine();
                    Console.Write("Nhap ten TP: ");
                    tp = Console.ReadLine();
                    dc = new DiaChi(sonha, duong, phuong, quan, tp);
                    arrNV[i].DiaChi = dc;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    Console.WriteLine(arrNV[i].toString());
                    break;
            }
            using (StreamWriter sw = new StreamWriter(@"NV.txt"))
            {
                sw.WriteLine(arrNV.Length);
                for (int j = 0; j < arrNV.Length; j++)
                {
                    sw.WriteLine($"{arrNV[j].HoTen}#{arrNV[j].NgaySinh}#{arrNV[j].SCMND}#{arrNV[j].MaNV}#{arrNV[j].SDT}#{arrNV[j].DiaChi.SoNha}#{arrNV[j].DiaChi.TenDuong}#{arrNV[j].DiaChi.TenPhuong}#{arrNV[j].DiaChi.TenQuan}#{arrNV[j].DiaChi.TenTP}");
                }
            }
            return arrNV;
        }
        // Ham sua thong tin khach hang:
        static KhachHang[] SuaKH(KhachHang[] arrKH)
        {
            string makh = "";
            int chucnang = 0;
            Console.Write("Nhap ma khach hang can sua thong tin(vd:KH01,KH02,..): ");
        aa:
            makh = Console.ReadLine();
            if (KTmaKH(makh) == false || KTmaKH_Trung(arrKH, makh) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma khach hang {makh} khong co, vui long nhap ma khach hang khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            int i;
            for (i = 0; i < arrKH.Length; i++)
            {
                if (makh == arrKH[i].MaKH)
                {
                    break;
                }
            }
            Console.WriteLine("Chon thong tin muon sua.");
            Console.WriteLine($"1.Ho ten khach hang: {arrKH[i].HoTen}");
            Console.WriteLine($"2.So dien thoai: {arrKH[i].SDT}");
            Console.WriteLine($"3.Dia chi: {arrKH[i].DiaChi.toString()}");
            Console.Write("Ban chon: ");
            int.TryParse(Console.ReadLine(), out chucnang);
            switch (chucnang)
            {
                case 1:
                    string hoten = "";
                    Console.WriteLine($"Ho ten cua khach hang {arrKH[i].MaKH} la: {arrKH[i].HoTen}.");
                    Console.Write("Ban muon sua thanh: ");
                    hoten = Console.ReadLine();
                    arrKH[i].HoTen = hoten;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    Console.WriteLine(arrKH[i].toString());
                    break;
                case 2:
                    string sdt = "";
                    Console.WriteLine($"So dien thoai cua khach hang {arrKH[i].MaKH} la: {arrKH[i].SDT}.");
                    Console.Write("Ban muon sua thanh: ");
                    sdt = Console.ReadLine();
                    arrKH[i].SDT = sdt;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    Console.WriteLine(arrKH[i].toString());
                    break;
                case 3:
                    int sonha = 0;
                    DiaChi dc = new DiaChi();
                    string duong, phuong, quan, tp;
                    Console.WriteLine($"Dia chi cua khach hang {arrKH[i].MaKH} la: {arrKH[i].DiaChi.toString()}.");
                    Console.WriteLine("Ban muon sua lai thanh ");
                    Console.Write("Nhap so nha: ");
                    int.TryParse(Console.ReadLine(), out sonha);
                    Console.Write("Nhap ten duong: ");
                    duong = Console.ReadLine();
                    Console.Write("Nhap ten phuong: ");
                    phuong = Console.ReadLine();
                    Console.Write("Nhap ten Quan: ");
                    quan = Console.ReadLine();
                    Console.Write("Nhap ten TP: ");
                    tp = Console.ReadLine();
                    dc = new DiaChi(sonha, duong, phuong, quan, tp);
                    arrKH[i].DiaChi = dc;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong!");
                    Console.WriteLine(arrKH[i].toString());
                    break;
            }
            using (StreamWriter sw = new StreamWriter(@"KH.txt"))
            {
                sw.WriteLine(arrKH.Length);
                for (int j = 0; j < arrKH.Length; j++)
                {
                    sw.WriteLine($"{arrKH[j].HoTen}#{arrKH[j].MaKH}#{arrKH[j].SDT}#{arrKH[j].SCMND}#{arrKH[j].NgaySinh}#{arrKH[j].DiaChi.SoNha}#{arrKH[j].DiaChi.TenDuong}#{arrKH[j].DiaChi.TenPhuong}#{arrKH[j].DiaChi.TenQuan}#{arrKH[j].DiaChi.TenTP}");
                }
            }
            return arrKH;
        }
        // Ham sua thong tin hang hoa:
        static HangHoa[] SuaHH(HangHoa[] arrHH)
        {
            string mahh = "";
            int chucnang = 0;
            Console.Write("Nhap ma hang hoa can sua thong tin(vd:HH01,HH02,...): ");
        aa:
            mahh = Console.ReadLine();
            if (KTmaHH(mahh) == false || KTmaHH_Trung(arrHH, mahh) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma hang hoa {mahh} khong co hang hoa nay, vui long nhap ma hang hoa khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            int i;
            for (i = 0; i < arrHH.Length; i++)
            {
                if (mahh == arrHH[i].MaHH)
                {
                    break;
                }
            }
            Console.WriteLine("Chon thong tin muon sua.");
            Console.WriteLine($"1.Ten hang hoa: {arrHH[i].SanPham}");
            Console.WriteLine($"2.So luong hang hoa: {arrHH[i].SoLuong}");
            Console.WriteLine($"3.Ngay nhap kho: {arrHH[i].NgayNhapKho}");
            Console.WriteLine($"4.Gia ban cua hang hoa: {arrHH[i].GiaBan}");
            Console.WriteLine($"5.Gia nhap kho cua hang hoa: {arrHH[i].GiaNhapKho}");
            Console.Write("Chon thong tin muon sua: ");
            int.TryParse(Console.ReadLine(), out chucnang);
            switch (chucnang)
            {
                case 1:
                    string tenhh = "";
                    Console.WriteLine($"Ten hang hoa cua {mahh} la: {arrHH[i].SanPham}.");
                    Console.Write("Ban muon sua thanh: ");
                    tenhh = Console.ReadLine();
                    arrHH[i].SanPham = tenhh;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong.");
                    Console.WriteLine(arrHH[i].toString());
                    break;
                case 2:
                    int soluong = 0;
                    Console.WriteLine($"So luong hang hoa cua {mahh} la: {arrHH[i].SoLuong}");
                    Console.Write("Ban muon sua thanh: ");
                    int.TryParse(Console.ReadLine(), out soluong);
                    arrHH[i].SoLuong = soluong;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong.");
                    Console.WriteLine(arrHH[i].toString());
                    break;
                case 3:
                    DateTime ngaynhap = new DateTime();
                    Console.WriteLine($"Ngay nhap kho cua {mahh} la: {arrHH[i].NgayNhapKho}");
                    Console.Write("Ban muon sua thanh: ");
                    DateTime.TryParse(Console.ReadLine(), out ngaynhap);
                    arrHH[i].NgayNhapKho = ngaynhap;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong.");
                    Console.WriteLine(arrHH[i].toString());
                    break;
                case 4:
                    double giaban = 0;
                    Console.WriteLine($"Gia nhap kho cua {mahh} la: {arrHH[i].GiaBan}");
                    Console.Write("Ban muon sua thanh: ");
                    double.TryParse(Console.ReadLine(), out giaban);
                    arrHH[i].GiaBan = giaban;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong.");
                    Console.WriteLine(arrHH[i].toString());
                    break;
                case 5:
                    double gianhap = 0;
                    Console.WriteLine($"Gia nhap kho cua {mahh} la: {arrHH[i].GiaNhapKho}");
                    Console.Write("Ban muon sua thanh: ");
                    double.TryParse(Console.ReadLine(), out gianhap);
                    arrHH[i].GiaBan = gianhap;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Da sua thanh cong.");
                    Console.WriteLine(arrHH[i].toString());
                    break;
            }
            using (StreamWriter sw = new StreamWriter(@"HH.txt"))
            {
                sw.WriteLine(arrHH.Length);
                for (int j = 0; j < arrHH.Length; j++)
                {
                    sw.WriteLine($"{arrHH[j].SanPham}#{arrHH[j].MaHH}#{arrHH[j].SoLuong}#{arrHH[j].NgayNhapKho}#{arrHH[j].GiaBan}#{arrHH[j].GiaNhapKho}");
                }
            }
            return arrHH;
        }
        // Xem thong tin hoa don:
        static void XemHD(HoaDon[] arrHD)
        {
            string mahd = "";
            Console.Write("Nhap ma hoa don can xem (vd:HD01,HD02,...): ");
        aa:
            mahd = Console.ReadLine();
            if (KTmaHD(mahd) == false || KTmaHD_Trung(arrHD, mahd) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma hoa don {mahd} khong co, vui long nhap ma hoa don khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrHD.Length; i++)
            {
                if (mahd == arrHD[i].MaHD)
                {
                    arrHD[i].toString();
                }
            }
        }
        // Xem thong tin khach hang:
        static void XemKH(KhachHang[] arrKH)
        {
            string makh = "";
            Console.Write("Nhap ma khach hang can xem (vd:KH01,KH02,..): ");
        aa:
            makh = Console.ReadLine();
            if (KTmaKH(makh) == false || KTmaKH_Trung(arrKH, makh) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma khach hang {makh} khong co, vui long nhap ma khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrKH.Length; i++)
            {
                if (makh == arrKH[i].MaKH)
                {
                    Console.WriteLine(arrKH[i].toString());
                }
            }
        }
        // Xem thong tin nhan vien:
        static void XemNV(NhanVien[] arrNV)
        {
            string manv = "";
            Console.Write("Nhap ma nhan vien can xem (vd:NV01,NV02,...): ");
        aa:
            manv = Console.ReadLine();
            if (KTmaNV(manv) == false || KTmaNV_Trung(arrNV, manv) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma nhan vien {manv} khong co, vui long nhap ma khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrNV.Length; i++)
            {
                if (manv == arrNV[i].MaNV)
                {
                    Console.WriteLine(arrNV[i].toString());
                }
            }
        }
        // Xem thong tin hang hoa:
        static void XemHH(HangHoa[] arrHH)
        {
            string mahh = "";
            Console.Write("Nhap ma hang hoa can xem (vd:HH01,HH02,...): ");
        aa:
            mahh = Console.ReadLine();
            if (KTmaHH(mahh) == false || KTmaHH_Trung(arrHH, mahh) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma hang {mahh} khong co, vui long nhap ma khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrHH.Length; i++)
            {
                if (mahh == arrHH[i].MaHH)
                {
                    Console.WriteLine(arrHH[i].toString());
                }
            }
        }
        // Xem danh sach cac hang hoa:
        static void XemDSHH(HangHoa[] arrHH)
        {
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrHH.Length; i++)
            {
                Console.WriteLine($"- {i + 1}. {arrHH[i].SanPham}\t Gia: {arrHH[i].GiaBan}");
            }
        }
        // Xem danh sach khach hang:
        static void XemDSKH(KhachHang[] arrKH)
        {
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrKH.Length; i++)
            {
                Console.WriteLine($"- {i + 1}. {arrKH[i].HoTen}\t - MaKH: {arrKH[i].MaKH}");
            }
        }
        // Xem danh sach nhan vien:
        static void XemDSNV(NhanVien[] arrNV)
        {
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrNV.Length; i++)
            {
                Console.WriteLine($"- {i + 1}. {arrNV[i].HoTen}\t - MaNV: {arrNV[i].MaNV}");
            }
        }
        // Xem danh sach hoa don:
        static void XemDSHD(HoaDon[] arrHD)
        {
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            for (int i = 0; i < arrHD.Length; i++)
            {
                Console.WriteLine($"- {i + 1}. MaHD: {arrHD[i].MaHD}\t - Gia tien: {arrHD[i].getTinhTien()}");
            }
        }
        // Ham them nhan vien:
        static NhanVien[] ThemNV(NhanVien[] arrNV)
        {
            int soNVmoi = arrNV.Length + 1;
            DateTime ngaySinh;
            string sCMND, hoTen, sDT;
            DiaChi diaChi = new DiaChi();
            NhanVien[] arrNVmoi = new NhanVien[soNVmoi];
            for (int i = 0; i < arrNV.Length; i++)
            {
                arrNVmoi[i] = arrNV[i];
            }
            int soNha;
            string tenDuong;
            string tenPhuong;
            string tenQuan;
            string tenTP;
            string manvthem = "";
            Console.Write("Nhap ma nhan vien can them (vd: NV01,NV02,..): ");
        aa:
            manvthem = Console.ReadLine();
            if (KTmaNV(manvthem) == false || KTmaNV_Trung(arrNV, manvthem))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma nhan vien {manvthem} da ton tai, vui long nhap ma nhan vien khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            Console.WriteLine("---Nhap thong tin cho nhan vien them.");
            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhap CMND: ");
            sCMND = Console.ReadLine();
            Console.Write("Nhap so dien thoai: ");
            sDT = Console.ReadLine();
            Console.Write("Nhap ngay sinh: ");
            DateTime.TryParse(Console.ReadLine(), out ngaySinh);
            Console.WriteLine("Nhap dia chi.");
            Console.Write("So nha: ");
            int.TryParse(Console.ReadLine(), out soNha);
            Console.Write("Ten duong: ");
            tenDuong = Console.ReadLine();
            Console.Write("Ten phuong: ");
            tenPhuong = Console.ReadLine();
            Console.Write("Ten quan: ");
            tenQuan = Console.ReadLine();
            Console.Write("Ten TP: ");
            tenTP = Console.ReadLine();
            diaChi = new DiaChi(soNha, tenDuong, tenPhuong, tenQuan, tenTP);
            arrNVmoi[soNVmoi - 1] = new NhanVien(manvthem, hoTen, ngaySinh, sCMND, sDT, diaChi);
            Console.Clear();
            ChoMotChut();
            using (StreamWriter sw = new StreamWriter(@"NV.txt"))
            {
                sw.WriteLine(arrNVmoi.Length);
                for (int j = 0; j < arrNVmoi.Length; j++)
                {
                    sw.WriteLine($"{arrNVmoi[j].HoTen}#{arrNVmoi[j].NgaySinh}#{arrNVmoi[j].SCMND}#{arrNVmoi[j].MaNV}#{arrNVmoi[j].SDT}#{arrNVmoi[j].DiaChi.SoNha}#{arrNVmoi[j].DiaChi.TenDuong}#{arrNVmoi[j].DiaChi.TenPhuong}#{arrNVmoi[j].DiaChi.TenQuan}#{arrNVmoi[j].DiaChi.TenTP}");
                }
            }
            Console.WriteLine("Da them nhan vien thanh cong voi thong tin: ");
            Console.WriteLine(arrNVmoi[soNVmoi - 1].toString());
            arrNVmoi = NhapNV();
            return arrNVmoi;
        }
        // Ham them hang hoa:
        static HangHoa[] ThemHH(HangHoa[] arrHH)
        {
            string tenhh;
            DateTime ngaynhap;
            int soluong;
            double giaban, gianhap;
            string mahhthem = "";
            int soluonghhmoi = 0;
            do
            {
                Console.Write("Nhap ma hang hoa can them (vd:HH01,HH02,...): ");
                mahhthem = Console.ReadLine();
            } while (KTmaHH(mahhthem) == false);
            if (KTmaHH_Trung(arrHH, mahhthem) == true)
            {
                for (int j = 0; j < arrHH.Length; j++)
                {
                    if (mahhthem == arrHH[j].MaHH)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Ma hang nay da ton tai, cap nhat them so luong: ");
                        Console.ResetColor();
                        int.TryParse(Console.ReadLine(), out soluonghhmoi);
                        Console.WriteLine($"So luong da duoc cap nhat cho ma hang {arrHH[j].MaHH} la: {arrHH[j].SoLuong}");
                        arrHH[j].SoLuong += soluonghhmoi;
                    }
                }
                using (StreamWriter sw = new StreamWriter(@"HH.txt"))
                {
                    sw.WriteLine(arrHH.Length);
                    for (int j = 0; j < arrHH.Length; j++)
                    {
                        sw.WriteLine($"{arrHH[j].SanPham}#{arrHH[j].MaHH}#{arrHH[j].SoLuong}#{arrHH[j].NgayNhapKho}#{arrHH[j].GiaBan}#{arrHH[j].GiaNhapKho}");
                    }
                }
                ChoMotChut();
                Console.WriteLine("Da cap nhat thong tin thanh cong.");
                for (int i = 0; i < arrHH.Length; i++)
                {
                    if (mahhthem == arrHH[i].MaHH)
                    {
                        Console.WriteLine(arrHH[i].toString());
                    }
                }
                arrHH = NhapHH();
                return arrHH;
            }
            else
            {
                HangHoa HangHoa_Moi = new HangHoa();
                Console.Write("Nhap ten hang hoa: ");
                tenhh = Console.ReadLine();
                Console.Write("Nhap so luong: ");
                int.TryParse(Console.ReadLine(), out soluong);
                Console.Write("Nhap ngay nhap hang: ");
                DateTime.TryParse(Console.ReadLine(), out ngaynhap);
                Console.Write("Nhap gia ban: ");
                double.TryParse(Console.ReadLine(), out giaban);
                Console.Write("Nhap gia nhap kho: ");
                double.TryParse(Console.ReadLine(), out gianhap);
                HangHoa_Moi = new HangHoa(tenhh, mahhthem, soluong, ngaynhap, giaban, gianhap);
                HangHoa[] arrHH_Moi = new HangHoa[arrHH.Length + 1];
                for (int i = 0; i < arrHH.Length; i++)
                {
                    arrHH_Moi[i] = arrHH[i];
                }
                arrHH_Moi[arrHH_Moi.Length - 1] = HangHoa_Moi;
                using (StreamWriter sw = new StreamWriter(@"HH.txt"))
                {
                    sw.WriteLine(arrHH_Moi.Length);
                    for (int j = 0; j < arrHH_Moi.Length; j++)
                    {
                        sw.WriteLine($"{arrHH_Moi[j].SanPham}#{arrHH_Moi[j].MaHH}#{arrHH_Moi[j].SoLuong}#{arrHH_Moi[j].NgayNhapKho}#{arrHH_Moi[j].GiaBan}#{arrHH_Moi[j].GiaNhapKho}");
                    }
                }
                ChoMotChut();
                Console.WriteLine("Da cap nhat thong tin thanh cong.");
                for (int i = 0; i < arrHH_Moi.Length; i++)
                {
                    if (mahhthem == arrHH_Moi[i].MaHH)
                    {
                        Console.WriteLine(arrHH_Moi[i].toString());
                    }
                }
                arrHH = NhapHH();
                return arrHH;
            }
        }
        //Ham them khach hang:
        static KhachHang[] ThemKH(KhachHang[] arrKH)
        {
            int soKHmoi = arrKH.Length + 1;
            DateTime ngaySinh;
            string sCMND, hoTen, sDT;
            DiaChi diaChi = new DiaChi();
            KhachHang[] arrKHmoi = new KhachHang[soKHmoi];
            for (int i = 0; i < arrKH.Length; i++)
            {
                arrKHmoi[i] = arrKH[i];
            }
            int soNha;
            string tenDuong;
            string tenPhuong;
            string tenQuan;
            string tenTP;
            string makhthem = "";
            Console.Write("Nhap ma khach hang can them (vd: KH01,KH02,..): ");
        aa:
            makhthem = Console.ReadLine();
            if (KTmaKH(makhthem) == false || KTmaKH_Trung(arrKH, makhthem))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma khach hang {makhthem} da ton tai, vui long nhap ma khach hang khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            Console.WriteLine("---Nhap thong tin cho khach hang them.");
            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhap CMND: ");
            sCMND = Console.ReadLine();
            Console.Write("Nhap so dien thoai: ");
            sDT = Console.ReadLine();
            Console.Write("Nhap ngay sinh: ");
            DateTime.TryParse(Console.ReadLine(), out ngaySinh);
            Console.WriteLine("Nhap dia chi: ");
            Console.Write("Nhap so nha: ");
            int.TryParse(Console.ReadLine(), out soNha);
            Console.Write("Nhap ten duong: ");
            tenDuong = Console.ReadLine();
            Console.Write("Nhap ten phuong: ");
            tenPhuong = Console.ReadLine();
            Console.Write("Nhap ten quan: ");
            tenQuan = Console.ReadLine();
            Console.Write("Nhap ten TP: ");
            tenTP = Console.ReadLine();
            diaChi = new DiaChi(soNha, tenDuong, tenPhuong, tenQuan, tenTP);
            arrKHmoi[soKHmoi - 1] = new KhachHang(makhthem, hoTen, ngaySinh, sCMND, sDT, diaChi);
            Console.Clear();
            ChoMotChut();
            using (StreamWriter sw = new StreamWriter(@"KH.txt"))
            {
                sw.WriteLine(arrKHmoi.Length);
                for (int j = 0; j < arrKHmoi.Length; j++)
                {
                    sw.WriteLine($"{arrKHmoi[j].HoTen}#{arrKHmoi[j].MaKH}#{arrKHmoi[j].SDT}#{arrKHmoi[j].SCMND}#{arrKHmoi[j].NgaySinh}#{arrKHmoi[j].DiaChi.SoNha}#{arrKHmoi[j].DiaChi.TenDuong}#{arrKHmoi[j].DiaChi.TenPhuong}#{arrKHmoi[j].DiaChi.TenQuan}#{arrKHmoi[j].DiaChi.TenTP}");
                }
            }
            Console.WriteLine("Da them khach hang thanh cong voi thong tin: ");
            Console.WriteLine(arrKHmoi[soKHmoi - 1].toString());
            arrKHmoi = NhapKH();
            return arrKHmoi;
        }
        // Them hoa don:
        static HoaDon[] ThemHD(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV, HoaDon[] arrHD)
        {
            DateTime ngaylap;
            string mahdthem = "", manv, makh, mahh;
            int soluonghh = 0;
            HoaDon hdmoi;
            Console.Write("Nhap ma hoa don can them (vd:HH01,HH02,...): ");
        aa:
            mahdthem = Console.ReadLine();
            if (KTmaHD(mahdthem) == false || KTmaHD_Trung(arrHD, mahdthem))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Ma hoa don {mahdthem} da ton tai, vui long nhap ma hoa don khac: ");
                goto aa;
            }
            Console.ResetColor();
            ChoMotChut();
            Console.Clear();
            Console.Write("Nhap ngay lap hoa don:");
            DateTime.TryParse(Console.ReadLine(), out ngaylap);
            Console.Write("Nhap so luong hang hoa trong hoa don: ");
            int.TryParse(Console.ReadLine(), out soluonghh);
            LinkedList<HangHoa> hh = new LinkedList<HangHoa>();
            for (int i = 0; i < soluonghh; i++)
            {
                do
                {
                    Console.Write($"Nhap ma hang hoa thu {i + 1}: ");
                    mahh = Console.ReadLine();
                } while (KTmaHH(mahh) == false || KTmaHH_Trung(arrHH, mahh) == false);
                for (int k = 0; k < arrHH.Length; k++)
                {
                    if (mahh == arrHH[k].MaHH)
                    {
                        hh.AddLast(arrHH[k]);
                    }
                }
            }
            do
            {
                Console.Write("Nhap ma nhan vien lap hoa don: ");
                manv = Console.ReadLine();
            } while (KTmaNV(manv) == false || KTmaNV_Trung(arrNV, manv) == false);
            NhanVien nv = new NhanVien();
            for (int i = 0; i < arrNV.Length; i++)
            {
                if (manv == arrNV[i].MaNV)
                {
                    nv = arrNV[i];
                }
            }
            do
            {
                Console.Write("Nhap ma khach hang trong hoa don: ");
                makh = Console.ReadLine();
            } while (KTmaKH(makh) == false || KTmaKH_Trung(arrKH, makh) == false);
            KhachHang kh = new KhachHang();
            for (int i = 0; i < arrKH.Length; i++)
            {
                if (makh == arrKH[i].MaKH)
                {
                    kh = arrKH[i];
                }
            }
            hdmoi = new HoaDon(mahdthem, ngaylap, soluonghh, hh, nv, kh);
            using (StreamWriter sw = new StreamWriter(@"HD.txt"))
            {
                sw.WriteLine(arrHD.Length + 1);
                for (int j = 0; j < arrHD.Length; j++)
                {
                    string manghh = "";
                    for (LinkedListNode<HangHoa> p = arrHD[j].SanPham.First; p != null; p = p.Next)
                    {
                        manghh += $"{p.Value.MaHH}#";
                    }
                    sw.WriteLine($"{arrHD[j].MaHD}#{arrHD[j].NgayMua}#{arrHD[j].SoLuongMua}#{manghh}{arrHD[j].NhanVien.MaNV}#{arrHD[j].KhachHang.MaKH}");
                }
                string manghh1 = "";
                for (LinkedListNode<HangHoa> p = hh.First; p != null; p = p.Next)
                {
                    manghh1 += $"{p.Value.MaHH}#";
                }
                sw.WriteLine($"{mahdthem}#{ngaylap}#{soluonghh}#{manghh1}{manv}#{makh}");
            }
            arrHD = NhapHD(arrHH, arrKH, arrNV);
            ChoMotChut();
            Console.WriteLine("Da them hoa don thanh cong: ");
            hdmoi.toString();
            arrHD = NhapHD(arrHH, arrKH, arrNV);
            return arrHD;
        }
        // Ham kiem tra ma nhan vien trung nhau:
        static bool KTmaNV_Trung(NhanVien[] arrNV, string manv)
        {
            for (int i = 0; i < arrNV.Length; i++)
            {
                if (manv == arrNV[i].MaNV)
                {
                    return true;
                }
            }
            return false;
        }
        // Ham kiem tra ma khach hang trung nhau:
        static bool KTmaHH_Trung(HangHoa[] arrHH, string mahh)
        {
            for (int i = 0; i < arrHH.Length; i++)
            {
                if (mahh == arrHH[i].MaHH)
                {
                    return true;
                }
            }
            return false;
        }
        // Ham kiem tra ma hang hoa trung nhau:
        static bool KTmaKH_Trung(KhachHang[] arrKH, string makh)
        {
            for (int i = 0; i < arrKH.Length; i++)
            {
                if (makh == arrKH[i].MaKH)
                {
                    return true;
                }
            }
            return false;
        }
        // Ham kiem tra ma hoa don trung nhau:
        static bool KTmaHD_Trung(HoaDon[] arrHD, string mahd)
        {
            for (int i = 0; i < arrHD.Length; i++)
            {
                if (mahd == arrHD[i].MaHD)
                {
                    return true;
                }
            }
            return false;
        }
        // Ham kiem tra ma hang hoa:
        static bool KTmaHH(string maHH)
        {
            if (maHH.Length != 4)
            {
                return false;
            }
            else
            {
                if (maHH[0] == 'H' && maHH[1] == 'H')
                {
                    return true;
                }
                return false;
            }
        }
        // Ham kiem tra ma hoa don:
        static bool KTmaHD(string maHD)
        {
            if (maHD.Length != 4)
            {
                return false;
            }
            else
            {
                if (maHD[0] == 'H' && maHD[1] == 'D')
                {
                    return true;
                }
                return false;
            }
        }
        // Ham kiem tra ma khach hang:
        static bool KTmaKH(string maKH)
        {
            if (maKH.Length != 4)
            {
                return false;
            }
            else
            {
                if (maKH[0] == 'K' && maKH[1] == 'H')
                {
                    return true;
                }
                return false;
            }
        }
        // Ham kiem tra ma nhan vien:
        static bool KTmaNV(string maNV)
        {
            if (maNV.Length != 4)
            {
                return false;
            }
            else
            {
                if (maNV[0] == 'N' && maNV[1] == 'V')
                {
                    return true;
                }
                return false;
            }
        }
        // Ham cho mot chut:
        static void ChoMotChut()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Vui long cho mot chut");
            Thread.Sleep(400);
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        // Nhap du lieu cho hoa don:
        static HoaDon[] NhapHD(HangHoa[] arrHH, KhachHang[] arrKH, NhanVien[] arrNV)
        {
            HoaDon[] arrHD;
            string mahd, mahh, manv, makh;
            DateTime ngaymua;
            int sohh;
            string file = @"HD.txt";
            using (StreamReader rd = new StreamReader(file))
            {
                int spt = Convert.ToInt32(rd.ReadLine());
                arrHD = new HoaDon[spt];
                for (int i = 0; i < arrHD.Length; i++)
                {
                    string line = rd.ReadLine();
                    string[] separator = new string[] { "#" };
                    string[] arr = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    mahd = arr[0];
                    ngaymua = Convert.ToDateTime(arr[1]);
                    sohh = int.Parse(arr[2]);
                    HangHoa hanghoa = new HangHoa();
                    LinkedList<HangHoa> hh = new LinkedList<HangHoa>();
                    for (int j = 0; j < sohh; j++)
                    {
                        mahh = arr[j + 3];
                        double giaban, gianhap;
                        DateTime ngaynhap;
                        string sanpham;
                        int soluong;
                        for (int k = 0; k < arrHH.Length; k++)
                        {
                            if (mahh == arrHH[k].MaHH)
                            {
                                giaban = arrHH[k].GiaBan;
                                gianhap = arrHH[k].GiaNhapKho;
                                ngaynhap = arrHH[k].NgayNhapKho;
                                sanpham = arrHH[k].SanPham;
                                soluong = arrHH[k].SoLuong;
                                hanghoa = new HangHoa(sanpham, mahh, soluong, ngaynhap, giaban, gianhap);
                                hh.AddLast(hanghoa);
                            }
                        }
                    }
                    NhanVien nv = new NhanVien();
                    string tennv, cmnd, sdt, duong, phuong, quan, tp;
                    DateTime ngaysinh;
                    int sonha;
                    manv = Convert.ToString(arr[2 + sohh + 1]);
                    for (int j = 0; j < arrNV.Length; j++)
                    {
                        if (arrNV[j].MaNV == manv)
                        {
                            tennv = arrNV[j].HoTen;
                            cmnd = arrNV[j].SCMND;
                            sdt = arrNV[j].SDT;
                            duong = arrNV[j].DiaChi.TenDuong;
                            phuong = arrNV[j].DiaChi.TenPhuong;
                            quan = arrNV[j].DiaChi.TenQuan;
                            tp = arrNV[j].DiaChi.TenTP;
                            ngaysinh = arrNV[j].NgaySinh;
                            sonha = arrNV[j].DiaChi.SoNha;
                            DiaChi DC = new DiaChi(sonha, duong, phuong, quan, tp);
                            nv = new NhanVien(manv, tennv, ngaysinh, cmnd, sdt, DC);

                        }
                    }
                    KhachHang kh = new KhachHang();
                    makh = Convert.ToString(arr[2 + sohh + 2]);
                    string tenkh, cmndkh, sdtkh, duongkh, phuongkh, quankh, tpkh;
                    DateTime ngaysinhkh;
                    int sonhakh;
                    for (int j = 0; j < arrKH.Length; j++)
                    {
                        tenkh = arrKH[j].HoTen;
                        cmndkh = arrKH[j].SCMND;
                        sdtkh = arrKH[j].SDT;
                        duongkh = arrNV[j].DiaChi.TenDuong;
                        phuongkh = arrNV[j].DiaChi.TenPhuong;
                        quankh = arrNV[j].DiaChi.TenQuan;
                        tpkh = arrNV[j].DiaChi.TenTP;
                        ngaysinhkh = arrNV[j].NgaySinh;
                        sonhakh = arrNV[j].DiaChi.SoNha;
                        DiaChi DC = new DiaChi(sonhakh, duongkh, phuongkh, quankh, tpkh);
                        kh = new KhachHang(makh, tenkh, ngaysinhkh, cmndkh, sdtkh, DC);


                    }
                    arrHD[i] = new HoaDon(mahd, ngaymua, sohh, hh, nv, kh);
                }
            }
            return arrHD;
        }
        // Nhap du lieu cho hang hoa:
        static HangHoa[] NhapHH()
        {
            HangHoa[] arrHH;
            string tenhh, mahh;
            int soluong;
            DateTime ngaynhap;
            double giaban, gianhap;
            string file = @"HH.txt";
            using (StreamReader rd = new StreamReader(file))
            {
                int spt = Convert.ToInt32(rd.ReadLine());
                arrHH = new HangHoa[spt];
                for (int i = 0; i < arrHH.Length; i++)
                {
                    string line = rd.ReadLine();
                    string[] separator = new string[] { "#" };
                    string[] arr = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    tenhh = Convert.ToString(arr[0]);
                    mahh = Convert.ToString(arr[1]);
                    soluong = Convert.ToInt32(arr[2]);
                    ngaynhap = Convert.ToDateTime(arr[3]);
                    giaban = Convert.ToDouble(arr[4]);
                    gianhap = Convert.ToDouble(arr[5]);
                    arrHH[i] = new HangHoa(tenhh, mahh, soluong, ngaynhap, giaban, gianhap);
                }
            }
            return arrHH;
        }
        // Nhap du lieu cho khach hang:
        static KhachHang[] NhapKH()
        {
            KhachHang[] arrKH;
            string tenkh, makh, sdt, cmnd, duong, phuong, quan, tp;
            DateTime ngaysinh;
            int sonha;
            string file = @"KH.txt";
            using (StreamReader rd = new StreamReader(file))
            {
                int spt = Convert.ToInt32(rd.ReadLine());
                arrKH = new KhachHang[spt];
                for (int i = 0; i < arrKH.Length; i++)
                {
                    string line = rd.ReadLine();
                    string[] separator = new string[] { "#" };
                    string[] arr = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    tenkh = Convert.ToString(arr[0]);
                    makh = Convert.ToString(arr[1]);
                    sdt = Convert.ToString(arr[2]);
                    cmnd = Convert.ToString(arr[3]);
                    ngaysinh = Convert.ToDateTime(arr[4]);
                    sonha = Convert.ToInt32(arr[5]);
                    duong = Convert.ToString(arr[6]);
                    phuong = Convert.ToString(arr[7]);
                    quan = Convert.ToString(arr[8]);
                    tp = Convert.ToString(arr[9]);
                    DiaChi DC = new DiaChi(sonha, duong, phuong, quan, tp);
                    arrKH[i] = new KhachHang(makh, tenkh, ngaysinh, cmnd, sdt, DC);
                }
            }
            return arrKH;
        }
        // Nhap du lieu cho nhan vien:
        static NhanVien[] NhapNV()
        {
            NhanVien[] arrNV;
            string tennv, cmnd, manv, sdt, duong, phuong, quan, tp;
            DateTime ngaysinh;
            int sonha;
            string file = @"NV.txt";
            using (StreamReader rd = new StreamReader(file))
            {
                int spt = Convert.ToInt32(rd.ReadLine());
                arrNV = new NhanVien[spt];
                for (int i = 0; i < arrNV.Length; i++)
                {
                    string line = rd.ReadLine();
                    string[] separator = new string[] { "#" };
                    string[] arr = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    tennv = Convert.ToString(arr[0]);
                    ngaysinh = Convert.ToDateTime(arr[1]);
                    cmnd = Convert.ToString(arr[2]);
                    manv = Convert.ToString(arr[3]);
                    sdt = Convert.ToString(arr[4]);
                    sonha = Convert.ToInt32(arr[5]);
                    duong = Convert.ToString(arr[6]);
                    phuong = Convert.ToString(arr[7]);
                    quan = Convert.ToString(arr[8]);
                    tp = Convert.ToString(arr[9]);
                    DiaChi DC = new DiaChi(sonha, duong, phuong, quan, tp);
                    arrNV[i] = new NhanVien(manv, tennv, ngaysinh, cmnd, sdt, DC);
                }
            }
            return arrNV;
        }
    }
}
