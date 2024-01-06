using System.Linq;
using System.Text;

namespace ViewModel
{
    public static class TextPreparator
    {
        public static string PrepareTexts(string input, bool differSignSizes, bool ignoreWhitespaces, bool ignorePunctation)
        {
            if (differSignSizes == true)
            {
                input = input.ToLower();
            }

            if (ignoreWhitespaces == true)
            {
                input = RemoveWhitespace(input);
            }

            if (ignorePunctation == true)
            {
                input = RemovePunctuation(input);
            }

            return input;
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        static string RemovePunctuation(string input)
        {
            StringBuilder cleanedText = new();

            foreach (char c in input)
            {
                if (!char.IsPunctuation(c))
                {
                    cleanedText.Append(c);
                }
            }
            return cleanedText.ToString();
        }
    }
}

