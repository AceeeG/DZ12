using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace DZ12
{
    internal class Program
    {
        static void PrintNumbersFromOneToTen()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void DoExercise1()
        {
            Console.WriteLine("Упражнение 1\n");
            Thread my_thread1 = new Thread(PrintNumbersFromOneToTen);
            Thread my_thread2 = new Thread(PrintNumbersFromOneToTen);
            Thread my_thread3 = new Thread(PrintNumbersFromOneToTen);

            my_thread1.Start();
            my_thread2.Start();
            my_thread3.Start();
        }

        static int CalculateFactorial(int num)
        {
            int factorial = num;
            for(int i = num - 1; i > 0; i--)
            {
                factorial = factorial * i;
            }
            Console.WriteLine($"Факториал от {num} = {factorial}");
            return factorial;
        }
        static int CalculateSquare(int num)
        {
            Console.WriteLine($"Квадрат от {num} == {num * num}");
            return num * num;
        }
        static async Task DoExercise2()
        {
            Console.WriteLine("Упражнение 2\nВведите число");
            bool flag = int.TryParse(Console.ReadLine(), out int num);
            if(!flag)
            {
                do
                {
                    Console.WriteLine("Вы не ввели число, повторите\n");
                    flag = int.TryParse(Console.ReadLine(), out num);
                }while(!flag);
            }
            CalculateSquare(num);
            Console.WriteLine("Спим 8 сек");
            Thread.Sleep(8000);
            await Task.Run(() => CalculateFactorial(num));
        }
        static void DoExercise3()
        {
            Console.WriteLine("Упражнение 3\nВсе методы класса\n");
            Refl obj = new Refl();

            MethodInfo[] methods = obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
        static void Main(string[] args)
        {
            DoExercise1();
            Thread.Sleep(100);
            DoExercise2();
            DoExercise3();
            Console.ReadKey();
        }
    }
}
