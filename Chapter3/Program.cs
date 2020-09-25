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
            var names = new List<string>
            {
            "Tokyo","New Delhi","Bankoku","London","Paris","Berlin","Canberra","Hong Kong",
            };
            //即時
            var  query = names.Where(s => s.Length <= 5).ToList();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------");

            names[0] = "Osaka";
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }

    }
}
