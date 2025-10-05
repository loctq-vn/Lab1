using System;
using System.Runtime.ExceptionServices;

namespace Bai2
{
    class Program
    {
        static bool KtrSNT(int n)
        {             
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static int TongSNT(int n)
        {
            int sum = 0;
            for (int i = 2; i < n; i++)
            {
                if (KtrSNT(i))
                {
                    sum += i;
                }
            }
            return sum;
        }
        static void Menu(int n)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Tong cac so nguyen to < n");
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
                            Console.WriteLine($"Tong cac so nguyen to < {n} la: {TongSNT(n)}");
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
            Console.Write("Nhap so nguyen duong n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0)
            {                 
                Console.WriteLine("n phai la so nguyen duong. Vui long chay lai chuong trinh.");
                return;
            }
            Menu(n);
        }
    }
}
