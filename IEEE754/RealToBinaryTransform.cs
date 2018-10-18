using System;
using System.Collections.Generic;

namespace RealNumberTransform
{
    public static class RealNumberTransform
    {
        public static string IEEE754(double number)
        {
            int power = 0;
            string result = null;
            SetSignBite(ref result, number);
            SetMantissa(ref result, number, ref power);
            SetExponent(ref result, power);
            return result;
        }
        private static void SetSignBite(ref string digits, double number)
        {
            if (number < 0)
                digits = "1";
            else
                digits = "0";
        }
        private static void SetMantissa(ref string digits, double number, ref int power)
        {
            number = Math.Abs(number);
            Int64 integerPart = (Int64)Math.Truncate(number);
            double referencePart = number - integerPart;
            bool flag = false;
            List<byte> integerPartBinary = MainToBinary(integerPart, ref power, ref flag);
            List<byte> referencePartBinary = ReferenceToBinary(referencePart, ref power, ref flag);
            MergeParts(integerPartBinary, referencePartBinary, ref digits, power);
        }
        private static void SetExponent(ref string digits, int power)
        {
            bool flag = false;
            int offset = 1023, expLength = 11, temp = 0;
            int exponent = offset + power;
            string exp = String.Concat<byte>(MainToBinary(exponent, ref temp, ref flag));
            if (exp.Length != expLength)
            {
                string zeros = new string('0', expLength - exp.Length);
                exp = zeros + exp;
            }
            digits = digits.Insert(1, exp);
        }
        private static List<byte> MainToBinary(Int64 integerPart, ref int power, ref bool flag)
        {
            if (integerPart == 0)
                return null;
            int counter = 0;
            List<byte> integerPartBinary = new List<byte>();
            while (integerPart != 0)
            {
                if (integerPart % 2 == 1)
                {
                    power = counter;
                    flag = true;
                }
                integerPartBinary.Insert(0, (byte)(integerPart % 2));
                integerPart /= 2;
                counter++;
            }
            return integerPartBinary;
        }
        private static List<byte> ReferenceToBinary(double referencePart, ref int power, ref bool flag)  
        {
            if (referencePart == 0)
                return null;
            int counter = 1;
            List<byte> referencePartBinary = new List<byte>();
            while(flag == false)
            {
                referencePart *= 2;
                if(referencePart >= 1)
                {
                    referencePart -= 1; 
                    power = -counter;
                    flag = true;
                }
                counter++;
            }
            counter = 0;
            while (counter < 52)
            {
                referencePart *= 2;
                if (referencePart >= 1)
                {
                    referencePartBinary.Add(1);
                    referencePart -= 1;
                }
                else
                {
                    referencePartBinary.Add(0);
                }
                counter++;
            }
            return referencePartBinary;
        }
        private static void MergeParts(List<byte> integerPart, List<byte> referencePart, ref string digits, int power)
        {
            int insertPosition = 1;
            string intPart = null, refPart = null;
            if (integerPart != null)
            {
                intPart = String.Concat<byte>(integerPart);
                Console.WriteLine(digits.Length);
                digits = digits.Insert(insertPosition, intPart.Substring(intPart.Length - power, power));
            }
            if (referencePart != null)
            {
                refPart = String.Concat<byte>(referencePart);
                digits = digits.Insert(digits.Length, refPart.Substring(0, refPart.Length - power));
            }
            if (digits.Length < (64 - 11))
            {
                digits = digits.Insert(digits.Length, new string('0', 64 - digits.Length));
            }
        }
    }
}
