using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    public class Rule1 : IRule
    {
        public Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            result.signalColor = row.HasRepositorySystem == false ? Result.colors.red : (row.HasBackup == true ? Result.colors.green : Result.colors.yellow);
            result.score = result.signalColor.ToString().Equals("red") ? 0 : result.signalColor.ToString().Equals("green") ? 5 : 4;

            Console.WriteLine( "Score for rule 1 : "+result.score );
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result ;
        }
    }
}
