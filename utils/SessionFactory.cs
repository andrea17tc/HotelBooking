using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;

namespace HotelBooking.utils
{
    public class SessionFactory
    {
        public static ISessionFactory BuildSessionFactory()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure("E:\\UBB\\ISS\\Project\\HotelBooking\\App.config"); // Load NHibernate configuration from a file
            var mappingFilePath = ConfigurationManager.AppSettings["UserFilePath"];

            // Add the mapping file to NHibernate configuration
            configuration.AddFile(mappingFilePath);
            var sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }
    }
}
