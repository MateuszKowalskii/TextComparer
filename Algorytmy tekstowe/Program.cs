// See https://aka.ms/new-console-template for more information
using Algorytmy_tekstowe;

Console.WriteLine("Hello, World!");




string l1 = "deszcz pada a wiatr wieje";
string l2 = "jutro będzie piękniejsze";

double result = Levenshtein.LevenshteinDistance(l1, l2);
Console.WriteLine("Stopień podobieństwa tych dwóch znaków wg. Levenshteina wynosi " + result + "%");

double nextResult = JaroWinkler.JaroWinklerDistance(l1 , l2);
Console.WriteLine("Stopień podobieństwa tych dwóch znaków wg. Jaro-Winklera wynosi " + nextResult + "%");