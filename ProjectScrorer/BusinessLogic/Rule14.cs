using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    static class Rule14:IRule
    {
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.TestCoverage.ToLower().Contains("more than 80%"))
            {
                result.signalColor = Result.colors.green;
            }
            else if (row.TestCoverage.ToLower().Contains("50 - 80"))
            {
                result.signalColor = Result.colors.yellow;
            }
            else
            {
                result.signalColor = Result.colors.red;
            }
            return result;
        }
    }
}
