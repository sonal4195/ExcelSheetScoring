using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    class Rule7 : IRule
    {
        
        public static Result logic(ExcelDataRow row)
        {
            Result result = new Result();
            Console.WriteLine("Score for rule 5 : " + result.score);
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result;
        }
    }
}
