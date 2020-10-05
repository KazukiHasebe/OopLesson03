using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4, };
            Console.WriteLine($"平均値：{numbers.Average()}");
            Console.WriteLine($"合計値：{numbers.Sum()}");
            Console.WriteLine($"最小値：{numbers.Where(n => n > 0).Min()}");
            Console.WriteLine($"最大値：{numbers.Max()}");

            var books = Books.GetBooks();
            Console.WriteLine($"平均値：{books.Average(a => a.Price)}");
            Console.WriteLine($"合計値：{books.Sum(s => s.Price)}");
            Console.WriteLine($"本のページが最大：{books.Max(s => s.Pages)}");
            Console.WriteLine($"高価な本：{books.Max(s => s.Price)}");
            Console.WriteLine($"タイトルに「物語」がある冊数：{books.Count(s => s.Title.Contains("物語")) }");

        }
    }
}
