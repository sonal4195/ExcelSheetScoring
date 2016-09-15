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
                for (int rowNum = 0; rowNum <= totalRows - 2; rowNum++)
                {
                    ExcelDataRow excelRow = new ExcelDataRow();
                    // check if there is any source control system : RULE 1
                    if (Worksheet.Cells[rowNum + 2, 14].ToString().ToLower().Contains("no"))  
                    {
                        excelRow.HasRepositorySystem = false;
                        excelRow.HasBackup = false;
                    }
                    else
                    {
                        excelRow.HasRepositorySystem = true;
                        // check if there is  any backup system
                        if (Worksheet.Cells[rowNum+2, 16].ToString().ToLower().Contains("none") || Worksheet.Cells[rowNum+2, 16].ToString().ToLower().Contains("na"))
                        {
                            excelRow.HasBackup = false;
                        }
                        else
                        {
                            excelRow.HasBackup = true;
                        }
                    }
                    //check for rule 2
                    if (Worksheet.Cells[rowNum+2, 18].ToString().ToLower().Contains("still in deciding stage") || Worksheet.Cells[rowNum+2, 18].ToString().ToLower().Contains("no"))
                    {
                        excelRow.BranchingUsed = false;
                        excelRow.TaggedReleases = false;
                    }
                    else
                    {
                        excelRow.BranchingUsed = true;
                        if (Worksheet.Cells[rowNum+2, 18].ToString().ToLower().Contains("branch per release"))
                        {
                            excelRow.TaggedReleases = true;
                        }
                        else
                        {
                            excelRow.TaggedReleases = false;
                        }
                    }

                    // add project management tool :  RULE 3
                    excelRow.ProjectManagementTool = Worksheet.Cells[rowNum+2, 22].ToString().ToLower();
                    //check for rule 4
                    if (Worksheet.Cells[rowNum+2, 23].ToString().ToLower().Contains("na"))
                    {
                        excelRow.DocTool = "RedDocTool";
                    }
                    else
                    {
                        if(Worksheet.Cells[rowNum+2, 23].ToString().ToLower().Contains("word/excel"))
                        {
                            excelRow.DocTool = "YellowDocTool";
                        }
                        else
                        {
                            excelRow.DocTool = "GreenDocTool";
                        }
                    }

                    // RULE 5 : application monitoring  
                    excelRow.ApplicationMonitoring = Worksheet.Cells[rowNum+2, 24].ToString().ToLower();

                    // RULE 6 : Documentaion
                    excelRow.Documentation = Worksheet.Cells[rowNum+2, 25].ToString().ToLower();

                    // RULE  7 : Automated builds and  deployment
                    excelRow.AutomatedBuildAndDeployment = Worksheet.Cells[rowNum+2, 27].ToString().ToLower();

                    //RULE 8 :Tests
                    excelRow.Tests = Worksheet.Cells[rowNum+2, 29].ToString().ToLower();

                    // RULE 9 : Coding guidelines followed
                    excelRow.FollowCodeGuidelines = Worksheet.Cells[rowNum+2,32].ToString().ToLower().Contains("no") ? false : true;
                    excelRow.GuideLines = Worksheet.Cells[rowNum+2, 33].ToString().ToLower();

                    //RULE 10: Code Reviews
                    excelRow.Tests = Worksheet.Cells[rowNum+2, 34].ToString().ToLower();

                    // RULE 11 :  Design discussions
                    excelRow.DesignDiscussions = Worksheet.Cells[rowNum+2, 35].ToString().ToLower();

                    //RULE 12: Development Model
                    excelRow.DevModel = Worksheet.Cells[rowNum+2, 19].ToString().ToLower();

                    // RULE 13 : Scrum Practices
                    excelRow.ScrumPractices = Worksheet.Cells[rowNum+2, 36].ToString().ToLower();

                    //RULE 14: Test Coverage
                    excelRow.TestCoverage = Worksheet.Cells[rowNum+2, 30].ToString().ToLower();
                    updatedRows.Add(excelRow);
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
    }
}
