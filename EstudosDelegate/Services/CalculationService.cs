using System;

namespace EstudosDelegate.Services
{
    public static class CalculationService
    {
        public static double Max(double x, double y)
        {
            return (x > y) ? x : y;
        }

        public static double Sum(double x, double y)
        {
            return x + y;
        }

        public static double Square(double x)
        {
            return x * x;
        }

        public static void ShowMax(double x, double y)
        {
            var max = Max(x, y);
            Console.WriteLine(max);
        }
        
        public static void ShowSum(double x, double y)
        {
            var sum = Sum(x, y);
            Console.WriteLine(sum);
        }
    }
}