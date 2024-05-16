using HotelBooking.model;
using HotelBooking.repository;
using NHibernate;
using NHibernate.Cfg;
using log4net;
using System.Configuration;
using HotelBooking.service;
using log4net.Config;

namespace HotelBooking
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            log.Info("Application started");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            UserRepository userRepository = new UserRepository();
            HotelRepository hotelRepository = new HotelRepository();
            OfferRepository offerRepository = new OfferRepository();
            Service service = new Service(userRepository, hotelRepository, offerRepository);
            Application.Run(new Login(service));
            log.Info("Application ended");
        }
    }
}