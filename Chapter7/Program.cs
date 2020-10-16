using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            //問題7-1
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text);
            Console.WriteLine();

            Exercise1_2(text);
            Console.WriteLine();


        }

        static void Exercise1_1(string text)
        {
            var dict = new Dictionary<char, int>();
            foreach (var item in text.ToUpper())
            {
                if ('A' <= item && item <= 'Z')
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item] += 1;
                    }
                    else
                    {
                        dict.Add(item, 1);
                    }
                }
            }

            foreach (var item in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"'{item.Key}' : {item.Value}");
            }
        }

        static void Exercise1_2(string text)
        {
            var dict = new SortedDictionary<char, int>();
            foreach (var item in text.ToUpper())
            {
                if ('A' <= item && item <= 'Z')
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item] += 1;
                    }
                    else
                    {
                        dict[item] = 1;
                    }
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"'{item.Key}' : {item.Value}");
            }
        }
    }
}
