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
        public void CallAlRules()
        {
            //calls all rules
            Records rec  = new Records();
            int total;
            foreach (var row in rec.records)
            {
                total = 0;
                total += Rule1.logic(row).score;
                /* call all rules here */
                Console.WriteLine("Total : " + total);
            }
        }
    }
}
