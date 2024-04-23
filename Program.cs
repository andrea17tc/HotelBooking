using HotelBooking.model;
using HotelBooking.repository;
using NHibernate;
using NHibernate.Cfg;
using log4net;
using System.Configuration;
using HotelBooking.service;

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
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log.Info("Application started");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            UserRepository userRepository = new UserRepository();
            Service service = new Service(userRepository);
            Application.Run(new Login(service));
        }
    }
}