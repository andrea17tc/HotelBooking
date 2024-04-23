using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.model;

public class Reservation : Entity<int>
{
    int userID;
    int offerID;
    string date;
    int noRooms;

    // Constructor
    public Reservation(int userID, int offerID, string date, int noRooms)
    {
        this.userID = userID;
        this.offerID = offerID;
        this.date = date;
        this.noRooms = noRooms;
    }

    // Getters and setters
    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public int OfferID
    {
        get { return offerID; }
        set { offerID = value; }
    }

    public string Date
    {
        get { return date; }
        set { date = value; }
    }

    public int NoRooms
    {
        get { return noRooms; }
        set { noRooms = value; }
    }

}
