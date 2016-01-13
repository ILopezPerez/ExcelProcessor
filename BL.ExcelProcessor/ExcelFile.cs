using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.ExcelProcessor
{
    public abstract class ExcelFile
    {
        protected string _Name;
        public string Name
        {
            get { return _Name; }
        }
        protected string _Path;
        public string Path
        {
            get { return _Path; }
        }

        public ExcelFile(string Name, String Path)
        {
            this._Name = Name;
            this._Path = Path;
        }
        public ExcelFile()
        {
        }

        public override string ToString()
        {
            return this._Name;
        }
    }
}
