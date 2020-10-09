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
            //問題6-1
            var number = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };
            
            Console.WriteLine("問題6-1-1");
            Console.WriteLine(number.Max());

            Console.WriteLine("\n問題6-1-2");
            int pos = number.Length - 2;
            foreach (var num in number.Skip(pos))
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\n問題6-1-3");
            foreach (var str in number.Select(n => n.ToString()))
            {
                Console.Write(str + " ");
            }

            Console.WriteLine("\n問題6-1-4");
            foreach (var item in number.OrderBy(n => n).Take(3))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n問題6-1-5");
            Console.WriteLine(number.Distinct().Count(n => n > 10));

            //問題6-2
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Console.WriteLine("\n問題6-2-1");
            var book = books.FirstOrDefault(x => x.Title == "ワンダフル・C#ライフ");
            if (book != null)
            {
                Console.WriteLine($"{book.Price} {book.Pages}");
            }

            Console.WriteLine("\n問題6-2-2");
            Console.WriteLine(books.Count(x => x.Title.Contains("C#")));

            Console.WriteLine("\n問題6-2-3");
            Console.WriteLine(books.Where(x => x.Title.Contains("C#")).Average(x => x.Pages));

            Console.WriteLine("\n問題6-2-4");
            var book2 = books.FirstOrDefault(x => x.Price >= 4000);
            if (book != null)
            {
                Console.WriteLine(book2.Title);
            }

            Console.WriteLine("\n問題6-2-5");
            Console.WriteLine(books.Where(x => x.Price < 4000).Max(x => x.Pages));

            Console.WriteLine("\n問題6-2-6");
            foreach (var item in books.Where(x => x.Pages >= 400).OrderByDescending(x => x.Price))
            {
                Console.WriteLine($"{item.Title} {item.Price}");
            }

            Console.WriteLine("\n問題6-2-7");
            foreach (var item in books.Where(x => x.Title.Contains("C#") && x.Pages <= 500))
            {
                Console.WriteLine(item.Title);
            }
            
        }    
    }
}
