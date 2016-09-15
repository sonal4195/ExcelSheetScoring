using BusinessLogic.Helpers;
using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule6 :IRule
    {        
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.Documentation.ToLower().Contains("low level design") && row.Documentation.ToLower().Contains("unit test cases") && row.Documentation.ToLower().Contains("system test cases") && row.Documentation.ToLower().Contains("license agreements"))
            {
                result.SignalColor = Colors.Green;
                result.Score = 10;
            }
            else if (row.Documentation.ToLower().Contains("br") && row.Documentation.ToLower().Contains("sr") && row.Documentation.ToLower().Contains("arch") && row.Documentation.ToLower().Contains("tech") && row.Documentation.ToLower().Contains("component") && row.Documentation.ToLower().Contains("design") && row.Documentation.ToLower().Contains("release doc"))
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
