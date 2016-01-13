using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.ExcelProcessor
{
    public class FeErratasDAL
    {
        public class Prov_Com
        {
           public string prov;
           public string com;
        }

        /// <summary>
        /// Se obtienen los detalles del pack cuyo itemcode se recibe como parámetro
        /// </summary>
        /// <param name="ItemCode">Itemcode del pack cuyos datos se desean recuperar</param>
        /// <returns></returns>
        public static Boolean ExistFeErrata(string establecimiento, string provincia, string comunidad, string errata, string referenciaPack)
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = (from p in context.GEISIntermediaErratas
                                where (p.Colaborador == establecimiento) &&
                                (p.Provincia==provincia) &&
                                (p.Comunidad == comunidad) &&
                                (p.Errata== errata) &&
                                (p.ReferenciaPack == referenciaPack)
                                select p).SingleOrDefault();
                    if (query == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertFeErratas(string establecimiento, string provincia, string comunidad, string errata, string referenciaPack, string nombrePack)
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    GEISIntermediaErratas FeErrata = new GEISIntermediaErratas();
                    FeErrata.ItemName = referenciaPack.Substring(0, 5) + getMaxItemName(referenciaPack).ToString("D3");
                    FeErrata.Colaborador = establecimiento;
                    FeErrata.Provincia = provincia;
                    FeErrata.Comunidad = comunidad;
                    FeErrata.Errata = errata;
                    FeErrata.ReferenciaPack = referenciaPack;
                    FeErrata.NombrePack = nombrePack;
                    context.AddToGEISIntermediaErratas(FeErrata); 
                    context.SaveChanges();
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int getMaxItemName(string ReferenciaPack)
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = (from p in context.GEISIntermediaErratas
                                 where p.ItemName.StartsWith(ReferenciaPack.Substring(0, 5))
                                 select p.ItemName).Max();
                    int contador = 0;
                    if (query != null)
                    {
                        int.TryParse(query.ToString().Substring(5), out contador);
                        contador++;
                    }
                    return contador;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Prov_Com> cargaProvincias()
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = (from p in context.GEISIntermediaErratas
                                 group p by new
                                 {
                                     p.Provincia,
                                     p.Comunidad
                                 } into pc
                                 select new Prov_Com()
                                 {
                                     prov = pc.Key.Provincia,
                                     com = pc.Key.Comunidad
                                 }
                                 ).ToList();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
