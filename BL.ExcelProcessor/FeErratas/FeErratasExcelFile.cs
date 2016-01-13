using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.ExcelProcessor.FeErratas
{
    public class FeErratasExcelFile:ExcelFile
    {
        private string _TCode;
        public string TCode
        {
            get { return _TCode; }
        }
        private string _PackName;
        public string PackName
        {
            get { return _PackName; }
        }

        private void evalExcelFile()
        {
            _TCode = _Name.Split(' ')[0];
            if  (PacksBL.DicPackPorTCode.ContainsKey(_TCode))
                _PackName = PacksBL.DicPackPorTCode[_TCode].ItemName;

        }
        public FeErratasExcelFile(string Name, String Path)
        {
            _Name = Name;
            _Path = Path;
            evalExcelFile();
        }
    }
}
