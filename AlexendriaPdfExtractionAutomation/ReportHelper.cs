using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexendriaPdfExtractionAutomation
{
    public static class ReportHelper
    {
        enum Schedules
        {
            IS,
            BS,
            CF
        }
        public static void InsertRecord(ReportRecord record, ExcelWorksheet sheet, int rowNum)
        {
            sheet.Cells[rowNum, constants.FILE_NAME_COL].Value = record.filename;
            sheet.Cells[rowNum, constants.IS_PAGE_COL].Value = record.IS_page_num;
            sheet.Cells[rowNum, constants.BS_PAGE_COL].Value = record.BS_page_num;
            sheet.Cells[rowNum, constants.CF_PAGE_COL].Value = record.CF_page_num;
            sheet.Cells[rowNum, constants.LINE_ITEM_COL + (int)Schedules.IS].Value = GetLineItemCount(record, "IS");
            sheet.Cells[rowNum, constants.LINE_ITEM_COL + (int)Schedules.BS].Value = GetLineItemCount(record, "BS");
            sheet.Cells[rowNum, constants.LINE_ITEM_COL + (int)Schedules.CF].Value = GetLineItemCount(record, "CF");
            sheet.Cells[rowNum, constants.MAPPED_LINE_ITEM_COL + (int)Schedules.IS].Value = GetMappedLineItemCount(record, "IS");
            sheet.Cells[rowNum, constants.MAPPED_LINE_ITEM_COL + (int)Schedules.BS].Value = GetMappedLineItemCount(record, "BS");
            sheet.Cells[rowNum, constants.MAPPED_LINE_ITEM_COL + (int)Schedules.CF].Value = GetMappedLineItemCount(record, "CF");
            sheet.Cells[rowNum, constants.UNMAPPED_LINE_ITEM_COL + (int)Schedules.IS].Value = GetUnmapedLineItem(record, "IS");
            sheet.Cells[rowNum, constants.UNMAPPED_LINE_ITEM_COL + (int)Schedules.BS].Value = GetUnmapedLineItem(record, "BS");
            sheet.Cells[rowNum, constants.UNMAPPED_LINE_ITEM_COL + (int)Schedules.CF].Value = GetUnmapedLineItem(record, "CF");
        }
        private static string GetLineItemCount(ReportRecord record, string schedule)
        {
            var res = record.lineItemStat.Where(item => item.Schedule == schedule).FirstOrDefault().LineItemCount;
            return string.IsNullOrEmpty(res) ? "" : res.ToString();
        }

        private static string GetMappedLineItemCount(ReportRecord record, string schedule)
        {
            var res = record.lineItemStat.Where(item => item.Schedule == schedule).FirstOrDefault().MappedLineItemCount;
            return string.IsNullOrEmpty(res) ? "" : res.ToString();
        }

        private static string GetUnmapedLineItem(ReportRecord record, string schedule)
        {
            var res = record.lineItemStat.Where(item => item.Schedule == schedule).FirstOrDefault().UnmapedLineItem;
            return string.IsNullOrEmpty(res) ? "" : res.ToString();
        }
    }
}
