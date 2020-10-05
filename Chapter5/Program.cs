using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("問題5-1");
            var mozi_a = Console.ReadLine();
            var mozi_b = Console.ReadLine();

            if (String.Compare(mozi_a, mozi_b, ignoreCase: true) == 0)
            {
                Console.WriteLine("等しい");
            }
            else
            {
                Console.WriteLine("等しくない");
            }

            Console.WriteLine("\n問題5-2");
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine($"{number:#,0}");
            }
            else
            {
                Console.WriteLine("数値文字列に変換できません");
            }

            //問題5-3
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("\n問題5-3-1");
            Console.WriteLine(text.Count(s => s == ' '));

            Console.WriteLine("\n問題5-3-2");
            Console.WriteLine(text.Replace("big", "small"));

            Console.WriteLine("\n問題5-3-3");
            Console.WriteLine(text.Split(' ').Count());

            Console.WriteLine("\n問題5-3-4");
            text.Split(' ').Where(s => s.Length <= 4).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\n問題5-3-5");
            var array = text.Split(' ').ToArray();
            if (array.Length > 0)
            {
                var sb = new StringBuilder(array[0]);
                foreach (var word in array.Skip(1))
                {
                    sb.Append(' ');
                    sb.Append(word);
                }
                Console.WriteLine(sb);
            }

            Console.WriteLine("問題5-4");
            var lines = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            foreach (var item in lines.Split(';'))
            {
                var word = item.Split('=');
                Console.WriteLine("{0}:{1}", ToJapanese(word[0]), word[1]);
            }
        }

        static string ToJapanese(string key)
        {
            switch (key)
            {
                case "Novelist":
                    return "作家";

                case "BestWork":
                    return "代表作";

                case "Born":
                    return "誕生年";

                default:
                    return "     ";
            }
        }
    }
}