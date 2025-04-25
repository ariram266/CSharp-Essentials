using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharp_Concepts
{
    public static class StringManipulations
    {
        public static string name = "Ariram";
        public static int age = 34;
        public static  void challenges()
        {
            var result = CountVowelsAndConsonants("input");
            Print($"Vowels:{result.vowels},consonants:{result.consonants}");
            Print(RemoveDuplicates("iinnpuutt"));
            Print(FirstNonRepeatingCharacter("iinnppuutt").ToString());
            Print(IsomorphicStrings("add", "egg"));
            Print(CompressString("iinnnpuuuuuaaaaatt"));
            Print(LongestSubstringWithoutRepeating("iinnnpuuuuuaaaaatst").ToString());
            Print(ReverseWords("Hi Hello how are you !      l"));
            Print(LongestPalindromicSubstring("baabbbad"));

        }
        public static string ReverseWords(string input)
        {
            var words = input.Split(new[] { ' ' });
            //var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        public static string LongestPalindromicSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            // Preprocess the string to avoid even-length palindromes handling
            string t = "#" + string.Join("#", s.ToCharArray()) + "#";
            int n = t.Length;
            int[] p = new int[n];
            int c = 0, r = 0;
            int maxLen = 0;
            int start = 0;

            for (int i = 0; i < n; i++)
            {
                int mirror = 2 * c - i;

                if (i < r)
                    p[i] = Math.Min(r - i, p[mirror]);

                // Expand around the center
                while (i + p[i] + 1 < n && i - p[i] - 1 >= 0 && t[i + p[i] + 1] == t[i - p[i] - 1])
                    p[i]++;

                // Update center and right edge
                if (i + p[i] > r)
                {
                    c = i;
                    r = i + p[i];
                }

                // Update the longest palindromic substring
                if (p[i] > maxLen)
                {
                    maxLen = p[i];
                    start = (i - p[i]) / 2;  // Map the start index back to the original string
                }
            }

            return s.Substring(start, maxLen);
        }
    

    public static int LongestSubstringWithoutRepeating(string input)
        {
            var charIndexMap = new Dictionary<char, int>();
            int maxLength = 0, start = 0;

            for (int end = 0; end < input.Length; end++)
            {
                if (charIndexMap.ContainsKey(input[end]))
                {
                    start = Math.Max(start, charIndexMap[input[end]] + 1);
                }

                charIndexMap[input[end]] = end;
                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }

        private static string CompressString(string input)
        {
            //var result = new StringBuilder();
            //var prevChar = '\0';
            //int count = 1;
            //foreach( var c in v)
            //{
            //    if(prevChar == c)
            //    {
            //        count++;
            //        continue;
            //    }
            //   if(count > 1)
            //        result.Append(count);
            //   result.Append(c); 
            //    prevChar = c;
            //    count = 1;
            //}
            //if (count > 1)
            //    result.Append(count);
            //return result.ToString().Length < v.Length ? result.ToString() : v ;

            if (string.IsNullOrEmpty(input))
                return input;

            var sb = new StringBuilder();
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    sb.Append(input[i - 1]);
                    sb.Append(count);
                    count = 1;
                }
            }

            sb.Append(input[input.Length - 1]);
            sb.Append(count);

            return sb.Length < input.Length ? sb.ToString() : input;


        }

        private static string IsomorphicStrings(string v1, string v2)
        {
            var v1Tov2 = new Dictionary<char,char>();
            var v2ToV1 = new Dictionary<char,char>();
            if (v1.Length != v2.Length)
                return "Not Isomorph";
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1Tov2.Keys.Contains(v1[i]))
                {
                    if (v1Tov2[v1[i]] != v2[i])
                        return "non Isomorph";
                }
                else
                    v1Tov2[v1[i]] = v2[i];
            }
            for (int i = 0; i < v2.Length; i++)
            {
                if (v2ToV1.Keys.Contains(v2[i]))
                {
                    if (v2ToV1[v2[i]] != v1[i])
                        return "non Isomorph";
                }
                else
                    v2ToV1[v2[i]] = v1[i];
            }
            return "Isomorph";
        }

        private static string FirstNonRepeatingCharacter(string input)
        {
            var nonRepeat = new HashSet<char>();
            var Repeat = new HashSet<char>();
            foreach (var item in input)
            {
                if (!nonRepeat.Contains(item) && !Repeat.Contains(item))
                    nonRepeat.Add(item);
                else
                {
                    Repeat.Add(item);
                    nonRepeat.Remove(item);
                }
            }

            //var characterCount = new Dictionary<char, int>();
            //foreach (var item in input)
            //{
            //    if (characterCount.Keys.Contains(item))
            //        characterCount[item]++;
            //    else
            //        characterCount[item] = 1;
            //}
            //return characterCount.Where((x,y) => y==1).selr.First().Key.ToString();
            return nonRepeat.Count > 0 ? nonRepeat.First().ToString() : "\0";
        }

        private static string RemoveDuplicates(string input)
        {
            
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (!sb.ToString().Contains(item))
                    sb.Append(item);
            }
            //if(string.IsNullOrEmpty(input.ToString()))
            //    return string.Empty;
            //var hs = new HashSet<char>();
            //foreach (var item in input)
            //{
            //    if (!hs.Contains(item))
            //        hs.Append(item);
            //}
            //return hs.ToString();
            return sb.ToString();
        }

        private static (int vowels,int consonants) CountVowelsAndConsonants(string input)
        {
            int vowels = 0;
            int consonants = 0;
            /*foreach (var item in input.ToUpper())
            {
                if (item == 'A' | item == 'E' | item == 'I' | item == 'O' | item == 'U')
                    vowels++;
                else
                    consonants++;

            }*/
            string vowelslist = "aeiouAEIOU";
            foreach (var item in input)
            {
                if (Char.IsLetter(item))
                {
                    if (vowelslist.Contains(item))
                        vowels++;
                    else
                        consonants++;
                }

            }
            return (vowels, consonants);
        }

        public static void execute()
        {
            Interpolation();//String interpolation allows you to embed expressions inside string literals using curly braces {}.
            Format(); // allows you to format strings using placeholders.
            Concatenate(); // joins strings using +or String.Concat
            Substring(); //Extract substrings using Substring
            Split();// splits a string into an array of substrings using Split
            Join(); // joins an array of strings into a single string with a specified separator using Join.
            Replace(); // replace substrings or characters using Replace
            ReplacingMultiplePatterns(); //use a loop or a dictionary to handle different replacements
            CustomReplacements(); // you can use the MatchEvaluator delegate with Regex.Replace.
            Trim(); //Remove whitespace from the beginning and end of a string using Trim
            Compare(); //Compare strings using Compare, Equals, or String.Compare.
            RegEx_Split();//Use Regex.Split to split strings based on regular expression patterns.
            RegEx_Match(); //Match strings using Regex.Match.
            Padding(); //Pad strings to a certain length using PadLeft or PadRight
            Normalize();// strings to a specific form using Normalize
            ConvertString(); // strings to other data types using TryParse.
            InvariantCulture(); //Perform culture-insensitive operations using InvariantCulture.
            StringBuiler(); // Use StringBuilder for efficient string concatenation and manipulation, especially in loops.
            PatternMatch();// Use pattern matching to inspect and manipulate strings
            Base64Convertion(); //Convert strings to and from Base64 encoding.
        }

        private static void Base64Convertion()
        {
            string original = "Hello, World!";
            string encoded = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(original));
            string decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
        }

        private static void PatternMatch()
        {

             string DescribeString(string input) =>
             input switch
             {
                 null => "String is null",
                 "" => "String is empty",
                 var s when s.Length < 5 => "Short string",
                 var s when s.Length >= 5 => "Long string",
                 _ => "Unknown"
             };
            Print(DescribeString("xxx"));

        }

        private static void StringBuiler()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Hello");
            builder.Append(" ");
            builder.Append("World!");
            string result = builder.ToString(); // "Hello World!"
            builder.Remove(2,2);
             result = builder.ToString(); // "Hello World!"

        }

        private static void InvariantCulture()
        {
            string date = "2024-08-20";
            DateTime parsedDate = DateTime.Parse(date, CultureInfo.InvariantCulture);
        }

        private static void ConvertString()
        {
            string numberStr = "123";
            if (int.TryParse(numberStr, out int number))
            {
                Console.WriteLine($"Parsed number: {number}");
            }

        }

        private static void Normalize()
        {
            string decomposed = "e\u0301"; // 'e' followed by an acute accent
            string composed = decomposed.Normalize(NormalizationForm.FormC); // 'é'

        }

        private static void Padding()
        {
            string number = "42";
            string paddedNumber = number.PadLeft(5, '0'); // "00042"
            string paddedNumberwithSpace = number.PadLeft(5); // "   42"
            string paddedNumberRight = number.PadRight(5, '0'); // "00042"
            string paddedNumberRightWithSpace = number.PadRight(5); // "42   "
            var prpend = number.Prepend('2'); // "42   "

        }

        private static void RegEx_Match()
        {
            string input = "My email is 2example@example.cOm";
            Match match = Regex.Match(input, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}");

            if (match.Success)
            {
                Console.WriteLine($"Found email: {match.Value}");
            }

        }

        private static void RegEx_Split()
        {
            string data = "one1two2three3";
            string[] parts = Regex.Split(data, @"\d"); // ["one", "two", "three"]
        }

        private static void Compare()
        {
            string str1= "hello";
            string str2 = "Hello";

            bool areEqual = str1.Equals(str2, StringComparison.OrdinalIgnoreCase); // true
            int comparisonResult = string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase); // 0

        }

        private static void Trim()
        {
            string padded = "   hello   ";
            Print(padded.Trim()); // "hello"

        }

        private static void CustomReplacements()
        {
            string original = "The price is $123 and the discount is $45.";
            string pattern = @"\$(\d+)"; // Pattern to match monetary amounts

            string result = Regex.Replace(original, pattern, new MatchEvaluator(ReplaceMatch));
            Console.WriteLine(result); // Output: The price is [price: 123] and the discount is [price: 45].

        }

        private static string ReplaceMatch(Match match)
        {
            return $"[price: {match.Groups[1].Value}]";
        }

        private static void ReplacingMultiplePatterns()
        {
            string original = "Hello World! World is amazing.";

            var replacements = new Dictionary<string, string>
        {
            { "World", "Universe" },
            { "amazing", "fantastic" }
        };

            string result = original;
            foreach (var pair in replacements)
            {
                result = Regex.Replace(result, Regex.Escape(pair.Key), pair.Value);
            }

            Console.WriteLine(result); // Output: Hello Universe! Universe is fantastic.
        }

        private static void Replace()
        {
            string sentence = "The quick brown fox";
            Print(sentence.Replace("fox", "dog")); // "The quick brown dog"
            Print(sentence.Replace("Fox", "dog",StringComparison.Ordinal)); // "The quick brown fox"
            Print(sentence.Replace("Fox", "dog", StringComparison.OrdinalIgnoreCase)); // "The quick brown dog"
            Print(sentence.Replace("Fox", "dog", false,CultureInfo.InvariantCulture)); // "The quick brown dog"

            string original = "Hello world! World is beautiful.";
            string pattern = "world";
            string replacement = "Universe";
            Print(Regex.Replace(original, pattern, replacement, RegexOptions.IgnoreCase));

             original = "The price is $123 and the discount is $45.";
             pattern = @"\$\d+"; // Pattern to match monetary amounts
             replacement = "[amount]";

            Print(Regex.Replace(original, pattern, replacement));

             original = "Hello World! Welcome to the World of programming.";
            StringBuilder sb = new StringBuilder(original);

            sb.Replace("World", "Universe");
            sb.Replace("programming", "C# programming");

            Print(sb.ToString());

        }

        private static void Join()
        {
            string[] words = { "apple", "banana", "cherry" };
            Print(string.Join(", ", words)); // "apple, banana, cherry"
            Print(string.Join(',',words));
        }

        private static void Split()
        {
            string csv = "apple,banana,cherry";
            string[] fruits = csv.Split(',');
            Print(string.Join(",", fruits));
            fruits.ToList().ForEach(item => Print(item)); //LINQ
            Array.ForEach(fruits, Print); //Array

        }

        private static void Substring()
        {
            string text = "Hello, World!";
            Print(text.Substring(7, 5));
            Print(text.Substring(7));
            //Print(text.Substring(7,8)); // throws Exception index out of Range

        }

        private static void Concatenate()
        {
            Print(name+" - "+ age);
            Print(string.Concat(name, "-",age));
        }

        private static void Format()
        {
            string formatString = "Name: {0}, Age: {1}";
            string formattedMessage = string.Format(formatString, name, age);
            Print(formattedMessage);
        }

        private static void Interpolation()
        {
            
            Print($"Name:{name}\nAge:{age}");
        }
        private static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
