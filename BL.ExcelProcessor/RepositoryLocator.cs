using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace BL.ExcelProcessor
{
    public static class RepositoryLocator
    {
        //Constantes
        private const string DEFAULT_UNITY_CONTAINER_NAME = "FeErratas";
        private const string ORDERSTATUS_UNITY_CONTAINER_NAME = "OrderStatus";
        private const string SMBCLUB_UNITY_CONTAINER_NAME = "SmartBoxClub";

        //Container
        private static IUnityContainer container = null;
        /// <summary>
        /// Crea el UnityContainer
        /// </summary>
        private static void CreateContainer(string unityContainerName)
        {
            if (container != null) return;

            container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section == null)
                throw new Exception();
            section.Configure(container, unityContainerName);
        }

        /// <summary>
        /// Devuelve la clase concreta de un repositorio
        /// </summary>
        /// <typeparam name="TRepository">Tipo del repositorio</typeparam>
        /// <param name="btc">Coordinador de transacción de negocio</param>
        /// <param name="unityContainerName">Nombre del contenedor</param>
        /// <returns>Un repositorio del tipo dado</returns>
        public static TRepository Resolve<TRepository>()
        {
            CreateContainer(DEFAULT_UNITY_CONTAINER_NAME);
            //CreateContainer(ORDERSTATUS_UNITY_CONTAINER_NAME);
            //CreateContainer(SMBCLUB_UNITY_CONTAINER_NAME);
            TRepository repository = container.Resolve<TRepository>();

            //Return
            return repository;
        }
    }
}
