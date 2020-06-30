using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class InputHandle : ILog, IDisposable, IExcelConnection
    {
        private Action<String> logDelegate;
        private XLWorkbook workBook;
        private List<string> allSheets;

        public InputHandle(string excelFilePath, Action<string> LogDelegate)
        {
            this.logDelegate = LogDelegate;
            FileInfo fi = new FileInfo(excelFilePath);
            workBook = new XLWorkbook(fi.FullName);
        } 

        public DataSet InputDataSet { get; private set; }

        public void Dispose()
        {
            if (workBook != null)
            {
                workBook.Dispose();
                workBook = null;
            }
        }

        public List<string> GetAllSheet()
        {
            if (allSheets == null)
            {
                List<string> listSheet = new List<string>();
                foreach (IXLWorksheet workSheet in workBook.Worksheets)
                {
                    listSheet.Add(workSheet.Name);
                }

                WriteLog("All Sheets :" + string.Join(" | ", listSheet));

                allSheets = listSheet;
            }

            return allSheets;
        }

        public DataTable GetDataTable(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string SheetName)
        {
            throw new NotImplementedException();
        }

        public bool Validate(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
        {
            if (logDelegate != null)
            {
                logDelegate(logtext);
            }
        }



    }
}
