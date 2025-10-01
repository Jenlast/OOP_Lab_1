using System;

namespace OOP_Lab_1
{
    public class GeometricProgression
    {
        private double _a;
        private double _q;

        public double A
        {
            get { return _a; }
            set
            {
                _a = value;
            }
        }

        public double Q
        {
            get { return _q; }
            set
            {
                _q = value;
            }
        }

        public GeometricProgression(double a, double q)
        {
            A = a;
            Q = q;
        }

        public double this[int i]
        {
            get
            {
                if (i <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(i), "Номер члена прогресії повинен бути додатним.");
                }
                return A * Math.Pow(Q, i - 1);
            }
        }

        public void Input()
        {
            Console.WriteLine("Введіть перший член геометричної прогресії (a):");
            while (!double.TryParse(Console.ReadLine(), out _a))
            {
                Console.WriteLine("Некоректне значення. Будь ласка, введіть числове значення для першого члена:");
            }

            Console.WriteLine("Введіть знаменник геометричної прогресії (q):");
            while (!double.TryParse(Console.ReadLine(), out _q))
            {
                Console.WriteLine("Некоректне значення. Будь ласка, введіть числове значення для знаменника:");
            }
        }

        public void Output()
        {
            Console.WriteLine($"Перший член прогресії (a): {A}");
            Console.WriteLine($"Знаменник прогресії (q): {Q}");
        }

        public double GetAn(int i)
        {
            return this[i];
        }

        public double GetSum(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Кількість членів повинна бути додатним числом.");
            }

            if (Q == 1)
            {
                return A * n;
            }
            else
            {
                return A * (1 - Math.Pow(Q, n)) / (1 - Q);
            }
        }

        public static void RunProgression()
        {
            GeometricProgression gp = new GeometricProgression(0, 0);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                           ГЕОМЕТРИЧНА ПРОГРЕСІЯ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            gp.Input();
            gp.Output();

            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                    ДІЇ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(
                    """
                    1) Знайти n-й член прогресії
                    2) Знайти суму перших n членів прогресії
                    0) Вийти
                    """);
                string choiceStr = Console.ReadLine();
                if (!byte.TryParse(choiceStr, out byte choice))
                {
                    Console.WriteLine("Некоректний вибір. Будь ласка, введіть число від 0 до 2.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введіть номер члена прогресії (i), який ви хочете знайти:");
                        if (int.TryParse(Console.ReadLine(), out int i) && i > 0)
                        {
                            try
                            {
                                Console.WriteLine($"Значення {i}-го члена прогресії: {gp[i]}");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректне значення. Будь ласка, введіть додатне ціле число.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введіть кількість перших членів прогресії (n), суму яких ви хочете знайти:");
                        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                        {
                            try
                            {
                                Console.WriteLine($"Сума перших {n} членів прогресії: {gp.GetSum(n)}");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректне значення. Будь ласка, введіть додатне ціле число.");
                        }
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Такої опції не існує. Спробуйте ще раз.");
                        break;
                }
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("Завершення роботи з геометричною прогресією.");
        }
    }
}