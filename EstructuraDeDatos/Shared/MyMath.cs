using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class MyMath
    {
        public static double Factorial(int n)
        {
            double factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++) //use the square root so we can divide n by every number that is less than n
            {
                if (n % i == 0) //and if there is no residue, then it isn´t a prime number.
                {
                    return false;
                }
            }
            return true; //if it passes all divisions, then it is a prime number.
        }
    }
}
