using System;
using System.Configuration;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ConsoleApp.ExcelProcessor
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {

            BL.ExcelProcessor.EventHelper.printInfo += new BL.ExcelProcessor.EventHelper.MyEventHandler(HandleSomethingHappened);
            string path = ConfigurationManager.AppSettings.Get("Path");
            //string path = "C:\\Users\\Ignacio.Perez\\Desktop\\FeErratasFiles";
            object[] files = BL.ExcelProcessor.GenericUtils.loadFiles(path);            
            BL.ExcelProcessor.DataDump.ProcessFiles(finalFiles(files)); 
        }

     static void HandleSomethingHappened(string foo)
        {
            log.Info(foo);
            Console.WriteLine(foo);
        }

     static object[] finalFiles(object[] files)
     {
         object[] finalFiles = new object[files.Length - 1];
         for (int i = 0; i < files.Length - 1; i++)
         {
             finalFiles[i] = files[i + 1];
         }
         return finalFiles;
     }
    }
}
