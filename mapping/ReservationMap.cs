using FluentNHibernate.Mapping;
using HotelBooking.model;
using NHibernate.Mapping.ByCode.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;
using NHibernate;

namespace HotelBooking.mapping
{
    public class ReservationMap : ClassMap<Reservation>
    {
        public ReservationMap() { 
            Table("Reservation");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.UserID).Column("userID");
            Map(x => x.OfferID).Column("offerID");
            Map(x => x.Date).CustomType<DateTimeType>();

        }
    }
}
