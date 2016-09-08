using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public interface IRule
    {
        public static Result logic(ExcelDataRow row);
    }
}
