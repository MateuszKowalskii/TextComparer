using System;

namespace Model
{
    public static class Levenshtein
    {
        public static double LevenshteinDistance(string firstString, string secondString)
        {
            int i, j, m, n, cost;
            int[,] d;
            m = firstString.Length;
            n = secondString.Length;

            d = new int[m + 1, n + 1];
            for (i = 0; i <= m; i++)
            {
                d[i, 0] = i;
            }
            for (j = 1; j <= n; j++)
            {
                d[0, j] = j;
            }

            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    if (firstString[i - 1] == secondString[j - 1]) cost = 0;
                    else cost = 1;
                    d[i, j] = Math.Min(d[i - 1, j] + 1,  // usunięcie znaku 
                        Math.Min(d[i, j - 1] + 1, // wstawienie znaku
                        d[i - 1, j - 1] + cost)); // zamiana znaku na inny 
                }
            }
            return 1 - (double)d[m, n] / Math.Max(m, n);
            //return d[m, n]; <-- To jest odległość Levenhsteina
        }
    }
}