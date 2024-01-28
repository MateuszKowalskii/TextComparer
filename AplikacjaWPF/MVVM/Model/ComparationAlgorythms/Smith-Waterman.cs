using System;

namespace Model
{
    public static class SmithWaterman
    {
        static double Max(double a, double b, double c, double d)
        {
            return Math.Max(Math.Max(Math.Max(a, b), c), d);
        }

        public static double SmithWatermanDistance(string s1, string s2)
        {
            double gapPenalty = -5;
            double[,] matrix = new double[s1.Length + 1, s2.Length + 1];
            double maxScore = 0;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        matrix[i, j] = Max(0, matrix[i - 1, j - 1] + 1, matrix[i - 1, j] - gapPenalty, matrix[i, j - 1] - gapPenalty);
                        maxScore = Math.Max(maxScore, matrix[i, j]);
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return (double)maxScore / Math.Max(s1.Length, s2.Length);
        }
    }
}
