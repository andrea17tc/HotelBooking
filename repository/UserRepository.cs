using HotelBooking.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using HotelBooking.utils;

namespace HotelBooking.repository
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly ISessionFactory sessionFactory;
        public UserRepository()
        {
            this.sessionFactory =SessionFactory.BuildSessionFactory();
        }

        public IEnumerable<User> findAll()
        {
            throw new NotImplementedException();
        }

        public User? findOne(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {          
                return session.Get<User>(id);
            }
        }
        public User? findByUsername(string username)
        {
            using (var session = sessionFactory.OpenSession())
            {
                return session.Query<User>().FirstOrDefault(u => u.Username == username);
            }
        }

        public void save(User entity)
        {
            //save user to database
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
