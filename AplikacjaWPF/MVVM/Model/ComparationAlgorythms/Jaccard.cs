using System.Collections.Generic;
using System.Linq;

namespace Model 
{ 
    public static class Jaccard
    {
        public static double JaccardDistance(string firstString, string secondString)
        {

            List<char> list1 = new List<char>(firstString);
            List<char> list2 = new List<char>(secondString);
            List<char> list3 = new List<char>(secondString);

            int intersection = list1.Count(item => list2.Remove(item));

            int union = list1.Count + list3.Count - intersection;

            double similarity = (double)intersection / union;

            return similarity;
        }
    }
}