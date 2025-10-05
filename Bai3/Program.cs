using System;

namespace Bai3
{     
    class Program
    {
        static bool KtrNamNhuan(int nam)
        {
            if ((nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0))
                return true;
            return false;
        }
        static bool KtrNgayHopLe(int ngay, int thang, int nam)
        {
            if (nam < 0 || thang < 1 || thang > 12 || ngay < 1 || ngay > 31)
                return false;
            if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                if (ngay > 30)
                    return false;
            }
            else if (thang == 2)
            {
                if (KtrNamNhuan(nam))
                {
                    if (ngay > 29)
                        return false;
                }
                else
                {
                    if (ngay > 28)
                        return false;
                }
            }
            return true;
        }
        static void Menu(int ngay, int thang, int nam)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Kiem tra ngay thang nam co hop le khong");
            Console.WriteLine("0. Thoat");
            int choice = -1;
            while (choice != 0)
            {
                Console.Write("Chon chuc nang: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 0 || choice > 1)
                {
                    Console.WriteLine("Chuc nang khong hop le. Vui long chon lai.");
                    continue;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            if (KtrNgayHopLe(ngay, thang, nam))
                                Console.WriteLine("Ngay thang nam hop le.");
                            else
                                Console.WriteLine("Ngay thang nam khong hop le.");
                            break;
                        case 0:
                            Console.WriteLine("Thoat chuong trinh.");
                            return;
                    }

                }
            }

        }
        static void Main(string[] args)
        {
            Console.Write("Nhap ngay: ");
            int ngay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap thang: ");
            int thang = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap nam: ");
            int nam = Convert.ToInt32(Console.ReadLine());
            Menu(ngay, thang, nam);
        }
    }
}