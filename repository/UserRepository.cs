using HotelBooking.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using HotelBooking.utils;
using log4net;

namespace HotelBooking.repository
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly ISessionFactory sessionFactory;
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepository));

        public UserRepository()
        {
            Log.Info("Creating UserRepository");
            this.sessionFactory =SessionFactory.BuildSessionFactory();
        }

        public IEnumerable<User> findAll()
        {
            throw new NotImplementedException();
        }

        public User? findOne(int id)
        {
            Log.Info("Finding user with id " + id);
            using (var session = sessionFactory.OpenSession())
            {          
                return session.Get<User>(id);
            }
        }
        public User? findByUsername(string username)
        {
            Log.Info("Finding user with username " + username);
            using (var session = sessionFactory.OpenSession())
            {
                return session.Query<User>().FirstOrDefault(u => u.Username == username);
            }
        }

        public void save(User entity)
        {
            //save user to database
            Log.Info("Saving user with username " + entity.Username);
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }

        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public void update(User entity)
        {
            throw new NotImplementedException();
        }
        
    }
}
