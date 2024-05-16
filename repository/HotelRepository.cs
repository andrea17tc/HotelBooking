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
    public class HotelRepository : IRepository<int, Hotel>
    {
        private readonly ISessionFactory sessionFactory;
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepository));

        public HotelRepository()
        {
            Log.Info("Creating HotelRepository");
            this.sessionFactory = SessionFactory.BuildSessionFactory();
        }
        public void delete(int id)
        {
            Log.Info("Deleting hotel with id " + id);
            using (var session = sessionFactory.OpenSession())
            {
                var hotelToDelete = session.Get<Hotel>(id);
                if (hotelToDelete != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(hotelToDelete);
                        transaction.Commit();
                    }
                    Log.Info("Hotel with id " + id + " deleted successfully");
                }
                else
                {
                    Log.Error("Hotel with id " + id + " not found");
                    throw new Exception("Hotel not found");
                }
            }
        }

        public IEnumerable<Hotel> findAll()
        {
            Log.Info("Finding all hotels");
            using (var session = sessionFactory.OpenSession())
            {
                return session.Query<Hotel>().ToList();
            }
        }

        public Hotel? findOne(int id)
        {
            Log.Info("Finding hotel with id " + id);
            using (var session = sessionFactory.OpenSession())
            {
                return session.Get<Hotel>(id);
            }
        }

        public void save(Hotel entity)
        {
            Log.Info("Saving hotel with name " + entity.Name);
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public void update(Hotel entity)
        {
            Log.Info("Updating hotel with id " + entity.Id);
            using (var session = sessionFactory.OpenSession())
            {
                var hotelToUpdate = session.Get<Hotel>(entity.Id);
                if (hotelToUpdate != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        hotelToUpdate.Name = entity.Name;
                        hotelToUpdate.Location = entity.Location;
                        hotelToUpdate.Address = entity.Address;
                        hotelToUpdate.NoRooms = entity.NoRooms;
                        session.Update(hotelToUpdate);
                        transaction.Commit();
                    }
                    Log.Info("Hotel with id " + entity.Id + " updated successfully");
                }
                else
                {
                    Log.Error("Hotel with id " + entity.Id + " not found");
                    throw new Exception("Hotel not found");
                }
            }
        }
    }
}
