using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using log4net;

namespace HotelBooking.utils
{
    public class SessionFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SessionFactory));
        public static ISessionFactory BuildSessionFactory()
        {
            Log.Info("Creating SessionFactory");
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure("E:\\UBB\\ISS\\Project\\HotelBooking\\App.config"); // Load NHibernate configuration from a file
            
            // Add the mapping file to NHibernate configuration
            var mappingFilePath = ConfigurationManager.AppSettings["UserFilePath"];
            configuration.AddFile(mappingFilePath);
            mappingFilePath = ConfigurationManager.AppSettings["HotelFilePath"];
            configuration.AddFile(mappingFilePath);

            var sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }
    }
}
