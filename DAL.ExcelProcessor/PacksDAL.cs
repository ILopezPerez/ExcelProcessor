using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.ExcelProcessor
{
    public class PacksDAL
    {
        public class NombrePack
        {
           public string ItemName;
           public string ItemDescription;
           public string TCode;
        }
        /// <summary>
        /// Se obtienen los detalles del pack cuyo itemcode se recibe como parámetro
        /// </summary>
        /// <param name="ItemCode">Itemcode del pack cuyos datos se desean recuperar</param>
        /// <returns></returns>
        public static GEISIntermediaPacks PackPorTCode(string tcode)
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = from p in context.GEISIntermediaPacks
                                where p.TCode == tcode
                                select p;

                    return query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un listado completo de los TCodes dados de alta en el sistema
        /// </summary>
        /// <returns></returns>
        public static List<String> ListadoTCodes()
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = from p in context.GEISIntermediaPacks
                                orderby p.RetailPrice
                                select p.TCode;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene un listado completo de los TCodes dados de alta en el sistema
        /// </summary>
        /// <returns></returns>
        public static List<String> ListadoTCodesHidden()
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = from p in context.GEISIntermediaPacksHidden
                                orderby p.RetailPrice
                                select p.TCode;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NombrePack> ListadoNombresPacks()
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = (from p in context.GEISIntermediaPacks
                                 select new NombrePack()
                     {
                         ItemDescription = p.ItemDescription,
                         ItemName = p.ItemName,
                         TCode = p.TCode
                     }).ToList();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<NombrePack> ListadoNombresPacksHidden()
        {
            try
            {
                using (AVEB_ESEntities context = new AVEB_ESEntities())
                {
                    var query = (from p in context.GEISIntermediaPacksHidden
                               select new NombrePack()
                     {
                         ItemDescription = p.ItemDescription,
                         ItemName = p.ItemName,
                         TCode = p.TCode 
                     }).ToList();

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
