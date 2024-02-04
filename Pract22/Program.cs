using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива:");
            int size = int.Parse(Console.ReadLine());

            // Создание массива случайных чисел
            int[] array = GenerateRandomArray(size);

            // Вычисление суммы чисел массива и максимального числа в массиве
            Task<int> sumTask = Task.Run(() => CalculateSum(array));
            Task<int> maxTask = sumTask.ContinueWith(previousTask => CalculateMax(array));

            // Ожидание завершения обоих задач
            Task.WaitAll(sumTask, maxTask);

            // Вывод результатов
            Console.WriteLine($"Сумма чисел массива: {sumTask.Result}");
            Console.WriteLine($"Максимальное число в массиве: {maxTask.Result}");
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(100); // Генерация случайных чисел от 0 до 99
            }
            return array;
        }

        static int CalculateSum(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum;
        }

        static int CalculateMax(int[] array)
        {
            int max = int.MinValue;
            foreach (int num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }
    }
}