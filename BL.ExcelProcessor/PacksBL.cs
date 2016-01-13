using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ExcelProcessor;

namespace BL.ExcelProcessor
{
    public static class PacksBL
    {
        private static List<String> _TCodes;
        private static Dictionary<string, DAL.ExcelProcessor.PacksDAL.NombrePack> _dicPackPorTCode;
        
        public static Dictionary<string, DAL.ExcelProcessor.PacksDAL.NombrePack> DicPackPorTCode
        {
            get { return loadDicPackPorTCode(); }
        }

        public static List<String> TCodes
        {
            get { return loadTCodes(); }
        }
        public static List<String> loadTCodes()
        {
            if(_TCodes ==null)
            {
                _TCodes=PacksDAL.ListadoTCodes();
                _TCodes.AddRange(PacksDAL.ListadoTCodesHidden());
            }
            return _TCodes;
        }
        public static Dictionary<string, DAL.ExcelProcessor.PacksDAL.NombrePack> loadDicPackPorTCode()
        {
            if (_dicPackPorTCode == null)
            {
                _dicPackPorTCode = new Dictionary<string, DAL.ExcelProcessor.PacksDAL.NombrePack>();
                foreach (DAL.ExcelProcessor.PacksDAL.NombrePack NombrePack in getListNamesAllPacks())
                {
                    _dicPackPorTCode.Add(NombrePack.TCode, NombrePack);
                }
            }
            return _dicPackPorTCode;
        }

        public static List<DAL.ExcelProcessor.PacksDAL.NombrePack> getListNamesAllPacks()
        {
            List<DAL.ExcelProcessor.PacksDAL.NombrePack> lPacks = new List<DAL.ExcelProcessor.PacksDAL.NombrePack>();
            lPacks.AddRange(DAL.ExcelProcessor.PacksDAL.ListadoNombresPacks());
            lPacks.AddRange(DAL.ExcelProcessor.PacksDAL.ListadoNombresPacksHidden());
            return lPacks;
        }

    }
}
