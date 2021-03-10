using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spreadsheetgear.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public FileStreamResult DownloadReport()
        {
            // Create a new workbook.
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Set the worksheet name.
            worksheet.Name = "2005 Sales";

            // Load column titles and center.
            cells["B1"].Formula = "North";
            cells["C1"].Formula = "South";
            cells["D1"].Formula = "East";
            cells["E1"].Formula = "West";
            cells["B1:E1"].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

            // Load row titles using multiple cell text reference and iteration.
            int quarter = 1;
            foreach (SpreadsheetGear.IRange cell in cells["A2:A5"])
                cell.Formula = "Q" + quarter++;

            // Load random data and format as $ using a multiple cell range.
            SpreadsheetGear.IRange body = cells[1, 1, 4, 4];
            body.Formula = "=RAND() * 10000";
            body.NumberFormat = "$#,##0_);($#,##0)";


            // Save workbook to an Open XML (XLSX) workbook stream.
            System.IO.Stream stream = workbook.SaveToStream(
                SpreadsheetGear.FileFormat.OpenXMLWorkbook);

            // Reset stream's current position back to the beginning.
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            // Stream the Excel workbook to the client in the Open XML file
            // format compatible with Excel 2007-2019 and Excel for Office 365.
            Console.WriteLine("Working");
            return new FileStreamResult(stream,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}