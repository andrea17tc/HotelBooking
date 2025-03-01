using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.model;

public class Offer : Entity<int>
{
    Hotel hotel;
    DateOnly startDate;
    int noNights;

    // Constructor

    public Offer()
    {
    }
    public Offer(Hotel hotel, DateOnly date, int noNights)
    {
        this.hotel = hotel;
        this.startDate = date;
        this.noNights = noNights;
    }

    // Getters and setters

    public virtual Hotel Hotel
    {
        get { return hotel; }
        set { hotel = value; }
    }

    public virtual string HotelName
    {
        get { return hotel.Name; }
        set { hotel.Name = value; }
    }

    public virtual int HotelId
    {
        get { return hotel.Id; }
        set { hotel.Id = value; }
    }
    public virtual DateOnly StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }
    public virtual int NoNights
    {
        get { return noNights; }
        set { noNights = value; }
    }
    // Override ToString
    public override string ToString()
    {
        return $"{hotel.Name} from {startDate} for {noNights} nights";
    }
}
