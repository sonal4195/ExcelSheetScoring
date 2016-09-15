using ProjectDomain;

namespace BusinessLogic.Rules
{
    public class Rule14:IRule
    {
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.TestCoverage.ToLower().Contains("more than 80%"))
            {
                result.SignalColor = Colors.Green;
            }
            else if (row.TestCoverage.ToLower().Contains("50 - 80"))
            {
                result.SignalColor = Colors.Yellow;
            }
            else
            {
                result.SignalColor = Colors.Red;
            }
            return result;
        }
    }
}
