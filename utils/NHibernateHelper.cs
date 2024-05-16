using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HotelBooking.mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
//using System.Configuration;

namespace HotelBooking.utils
{
    public class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            // Define your connection string
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure("E:\\UBB\\ISS\\Project\\HotelBooking\\App.config"); // Load NHibernate configuration from a file
            string connectionString = configuration.GetProperty("connection.connection_string");

            // Configure NHibernate using Fluent NHibernate
            FluentConfiguration fluentConfig = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OfferMap>());

            // Import mappings from XML file
            Configuration nhConfig = fluentConfig.BuildConfiguration();
            nhConfig.AddXmlFile("E:\\UBB\\ISS\\Project\\HotelBooking\\mapping\\Hotel.hbm.xml"); // Replace "path_to_Hotel_hbm.xml" with the actual path

            // Build session factory
            return nhConfig.BuildSessionFactory();
        }
    }

}
