using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    static class Rule6 :IRule
    {
        
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Documentation.ToLower().Contains("low level design") && row.Documentation.ToLower().Contains("unit test cases") && row.Documentation.ToLower().Contains("system test cases") && row.Documentation.ToLower().Contains("license agreements"))
            {
                result.signalColor = Result.colors.green;
                result.score = 10;
            }
            else if (row.Documentation.ToLower().Contains("br") && row.Documentation.ToLower().Contains("sr") && row.Documentation.ToLower().Contains("arch") && row.Documentation.ToLower().Contains("tech") && row.Documentation.ToLower().Contains("component") && row.Documentation.ToLower().Contains("design") && row.Documentation.ToLower().Contains("release doc"))
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
