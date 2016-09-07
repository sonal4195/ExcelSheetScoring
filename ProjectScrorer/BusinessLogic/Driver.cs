using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    class Driver
    {
        public void CallAllRules ()
        {
            //calls all rules
            int total;
            foreach (var row in Records.records)
            {
                total = 0;
                total += Rule1.logic(row).score;
                /* call all rules here */
                Console.WriteLine("Total : " + total);
            }
        }
    }
}
