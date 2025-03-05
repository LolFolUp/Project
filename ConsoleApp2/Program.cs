using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Brain Games!");
            Console.Write("May I have your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
            Console.WriteLine("Find the smallest common multiple of given numbers.");

            Random random = new Random();
            int correctAnswers = 0;

            while (correctAnswers < 3)
            {
                int[] numbers = GenerateNumbers(random);
                int lcm = CalculateLCM(numbers);
                Console.WriteLine($"Question: {string.Join(" ", numbers)}");
                Console.Write("Your answer: ");
                if (int.TryParse(Console.ReadLine(), out int userAnswer))
                {
                    if (userAnswer == lcm)
                    {
                        Console.WriteLine("Correct!");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine($"'{userAnswer}' is wrong answer ;(. Correct answer was '{lcm}'.");
                        Console.WriteLine($"Let's try again, {name}!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            Console.WriteLine($"Congratulations, {name}!");
        }

        static int[] GenerateNumbers(Random random)
        {
            int[] numbers = new int[3];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101); // Генерация чисел от 1 до 100
            }
            return numbers;
        }

        static int CalculateLCM(int[] numbers)
        {
            int lcm = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                lcm = LCM(lcm, numbers[i]);
            }
            return lcm;
        }

        static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
