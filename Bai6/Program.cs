using System;

namespace Bai6
{     
    class Program
    {
        static void XuatMaTran(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            Console.WriteLine("Ma tran:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static int TimPhanTuLonNhat(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int max = arr[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                }
            }
            return max;
        }
        static int TimPhanTuNhoNhat(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int min = arr[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
                }
            }
            return min;
        }
        static int TimDongCoTongLonNhat(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int maxSum = int.MinValue;
            int rowIndex = -1;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += arr[i, j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    rowIndex = i;
                }
            }
            return rowIndex;
        }
        static bool LaSoNguyenTo(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        static int TinhTongCacSoKhongPhaiSoNguyenTo(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!LaSoNguyenTo(arr[i, j]))
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }

        static int[,] XoaDongThuK(int[,] arr, int k)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            if (k < 0 || k >= n)
            {
                Console.WriteLine("Dong k khong hop le.");
                return arr;
            }
            int[,] newArr = new int[n - 1, m];
            for (int i = 0, newI = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                {
                    newArr[newI, j] = arr[i, j];
                }
                newI++;
            }
            return newArr;
        }
        static int[,] XoaCotChuaPhanTuLonNhat(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int max = TimPhanTuLonNhat(arr);
            int colIndex = -1;
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (arr[i, j] == max)
                    {
                        colIndex = j;
                        break;
                    }
                }
                if (colIndex != -1) break;
            }
            int[,] newArr = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0, newJ = 0; j < m; j++)
                {
                    if (j == colIndex) continue;
                    newArr[i, newJ] = arr[i, j];
                    newJ++;
                }
            }
            return newArr;
        }

        static void Menu(int[,] arr)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Xuat ma tran");
            Console.WriteLine("2. Tim phan tu lon nhat");
            Console.WriteLine("3. Tim phan tu nho nhat");
            Console.WriteLine("4. Tim dong co tong lon nhat");
            Console.WriteLine("5. Tinh tong cac so khong phai so nguyen to");
            Console.WriteLine("6. Xoa dong thu k trong ma tran");
            Console.WriteLine("7. Xoa cot chua phan tu lon nhat trong ma tran");
            Console.WriteLine("0. Thoat");
            int choice = -1;
            while (choice != 0)
            {
                Console.Write("Chon chuc nang: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 0 || choice > 7)
                {
                    Console.WriteLine("Chuc nang khong hop le. Vui long chon lai.");
                    continue;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            XuatMaTran(arr);
                            break;
                        case 2:
                            int max = TimPhanTuLonNhat(arr);
                            Console.WriteLine("Phan tu lon nhat: " + max);
                            break;
                        case 3:
                            int min = TimPhanTuNhoNhat(arr);
                            Console.WriteLine("Phan tu nho nhat: " + min);
                            break;
                        case 4:
                            int rowIndex = TimDongCoTongLonNhat(arr);
                            Console.WriteLine("Dong co tong lon nhat: " + rowIndex);
                            break;
                        case 5:
                            int sum = TinhTongCacSoKhongPhaiSoNguyenTo(arr);
                            Console.WriteLine("Tong cac so khong phai so nguyen to: " + sum);
                            break;
                        case 6:
                            Console.Write("Nhap dong k can xoa: ");
                            int k = Convert.ToInt32(Console.ReadLine());
                            arr = XoaDongThuK(arr, k);
                            Console.WriteLine("Da xoa dong thu " + k);
                            XuatMaTran(arr);
                            break;
                        case 7:
                            arr = XoaCotChuaPhanTuLonNhat(arr);
                            Console.WriteLine("Da xoa cot chua phan tu lon nhat.");
                            XuatMaTran(arr);
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
            Console.Write("Nhap so dong: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rand.Next(0, 100);
                }
            }
            Menu(arr);
        }
    }
}
