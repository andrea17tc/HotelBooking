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
    DateTime date;

    // Constructor
    public Reservation(int userID, int offerID, DateTime date)
    {
        this.userID = userID;
        this.offerID = offerID;
        this.date = date;
    }

    public Reservation()
    {
    }

    // Getters and setters
    public virtual int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public virtual int OfferID
    {
        get { return offerID; }
        set { offerID = value; }
    }

    public virtual DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

}
