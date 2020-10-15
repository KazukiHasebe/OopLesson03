using System;
using System.Collections.Generic;
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
            var dict = new Dictionary<string, List<string>>();
            bool loop = true;

            Console.WriteLine("**********************");
            Console.WriteLine("* 辞書登録プログラム *");
            Console.WriteLine("**********************");

            while (loop)
            {
                Console.WriteLine("1. 登録　2. 内容を表示　3. 終了");
                Console.Write(">");
                int mode;
                int.TryParse(Console.ReadLine(), out mode);

                switch (mode)
                {
                    case 1:
                        Console.Write("KEYを入力：");
                        string key = Console.ReadLine();
                        Console.Write("VALUEを入力:");
                        string value = Console.ReadLine();
                        if (dict.ContainsKey(key))
                        {
                            dict[key].Add(value);
                        }
                        else
                        {
                            dict[key] = new List<string> { value };
                        }
                        Console.WriteLine("登録しました。\n");
                        break;

                    case 2:
                        if (dict.Count == 0)
                        {
                            Console.WriteLine("内容が入っていません。\n");
                        }
                        else
                        {
                            foreach (var item in dict)
                            {
                                foreach (var term in item.Value)
                                {
                                    Console.WriteLine($"{item.Key} {term}");
                                }
                            }
                            Console.WriteLine("内容表示しました。\n");
                        }
                        break;

                    case 3:
                        loop = false;
                        Console.WriteLine("プログラムを終了します。");
                        break;

                    default:
                        break;
                }
            }
        }   
    }
}
