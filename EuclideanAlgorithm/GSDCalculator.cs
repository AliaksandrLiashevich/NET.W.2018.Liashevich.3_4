using System;
using System.Diagnostics;


namespace GSDSearch
{
    public static class GSDCalculator
    {
        public static int EuclideanAlgorithm(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            return a > b ? a : b;
        }
        public static int EuclideanAlgorithm(int[] numbers, Stopwatch time)
        {
            if (numbers == null)
                throw new ArgumentNullException("Object cannot be null");
            if (numbers.Length == 1)
                return numbers[0];
            time.Start();
            int divider = EuclideanAlgorithm(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                divider = EuclideanAlgorithm(divider, numbers[i]);
            }
            time.Stop();
            return divider;
        }
        public static int BinaryEuclideanAlgorithm(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int power = 2;
            while (a != 0 && b != 0)
            {
                if ((a & 1) == 0 && (b & 1) == 0)
                {
                    a >>= 1;
                    b >>= 1;
                    power <<= 1;
                }
                else if ((a & 1) == 0)
                {
                    a >>= 1;
                }
                else if ((b & 1) == 0)
                {
                    b >>= 1;
                }
                else
                {
                    if (a > b) a -= b;
                    else b -= a;
                }
            }
            return (a > b ? a : b) * (power >>= 1);
        }
        public static int BinaryEuclideanAlgorithm(int[] numbers, Stopwatch time)
        {
            if (numbers == null)
                throw new ArgumentNullException("Object cannot be null");
            if (numbers.Length == 1)
                return numbers[0];
            time.Start();
            int divider = BinaryEuclideanAlgorithm(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                divider = BinaryEuclideanAlgorithm(divider, numbers[i]);
            }
            time.Stop();
            return divider;
        }
    }
}
