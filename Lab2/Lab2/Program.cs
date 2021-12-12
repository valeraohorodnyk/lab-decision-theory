using System;
using System.IO;

namespace Lab2
{
    class Program
    {
        //Функція для підрахунку доходу при ймовірному будівництву заводу
        private static void Factory(double[] array, int year)
        {
            double prubutok;
            //Підрахунок прибутку (річний дохід в розмірі array[1] з ймовірністю array[2] і низький попит array[3] з ймовірністю array[4]
            prubutok = year * (array[1] * array[2] + array[3] * array[4]);
            if (array[0] >= prubutok)
            {
                Console.WriteLine("Збиток = {0}",(array[0] - prubutok));
            }
            else
            {
                Console.WriteLine("Прибуток = {0}",(prubutok - array[0]));
            }
        }

        //Зміна ймовірностей
        private static void Change(double[] array, double[] change)
        {
            array[2] = change[2];
            array[4] = change[3];
        }

        static void Main(string[] args)
        {            
            //Console.WriteLine(5*(200 * 0.75 - 75 * 0.25));
            //Console.WriteLine(5*(150 * 0.75 - 40 * 0.25));
            //Console.WriteLine(4 * (200 * 0.85 - 75 * 0.15));
            //Console.WriteLine(4 * (150 * 0.85 - 40 * 0.15));

            //Прочитали всі строки з файла
            string[] s = File.ReadAllLines("lab2.txt");

            double[][] array = new double[s.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                //Розбили строку пробелами            
                string[] str = s[i].Trim().Split(' ');
                //Створили массив 
                array[i] = new double[str.Length];
                for (int j = 0; j < str.Length; j++)
                    //Обрізали пробіли и перетворили в ціле число
                    array[i][j] = double.Parse(str[j].Trim());
            }
            //Вивід масива на экран
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write(array[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

            //Присвоєння 1 строки файла масиву А
            double[] A = new double[array[0].Length];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = array[0][i];
            }

            //Присвоєння 2 строки файла масиву В
            double[] B = new double[array[1].Length];
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = array[1][i];
            }

            //Присвоєння 3 строки файла масиву С
            double[] C = new double[array[2].Length];
            for (int i = 0; i < C.Length; i++)
            {
                C[i] = array[2][i];
            }

            Console.Write("Варiант А: ");
            Factory(A, 5);
            Console.Write("Варiант Б: ");
            Factory(B, 5);           
            Console.Write("Варiант А_С: ");
            Change(A, C);
            Factory(A, 4);
            Console.Write("Варiант B_С: ");
            Change(B, C);
            Factory(B, 4);
            Console.ReadKey();
        }
    }
}
