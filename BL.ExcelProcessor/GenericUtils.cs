using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BL.ExcelProcessor
{
    public static class GenericUtils
    {

        public static object[] loadFiles(string path)
        {
            object[] oFiles = new object[0];
            IExcelUtils repository = RepositoryLocator.Resolve<IExcelUtils>();
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    string[] files = Directory.GetFiles(path);
                    oFiles = repository.filesFilter(files, path);
                    return oFiles;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oFiles;
        }


    }
}
