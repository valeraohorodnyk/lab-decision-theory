using System;
using System.IO;

namespace Lab1
{
    class Program
    {
        //Вальд
        private static int[] Vald(int[][] array)
        {
            int buble;
            //Виділення місця для масива = кількості рядків
            int[] mas = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                //Встановлюємо buble = 1 елементу кожного рядка
                buble = array[i][0];
                for (int j = 0; j < array[i].Length; j++)
                {
                    //Пошук найменшого елементу в кожному рядку
                    if (buble > array[i][j])
                    {
                        buble = array[i][j];
                    }
                }
                //Запис найменшого елемента в масив
                mas[i] = buble;                  
            }          
            return mas;
        }

        //Гурвіц
        private static double[] Gurviz(int[][] array)
        {
            int min, max;
            double k = 0.6;
            //Виділення місця для масива = кількості рядків
            double[] mas = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                //Встановлюємо max,min = 1 елементу кожного рядка
                min = array[i][0];
                max = array[i][0];
                for (int j = 0; j < array[i].Length; j++)
                {
                    //Пошук найменшого елементу в кожному рядку
                    if (min > array[i][j])
                    {
                        min = array[i][j];
                    }
                    //Пошук найбільшого елементу в кожному рядку
                    if (max < array[i][j])
                    {
                        max = array[i][j];
                    }
                }
                //Запис найменшого елемента в масив
                mas[i] = k*min + (1-k)*max;
            }
            return mas;
        }

        //Лаплас
        private static int[] Laplas(int[][] array)
        {
            int buble;
            //Виділення місця для масива = кількості рядків
            int[] mas = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {              
                buble = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    //Знаходження суми елементів рядка
                    buble += array[i][j];
                }
                //Запис суми елементів рядка /3 в масив
                mas[i] = buble/3;
            }
            return mas;
        }

        //Баєс
        private static double[] Baes(int[][] array)
        {
            int buble;
            double[] koef = { 0.55, 0.3, 0.15 };
            //Виділення місця для масива = кількості рядків
            double[] mas = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                buble = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    //Знаходження суми елементів рядка
                    buble += array[i][j];
                }
                //Запис суми елементів рядка *koef в масив
                mas[i] = buble*koef[i];
            }
            return mas;
        }

        static void Main(string[] args)
        {          
            // Прочитали всі строки з файла
            string[] s = File.ReadAllLines("lab1.txt");

            int[][] array = new int[s.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                //Розбили строку пробелами            
                string[] str = s[i].Trim().Split(' ');
                //Створили массив 
                array[i] = new int[str.Length];
                for (int j = 0; j < str.Length; j++)
                    //Обрізали пробіли и перетворили в ціле число
                    array[i][j] = int.Parse(str[j].Trim());
            }
            //Вивід масива на экран
            Console.WriteLine("Матриця цiнностей");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write(array[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine(); 

            //Критерій Вальда
            int[] vald = new int[Vald(array).Length];
            vald = Vald(array);
            Console.Write("Критерiй Вальда: ");
            for (int i = 0; i < vald.Length; i++)
            {                   
                    Console.Write(vald[i] + " ");
            }
            Console.WriteLine();

            //Критерій Лапласа
            int[] laplas = new int[Laplas(array).Length];
            laplas = Laplas(array);
            Console.Write("Критерiй Лапласа: ");
            for (int i = 0; i < laplas.Length; i++)
            {
                Console.Write(laplas[i] + " ");
            }
            Console.WriteLine();

            //Критерій Гурвіца
            double[] gurviz = new double[Gurviz(array).Length];
            gurviz = Gurviz(array);
            Console.Write("Критерiй Гурвiца: ");
            for (int i = 0; i < gurviz.Length; i++)
            {
                Console.Write(gurviz[i] + " ");
            }
            Console.WriteLine();

            //Критерій Байеса-Лапласа
            double[] baes = new double[Baes(array).Length];
            baes = Baes(array);
            Console.Write("Критерiй Байеса-Лапласа: ");
            for (int i = 0; i < baes.Length; i++)
            {
                Console.Write(baes[i] + " ");
            }
            Console.WriteLine("\n");

            //Фінальний вивід
            Console.WriteLine("Матриця цiнностей \t V \t L \t G \t BL");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                { 
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine(vald[i] + "\t" + laplas[i] + "\t" + gurviz[i] + "\t" + baes[i]);                
            }

            Console.ReadKey();
        }
    }
}
