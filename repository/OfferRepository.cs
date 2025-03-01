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
    public class OfferRepository : IRepository<int, Offer>
    {
        private readonly ISessionFactory sessionFactory;
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepository));

        public OfferRepository()
        {
            Log.Info("Creating OfferRepository");
            this.sessionFactory = NHibernateHelper.CreateSessionFactory();
        }

        public IEnumerable<Offer> FindAll()
        {
            Log.Info("Finding all offers");
            List<Offer> offers = new List<Offer>();
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.Query<Offer>();
                foreach (Offer offer in query)
                {
                    NHibernateUtil.Initialize(offer.Hotel);
                    offers.Add(offer);

                }
            }
            return offers;
        }

        public IEnumerable<Offer> FindAllByHotel(int hotelID)
        {
            Log.Info("Finding all offers for hotel with id " + hotelID);
            List<Offer> offers = new List<Offer>();
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.Query<Offer>().Where(o => o.Hotel.Id == hotelID);
                foreach (var offer in query)
                {
                    Offer newOffer = new Offer(offer.Hotel, DateOnly.Parse(offer.StartDate.ToString()), offer.NoNights);
                    offers.Add(offer);
                }
            }
            return offers;
        }

        public Offer FindOne(int id)
        {
            Log.Info("Finding offer with id " + id);
            using (var session = sessionFactory.OpenSession())
            {
                Offer offer =  session.Get<Offer>(id);
                if (offer != null)
                {
                    NHibernateUtil.Initialize(offer.Hotel);
                    return offer;
                }
                else
                {
                    Log.Error("Offer with id " + id + " not found");
                    throw new Exception("Offer not found");
                }
            }
        }

        public void Save(Offer entity)
        {
            Log.Info("Saving offer");
            //save offer to database, converting DateOnly to string
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Offer offer = new Offer(entity.Hotel, entity.StartDate, entity.NoNights);
                    session.Save(offer);
                    transaction.Commit();
                }
            }
        }

        public void Update(Offer entity)
        {
            Log.Info("Updating offer with id " + entity.Id);
            //update offer in database
            using (var session = sessionFactory.OpenSession())
            {
                var offerToUpdate = session.Get<Offer>(entity.Id);
                if (offerToUpdate != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        offerToUpdate.Hotel = entity.Hotel;
                        offerToUpdate.StartDate = entity.StartDate;
                        offerToUpdate.NoNights = entity.NoNights;
                        session.Update(offerToUpdate);
                        transaction.Commit();
                    }
                    Log.Info("Offer with id " + entity.Id + " updated successfully");
                }
                else
                {
                    Log.Error("Offer with id " + entity.Id + " not found");
                    throw new Exception("Offer not found");
                }
            }

        }

        public void Delete(int id)
        {
            Log.Info("Deleting offer with id " + id);
            //delete offer from database
            using (var session = sessionFactory.OpenSession())
            {
                var offerToDelete = session.Get<Offer>(id);
                if (offerToDelete != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(offerToDelete);
                        transaction.Commit();
                    }
                    Log.Info("Offer with id " + id + " deleted successfully");
                }
                else
                {
                    Log.Error("Offer with id " + id + " not found");
                    throw new Exception("Offer not found");
                }
            }
            
        }




    }
}
