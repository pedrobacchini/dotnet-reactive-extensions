using EstudosDelegate.Services;

namespace EstudosDelegate
{
    internal static class Program
    {
        private delegate double BinaryNumericOperation(double n1, double n2);

        private delegate void ShowMath(double n1, double n2);
        
        private static void Main()
        {
            const double a = 10;
            const double b = 12;

            BinaryNumericOperation op = CalculationService.Max;

//            var sum = CalculationService.Max(a, b);
//            var square = CalculationService.Square(a);

            var d = op.Invoke(a, b);

//            Console.WriteLine(sum);
//            Console.WriteLine(square);

            ShowMath showMath = CalculationService.ShowMax;
            showMath += CalculationService.ShowSum;

            showMath(a, b);
        }
    }
}