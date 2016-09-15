using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace ProjectUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            driver.CallAllRules();
            Console.Read();
        }
    }
}
