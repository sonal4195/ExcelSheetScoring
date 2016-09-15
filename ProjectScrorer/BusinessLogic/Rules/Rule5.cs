using BusinessLogic.Helpers;
using ProjectDomain;
using System.Collections.Generic;

namespace BusinessLogic.Rules
{
    public class Rule5 : IRule
    {       
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            List<string> monitor = new List<string>();
            monitor.Add("memory"); monitor.Add("disk");
            foreach (var check in monitor)
            {
                if (row.ApplicationMonitoring.Contains(check))
                {
                    result.SignalColor = Colors.Yellow;
                    result.Score += 2;
                }
            }
            if (row.ApplicationMonitoring.Contains("Metrics") || row.ApplicationMonitoring.Contains("Appdynamics"))
            {
                result.SignalColor = Colors.Green;
                result.Score = 5;
            }

            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
