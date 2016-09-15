using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule9 : IRule 
    {
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (!row.FollowCodeGuidelines)
            {
                result.SignalColor = Colors.Red;
                result.Score = 0;
            }
            else if (row.GuideLines.Contains("style guide"))
            {
                result.SignalColor = Colors.Green;
                result.Score = 5;
            }
            else
            {
                result.SignalColor = Colors.Yellow;
                result.Score = 4;
            }
            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
