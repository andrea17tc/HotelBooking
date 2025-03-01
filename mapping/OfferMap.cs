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
    public class OfferMap : ClassMap<Offer>
    {
        public OfferMap()
        {
            Table("Offer");
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.Hotel, "hotelID").Column("hotelID").Fetch.Join();
            Map(x => x.StartDate).CustomType<DateOnlyType>();
            Map(x => x.NoNights).Column("noNights");
            Map(x => x.HotelName).Formula("(select h.name from Hotel h where h.id = hotelID)");
        }
    }
   
}
