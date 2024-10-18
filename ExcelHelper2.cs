using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

using OfficeOpenXml;


namespace 倍福读取Demo
{
    public  class ExcelHelper2
    {

      

            private void btnOpenExcel_Click(object sender, RoutedEventArgs e)
            {
               
            }

            public void btnSaveExcel_Click(object sender,DataGrid dataGrid, RoutedEventArgs e)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    DataTable dataTable = (dataGrid.ItemsSource as DataView).ToTable();
                    WriteExcelFile(filePath, dataTable);
                    MessageBox.Show("File saved successfully!");
                }
            }

            public DataTable ReadExcelFile(string filePath)
            {
                DataTable dataTable = new DataTable();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    bool hasHeader = true; // adjust it accordingly( i've mentioned that this is a simple approach)
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        dataTable.Columns.Add(hasHeader ? firstRowCell.Text : $"Column {firstRowCell.Start.Column}");
                    }
                    var startRow = hasHeader ? 2 : 1;
                    for (int rowNum = startRow; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];
                        DataRow row = dataTable.NewRow();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        dataTable.Rows.Add(row);
                    }
                }
                return dataTable;
            }

            public void WriteExcelFile(string filePath, DataTable dataTable)
            {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                    }
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                        }
                    }
                    package.SaveAs(new FileInfo(filePath));
                }
            }
        }
    
}

