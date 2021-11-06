using System;
using System.Collections;
using System.Collections.Generic;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(20);
            foreach(var a in numbers)
            {
                Console.WriteLine(a);
            }

            ArrayList arrayList = new ArrayList();
            arrayList.Add("ffaf");
            arrayList.Add(10);
            foreach (var a in arrayList)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }
    }
}
