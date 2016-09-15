using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;
using BusinessLogic.Rules;

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
            Rule10 rule10 = new Rule10();
            Rule11 rule11 = new Rule11();
            Rule12 rule12 = new Rule12();
            Rule13 rule13 = new Rule13();
            ReadExcelData readData = new ReadExcelData();
            readData.ReadFromExcelFile("");
            //calls all rules
            int total;
            foreach (var row in Records.records)
            {                
                total = 0;
                total += rule1.Evaluate(row).Score;
                total += rule2.Evaluate(row).Score;
                total += rule3.Evaluate(row).Score;
                total += rule4.Evaluate(row).Score;
                total += rule5.Evaluate(row).Score;
                total += rule6.Evaluate(row).Score;
                total += rule7.Evaluate(row).Score;
                total += rule8.Evaluate(row).Score;
                total += rule9.Evaluate(row).Score;
                total += rule10.Evaluate(row).Score;
                total += rule11.Evaluate(row).Score;
                total += rule12.Evaluate(row).Score;
                total += rule13.Evaluate(row).Score;
                /* call all rules here */
                Console.WriteLine("Total score: " + total);
            }
        }
    }
}
