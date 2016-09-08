using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    class Rule11 : IRule 
    {
         class Rule9 : IRule 
    {
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            if (row.DesignDiscussions.Contains("high level design")){
                result.signalColor = Result.colors.green;
                result.score = 5;
            }
            else if (row.DesignDiscussions.Contains("if someone wants to discuss an approach")){
                result.signalColor = Result.colors.yellow;
                result.score = 4;
            }
            else {
                result.signalColor = Result.colors.red;
                result.score = 2;
            }
            


            Console.WriteLine("Score for rule 11 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
