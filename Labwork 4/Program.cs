using System;


namespace Labwork_4
{
    internal class Program
    {
        //Замінити всі елементи, які розміщені перед першим від’ємним числом, на число 2.
        static void Main(string[] args)
        {
            int[] array = GetArrayFromUser();
            Console.WriteLine("Введений масив:");
            PrintArray(array);

            ProcessArray(ref array);

            Console.WriteLine("Оброблений масив:");
            PrintArray(array);
        }

        static int[] GetArrayFromUser()
        {
            Console.WriteLine("Ви бажаєте заповнити масив випадковим чином чи вручну?");
            Console.WriteLine("1 - Випадковим чином");
            Console.WriteLine("2 - Вручну");
            int choice = GetUserChoice(1, 2);

            if (choice == 1)
            {
                return GetRandomArray();
            }
            else
            {
                Console.WriteLine("Ви бажаєте вводити елементи в окремих рядках чи одним рядком?");
                Console.WriteLine("1 - Окремими рядками");
                Console.WriteLine("2 - Одним рядком");
                int inputMethod = GetUserChoice(1, 2);

                if (inputMethod == 1)
                    return GetArrayFromUserByLines();
                else
                    return GetArrayFromUserBySingleLine();
            }
        }

        static int[] GetRandomArray()
        {
            Console.Write("Введiть кiлькiсть елементiв масиву: ");
            int size = int.Parse(Console.ReadLine());

            Console.Write("Введiть мiнiмальне значення для випадкових чисел: ");
            int minValue = int.Parse(Console.ReadLine());

            Console.Write("Введiть максимальне значення для випадкових чисел: ");
            int maxValue = int.Parse(Console.ReadLine());

            if (minValue > maxValue)
            {
                Console.WriteLine("Мiнiмальне значення не може бути бiльшим за максимальне. Повторiть введення.");
                return GetRandomArray();
            }

            int[] array;
            Random rand = new Random();

            while (true)
            {
                array = new int[size];
                bool flag = false;

                for (int i = 0; i < size; i++)
                {
                    array[i] = rand.Next(minValue, maxValue + 1);
                    if (array[i] < 0)
                    {
                        flag = true;
                    }
                }

                if (flag)
                {
                    break;
                }

                Console.WriteLine("Масив не мiстить вiд’ємних чисел. Генеруємо новий...");
            }

            return array;
        }


        static int[] GetArrayFromUserByLines()
        {
            Console.Write("Введiть кiлькiсть елементiв масиву: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            return array;
        }

        static int[] GetArrayFromUserBySingleLine()
        {
            Console.WriteLine("Введiть елементи масиву через пробiл:");
            string[] parts = Console.ReadLine().Trim().Split(' ');

            int[] array = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = int.Parse(parts[i]);
            }

            return array;
        }

        static void ProcessArray(ref int[] array)
        {
            int firstNegativeIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    firstNegativeIndex = i;
                    break;
                }
            }

           
            if (firstNegativeIndex == -1)
            {
                Console.WriteLine("В масивi немає вiд’ємних чисел.");
                return;
            }

            for (int i = 0; i < firstNegativeIndex; i++)
            {
                array[i] = 2;
            }
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static int GetUserChoice(int min, int max)
        {
            int choice;
            do
            {
                Console.Write($"Введiть число вiд {min} до {max}: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max);

            return choice;
        }
    }

}


