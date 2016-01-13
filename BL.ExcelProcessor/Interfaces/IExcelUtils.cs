using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BL.ExcelProcessor
{
    //INTERFACE
   public interface IExcelUtils
    {
        void processData(DataTable data);

        object[] filesFilter(string[] files, string path = "");
    }
}
