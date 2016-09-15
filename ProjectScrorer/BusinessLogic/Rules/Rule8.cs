using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule8 : IRule
    {
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Tests.ToLower().Contains("automated") && row.Tests.ToLower().Contains("mutation"))
            {
                result.SignalColor = Colors.Green;
                result.Score = 10;
            }
            else if (row.Tests.ToLower().Contains("unit") && row.Tests.ToLower().Contains("manual"))
            {
                result.SignalColor = Colors.Yellow;
                result.Score = 8;
            }
            else
            {
                result.SignalColor = Colors.Red;
                result.Score = 0;
            }
            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
