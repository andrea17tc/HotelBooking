using HotelBooking.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E? FindOne(ID id);
        IEnumerable<E> FindAll();

        void Save(E entity);

        void Delete(ID id);

        void Update(E entity);

    }
}
