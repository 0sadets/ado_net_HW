using System;
using System.Text;

namespace HW3_LINQ
{
//    Завдання 1:
//Дано цілочисельну послідовність.Витягти з неї всі позитивні
//числа, відсортувавши їх по зростанню.
//Завдання 2:
//Дано колекцію цілих чисел.Знайти кількість позитивних
//двозначних елементів, а також їх середнє арифметичне.
//Завдання 3:
//Дано цілочисельну колекцію, яка зберігає список років.
//Витягти з неї всі високосні роки, відсортувавши їх по зростанню.
//Завдання 4:
//Дано колекцію цілих чисел. Знайти максимальне парне значення.
//Завдання 5:
//Дано колекцію непустих рядків. Отримати колекцію рядків,
//додавши вкінець до кожної три знаки оклику.
//Завдання 6:
//Дано певний символ і строкова колекція. Отримати колекцію
//строк, які мають відповідний символ.
//Завдання 7:
//Дано колекцію непустих рядків. Згрупувати всі елементи
//по кількості символів.
     class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // 1
            Console.WriteLine("Task 1");
            int[] arr = { -5, 8, 15, 9, -96, -7, 6, 12, -8, -15, 65 };
            var task1 = arr.Where(i => i > 0).OrderBy(i => i);
            foreach (var i in task1) {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();

            // 2
            Console.WriteLine("\nTask 2");
            var task2 = arr.Where(i => i >0 && i % 2 == 0);
            foreach (var i in task2)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
            Console.WriteLine($"кiлькiсть позитивних двозначних елементiв: {task2.Count()}");
            Console.WriteLine($"їх середнє арифметичне: {task2.Average()}");

            // 3
            Console.WriteLine("\nTask 3");
            int[] years = { 2014, 2016, 1990, 1800, 2018, 2020, 1996, 1998, 2022, 2024 };
            var task3 = years.Where(i => i % 4 == 0 && i % 100 != 0 || i % 400 == 0).OrderBy(i => i);
            foreach (var i in task3)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();

            // 4
            Console.WriteLine("\nTask 4");
            var task4 = arr.Where(i=>i%2==0).Max(i => i);
            Console.WriteLine($"максимальне парне значення: {task4}");

            // 5
            Console.WriteLine("\nTask 5");
            string[] lines = { "Hello", "my", "name", "is", "Sasha", "im", "doing", "my", "homework", "right", "now" };
            string item = "!!!";
            var task5 = lines.Select(i=>i+item);
            foreach (var i in task5)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // 6
            Console.WriteLine("\nTask 6");
            string[] words = { "hello", "world", "item", "pineapple", "journey", "nothing", "runner", "gasoline" };
            char symb = 'o';
            var task6 = words.Where(i => i.Contains(symb));
            foreach (var word in task6)
            {
                Console.Write($"{word}\t");
            } Console.WriteLine();

            // 7
            Console.WriteLine("\nTask 7");
            var task7 = words.GroupBy(i => i.Length);
            foreach (var group in task7)
            {
                Console.WriteLine($"Кількість символів: {group.Key}");
                foreach (var i in group)
                {
                    Console.WriteLine($"{i} ");
                }
            }

        }
    }
}