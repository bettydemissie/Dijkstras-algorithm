using System;
using Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;
using System.Text;

namespace GraphVersionOne
{

    public class ReadExcel
    {
        public LinkedList<string[]> items;
        ExcelPackage package;
        ExcelWorksheet worksheet;
        string[] arrayOfStation;
        

        public ReadExcel()
        {
            items = new LinkedList<string[]>();
            arrayOfStation = new string[4];
        }

        public LinkedList<string[]> Excel(string path, int page)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                package = new ExcelPackage(stream);
            }

            worksheet = package.Workbook.Worksheets[page];

            foreach (var worksheet in package.Workbook.Worksheets)
            {
                //to test if reading. comment out for submission
                Console.WriteLine($"Worksheet name: {worksheet.Name}");
                Console.WriteLine($"Total rows: {worksheet.Dimension.Rows}");
                Console.WriteLine($"Total columns: {worksheet.Dimension.Columns}");
                Console.WriteLine("Cell values:");

                string[] arrayOfStation = new string[worksheet.Dimension.Rows * worksheet.Dimension.Columns];
                int index = 0;

                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    var rowValues = new string[4];
                    for (int col = 1; col <= 4; col++)
                    {
                        var cell = worksheet.Cells[row, col].GetValue<string>() ?? "";
                        rowValues[col - 1] = cell;
                    }
                    items.AddLast(rowValues);

                }
            }
            return items;
        }
    }
}

