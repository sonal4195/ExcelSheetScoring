using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace BusinessLogic
{
    static class ReadExcelDataExtension
    {
        public static string GetStringValueFirst(this ExcelRange cells)
        {
            var firstCell = cells.First();
            return firstCell.Value == null ? string.Empty : firstCell.Value.ToString().Trim();
        }
    }
}
