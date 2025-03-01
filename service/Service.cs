using HotelBooking.model;
using HotelBooking.repository;
using HotelBooking.utils;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.service
{
    public class Service : IObservable
    {
        UserRepository userRepository;
        HotelRepository hotelRepository;
        OfferRepository offerRepository;
        ReservationRepository reservationRepository;

        List<IObserver> observers = new List<IObserver>();

        public Service(UserRepository userRepository, HotelRepository hotelRepository, OfferRepository offerRepository, ReservationRepository reservationRepository)
        {
            this.userRepository = userRepository;
            this.hotelRepository = hotelRepository;
            this.offerRepository = offerRepository;
            this.reservationRepository = reservationRepository;
        }

        public int Login(string username, string password)
        {
            var user = userRepository.FindByUsername(username);
            if (user == null)
            {
                return 0;
            }
            if (user.Password == password)
            {
                return user.Id;
            }
            return 0;
        }

        public Boolean FindByUsername(string username)
        {
            if (userRepository.FindByUsername(username) == null)
            {
                return false;
            }
            return true;
        }

        public void createUser(string username, string password, string firstName, string lastName, string? dateOfBirth, string? address)
        {
            User user =new User(username, password, firstName, lastName, dateOfBirth, address); 
            userRepository.Save(user);
        }

        public List<Hotel> FindAllHotels()
        {
            return hotelRepository.FindAll().ToList();
        }

        public void AddHotel(Hotel hotel)
        {
            hotelRepository.Save(hotel);
        }

        public void UpdateHotel(Hotel hotel)
        {
            hotelRepository.Update(hotel);
        }   

        public void DeleteHotel(int id)
        {
            hotelRepository.Delete(id);
        }

        public List<Offer> FindAllOffers()
        {
            return offerRepository.FindAll().ToList();
        }

        public List<Offer> FindAllAvailableOffers()
        {
            List<Offer> offers = new List<Offer>();
            List<Offer> allOffers = offerRepository.FindAll().ToList();
            foreach (Offer offer in allOffers)
            {
                if (reservationRepository.FindOneByOffer(offer.Id) == null)
                {
                    offers.Add(offer);
                }
            }
            return offers;

        }

        public List<Offer> FindAllOffersByHotel(int hotelId)
        {
            return offerRepository.FindAllByHotel(hotelId).ToList();
        }

        public void AddOffer(int hotelId, DateOnly date, int noNights)
        {
            Hotel hotel = hotelRepository.FindOne(hotelId);
            Offer offer = new Offer(hotel, date, noNights);
            offerRepository.Save(offer);
            NotifyObservers();
            
        }

        public void UpdateOffer(int id, int hotelId, DateOnly date, int noNights)
        {
            Hotel hotel = hotelRepository.FindOne(hotelId);
            Offer offer = new Offer(hotel, date, noNights);
            offer.Id = id;
            offerRepository.Update(offer);
            NotifyObservers();
        }

        public void DeleteOffer(int id)
        {
            offerRepository.Delete(id);
            NotifyObservers();
        }

        public void BookOffer(int userId, int offerId)
        { 
            Reservation r = new Reservation();
            r.UserID = userId;
            r.OfferID = offerId;
            r.Date = DateTime.Now;
            reservationRepository.Save(r);
        }

        public void AddObserver(IObserver obs)
        {
            observers.Add(obs);
        }

        public void RemoveObserver(IObserver obs)
        {
            observers.Remove(obs);
        }

        public void NotifyObservers()
        {
            foreach (IObserver obs in observers)
            {
                obs.Update();
            }
        }
    }
}
