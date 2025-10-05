using System;

namespace Bai4
{
    class Program
    {
        static bool KiemTraNamNhuan(int nam)
        {
            if ((nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0))
                return true;
            return false;
        }

        static int NgayCuaThang(int thang, int nam)
        {        
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (KiemTraNamNhuan(nam))
                        return 29;
                    else
                        return 28;
                default:
                    Console.WriteLine("Thang khong hop le.");
                    return -1;
            }
        }
        static void Menu(int thang, int nam)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Ngay cua thang");
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
                            int temp = NgayCuaThang(thang, nam);
                            if (temp != -1)
                            {
                                Console.WriteLine($"Thang {thang} nam {nam} co {temp} ngay.");
                            }
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
            Console.Write("Nhap thang: ");
            int thang = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap nam: ");
            int nam = Convert.ToInt32(Console.ReadLine());
            Menu(thang, nam);
        }
    }
}