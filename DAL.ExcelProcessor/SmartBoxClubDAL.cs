using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.ExcelProcessor
{
   public static class SmartBoxClubDAL
    {
       public static void InsertExperiences(List<promoSmartClub> listExperiences)
       {
           try
           {
               using (AVEB_ESEntities context = new AVEB_ESEntities())
               {
                   foreach (promoSmartClub experience in listExperiences)
                   {
                       context.promoSmartClub.AddObject(experience);
                   }
                   context.SaveChanges();
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
