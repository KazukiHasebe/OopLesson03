using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            bool exists = numbers.Any(n => n % 7 == 0);

            var results = numbers.Where(n => n > 0).Take(5);
            foreach (var result in results)
            {
                Console.Write(result + " ");
            }


            Console.WriteLine("\n---------------------");
            var books = Books.GetBooks();
            Console.WriteLine($"平均値：{books.Average(a => a.Price)}");
            Console.WriteLine($"合計値：{books.Sum(s => s.Price)}");
            Console.WriteLine($"本のページが最大：{books.Max(s => s.Pages)}");
            Console.WriteLine($"高価な本：{books.Max(s => s.Price)}");
            Console.WriteLine($"タイトルに「物語」がある冊数：{books.Count(s => s.Title.Contains("物語")) }");

            //600ページを超える書籍があるか?
            Console.Write("600ページを超える書籍は");
            Console.WriteLine(books.Any(x => x.Pages > 600) ? "ある" : "ない");

            //すべてが200ページ以上の書籍か?
            Console.Write("すべてが200ページ以上で");
            Console.WriteLine(books.All(x => x.Pages >= 200) ? "ある" : "ない");

            //400ページを超える本は何冊目か？
#if false
            var book = books.FirstOrDefault(x => x.Pages > 400);
            int count;
            for (count = 0; count < books.Count; count++)
            {
                if (books[count].Title.Contains(book.Title))
                {
                    break;
                }
            }
            Console.WriteLine($"400ページを超える本は{count+1}冊目です。");
#else
            var count = books.FindIndex(x => x.Pages > 400);
            Console.WriteLine($"400ページを超える本は{count + 1}冊目です。");
#endif

            //本の値段が400円以上のものを3冊表示
            books.Where(x => x.Price >= 400).Take(3).ToList().
                ForEach(item => Console.WriteLine(item.Title + " "));
            
        }
    }
}
