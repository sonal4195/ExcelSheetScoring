using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    public class Driver
    {
        public void CallAllRules ()
        {
            Rule1 rule1 = new Rule1();
            Rule2 rule2 = new Rule2();
            Rule3 rule3 = new Rule3();
            Rule4 rule4 = new Rule4();
            Rule5 rule5 = new Rule5();
            Rule6 rule6 = new Rule6();
            Rule7 rule7 = new Rule7();
            Rule8 rule8 = new Rule8();
            Rule9 rule9 = new Rule9();
            ReadExcelData readData = new ReadExcelData();
            readData.ReadFromExcelFile("");
            //calls all rules
            int total;
            foreach (var row in Records.records)
            {                
                total = 0;
                total += rule1.logic(row).score;
                total += rule2.logic(row).score;
                total += rule3.logic(row).score;
                total += rule4.logic(row).score;
                total += rule5.logic(row).score;
                total += rule6.logic(row).score;
                total += rule7.logic(row).score;
                total += rule8.logic(row).score;
                total += rule9.logic(row).score;
                /* call all rules here */
                Console.WriteLine("Total score: " + total);
            }
        }
    }
}
