using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    static class Rule8 : IRule
    {
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Tests.ToLower().Contains("Automated") && row.Tests.ToLower().Contains("Mutation"))
            {
                result.signalColor = Result.colors.green;
                result.score = 10;
            }
            else if (row.Tests.ToLower().Contains("Unit") && row.Tests.ToLower().Contains("Manual"))
            {
                result.signalColor = Result.colors.yellow;
                result.score = 8;
            }
            else
            {
                result.signalColor = Result.colors.red;
                result.score = 0;
            }
            return result;
        }
    }
}
