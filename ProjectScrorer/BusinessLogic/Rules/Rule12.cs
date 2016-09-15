using BusinessLogic.Helpers;
using ProjectDomain;
using System;

namespace BusinessLogic.Rules
{
    public class Rule12 :IRule
    {
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.DevModel.ToLower().Contains("mixed") && row.Tests.ToLower().Contains("agile/scrum"))
            {
                result.SignalColor = Colors.Green;
                result.Score = 5;
            }
            else if (row.DevModel.ToLower().Contains("mixed") && row.Tests.ToLower().Contains("waterfall"))
            {
                result.SignalColor = Colors.Yellow;
                result.Score = 4;
            }
            else
            {
                result.SignalColor = Colors.Red;
                //manual evaluation for score
                Random r = new Random();
                int rInt = r.Next(1, 9);
                result.Score = rInt;
            }
            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
