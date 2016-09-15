using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    public class Rule9 : IRule 
    {
        public Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (!row.FollowCodeGuidelines)
            {
                result.signalColor = Result.colors.red;
                result.score = 0;
            }
            else if (row.GuideLines.Contains("style guide"))
            {
                result.signalColor = Result.colors.green;
                result.score = 5;
            }
            else
            {
                result.signalColor = Result.colors.yellow;
                result.score = 4;
            }
            Console.WriteLine("Score for rule 9 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
