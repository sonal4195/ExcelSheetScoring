using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain;
using OfficeOpenXml;
using System.IO;

namespace BusinessLogic
{
    public class ReadExcelData
    {
        public void ReadFromExcelFile(string excelFilePath)
        {
            CheckFileExists(excelFilePath);

            var updatedRows = new List<ExcelDataRow>(); //ExcelDataRow - class to hold your excel row data - create your own
            var excel = new FileInfo(excelFilePath);
            using (ExcelPackage xlPackage = new ExcelPackage(excel))
            {
                CheckExcelValid(xlPackage);

                var Worksheet = xlPackage.Workbook.Worksheets.First();
                var totalRows = Worksheet.Dimension.End.Row;
                var totalColumns = Worksheet.Dimension.End.Column;
                for (int rowNum = 2; rowNum <= totalRows; rowNum++)
                {
                    // check if there is any source control system 
                    if (Worksheet.Cells[rowNum, 14].ToString().ToLower().Contains("no"))  
                    {
                        updatedRows[rowNum].HasRepositorySystem = false;
                        updatedRows[rowNum].HasBackup = false;
                    }
                    else
                    {
                        updatedRows[rowNum].HasRepositorySystem = true;
                        // check if there is  any backup system
                        if (Worksheet.Cells[rowNum, 16].ToString().ToLower().Contains("none") || Worksheet.Cells[rowNum, 16].ToString().ToLower().Contains("na"))
                        {
                            updatedRows[rowNum].HasBackup = false;
                        }
                        else
                        {
                            updatedRows[rowNum].HasBackup = true;
                        }
                    }
                    //check for rule 2
                    if (Worksheet.Cells[rowNum, 18].ToString().ToLower().Contains("still in deciding stage") || Worksheet.Cells[rowNum, 18].ToString().ToLower().Contains("no"))
                    {
                        updatedRows[rowNum].BranchingUsed = false;
                        updatedRows[rowNum].TaggedReleases = false;
                    }
                    else
                    {
                        updatedRows[rowNum].BranchingUsed = true;
                        if (Worksheet.Cells[rowNum, 18].ToString().ToLower().Contains("branch per release"))
                        {
                            updatedRows[rowNum].TaggedReleases = true;
                        }
                        else
                        {
                            updatedRows[rowNum].TaggedReleases = false;
                        }
                    }
                    //check for rule 4
                    if (Worksheet.Cells[rowNum, 23].ToString().ToLower().Contains("na"))
                    {
                        updatedRows[rowNum].DocTool = "RedDocTool";
                    }
                    else
                    {
                        if(Worksheet.Cells[rowNum, 23].ToString().ToLower().Contains("word/excel"))
                        {
                            updatedRows[rowNum].DocTool = "YellowDocTool";
                        }
                        else
                        {
                            updatedRows[rowNum].DocTool = "GreenDocTool";
                        }
                    }
                }
            }
            Records.records = updatedRows;
        }

        private static void CheckFileExists(string excelFilePath)
        {
            if (!File.Exists(excelFilePath))
                throw new FileNotFoundException("File invalid " + excelFilePath);
        }

        private static void CheckExcelValid(ExcelPackage xlPackage)
        {
            if (xlPackage.Workbook == null )
                throw new InvalidDataException("Excel is corrupt! Check the file and upload again."); //+ excelFilePath
        }

        //Excel extension - create in a separate static class
        public static string GetStringValueFirst(this ExcelRange cells)
        {
            var firstCell = cells.First();
            return firstCell.Value == null ? string.Empty : firstCell.Value.ToString().Trim();
        }
    }
}
