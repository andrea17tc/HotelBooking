using HotelBooking.model;
using HotelBooking.utils;
using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.repository
{
    public class ReservationRepository
    {
        private readonly ISessionFactory sessionFactory;
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepository));

        public ReservationRepository()
        {
            Log.Info("Creating ReservationRepository");
            this.sessionFactory = NHibernateHelper.CreateSessionFactory();
        }

        public void Save(Reservation reservation)
        {
            Log.Info("Saving reservation with id " + reservation.Id);
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(reservation);
                    transaction.Commit();
                }
            }
        }

        public IEnumerable<Reservation> FindAll()
        {
            Log.Info("Finding all reservations");
            List<Reservation> reservations = new List<Reservation>();
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.Query<Reservation>();
                foreach (Reservation reservation in query)
                {
                    reservations.Add(reservation);
                }
            }
            return reservations;
        }

        public Reservation FindOne(int id)
        {
            Log.Info("Finding reservation with id " + id);
            using (var session = sessionFactory.OpenSession())
            {
                return session.Get<Reservation>(id);
            }
        }

        public Reservation FindOneByOffer(int offerID)
        {
            Log.Info("Finding reservation with offer id " + offerID);
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.Query<Reservation>().Where(r => r.OfferID == offerID);
                return query.FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            Log.Info("Deleting reservation with id " + id);
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var reservation = session.Get<Reservation>(id);
                    session.Delete(reservation);
                    transaction.Commit();
                }
            }
        }

    }
}
