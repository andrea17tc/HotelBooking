using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.model;

public class Hotel : Entity<int>
{
    string name;
    string location;
    string address;
    int noRooms;

    // Constructor
    public Hotel()
    {
    }
    public Hotel(string name, string location, string address, int noRooms)
    {
        this.name = name;
        this.location = location;
        this.address = address;
        this.noRooms = noRooms;
    }

    // Getters and setters
    public virtual string Name
    {
        get { return name; }
        set { name = value; }
    }
    public virtual string Location
    {
        get { return location; }
        set { location = value; }
    }

    public virtual string Address
    {
        get { return address; }
        set { address = value; }
    }

    public virtual int NoRooms
    {
        get { return noRooms; }
        set { noRooms = value; }
    }

    // Override ToString
    public override string ToString()
    {
        return $"Hotel {name}, location={location}, adress={address}, noRooms={noRooms}";
    }

    // Override Equals
    public override bool Equals(object obj)
    {
        if (this == obj)
            return true;

        if (!(obj is Hotel))
            return false;

        Hotel hotel = (Hotel)obj;
        return Equals(Id, hotel.Id);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

