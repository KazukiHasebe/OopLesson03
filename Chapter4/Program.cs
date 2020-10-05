using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            var ymCollection = new YearMonth[]
            {
                new YearMonth(2018, 6),
                new YearMonth(2028, 8),
                new YearMonth(2038, 7),
                new YearMonth(2048, 9),
                new YearMonth(2058, 10)
            };

            Console.WriteLine("問題4-2-2");
            Exercise2_2(ymCollection);

            Console.WriteLine("\n問題4-2-4");
            Exercise2_4(ymCollection);

            Console.WriteLine("\n問題4-2-5");
            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection)
        {
            foreach (var ym in ymCollection)
            {
                Console.WriteLine(ym);
            }
        }

        static YearMonth FindFirst21C(YearMonth[] yms)
        {
            foreach (var ym in yms)
            {
                if (ym.Is21Century)
                {
                    return ym;
                }
            }
            return null;
        }

        private static void Exercise2_4(YearMonth[] ymCollection)
        {
            var yearmonth = FindFirst21C(ymCollection);
#if false
            var s = yearmonth == null ? "21世紀のデータはありません" : yearmonth.ToString();
            Console.WriteLine(s.Year);
#else
            if (yearmonth == null)
                Console.WriteLine("21世紀のデータはありません");
            else
                Console.WriteLine(yearmonth.Year);
#endif
        }

        private static void Exercise2_5(YearMonth[] ymCollection)
        {
            var array = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            foreach (var ym in array)
            {
                Console.WriteLine(ym);
            }
        }
    }
}
