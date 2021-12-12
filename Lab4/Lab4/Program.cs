using System;
using System.IO;

namespace Lab4
{
    class Program
    {
        private static double ExpertHelp(string A, string[,] array)
        {
            int a = 0;
            double sum = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (A == array[0,i])
                {
                    a = i;
                }
            }
            for (int i = 1; i < array.GetLength(0); i++)
            {
                double count = double.Parse(array[i, a]);
                double wag = double.Parse(array[i, 2]);
                sum += count*wag;              
            }
            //Console.WriteLine("{0}: {1} ", A, sum);
            return sum;
        }
        private static void Expert(string[,] array)
        {
            double[] mas = new double[array.GetLength(1)-3];
            double buble = 0;
            for (int i = 3,j=0; i < array.GetLength(1); i++,j++)
            {
                mas[j] = ExpertHelp(array[0, i], array);
                Console.WriteLine("{0}: {1} ", array[0, i], ExpertHelp(array[0, i], array));
            }
            for (int i = 0; i < mas.Length; i++)
            {         
                if (buble < mas[i])
                {
                    buble = mas[i];
                }
            }
            for (int i = 3; i < array.GetLength(1); i++)
            {
                if (buble == ExpertHelp(array[0, i], array))
                {
                    Console.WriteLine("Найкращий варiант за обрахунками: " + array[0, i]);
                }               
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
            Console.WriteLine("Вибiр телефону\n");
            //Вивід масива
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                    Console.Write(num[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine("");
            Expert(num);
            Console.ReadKey();
        }
    }
}