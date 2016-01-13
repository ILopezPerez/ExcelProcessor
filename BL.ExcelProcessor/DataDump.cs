using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;
using Microsoft.Practices.Unity;

namespace BL.ExcelProcessor
{
    public static class DataDump
    {
        static object eFileBeingProcesing = null;

        public static object EFileBeingProcesing
        {
            get { return DataDump.eFileBeingProcesing; }
            private set { DataDump.eFileBeingProcesing = value; }
        }
        public static void ProcessFiles(Object[] eFiles)
        {
            //DEPENDENCE INYECTION. WE CAN NOW CHANGE THE PROCESSDATA
            IExcelUtils repository = RepositoryLocator.Resolve<IExcelUtils>();
            foreach (Object eFile in eFiles)
            {
                EFileBeingProcesing = eFile;
                String fileName = ((ExcelFile)eFile).Path;
                DataTable data = loadDataFromExcel(fileName);   
                //BE CAREFULL, HERE WE GO TO THE INTERFACE. THE CLASS WHICH INHERIT IT IS IN PROCESSESDATA/FEERRATASPROCESSESDATA.CS
                repository.processData(data);
                EFileBeingProcesing = null;
            }
            EventHelper.OnPrintInfo("TERMINADO CORRECTAMENTE. Por favor, compruebe el log.");
        }

        private static DataTable loadDataFromExcel(string fileName)
        {
            EventHelper.OnPrintInfo("Analizando fichero " + fileName);
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", fileName);
            var adapter = new OleDbDataAdapter("SELECT * FROM [Hoja1$]", connectionString);
            var ds = new DataSet();

            adapter.Fill(ds, "Hoja1");
            DataTable data = ds.Tables["Hoja1"];
            return data;
        }

        
    }
}
