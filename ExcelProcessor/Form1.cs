using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BL.ExcelProcessor;
using System.Threading;

namespace ExcelProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            BL.ExcelProcessor.EventHelper.printInfo += new BL.ExcelProcessor.EventHelper.MyEventHandler(HandleSomethingHappened);
            InitializeComponent();
            loadPath();
        }
        private void loadPath()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                StreamReader sr = new StreamReader(appPath + "\\pathfile.dat");

                //Read the first line of text
                line = sr.ReadLine();
                tbFolderSearch.Text = line;
               
                sr.Close();
            }
            catch (Exception e)
            {                
            }
        }
        private void writePath()
        {
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(appPath + "\\pathfile.dat");

                //Write a line of text
                sw.WriteLine(tbFolderSearch.Text);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
            }
        }
        private void folderSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = tbFolderSearch.Text;
            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrEmpty(fbd.SelectedPath) && (result.ToString()=="OK"))
            {
                tbFolderSearch.Text = fbd.SelectedPath;
                writePath();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                checkedListBox1.Items.Clear();
                checkedListBox1.Items.AddRange(GenericUtils.loadFiles(tbFolderSearch.Text));
            }
            catch 
            {
                lblError.Visible = true;

            }
        }

        private void checkedListBox1_ItemCheckChanged(object sender, ItemCheckEventArgs e)
        {
            //WHEN WHE CLICK IN CHECK ALL, WE CHECK EVERYTHING EXCEPTS IT SELF
            if (e.Index==0)
            { 
                for (int i = 1; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemCheckState(i, e.NewValue);
                }
            }
        }

        private void btStartDataDump_Click(object sender, EventArgs e)
        {
            var listChecked = (from ExcelFile p in checkedListBox1.CheckedItems where p.Name != "--------MARCAR TODOS--------" select p);
            int Count = listChecked.Count();
            
            object[] eFiles = new object[Count];
            
            for (int i = 0; i < Count; i++)
            {
                eFiles[i] = (object)listChecked.ElementAt(i);
            }
            //CREATING A THREAD TO NOT BLOCK THE UI
            Worker workerObject = new Worker();
            Thread t = new Thread(workerObject.DoWork);
            t.Start(new MyThreadParams(eFiles));            
        }

        void HandleSomethingHappened(string foo)
        {
            foo = foo + "\n";
            if (this.tbInfo.InvokeRequired)
            {                
                //WE NEED TO INVOKE THIS, BECAUSE THE THREAD WHICH IS TRYING TO PAINT IS NOT THE UI THREAD
                this.tbInfo.Invoke(new MethodInvoker(delegate { this.tbInfo.AppendText(foo); }));
                this.tbInfo.AutoScrollOffset = new System.Drawing.Point(0, 0);
            }
            else
            {
                this.tbInfo.AppendText(foo);
                this.tbInfo.AutoScrollOffset = new System.Drawing.Point(0, 0);
            }
        }

    }
}
