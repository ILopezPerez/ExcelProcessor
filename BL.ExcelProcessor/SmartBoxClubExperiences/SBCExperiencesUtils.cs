using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using DAL.ExcelProcessor;

namespace BL.ExcelProcessor.SmartBoxClubExperiences
{
    public class SBCExperiencesUtils : IExcelUtils
    {

        public object[] filesFilter(string[] files, string path = "")
        {
            object[] oFiles = new object[files.Count() + 1];
            int count = 0;
            Boolean first = true;
            EventHelper.OnPrintInfo("----------INICIO DE CARGA DE ARCHIVOS-----------");
            for (int i = 0; i < files.Count(); i++)
            {
                BL.ExcelProcessor.OrderStatus.OrderStatusExcelFile eFiles = new BL.ExcelProcessor.OrderStatus.OrderStatusExcelFile(files[i].Substring(path.Count() + 1), files[i]);
                if (true)
                {
                    if (first)
                    {
                        oFiles[count] = new BL.ExcelProcessor.OrderStatus.OrderStatusExcelFile("--------MARCAR TODOS--------", "--------MARCAR_TODOS--------");
                        count++;
                        first = false;
                    }
                    oFiles[count] = eFiles;
                    count++;
                }
            }
            EventHelper.OnPrintInfo("----------FIN DE CARGA DE ARCHIVOS-----------");
            return oFiles;
        }

        public void processData(System.Data.DataTable data)
        {
            List<promoSmartClub> listExp = new List<promoSmartClub>();            
            foreach (DataRow row in data.Rows)
            {
                listExp.Add(ExcelToExperienceMap(row));
            }
            DAL.ExcelProcessor.SmartBoxClubDAL.InsertExperiences(listExp); 
        }
      
        public promoSmartClub ExcelToExperienceMap(DataRow row)
        {
            promoSmartClub exp = new promoSmartClub();
            try
            {
                exp.ID_Promo = "P001";
                exp.num_pagina = Int32.Parse(row[2].ToString());
                exp.nombreCompany = row[3].ToString();
                exp.universo = row[4].ToString();
                exp.direccion = row[5].ToString();
                exp.codPostal = row[6].ToString();
                exp.localidad = row[7].ToString();
                exp.provincia = row[8].ToString();
                exp.comunidadAutonoma = row[9].ToString();
                exp.telefono = row[10].ToString();
                exp.sitioWeb = row[11].ToString();
                exp.email = row[12].ToString();
                exp.opcion1 = row[13].ToString().Replace("€","€|");
                exp.opcion2 = row[14].ToString().Replace("€", "€|");
                exp.opcion3 = row[15].ToString().Replace("€", "€|");
                exp.opcion4 = row[16].ToString().Replace("€", "€|");
                exp.opcion5 = row[17].ToString().Replace("€", "€|");
                exp.opcion6 = row[18].ToString().Replace("€", "€|");
                exp.restricciones = row[19].ToString();
                exp.masVentajas = row[20].ToString();
                exp.infoPracticas = row[21].ToString();
                exp.idFoto = row[22].ToString().Replace(".","").Replace("-","").Replace("á","a").Replace("é", "e").Replace("í","i").Replace("ó","o").Replace("ú","u").Replace("Á","A").Replace("É","E").Replace("Í","I").Replace("Ó","O").Replace("Ú","U").TrimEnd('_');
            }
            catch (Exception ex)
            {
                EventHelper.OnPrintInfo(ex.Message);
            }
            return exp;
           
            
        }
    }
}
