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
                total += Rule2.logic(row).score;
                total += Rule3.logic(row).score;
                total += Rule4.logic(row).score;
                total += Rule5.logic(row).score;
                total += Rule6.logic(row).score;
                total += Rule8.logic(row).score;
                total += Rule10.logic(row).score;
                /* call all rules here */
                Console.WriteLine("Total score: " + total);
            }
        }
    }
}
