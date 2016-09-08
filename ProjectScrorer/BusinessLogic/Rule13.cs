using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    class Rule13 : IRule 
    {
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.ScrumPractices.Contains("release/sprint planning"))
            {
                result.score += 4;
            }
            if (row.ScrumPractices.Contains("team estimation discussions"))
            {
                result.score += 4;
            }
            if (row.ScrumPractices.Contains("daily scrums"))
            {
                result.score += 1;
            }
            if (row.ScrumPractices.Contains("retrospectives") || row.ScrumPractices.Contains("Maintained burn-down") || row.ScrumPractices.Contains("sprint velocity") )
            {
                result.score += 1;
            }
            if (row.ScrumPractices.Contains("pair programming") && result.score<9)
            {
                result.score += 1;
            }

            result.signalColor = result.score > 8 ? Result.colors.green : result.score < 8 ? Result.colors.red : Result.colors.yellow;
            Console.WriteLine("Score for rule 13 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
