using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    static class Rule4 : IRule
    {
        static Result result = new Result();
        public static Result logic(ExcelDataRow row)
        {
            result.signalColor = row.DocTool == "RedDocTool" ? Result.colors.red : row.DocTool == "YellowDocTool" ? Result.colors.yellow : Result.colors.green;
            result.score = result.signalColor.ToString().Contains("Red") ? 0 : result.signalColor.ToString().Contains("Yellow") ? 8 : 10;
            Console.WriteLine("Score for rule 4 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
