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

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public User? FindOne(int id)
        {
            Log.Info("Finding user with id " + id);
            using (var session = sessionFactory.OpenSession())
            {          
                return session.Get<User>(id);
            }
        }
        public User? FindByUsername(string username)
        {
            Log.Info("Finding user with username " + username);
            using (var session = sessionFactory.OpenSession())
            {
                return session.Query<User>().FirstOrDefault(u => u.Username == username);
            }
        }

        public void Save(User entity)
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        
    }
}
