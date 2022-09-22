using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SautinSoft;
using System.IO;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"D:\SETFLSEProg\SETFLSEProg.pdf";
            string pathToExcel = Path.ChangeExtension(pathToPdf, ".xls");
            
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

   
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = false;

            // 'true'  = Preserve original page layout.
            // 'false' = Place tables before text.
            f.ExcelOptions.PreservePageLayout = true;

            // The information includes the names for the culture, the writing system,
            // the calendar used, the sort order of strings, and formatting for dates and numbers.
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.NumberGroupSeparator = ".";
            f.ExcelOptions.CultureInfo = ci;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToExcel(pathToExcel);

                // Open the resulted Excel workbook.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(pathToExcel);
                }
            }
        }
    }
}
