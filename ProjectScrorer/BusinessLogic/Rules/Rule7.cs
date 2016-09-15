using BusinessLogic.Helpers;
using ProjectDomain;
using System.Collections.Generic;

namespace BusinessLogic.Rules
{
    public class Rule7 : IRule
    {        
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.AutomatedBuildAndDeployment.Contains("no") || row.AutomatedBuildAndDeployment.Contains("na"))
            {
                result.SignalColor = Colors.Red;
                result.Score = 0;
            }
            List<string> conditions = new List<string>();
            conditions.Add("build on each commit");
            conditions.Add("deploy");
            conditions.Add("automation tests");
            conditions.Add("pass-fail report");
            conditions.Add("converage  report");
            conditions.Add("dedicated  environment");
            foreach (var check in conditions)
            {
                if (row.AutomatedBuildAndDeployment.Contains(check))
                    result.Score += 2;
            }
            if (result.Score < 8)
            {
                result.SignalColor = Colors.Red;
            }
            else if (result.Score > 8)
            {
                result.Score = 10;
                result.SignalColor = Colors.Green;
            }
            else
            {
                result.Score = 8;
                result.SignalColor = Colors.Yellow;
            }
            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
