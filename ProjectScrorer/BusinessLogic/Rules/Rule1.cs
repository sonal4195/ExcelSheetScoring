using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule1 : IRule
    {
        public Result Evaluate(ExcelDataRow row)
        {
            var color = row.HasRepositorySystem == false ? Colors.Red : (row.HasBackup == true ? Colors.Green : Colors.Yellow);
            Result result = new Result {
                SignalColor = color,
                Score = color == Colors.Red ? 0 : color == Colors.Green ? 5 : 4
            };

            Logger.LogRuleResult(this, result);
            return result ;
        }
    }
}
