using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.ExcelProcessor
{
    static public class EventHelper
    {
        public delegate void MyEventHandler(string foo);
        public static event MyEventHandler printInfo;

        public static void OnPrintInfo(string foo)
        {
            printInfo(foo);
        }
    }
}
