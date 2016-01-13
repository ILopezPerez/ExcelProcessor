using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BL.ExcelProcessor.FeErratas
{
    public class FeErratasUtils : IExcelUtils
    {
        private Dictionary<string, string> dicProvinciaComunidad = null;
        private Dictionary<string, string> dicReferenciaPackNombre = null;

        public FeErratasUtils()
        {
            List<DAL.ExcelProcessor.FeErratasDAL.Prov_Com> lProvComu = DAL.ExcelProcessor.FeErratasDAL.cargaProvincias();
            dicProvinciaComunidad = new Dictionary<string, string>();
            foreach (DAL.ExcelProcessor.FeErratasDAL.Prov_Com provComu in lProvComu)
            {
                string temp = string.Empty;
                dicProvinciaComunidad.TryGetValue(provComu.prov, out temp);
                if (string.IsNullOrEmpty(temp))
                    dicProvinciaComunidad.Add(provComu.prov, provComu.com);
            }
            List<DAL.ExcelProcessor.PacksDAL.NombrePack> lNombrePack = BL.ExcelProcessor.PacksBL.getListNamesAllPacks();
            dicReferenciaPackNombre = new Dictionary<string, string>();
            foreach (DAL.ExcelProcessor.PacksDAL.NombrePack NombrePack in lNombrePack)
            {
                dicReferenciaPackNombre.Add(NombrePack.ItemName, NombrePack.ItemDescription);
            }
        }

        public object[] filesFilter(string[] files, string path = "")
        {
            object[] oFiles = new object[files.Count() + 1];
            int count = 0;
            Boolean first = true;
            EventHelper.OnPrintInfo("----------INICIO DE CARGA DE ARCHIVOS-----------");
            for (int i = 0; i < files.Count(); i++)
            {
                BL.ExcelProcessor.FeErratas.FeErratasExcelFile eFiles = new BL.ExcelProcessor.FeErratas.FeErratasExcelFile(files[i].Substring(path.Count() + 1), files[i]);
                if (PacksBL.TCodes.Contains(eFiles.TCode))
                {
                    if (first)
                    {
                        oFiles[count] = new BL.ExcelProcessor.FeErratas.FeErratasExcelFile("--------MARCAR TODOS--------", "--------MARCAR_TODOS--------");
                        count++;
                        first = false;
                    }
                    oFiles[count] = eFiles;
                    count++;
                }
                else
                {
                    EventHelper.OnPrintInfo("No se reconoce el archivo :" + eFiles.Name);
                    resize(ref oFiles, oFiles.Count() - 1);
                }
            }
            EventHelper.OnPrintInfo("----------FIN DE CARGA DE ARCHIVOS-----------");
            return oFiles;
        }

        public void processData(DataTable data)
        {
            Boolean first = true;
            foreach (DataRow row in data.Rows)
            {
                if (!string.IsNullOrEmpty((string)row[0].ToString()))
                {
                    if (first)
                    {
                        if (!analyzeHeader(row))
                        {
                            EventHelper.OnPrintInfo("La información del archivo no es correcta");
                            break;
                        }
                        first = false;
                    }
                    else
                    {
                        processRow(row);
                        EventHelper.OnPrintInfo("Generando Erratas para");
                        string va = (string)row[0];
                        EventHelper.OnPrintInfo(va);
                    }
                }
            }
        }



        public void processRow(DataRow row)
        {
            try
            {
                if (this.dicProvinciaComunidad.ContainsKey(row[1].ToString()))
                {
                    if (!(DAL.ExcelProcessor.FeErratasDAL.ExistFeErrata(row[0].ToString(), row[1].ToString(), this.dicProvinciaComunidad[row[1].ToString()], row[3].ToString(), ((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString())))
                    {
                        DAL.ExcelProcessor.FeErratasDAL.InsertFeErratas(row[0].ToString(), row[1].ToString(), this.dicProvinciaComunidad[row[1].ToString()], row[3].ToString(), ((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString(), dicReferenciaPackNombre[((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString()]);
                    }
                }
                else
                {
                    if (!(DAL.ExcelProcessor.FeErratasDAL.ExistFeErrata(row[0].ToString(), row[2].ToString(), row[1].ToString(), row[3].ToString(), ((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString())))
                    {
                        DAL.ExcelProcessor.FeErratasDAL.InsertFeErratas(row[0].ToString(), row[2].ToString(), row[1].ToString(), row[3].ToString(), ((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString(), dicReferenciaPackNombre[((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString()]);
                    }
                }
            }
            catch
            {
                EventHelper.OnPrintInfo("No se ha podido insertar la errata : " + row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " " + ((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString() + " " + dicReferenciaPackNombre[((FeErratas.FeErratasExcelFile)BL.ExcelProcessor.DataDump.EFileBeingProcesing).PackName.ToString()]);
            }
        }

        public Boolean analyzeHeader(DataRow row)
        {
            if ((row[0].ToString() == "ESTABLECIMIENTO") && (row[1].ToString() == "PROVINCIA") && (row[2].ToString() == "LOCALIDAD") && (row[3].ToString() == "ERRATA"))
                return true;
            return false;
        }


        private static void resize(ref object[] oldArray, int newSize)
        {
            object[] newArray = new object[newSize];
            Array.Copy(oldArray, newArray, newSize);
            oldArray = newArray;
        }
    }
}
