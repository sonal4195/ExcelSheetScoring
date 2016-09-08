using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    static class Rule10
    {
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Tests.ToLower().Contains("feedback") && row.Tests.ToLower().Contains("crucible"))
            {
                result.signalColor = Result.colors.green;
                result.score = 10;
            }
            else if (row.Tests.ToLower().Contains("documented"))
            {
                result.signalColor = Result.colors.yellow;
                result.score = 8;
            }
            else
            {
                if (row.Tests.ToLower().Contains("verbally"))
                {
                    result.signalColor = Result.colors.red;
                    result.score = 4;
                }
                else
                {
                    result.signalColor = Result.colors.red;
                    result.score = 2;
                }
            }
            return result;
        }
    }
}
