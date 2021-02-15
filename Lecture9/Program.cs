using System;
using System.Diagnostics;

namespace Lecture9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создадим меню с помощью переменной infinite , которая будет находиться в цикле do while 
            //создадим переменную choice1 для хранения выбора пользователя, который будет отвечать за то, продолжает ли   
            //программа работать, затем вложим её на проверку в условный оператор switch
            //теперь создадим вторую переменную choice2, которую вложим в условный оператор switch, отвечающий за выбор
            //пункта меню.

            bool infinite = true;
            do
            {
                //-------------------------------------------------//
                Console.WriteLine("Продолжить? 0 или 1");
                int choice1 = int.Parse(Console.ReadLine());
                //-------------------------------------------------//

                //-------------------------------------------------//
                switch (choice1)
                    {
                    case 0:
                        {
                            infinite = false;
                            break;
                        }
                    case 1:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неправильный ввод");
                            break;
                        }
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                Menu();
                int choice2 = int.Parse(Console.ReadLine());
                switch (choice2)
                {
                    case 1:
                        {
                            Console.WriteLine("Сравнение скорости работы разных видов поиска");
                            Punkt1();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Сравнение скорости работы разных видов сортировки");
                            Punkt2();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Автор программы Григорук Пётр");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Вызод из программы");
                            infinite = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Выбор некорректен, повторите ввод");
                            break;
                        }
                        
                }
                //-------------------------------------------------//

            }
            while (infinite);
        }


        ///BINARY SEARCH
        static int BinarySearch(int[] array, int searchValue, int left, int right)
        {
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (searchValue == array[middle])
                {
                    return middle;
                }
                else if (searchValue < array[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }
        ///LINSEARCH SEARCH
        public static int LinSearch(int[] array, int searchValue)
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] == searchValue)
                {
                    //Возвращаем индекс искомого значения 
                    return index;
                }
            }
            return -1;
        }
        ///BUBBLE SORT
        public static void BubbleSort(int[] array)
        {

            for(int index = 0; index<array.Length;index++)
            {
                bool hasSwap = false;
                for(int curIndex = 0;curIndex<array.Length-index-1;curIndex++)
                {
                    if(array[curIndex] > array[curIndex+1])
                    {
                        hasSwap = true;
                        Swap(ref array[curIndex], ref array[curIndex + 1]);
                    }
                }
                if(hasSwap == false)
                { 
                    break;
                }
            }
        }
        ///QUICK SORT!!!
        public static void QuickSort(int[] arr)
        {

        }
        ///MERGE SORT!!!
        public static void MergeSort(int[] arr) 
        { 

        }
        ///SELECTION SORT
        public static void SelectionSort(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                int minIndex = index;
                for (int searchIndex = minIndex + 1; searchIndex < arr.Length; searchIndex++)
                {
                    if (arr[searchIndex] < arr[minIndex])
                    {
                        minIndex = searchIndex;
                    }

                }
                int curValue = arr[index];
                arr[index] = arr[minIndex];
                arr[minIndex] = curValue;
            }
        }

        //+++++++++++++++++++++++++++++++++++++++++++//
        
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        public static void Menu()
        {
            Console.WriteLine("1.Сравнение скорости работы разных видов поиска");
            Console.WriteLine("2.Сравнение скорости работы разных видов сортировки");
            Console.WriteLine("3.О программе");
            Console.WriteLine("4.Выход");
        }

        public static void Punkt1()
        {
            //Генерация массива
            int[] array = new int[10000000];
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = index;
            }

            //Какой значеине искать?
            Console.WriteLine("Введите элемент для поиска от 0 до 999999");
            int searchValue = int.Parse(Console.ReadLine());

            
            //Секундомер1
            Stopwatch stopwatch = new Stopwatch();
            //Секундомер2
            Stopwatch stopwatch2 = new Stopwatch();

            int counter = 0;
            while (counter != 1000)
            {
                
                stopwatch.Start();
                //Выполняем поиск
                int searchIndex = LinSearch(array, searchValue);
                stopwatch.Stop();


                
                stopwatch2.Start();
                //Выполняем поиск
                int searchIndex2 = BinarySearch(array, searchValue, 0, array.Length);
                stopwatch2.Stop();

                //Выводим результаты
                Console.WriteLine($"BINARY SEARCH Найденный элемент имеет индекс {searchIndex2}");
                Console.WriteLine($"{stopwatch2.ElapsedMilliseconds} миллисекунд");
                Console.WriteLine($"LINSEARCH Найденный элемент имеет индекс {searchIndex}");
                Console.WriteLine($"{stopwatch.ElapsedMilliseconds} миллисекунд");

                counter++;
            }
            
        }

        public static void Punkt2()
        {
            //Пользовательский ввод--------------------------------------//
            Console.WriteLine("Сколько элементов будет в массиве?");
            int elementsNum = int.Parse(Console.ReadLine());
            //-----------------------------------------------------------//

            //Генерация массива1-----------------------------------------//
            int[] array = new int[elementsNum];
            var random_num = new Random();
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = random_num.Next(0, 100);
            }
            //-----------------------------------------------------------//

            //-----------------------------------------------------------//
            Stopwatch stopwatchBubble = new Stopwatch();
            Console.WriteLine(string.Join(", ", array)); //необязательный вывод* исходного массива
            stopwatchBubble.Start();
            Console.WriteLine();
            BubbleSort(array);
            stopwatchBubble.Stop();
            Console.WriteLine(string.Join(", ", array));
            //-----------------------------------------------------------//

            //Генерация массива2-----------------------------------------//
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = random_num.Next(0, 100);
            }
            //-----------------------------------------------------------//

            //-----------------------------------------------------------//
            Stopwatch standartArraySort = new Stopwatch();
            Console.WriteLine(string.Join(", ", array)); //необязательный вывод* исходного массива
            standartArraySort.Start();
            Array.Sort(array);
            standartArraySort.Stop();
            Console.WriteLine(string.Join(", ", array));
            //-----------------------------------------------------------//

            //Генерация массива3-----------------------------------------//
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = random_num.Next(0, 100);
            }
            //-----------------------------------------------------------//


            //Блок вывода результатов ,которые покажут секундомеры-------//
            Console.WriteLine();
            Console.WriteLine($"{stopwatchBubble.ElapsedMilliseconds} миллисекунд");
            Console.WriteLine($"{standartArraySort.ElapsedMilliseconds} миллисекунд");
            //-----------------------------------------------------------//
        }
    }
}
