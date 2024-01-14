using System.Collections.Generic;

namespace Model { 
    public static class Jaccard
    {
        public static double JaccardDistance(string firstString, string secondString)
        {
            HashSet<char> firstSet = new(firstString);
            HashSet<char> secondSet = new(secondString);

            HashSet<char> intersection = new(firstSet);
            intersection.IntersectWith(secondSet);

            int unionSize = firstSet.Count + secondSet.Count - intersection.Count;
            if (unionSize == 0)
                return 0; 

            return (double)intersection.Count / unionSize;
        }
    }
}