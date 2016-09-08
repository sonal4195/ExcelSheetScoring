using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;


namespace BusinessLogic
{
    class Rule5 : IRule
    {
        static Result result = new Result();
        public static Result logic(ExcelDataRow row)
        {
                List<string> monitor = new List<string>();
                monitor.Add("memory"); monitor.Add("disk");
                foreach (var check in monitor)
                {
                    if (row.ApplicationMonitoring.Contains(check))
                    {
                        result.signalColor = Result.colors.yellow;
                        result.score += 2;
                    }
                }
                if (row.ApplicationMonitoring.Contains("Metrics") || row.ApplicationMonitoring.Contains("Appdynamics"))
                {
                    result.signalColor = Result.colors.green;
                    result.score = 5;
                }

            Console.WriteLine("Score for rule 5 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
