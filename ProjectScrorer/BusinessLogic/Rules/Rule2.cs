using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule2 : IRule
    {        
        public Result Evaluate(ExcelDataRow row)
        {
            var color = row.BranchingUsed == false ? Colors.Red : (row.TaggedReleases == false ? Colors.Yellow : Colors.Green);
            Result result = new Result
            {
                SignalColor = color,
                Score = color == Colors.Red ? 0 : color == Colors.Yellow ? 4 : 5
            };

            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
