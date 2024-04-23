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
    string adress;
    int noRooms;

    // Constructor
    public Hotel(string name, string location, string adress, int noRooms)
    {
        this.name = name;
        this.location = location;
        this.adress = adress;
        this.noRooms = noRooms;
    }

    // Getters and setters
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Location
    {
        get { return location; }
        set { location = value; }
    }

    public string Adress
    {
        get { return adress; }
        set { adress = value; }
    }

    public int NoRooms
    {
        get { return noRooms; }
        set { noRooms = value; }
    }

    // Override ToString
    public override string ToString()
    {
        return $"Hotel {name}, location={location}, adress={adress}, noRooms={noRooms}";
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
}

