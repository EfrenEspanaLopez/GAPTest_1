using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MergeString
{
    class Program
    {
        public static void Main(string[] args)
        {
            string value1 = string.Empty;
            string value2 = string.Empty;

            value1 = "abc";
            value2 = "efg";
            Console.WriteLine(ResultMerge(value1, value2) + " aebfcg");

            value1 = "abc";
            value2 = "efg123";
            Console.WriteLine(ResultMerge(value1, value2) + " aebfcg123");

            value1 = "abc123456";
            value2 = "efg";
            Console.WriteLine(ResultMerge(value1, value2) + " aebfcg123456");
                        

            Console.ReadKey();
        }

        public static string ResultMerge(string value1, string value2)
        {
            string result = string.Empty;
            foreach (var ctr in Interleave(value1, value2))
                result += ctr;

            return result;
        }

        public static IEnumerable<string> Interleave(string value1, string value2)
        {

            using (var enumerator1 = value1.GetEnumerator())
            using (var enumerator2 = value2.GetEnumerator())
            {
                bool continue1 = false, continue2 = false;

                while ((continue1 = enumerator1.MoveNext()) | (continue2 = enumerator2.MoveNext()))
                {
                    if (continue1)
                        yield return enumerator1.Current.ToString();

                    if (continue2)
                        yield return enumerator2.Current.ToString();
                }
            }
        }
    }
}