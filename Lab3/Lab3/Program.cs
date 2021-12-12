using System;
using System.IO;

namespace Lab3
{
    class Program
    {
        private static void KondorHelp(string A, string B, string[,] array)
        {
            int a = 0, b = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int count = int.Parse(array[i, 0]);
                    string temp = array[i, j];
                    string temp1 = array[i, j];
                    if (temp == A && j == 1)
                    {
                        a += count;
                    }
                    if (temp1 == B && j == 1)
                    {
                        b += count;
                    }
                    if (temp == A && j == 2 && array[i, 1] != B)
                    {
                        a += count;
                    }
                    if (temp1 == B && j == 2 && array[i, 1] != A)
                    {
                        b += count;
                    }
                }
            }
            if (a > b)
            {
                Console.WriteLine("За методом Кондорсе мiж {0} i {1}:", A, B);
                Console.WriteLine(A + ": " + a);
                Console.WriteLine(B + ": " + b);
                Console.WriteLine(A+" > "+B);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("За методом Кондорсе мiж {0} i {1}:", A, B);
                Console.WriteLine(A + ": " + a);
                Console.WriteLine(B + ": " + b);
                Console.WriteLine(B + " > " + A);
            }
        }
        private static int BordoHelp(string A, string[,] array)
        {
            int a = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int count = int.Parse(array[i, 0]);
                    string temp = array[i, j];
                    if (temp == A && j == 1)
                    {
                        a += count * 3;
                    }
                    if (temp == A && j == 2)
                    {
                        a += count * 2;
                    }
                    if (temp == A && j == 3)
                    {
                        a += count;
                    }
                }
            }
            return a;
        }
            //Кондорсе
            private static void Kondor(string[,] array)
            {
            KondorHelp("А", "Б", array);
            KondorHelp("А", "С", array);
            KondorHelp("С", "Б", array);           
            }
                //Бордо
        private static void Bordo(string[,] array)
        {
            int A = BordoHelp("А", array);
            int B = BordoHelp("Б", array);
            int C = BordoHelp("С", array);
            Console.WriteLine("За методом Бордо:");
            Console.WriteLine("A:" + A);
            Console.WriteLine("Б:" + B);
            Console.WriteLine("С:" + C);
            if (A>B && A>C)
            {
                Console.WriteLine("Переможець кандидат А");
            }
            if ( B > A && B > C)
            {
                Console.WriteLine("Переможець кандидат Б");
            }
            if (C > A && C > B)
            {
                Console.WriteLine("Переможець кандидат C");
            }
        }
        static void Main(string[] args)
        {
            // Прочитали всі строки з файла
            string[] s = File.ReadAllLines("ABC.txt");
            string[,] num = new string[s.Length, s[0].Split(' ').Length];
            for (int i = 0; i < s.Length; i++)
            {
                string[] temp = s[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    num[i, j] = temp[j];
            }
            //Вивід масива
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                    Console.Write(num[i,j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            Bordo(num);
            Console.WriteLine();
            Kondor(num);
            Console.ReadKey();                
        }       
    }
}