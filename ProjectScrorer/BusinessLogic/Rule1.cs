using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;

namespace BusinessLogic
{
    static class Rule1
    {
        static Result result = new Result();
        public static Result logic(ExcelDataRow row)
        {
            /*
              Write logic here 
            */
            Console.WriteLine( "Score for rule 1 : "+result.score );
            Console.WriteLine("Color : " + result.signalColor.ToString());
            return result ;
        }
    }
}
