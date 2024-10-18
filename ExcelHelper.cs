using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Data.Odbc;
/*

namespace 倍福读取Demo
{
    public class ExcelHelper
    {


        public System.Data.DataTable GetData(string Path)     //写一个方法
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 12.0;";      //连接语句，读取文件路劲
            string strExcel = "select * from [Sheet1$]";                                   //查询Excel表名，默认是Sheet1
            OleDbConnection ole = new OleDbConnection(strConn);
            ole.Open();                                                                                          //打开连接
            System.Data.DataTable schemaTable = new System.Data.DataTable();
            OleDbDataAdapter odp = new OleDbDataAdapter(strExcel, strConn);
            odp.Fill(schemaTable);
            ole.Close();
            return schemaTable;
        }


        /// 读取Excel文件
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns></returns>
        public System.Data.DataTable LoadExcel(string pPath)
        {

            string connString = "Driver={Driver do Microsoft Excel(*.xls)};DriverId=790;SafeTransactions=0;ReadOnly=1;MaxScanRows=16;Threads=3;MaxBufferSize=2024;UserCommitSync=Yes;FIL=excel 8.0;PageTimeout=5;";
            connString += "DBQ=" + pPath;
            OdbcConnection conn = new OdbcConnection(connString);
            OdbcCommand cmd = new OdbcCommand();
            cmd.Connection = conn;
            //获取Excel中第一个Sheet名称，作为查询时的表名
            string sheetName = this.GetExcelSheetName(pPath);
            string sql = "select * from [" + sheetName.Replace('.', '#') + "$]";
            cmd.CommandText = sql;
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                ds = null;
                throw new Exception("从Excel文件中获取数据时发生错误！"+e.ToString());
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                da.Dispose();
                da = null;
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn = null;
            }
        }


        private string GetExcelSheetName(string pPath)
        {
            //打开一个Excel应用

            var _excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (_excelApp == null)
            {
                throw new Exception("打开Excel应用时发生错误！");
            }
            var _books = _excelApp.Workbooks;
            //打开一个现有的工作薄
            var _book = _books.Add(pPath);
            var _sheets = _book.Sheets;
            //选择第一个Sheet页
            var _sheet = (Microsoft.Office.Interop.Excel._Worksheet)_sheets.get_Item(1);
            string sheetName = _sheet.Name;

            ReleaseCOM(_sheet);
            ReleaseCOM(_sheets);
            ReleaseCOM(_book);
            ReleaseCOM(_books);
            _excelApp.Quit();
            ReleaseCOM(_excelApp);
            return sheetName;
        }



        /// 释放COM对象
        /// </summary>
        /// <param name="pObj"></param>
        private void ReleaseCOM(object pObj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pObj);
            }
            catch
            {
                throw new Exception("释放资源时发生错误！");
            }
            finally
            {
                pObj = null;
            }
        }













        //保存数据到Excel 2024-9-30
        public void SaveToExcel(string excelName, System.Data.DataTable dataTable)
        {
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count != 0)
                    {
                        Mouse.SetCursor(Cursors.Wait);
                        CreateExcelRef();
                        FillSheet(dataTable);
                        SaveExcel(excelName);
                        Mouse.SetCursor(Cursors.Arrow);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while generating Excel report");
            }
            finally
            {
                ReleaseCOM(_sheet);
                ReleaseCOM(_sheets);
                ReleaseCOM(_book);
                ReleaseCOM(_books);
                ReleaseCOM(_excelApp);
            }
        }



        /// 创建一个Excel程序实例
        /// </summary>
        private void CreateExcelRef()
        {
            _excelApp = new Excel.Application();
            _books = (Excel.Workbooks)_excelApp.Workbooks;
            _book = (Excel._Workbook)(_books.Add(_optionalValue));
            _sheets = (Excel.Sheets)_book.Worksheets;
            _sheet = (Excel._Worksheet)(_sheets.get_Item(1));
        }




        /// 将数据填充到Excel工作表的单元格中
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <param name="values"></param>
        private void AddExcelRows(string startRange, int rowCount, int colCount, object values)
        {
            _range = _sheet.get_Range(startRange, _optionalValue);
            _range = _range.get_Resize(rowCount, colCount);
            _range.set_Value(_optionalValue, values);
        }




        /// 将内存中Excel保存到本地路径
        /// </summary>
        /// <param name="excelName"></param>
        private void SaveExcel(string excelName)
        {
            _excelApp.Visible = false;
            //保存为Office2003和Office2007都兼容的格式
            _book.SaveAs(excelName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            _excelApp.Quit();

        }

    }
}



*/