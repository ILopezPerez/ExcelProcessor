using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.ExcelProcessor;

namespace ExcelProcessor
{
    //THIS IS THE THREAD WHICH IS GOING TO WORK, NOT THE UI THREAD
    public class Worker
    {
        // This method will be called when the thread is started. 
        public void DoWork(object parameters)
        {            
            DataDump.ProcessFiles(((MyThreadParams)parameters)._eFiles);
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data 
        // member will be accessed by multiple threads. 
        private volatile bool _shouldStop;
    }
    public class MyThreadParams:object
    {
        public object[] _eFiles;
        public MyThreadParams(object[] eFiles)
        {
            this._eFiles = eFiles;
        }
    }
}
