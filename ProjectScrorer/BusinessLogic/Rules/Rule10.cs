using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule10 : IRule
    {
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Tests.ToLower().Contains("feedback") && row.Tests.ToLower().Contains("crucible"))
            {
                result.SignalColor = Colors.Green;
                result.Score = 10;
            }
            else if (row.Tests.ToLower().Contains("documented"))
            {
                result.SignalColor = Colors.Yellow;
                result.Score = 8;
            }
            else
            {
                if (row.Tests.ToLower().Contains("verbally"))
                {
                    result.SignalColor = Colors.Red;
                    result.Score = 4;
                }
                else
                {
                    result.SignalColor = Colors.Red;
                    result.Score = 2;
                }
            }
            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
