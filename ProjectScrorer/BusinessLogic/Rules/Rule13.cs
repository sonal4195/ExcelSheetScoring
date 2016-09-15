using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule13 : IRule 
    {
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.ScrumPractices.Contains("release/sprint planning"))
            {
                result.Score += 4;
            }
            if (row.ScrumPractices.Contains("team estimation discussions"))
            {
                result.Score += 4;
            }
            if (row.ScrumPractices.Contains("daily scrums"))
            {
                result.Score += 1;
            }
            if (row.ScrumPractices.Contains("retrospectives") || row.ScrumPractices.Contains("Maintained burn-down") || row.ScrumPractices.Contains("sprint velocity") )
            {
                result.Score += 1;
            }
            if (row.ScrumPractices.Contains("pair programming") && result.Score<9)
            {
                result.Score += 1;
            }

            result.SignalColor = result.Score > 8 ? Colors.Green : result.Score < 8 ? Colors.Red : Colors.Yellow;
            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
