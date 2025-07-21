using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming.Math
{
    internal class MathE
    {
        public void Question1107()
        {
            float x = -3;

            float xPow2 = MathF.Pow(x, 2); // this is -3^2 

            float result = xPow2 - 2 * x + 2;

            Console.WriteLine($"Result of X^2 - 2 * X + 2: {result}"); // This will log the result
        }

        void Calc(int a, int b) // Question 1102
        {
            int result = 4 * (a + b) - 3 * (b - a);
            Console.WriteLine($"Result of 4 * (A + B) - 3 * (B - A): {result}"); // This will log the result
        }

        public void CalcABAdd(float a, float b)
        {


            float bPow = MathF.Pow(b, 2);

            float result = a + bPow;

            Console.WriteLine($"Result of A + B^2: {result}"); // This will log the result

        }

        public void CalcABSub(float a, float b)
        {


            float bPow = MathF.Pow(b, 2);

            float result = a - bPow;

            Console.WriteLine($"Result of A - B^2: {result}"); // This will log the result

        }

        public void CalcParaABAdd(float a, float b)
        {


            float Add = (a + b);
            float check = -3 + -5; // this is same as above

            float pow = MathF.Pow(Add, 2); // this is -8^2

            float result = pow;

            Console.WriteLine($"Result of (A + B)^2: {result}"); // This will log the result
        }

        public void CalcParaABSub(float a, float b)
        {


            float Add = a - b;

            float pow = MathF.Pow(Add, 2); // this is -8^2

            float result = pow;

            Console.WriteLine($"Result of (A - B)^2: {result}"); // This will log the result

        }

        //public float Pow(float baseValue, float exponent)
        //{
        //    if (exponent == 0) return 1;
        //    if (exponent < 0) return 1 / Pow(baseValue, -exponent);
        //    float result = 1;
        //    for (int i = 0; i < exponent; i++)
        //    {
        //        result *= baseValue;
        //    }
        //    return result;
        //}
    }
}
