using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.model;

public class Offer : Entity<int>
{
    Hotel hotel;
    string startDate;
    int noNights;

    // Constructor
    public Offer(Hotel hotel, string date, int noNights)
    {
        this.hotel = hotel;
        this.startDate = date;
        this.noNights = noNights;
    }

    // Getters and setters

    public Hotel Hotel
    {
        get { return hotel; }
        set { hotel = value; }
    }
    public string StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }
    public int NoNights
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
