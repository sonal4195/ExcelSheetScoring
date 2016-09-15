using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain
{
    public interface IRule
    {
        Result logic(ExcelDataRow row);
    }
}
