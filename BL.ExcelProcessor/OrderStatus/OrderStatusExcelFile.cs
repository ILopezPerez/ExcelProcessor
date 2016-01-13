using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.ExcelProcessor.OrderStatus
{
    public class OrderStatusExcelFile:ExcelFile
    {
        public OrderStatusExcelFile(string Name, String Path)
        {
            _Name = Name;
            _Path = Path;
          
        }
    }
}
