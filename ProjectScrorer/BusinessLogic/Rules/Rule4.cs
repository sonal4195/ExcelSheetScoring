using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule4 : IRule
    {       
        public Result Evaluate(ExcelDataRow row)
        {
            var color = row.DocTool == "RedDocTool" ? Colors.Red : row.DocTool == "YellowDocTool" ? Colors.Yellow : Colors.Green;
            Result result = new Result { 
                SignalColor = color,
                Score = color == Colors.Red ? 0 : color == Colors.Yellow ? 8 : 10
            };

            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
