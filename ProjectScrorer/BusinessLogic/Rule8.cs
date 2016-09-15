using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Rule8 : IRule
    {
        public Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Tests.ToLower().Contains("automated") && row.Tests.ToLower().Contains("mutation"))
            {
                result.signalColor = Result.colors.green;
                result.score = 10;
            }
            else if (row.Tests.ToLower().Contains("unit") && row.Tests.ToLower().Contains("manual"))
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
