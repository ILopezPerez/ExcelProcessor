using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BL.ExcelProcessor.OrderStatus
{
   public class OrderStatusUtils:IExcelUtils
    {
        public object[] filesFilter(string[] files, string path = "")
        {
            object[] oFiles = new object[files.Count() + 1];
            int count = 0;
            Boolean first = true;
            EventHelper.OnPrintInfo("----------INICIO DE CARGA DE ARCHIVOS-----------");
            for (int i = 0; i < files.Count(); i++)
            {
                BL.ExcelProcessor.OrderStatus.OrderStatusExcelFile eFiles = new BL.ExcelProcessor.OrderStatus.OrderStatusExcelFile(files[i].Substring(path.Count() + 1), files[i]);
                if (true)
                {
                    if (first)
                    {
                        oFiles[count] = new BL.ExcelProcessor.OrderStatus.OrderStatusExcelFile("--------MARCAR TODOS--------", "--------MARCAR_TODOS--------");
                        count++;
                        first = false;
                    }
                    oFiles[count] = eFiles;
                    count++;
                }
            }
            EventHelper.OnPrintInfo("----------FIN DE CARGA DE ARCHIVOS-----------");
            return oFiles;
        }

        public void processData(System.Data.DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {
                    processRow(row);
            }
        }
        public void processRow(DataRow row)
        {
            try
            {
                string data = DAL.ExcelProcessor.SmartBridge.APICalls.callGetSmartBridge("v1.1/order/statusdetail/" + row[0].ToString(), true);
                EventHelper.OnPrintInfo(row[0].ToString() + ": " + DAL.ExcelProcessor.SmartBridge.APICalls.getElementTextFromXMLResponse(data, "OrderStatusLabel"));
            }
            catch
            {
                EventHelper.OnPrintInfo("Not found");
            }
        }

    }
}
