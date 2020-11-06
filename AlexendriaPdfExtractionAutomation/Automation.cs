using ApiServicesTestAutomation;
using ApiServicesTestAutomation.modelfiles;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlexendriaPdfExtractionAutomation
{
    public static class Automation
    {
        public static async void RunAutomation(string FolderPath)
        {
            var reportFilePath = CopyTemplateAndCreateTestReport();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage templateExl = new ExcelPackage(new FileInfo(reportFilePath));
            ExcelWorksheet reportSheet = templateExl.Workbook.Worksheets["Result"];
            //var files = Directory.EnumerateFiles(FolderPath, "*.pdf", SearchOption.AllDirectories);
            ReportRecord record = new ReportRecord();
            var pageData = SampleData.GetPageNumberData();

            record.filename = "test.pdf";
            record.IS_page_num = pageData.pageBody.Where(item => item.short_name == "IS").FirstOrDefault().page_num.ToString();
            record.BS_page_num = pageData.pageBody.Where(item => item.short_name == "BS").FirstOrDefault().page_num.ToString();
            record.CF_page_num = pageData.pageBody.Where(item => item.short_name == "CF").FirstOrDefault().page_num.ToString();
            record.lineItemStat = new List<LineItemStat>();
            foreach (var schedule in pageData.pageBody)
            {

                TableResponse data = SampleData.GetTableData(schedule.short_name);//should be replace with api call of alexandria to fetch data
                record.lineItemStat.Add(new LineItemStat
                {
                    Schedule = schedule.short_name,
                    LineItemCount = data.Body.Table.Select(line => line.LineitemNum).Distinct().Count().ToString(),
                    //MappedLineItemCount=data.Body.Table.Select(line =>line.
                });
            }



            int rowIndex = 2;
            ReportHelper.InsertRecord(record, reportSheet, rowIndex);

            //foreach (var file in files)
            //{

            //    string fileKey = await UploadDocument.UploadFileAsync(file);
            //    FinancialDocument finInfo = new FinancialDocument();
            //    PageResponse pageInfo = finInfo.GetDocumentPageNo(fileKey);
            //    TableResponse tableInfo = finInfo.GetDocumentTable(pageInfo);
            //    reportSheet.Cells[rowIndex, constants.FILE_NAME_COL].Value = file;
            //    rowIndex++;

            //}
            templateExl.Save();
        }

        
        public static string CopyTemplateAndCreateTestReport(string reportFolderPath = "", string templateFilePath = "")
        {
            try
            {

                Console.WriteLine($"copying template file to report folder");
                string reportDirPath = "";

                if (string.IsNullOrEmpty(reportFolderPath))
                {
                    reportDirPath = Path.Combine(ConfigHelper.GetRootLocation(), "Reports");
                }

                if (string.IsNullOrEmpty(templateFilePath))
                {
                    templateFilePath = Path.Combine(ConfigHelper.GetRootLocation(), "Template.xlsx");
                }

                string ReportFile = "";


                if (!Directory.Exists(reportDirPath)) { Directory.CreateDirectory(reportDirPath); }
                ReportFile = Path.Combine(reportDirPath, $"Reports_{DateTime.Now.ToString("ddMMyyyyhhmm")}.xlsx");
                if (!File.Exists(ReportFile))
                {
                    File.Copy(templateFilePath, ReportFile);
                }

                return ReportFile;
            }
            catch (FileNotFoundException e)
            {
                //_logger.LogError(e);
                return default(string);
            }
            catch (System.Exception e)
            {
                //_logger.LogError(e);
                return default(string);
            }
        }
    }
}
