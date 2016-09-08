using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    class Rule3 : IRule
    {
        
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.ProjectManagementTool.Contains("na") || row.ProjectManagementTool.Contains("none"))
            {
                result.signalColor = Result.colors.red;
                result.score = 0;
            }
            else
            { 
                List <string> tools = new List<string>();
                tools.Add("jira"); tools.Add("hp qc"); tools.Add("tfs"); tools.Add("mingle"); tools.Add("trello"); tools.Add("salesforce"); 
                if ( tools.Any(s => row.ProjectManagementTool.Contains(s)) )
                {
                    result.signalColor = Result.colors.green;
                    result.score = 10;
                }
                else
                {
                    result.signalColor = Result.colors.yellow;
                    result.score = 8;
                }
            }

            Console.WriteLine("Score for rule 3 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
