using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    static class Rule12 :IRule
    {
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Tests.ToLower().Contains("mixed") && row.Tests.ToLower().Contains("agile/scrum"))
            {
                result.signalColor = Result.colors.green;
                result.score = 5;
            }
            else if (row.Tests.ToLower().Contains("mixed") && row.Tests.ToLower().Contains("waterfall"))
            {
                result.signalColor = Result.colors.yellow;
                result.score = 4;
            }
            else
            {
                result.signalColor = Result.colors.red;
                //manual evaluation for score
                Random r = new Random();
                int rInt = r.Next(1, 9);
                result.score = rInt;
            }
            return result;
        }
    }
}
