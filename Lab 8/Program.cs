using System;

class Program
{
    static void Main(string[] args)
    {
        ArifmFunc[] funcs = { Cos, TaskB, x => (-Math.Pow((x / Math.PI), 2)) - 2 * x + 5 * Math.PI, Cicle, TaskE };
        double a = -2.0 * Math.PI;
        double b = Math.PI * 2.0;
        double step = Math.PI / 6.0;
        int negCount = 0;
        int rangeCount = 0;
        foreach (var del in funcs)
        {
            TabFunc(a, b, step, del);
            negCount += CountFunc(a, b, step, x => x < 0, del);
            rangeCount += CountFunc(a, b, step, x => x >= -1 && x <= 1, del);
        }
        Console.WriteLine($"Общее количество отрицательных значений функций: {negCount}");
        Console.WriteLine($"Общее количество значений из [-1; 1]: {rangeCount}");
    }
static void TabFunc(double a, double b, double step, ArifmFunc del)
    {
        Console.WriteLine($"\nЗначения функции {del.Method.Name} на отрезке [{a}, {b}] c шагом {step}");
        for (double x = a; x <= b; x += step)
        {
            Console.WriteLine($"x={x}\t f(x)={del(x)}");
        }
    }

    static int CountFunc(double a, double b, double step, Predicate<double> condition, ArifmFunc del)
    {
        int count = 0;
        for (double x = a; x <= b; x += step)
        {
            if (condition(del(x)))
            {
                count++;
            }
        }
        return count;
    }

    static double Cos(double x)
    {
        return Math.Cos(x);
    }

    static double TaskB(double x)
    {
        return 2 * Math.Sqrt(Math.Abs(x - 1)) + 1;
    }

    static double Cicle(double x)
    {
        double y = 0.0;
        for (int k = 1; k < 101; k++)
        {
            y += Math.Pow(((x / Math.PI * k) - 1), 2);
        }
        return y;
    }

    static double TaskE(double x)
    {
        if (x < 0)
        {
            return 1 / 4 * Math.Pow(Math.Sin(x), 2) + 1;
        }
        else
        {
            return 1 / 2 * Math.Cos(x) - 1;
        }
    }

    delegate double ArifmFunc(double x);
}