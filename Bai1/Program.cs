using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Bai1
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

        static bool KtrSCP(int n)
        {
            int k = Convert.ToInt32(Math.Sqrt(n));
            k = k * k;
            if (k == n) return true;
            return false;
        }

        static void InMang(int[] arr)
        {
            Console.Write("Mang hien tai la: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static int TinhTongLe(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    sum += arr[i];
                }
            }
            return sum;
        }

        static int DemSNT(int[] arr)
        {
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (KtrSNT(arr[i]))
                {
                    k++;
                }
            }
            return k;
        }

        static int TimSCPNN(int[] arr)
        {
            int min = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (KtrSCP(arr[i]))
                {
                    if (min == -1)
                    {
                        min = arr[i];
                    }
                    else if (arr[i] < min)
                    {
                        min = arr[i];
                    }
                }
            }
            return min;
        }
        static void Menu(int[] arr)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. In mang");
            Console.WriteLine("2. Tinh tong cac so le");
            Console.WriteLine("3. Dem so nguyen to");
            Console.WriteLine("4. Tim so chinh phuong nho nhat");
            Console.WriteLine("0. Thoat");
            int choice = -1;
            while (choice != 0)
            {
                Console.Write("Chon chuc nang: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 0 || choice > 4)
                {
                    Console.WriteLine("Chuc nang khong hop le. Vui long chon lai.");
                    continue;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            InMang(arr);
                            break;
                        case 2:
                            Console.WriteLine("Tong cac so le trong mang la: " + TinhTongLe(arr));
                            break;
                        case 3:
                            Console.WriteLine("So luong so nguyen to trong mang la: " + DemSNT(arr));
                            break;
                        case 4:
                            Console.WriteLine("So chinh phuong nho nhat trong mang la: " + TimSCPNN(arr));
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
            Console.Write("Nhap so phan tu cua mang: ");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n <= 0)
            {
                Console.Write("So phan tu khong hop le. Vui long nhap lai: ");
                n = Convert.ToInt32(Console.ReadLine());
            }

            int[] arr = new int[n];

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(0, 100);
            }

            Menu(arr);

        }
    }
}