using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            #region 問題3-1-1
            Console.WriteLine("問題3-1-1");
            if (numbers.Exists(n => n % 8 == 0 || n % 9 == 0))
            {
                Console.WriteLine("存在しています");
            }
            else
            {
                Console.WriteLine("存在していません");
            }
            #endregion

            #region 問題3-1-2
            Console.WriteLine("\n問題3-1-2");
            numbers.ForEach(n => Console.WriteLine(n/2.0));
            #endregion

            #region 問題3-1-3
            Console.WriteLine("\n問題3-1-3");
            numbers.Where(n => n >= 50).ToList().ForEach(Console.WriteLine);
            #endregion

            #region 問題3-1-4
            Console.WriteLine("\n問題3-1-4");
            List<int> select = numbers.Select(n => n * 2).ToList();
            foreach (var item in select)
            {
                Console.WriteLine(item);
            }
            #endregion

            var names = new List<string>
            {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong"
            };

            #region 問題3-2-1
            Console.WriteLine("\n問題3-2-1");
            do
            {
                Console.WriteLine("都市名を入力。空行で終了");
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                Console.WriteLine(names.FindIndex(s => s == line));
            } while (true);
            #endregion

            #region 問題3-2-2
            Console.WriteLine("\n問題3-2-2");
            Console.WriteLine(names.Count(s => s.Contains("o")));
            #endregion

            #region 問題3-2-3
            Console.WriteLine("\n問題3-2-3");
            var where2 = names.Where(s => s.Contains("o")).ToArray();
            foreach (var item in where2)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 問題3-2-4
            Console.WriteLine("\n問題3-2-4");
            names.Where(s => s.Contains("B")).Select(s => s.Length).ToList().ForEach(Console.WriteLine);
            #endregion
        }

    }
}
