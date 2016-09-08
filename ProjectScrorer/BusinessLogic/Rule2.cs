using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    static class Rule2 :IRule
    {
        
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            result.signalColor = row.BranchingUsed == false ? Result.colors.red : (row.TaggedReleases == false ? Result.colors.yellow : Result.colors.green);
            result.score = result.signalColor.ToString().Equals("red") ? 0 : result.signalColor.ToString().Equals("yellow") ? 4 : 5;
            Console.WriteLine("Score for rule 2 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
