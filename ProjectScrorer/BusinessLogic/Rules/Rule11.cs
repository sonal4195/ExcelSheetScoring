using BusinessLogic.Helpers;
using ProjectDomain;
using System;

namespace BusinessLogic.Rules
{
    public class Rule11 : IRule
    {
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.DesignDiscussions.Contains("high level design"))
            {
                result.SignalColor = Colors.Green;
                result.Score = 5;
            }
            else if (row.DesignDiscussions.Contains("if someone wants to discuss an approach"))
            {
                result.SignalColor = Colors.Yellow;
                result.Score = 4;
            }
            else
            {
                result.SignalColor = Colors.Red;
                result.Score = 2;
            }
            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
