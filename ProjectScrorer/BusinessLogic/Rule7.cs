using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    class Rule7 : IRule
    {
        
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.AutomatedBuildAndDeployment.Contains("no") || row.AutomatedBuildAndDeployment.Contains("na"))
            {
                result.signalColor = Result.colors.red;
                result.score = 0;
            }
            List<string> conditions = new List<string>();
            conditions.Add("build on each commit");
            conditions.Add("deploy");
            conditions.Add("automation tests");
            conditions.Add("pass-fail report");
            conditions.Add("converage  report");
            conditions.Add("dedicated  environment");
            foreach (var check in conditions)
            {
                if (row.AutomatedBuildAndDeployment.Contains(check))
                    result.score += 2;
            }
            if (result.score < 8)
            {
                result.signalColor = Result.colors.red;
            }
            else if (result.score > 8)
            {
                result.score = 10;
                result.signalColor = Result.colors.green;
            }
            else
            {
                result.score = 8;
                result.signalColor = Result.colors.yellow;
            }
            Console.WriteLine("Score for rule 7 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
