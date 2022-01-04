using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22ex01
{
    class Program
    {
        static void SumArray(int[] array)
        {
            int Sum = array.Sum();
            Console.WriteLine("Сумма - {0}", Sum);
        }
        static void MaxArray(Task task, object n)
        {
            int[] array = (int[])n;
            int max = array.Max();
            Console.WriteLine("Наибольшее число - {0}", max);
        }
        static void Main(string[] args)
        {
            //Ввод параметров массива случайных чисел
            Console.WriteLine("Введите количество элементов массива:");
            int lengthArray = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Диапазон рандома - введите минимум:");
            int minRandom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Диапазон рандома - введите максимум:");
            int maxRandom = Convert.ToInt32(Console.ReadLine());
            //Инициализация массива и рандома
            int[] array = new int[lengthArray];
            Random random = new Random();
            for (int i = 0; i < lengthArray; i++)
            {
                array[i] = random.Next(minRandom, maxRandom);
            }
            //Вывод получившегося массива
            for (int i = 0; i < lengthArray; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            //Преобразование массива в объект
            object arrayObj = (object)array;
            //Сумма всех элементов массива
            Task task1 = new Task(() => SumArray(array));
            //Продолжение - нахождение максимального числа
            Action<Task, object> actionMax = new Action<Task, object>(MaxArray);
            Task task2 = task1.ContinueWith(actionMax, arrayObj);

            task1.Start();

            Console.ReadKey();
        }
    }
}
