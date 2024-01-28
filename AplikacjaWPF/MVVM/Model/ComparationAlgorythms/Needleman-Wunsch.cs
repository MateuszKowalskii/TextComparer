using System;

namespace Model
{
    public class NeedlemanWunsch
    {
        public static double NeedlemanWunschDistance(string firstString, string secondString)
        {
            int[,] matrix = new int[firstString.Length + 1, secondString.Length + 1];
            int gapPenalty = -1;

            for (int i = 0; i <= firstString.Length; i++)
                matrix[i, 0] = i * gapPenalty;

            for (int j = 0; j <= secondString.Length; j++)
                matrix[0, j] = j * gapPenalty;

            for (int i = 1; i <= firstString.Length; i++)
            {
                for (int j = 1; j <= secondString.Length; j++)
                {
                    int match = matrix[i - 1, j - 1] + (firstString[i - 1] == secondString[j - 1] ? 1 : -1);
                    int delete = matrix[i - 1, j] + gapPenalty;
                    int insert = matrix[i, j - 1] + gapPenalty;

                    matrix[i, j] = Math.Max(Math.Max(match, delete), insert);
                }
            }

            return (((double)matrix[firstString.Length, secondString.Length])/((double)(Math.Max(firstString.Length,secondString.Length)))+1)/2;
        }
    }
}
