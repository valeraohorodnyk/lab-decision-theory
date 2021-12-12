﻿using System;
using System.IO;
using System.Linq;

namespace Lab5
{
    class Program
    {
        private static int[,] Transp(int[,] num)
        {
            int[,] trans = new int[num.GetLength(0),num.GetLength(1)];
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    trans[i, j] = num[j, i];

                }
            }    
                return trans;
        }
        private static int[,] Plus_rad(int[,] num)
        {
            int[,] rad = new int[num.GetLength(0)+1,num.GetLength(1)];
            for (int i = 0; i < rad.GetLength(0); i++)
            {
                for (int j = 0; j < rad.GetLength(1); j++)
                {
                    if ( i < num.GetLength(0))
                    {
                        rad[i, j] = num[i,j];
                    }
                    else
                    {
                        rad[i, j] = 1;
                    }
                }
            }
            return rad;
        }
        private static int[,] Plus_st(int[,] num)
        {
            int[,] st = new int[num.GetLength(0), num.GetLength(1)+1];
            int length = st.GetLength(0);
            int length1 = st.GetLength(1);
            for (int i = 0; i < st.GetLength(0); i++)
            {
                for (int j = 0; j < st.GetLength(1); j++)
                {
                    if (j < num.GetLength(1))
                    {
                        st[i, j] = num[i, j];
                    }
                    if (j == st.GetLength(1)-1 && i!= st.GetLength(0)-1)
                    {
                        st[i, j] = -1;
                    }
                    if (i == st.GetLength(0)-1 && j == st.GetLength(1)-1)
                    {
                        st[i, j] = 0;
                    }
                }
            }
            return st;
        }
        private static void Gaus(int[,] num, string name)
        {
            num = Plus_rad(num);
            num = Plus_st(num);
            int n = num.GetLength(0);
            double[,] a = new double[n, n];
            double[] b = new double[n];
            double[] x = new double[n];
            double s;
            for (int i = 0; i < n; i++)
                x[i] = 0;
            //коэффициенты системы
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = num[i,j];
                }
            //свободные коэффициенты
            for (int i = 0; i < n; i++)
            {
                if (i < n-1)
                {
                    b[i] = 0;
                }
                else
                {
                    b[i] = 1;
                }              
            }               
            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }
                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }
            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < n; j++)
                    s = s + a[k, j] * x[j];
                x[k] = (b[k] - s) / a[k, k];
            }
            Console.WriteLine("Стратегiї мають наступнi ймовiрностi");
            for (int i = 0; i < x.Length-1; i++)
            {
                Console.WriteLine("{0}{1}: {2}",name, i+1, Math.Round(x[i], 3));
            }
            Console.WriteLine("Цiна гри:");
            Console.WriteLine("y = " + Math.Round(x[x.Length-1], 3));
        }
        private static void Out(int[,] num)
        {
            Console.WriteLine();
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                    Console.Write(num[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
       
        private static int[,] Delete_str(int[,] array,int idx)
        {           
                int[,] arrOut = new int[array.GetLength(0) - 1, array.GetLength(1)];
                bool check = true;
                for (int i = 0; i < arrOut.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (i != idx && check)
                        {
                           arrOut[i,j] = array[i,j];
                        }
                        if (i==idx)
                        {
                            check = false;                            
                        }
                        if (check == false)
                        {
                        arrOut[i, j] = array[i+1, j];
                        }
                    }
                }
                
                return arrOut;            
        }
        private static int[,] Delete_row(int[,] array, int idx)
        {
            int[,] arrOut = new int[array.GetLength(0), array.GetLength(1) - 1];

            int temp = arrOut.GetLength(0);
            for (int i = 0; i < arrOut.GetLength(0); i++)
            {   
                bool check = true;
                for (int j = 0; j < arrOut.GetLength(1); j++)
                {
                    if (j != idx && check)
                    {
                        arrOut[i, j] = array[i, j];
                    }
                    if (j == idx)
                    {
                        check = false;
                    }
                    if (check == false)
                    {
                        arrOut[i, j] = array[i, j+1];
                    }
                }
            }

            return arrOut;
        }
        private static int[] Assignment_str(int[,] array, int number)
        {           
            int[] buble_str = new int[array.GetLength(1)];
            for (int j = 0; j < buble_str.Length; j++)
            {
                buble_str[j] = array[number,j];
            }
            return buble_str;
        }
        private static int[] Assignment_row(int[,] array, int number)
        {
            int[] buble_str = new int[array.GetLength(0)];
            for (int j = 0; j < buble_str.Length; j++)
            {
                buble_str[j] = array[j,number];
            }
            return buble_str;
        }
        private static int[,] Dominant_str(int[,] array)
        {
            int don = 0;
            int checkin = 0;
            while (don < array.GetLength(0))
        {           
            int[] buble = Assignment_str(array, don);
            for (int i = 0; i < array.GetLength(0); i++)
            {               
                bool chek = true;
                int[] mas = Assignment_str(array, i);
                if (don == i)
                {
                    continue;
                }
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (buble[j] > mas[j])
                    {
                        chek = false;
                        break;
                    }
                }
                if (chek)
                {
                    array = Delete_str(array, don);
                        checkin++;
                        break;
                }
            }
                if (checkin > 0)
                {
                    checkin = 0;
                    continue;
                }
                else
                {
                    don++;
                }               
        }
            
            return array;
        }

        private static int[,] Dominant_row(int[,] array)
        {
            int don = 0;
            int checkin = 0;
            while (don < array.GetLength(1))
            {
                int[] buble = Assignment_row(array, don);
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    bool chek = true;
                    int[] mas = Assignment_row(array, i);
                    if (don == i)
                    {
                        continue;
                    }
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (buble[j] < mas[j])
                        {
                            chek = false;
                            break;
                        }
                    }
                    if (chek)
                    {
                        array = Delete_row(array, don);
                        checkin++;
                        break;
                    }

                    //buble = Assignment(array, don);
                }
                if (checkin > 0)
                {
                    checkin = 0;
                    continue;
                }
                else
                {
                    don++;
                }
            }
            return array;
        }
        private static int Min(int[] array)
        {
            int buble = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (buble > array[i])
                {
                    buble = array[i];
                }
            }
            return buble;
        }
        private static int Max(int[] array)
        {
            int buble = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (buble < array[i])
                {
                    buble = array[i];
                }
            }
            return buble;
        }
        private static void Min_Max(int[,] array)
        {
            int[] mas_row = new int[array.GetLength(1)];
            int[] mas_str = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {   
                int temp = array[i,0];
                int temp_row = array[0,i];
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (temp_row < array[j, i])
                    {
                        temp_row = array[j, i];
                    }
                    if (temp > array[i,j])
                    {
                        temp = array[i,j];
                    }
                }
                mas_str[i] = temp;
                mas_row[i] = temp_row;
            }
            Console.WriteLine("Цiна гри");
            Console.WriteLine("{0} < y < {1}",Max(mas_str),Min(mas_row));
        }
        static void Main(string[] args)
        {
            // Прочитали всі строки з файла
            string[] s = File.ReadAllLines("ABC.txt");
            int[,] num = new int[s.Length, s[0].Split(' ').Length];
            for (int i = 0; i < s.Length; i++)
            {
                int[] temp = s[i].Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < temp.Length; j++)
                    num[i, j] = temp[j];
            }

            Out(num);
            Min_Max(num);
            bool finish = false;
            while (true)
            {
                Console.WriteLine("1) Вилучення рядкiв");
                Console.WriteLine("2) Вилучення стовпцiв");
                Console.WriteLine("3) Результати");
                int a = int.Parse(Console.ReadLine());
                
                switch (a)
                {
                    case 1:
                    num = Dominant_str(num);
                    Out(num);
                        break;
                    case 2:
                    num = Dominant_row(num);
                    Out(num);                    
                        break;
                    case 3:
                        Gaus(num,"q");
                        num = Transp(num);
                        Gaus(num, "p");  
                        finish = true;                      
                        break;                        
                }
                if (finish)
                {
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
