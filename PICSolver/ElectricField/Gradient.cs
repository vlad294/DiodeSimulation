﻿namespace PICSolver.ElectricField
{
    public class Gradient
    {
        /// <summary>
        /// Calculate gradient of flattened NxM matrix
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="hx"></param>
        /// <param name="hy"></param>
        public static void Calculate(double[] vector, double[] dx, double[] dy, int n, int m, double hx = 1.0, double hy = 1.0)
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (i == 0)
                        //left
                        dx[j * n + i] = -(-3 * vector[j * n + i] + 4 * vector[j * n + i + 1] - vector[j * n + i + 2]) / 2 / hx;

                    else if (i == n - 1)
                        //right
                        dx[j * n + i] = -(3 * vector[j * n + i] - 4 * vector[j * n + i - 1] + vector[j * n + i - 2]) / 2 / hx;
                    else
                        //central
                        dx[j * n + i] = -(vector[j * n + i + 1] - vector[j * n + i - 1]) / 2 / hx;

                    if (j == 0)
                        //left
                        dy[j * n + i] = -(-3 * vector[j * n + i] + 4 * vector[(j + 1) * n + i] - vector[(j + 2) * n + i]) / 2 / hy;
                    else if (j == m - 1)
                        //right
                        dy[j * n + i] = -(3 * vector[j * n + i] - 4 * vector[(j - 1) * n + i] + vector[(j - 2) * n + i]) / 2 / hy;
                    else
                        //central
                        dy[j * n + i] = -(vector[(j + 1) * n + i] - vector[(j - 1) * n + i]) / 2 / hy;
                }
            }
        }

        /// <summary>
        /// Get first derivative vector
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="hx"></param>
        /// <returns></returns>
        public static double[] VectorDerivative(double[] vector, double hx)
        {
            var n = vector.Length;
            var derivative = new double[n];
            for (var i = 0; i < n; i++)
            {
                if (i == 0)
                    derivative[i] = -(-3 * vector[i] + 4 * vector[i + 1] - vector[i + 2]) / 2 / hx;

                else if (i == n - 1)
                    derivative[i] = -(3 * vector[i] - 4 * vector[i - 1] + vector[i - 2]) / 2 / hx;
                else
                    derivative[i] = -(vector[i + 1] - vector[i - 1]) / 2 / hx;
            }
            return derivative;
        }
    }
}
