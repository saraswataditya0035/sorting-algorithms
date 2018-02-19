using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstInt = new List<int>() { 1, 2, 3, 4 };
            Console.WriteLine(lstInt.GetType().GetGenericArguments()[1].IsValueType);
            Console.ReadLine();
        }
    }
}
