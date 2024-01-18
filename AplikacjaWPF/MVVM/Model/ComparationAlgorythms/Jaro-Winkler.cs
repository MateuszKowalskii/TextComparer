using System;

namespace Model 
{ 
    public static class JaroWinkler
    {
        public static double JaroDistance(string firstString, string secondString)
        {

            int len1 = firstString.Length;
            int len2 = secondString.Length;

            if (len1 == 0 || len2 == 0) return 0.0;

            int maxDistance = (int)Math.Floor((double)Math.Max(len1, len2) / 2) - 1;

            int matches = 0;

            int[] s1Array = new int[firstString.Length];
            int[] s2Array = new int[secondString.Length];

            for (int i = 0; i < len1; i++)
            {
                for (int j = Math.Max(0, i - maxDistance);
                    j < Math.Min(len2, i + maxDistance + 1); j++)

                    if (firstString[i] == secondString[j] && s2Array[j] == 0)
                    {
                        s1Array[i] = 1;
                        s2Array[j] = 1;
                        matches++;
                        break;
                    }
            }

            if (matches == 0)
                return 0.0;

            double transpositions = 0;

            int point = 0;

            for (int i = 0; i < len1; i++)
                if (s1Array[i] == 1)
                {
                    while (s2Array[point] == 0)
                        point++;

                    if (firstString[i] != secondString[point++])
                        transpositions++;
                }
            transpositions /= 2;

            return (((double)matches) / ((double)len1)
                    + ((double)matches) / ((double)len2)
                    + ((double)matches - transpositions) / ((double)matches)) / 3.0;
        }


        public static double JaroWinklerDistance(string firstString, string secondString)
        {
            double jaroDist = JaroDistance(firstString, secondString);

            int prefix = 0;

            for (int i = 0; i < Math.Min(firstString.Length, secondString.Length); i++)
            {
                if (firstString[i] == secondString[i]) prefix++;
                else break;
            }

            prefix = Math.Min(4, prefix);

            jaroDist += 0.1 * prefix * (1 - jaroDist);
            return jaroDist;
        }
    }
}