using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    internal class Program
    {
        public static Action<string> ShowTime = (Time)
                => Console.WriteLine
                ($"Time: {DateTime.Now.ToString(Time)}");

        public static Func<double, double, double, double>
            ShowTriangleArea = TriangleArea;

        public static Func<double, double, double>
            ShowRectangleArea = RectangleArea;

        static void Main(string[] args)
        {
            ShowTime("hh:mm:ss");
            ShowTime("dd.MM.yy");
            ShowTime("dddd");
            Console.WriteLine($"Triangle Area: {ShowTriangleArea(5, 5, 5)}");
            Console.WriteLine($"Area Of a Rectangle: {ShowRectangleArea(5, 5)}");
        }

        public static double TriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
        public static double RectangleArea(double length, double width)
        {
            return length * width;
        }
    }
}
