using BusinessLogic.Helpers;
using ProjectDomain;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Rules
{
    public class Rule3 : IRule
    {
        
        public Result Evaluate(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.ProjectManagementTool.Contains("na") || row.ProjectManagementTool.Contains("none"))
            {
                result.SignalColor = Colors.Red;
                result.Score = 0;
            }
            else
            { 
                List <string> tools = new List<string>();
                tools.Add("jira"); tools.Add("hp qc"); tools.Add("tfs"); tools.Add("mingle"); tools.Add("trello"); tools.Add("salesforce"); 
                if ( tools.Any(s => row.ProjectManagementTool.Contains(s)) )
                {
                    result.SignalColor = Colors.Green;
                    result.Score = 10;
                }
                else
                {
                    result.SignalColor = Colors.Yellow;
                    result.Score = 8;
                }
            }

            Logger.LogRuleResult(this, result);
            return result;
        }
    }
}
