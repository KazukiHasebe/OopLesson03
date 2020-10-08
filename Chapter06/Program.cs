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
            //整数の例
            var numbers = 
                new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 12, 28, 19, 30, 24 };

            numbers.Distinct().Select(n => n.ToString("0000")).ToList().
                ForEach(str => Console.Write(str+" "));

            Console.WriteLine("\n-----------------------------");
            numbers.Distinct().OrderBy(n => n).ToList().
                ForEach(sortedNumbers => Console.Write(sortedNumbers + " "));

            //文字列の例
            Console.WriteLine("\n----------------------");
            var words = new List<string>
           {
               "Microsoft","Apple","Google","Oracle","FaceBook",
           };
            
            var lower = words.Select(name => name.ToLower()).ToArray();
            foreach (var low in lower)
            {
                Console.Write(low + " ");
            }

            //オブジェクトの例
            Console.WriteLine("\n------------------------");
            var books = Books.GetBooks();
            //タイトルリスト
            var titles = books.Select(name => name.Title);
            foreach (var title in titles)
            {
                Console.Write(title + " ");
            }
            //ページ数の多いベスト3
            Console.WriteLine("\n------------------------");
            books.OrderByDescending(x => x.Pages).Take(3).ToList().
                ForEach(book => Console.WriteLine(book.Title + " " + book.Pages));        
        }
    }
}
