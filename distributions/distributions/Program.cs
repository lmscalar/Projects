using System;

namespace distributions
{
    internal class Cumulative
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Black76(1, 100.0, 100.0, 0.30, 0.02, 30.0));

        }

       
		static double ND(double x)
		{   // normal distribution function
			const double PI = 3.14159265358979;

			double nd = (1.0 / Math.Sqrt(2.0 * PI)) * Math.Exp(-x * x / 2);

			return nd;

		}

        static double CNDist(double x)
		{
            // Cumulative normal distribution, approximation 
            // of Abromowitz and Stegun, up 6 decimal placs

            double normprime, norm;
			//const double PI = 3.14159265358979;

			const double lambda = 0.2316419;
			const double a1 = 0.31938153;
			const double a2 = -0.356563782;
			const double a3 = 1.781477937;
			const double a4 = -1.821255978;
			const double a5 = 1.330274429;

			double k = 1.0 / (1.0 + lambda * x);

			normprime = ND(x);


			if (x >= 0.0)
			{
				double temp;
				temp = a1 * k + a2 * Math.Pow(k, 2) + a3 * Math.Pow(k, 3) + a4 * Math.Pow(k, 4) + a5 * Math.Pow(k, 5);
				norm = (1.0 - normprime * temp);

				return norm;
            }
			else
			{
                norm = 1.0 - CNDist(-x);
				return norm;
			}
		}

        public static double Black76(int callPut, double F, double K, double v, double rate, double expiry)
        {
			double T = expiry / 365.0;
			double d1 = (Math.Log(F / K) + v * v * T / 2)/(v*Math.Sqrt(T));
			double d2 = d1 - v * Math.Sqrt(T);

            if (callPut == 1)
            {
				double value = Math.Exp(-rate * T) * (F * CNDist(d1) - K * CNDist(d2));
				return value;
            }
            else if (callPut == -1)
            {
				double value = Math.Exp(-rate * T) * (K * CNDist(-d2) - F * CNDist(-d1));
				return value;
            }
            else
            {
                Console.WriteLine("Please Enter a 1 or -1 for a Call or Put restpectively!");
				return 0.0;
            }

        }

	}
}
