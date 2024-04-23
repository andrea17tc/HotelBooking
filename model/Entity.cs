using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.model;

public class Entity<ID>
{
    protected ID id;
    public virtual ID Id
    {
        get { return id; }
        set { id = value; }
    }

    public override bool Equals(object obj)
    {
        if (this == obj)
            return true;

        if (!(obj is Entity<ID>))
            return false;

        Entity<ID> entity = (Entity<ID>)obj;
        return Equals(Id, entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"Entity{{id={id}}}";
    }

}
