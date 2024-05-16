using HotelBooking.model;
using HotelBooking.repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.service
{
    public class Service
    {
        UserRepository userRepository;
        HotelRepository hotelRepository;
        OfferRepository offerRepository;

        public Service(UserRepository userRepository, HotelRepository hotelRepository, OfferRepository offerRepository)
        {
            this.userRepository = userRepository;
            this.hotelRepository = hotelRepository;
            this.offerRepository = offerRepository;
        }

        public int login(string username, string password)
        {
            var user = userRepository.findByUsername(username);
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

        public Boolean findByUsername(string username)
        {
            if (userRepository.findByUsername(username) == null)
            {
                return false;
            }
            return true;
        }

        internal void createUser(string username, string password, string firstName, string lastName, string? dateOfBirth, string? address)
        {
            User user =new User(username, password, firstName, lastName, dateOfBirth, address); 
            userRepository.save(user);
        }

        public List<Hotel> FindAllHotels()
        {
            return hotelRepository.findAll().ToList();
        }

        public void AddHotel(Hotel hotel)
        {
            hotelRepository.save(hotel);
        }

        public void UpdateHotel(Hotel hotel)
        {
            hotelRepository.update(hotel);
        }   

        public void DeleteHotel(int id)
        {
            hotelRepository.delete(id);
        }

        public List<Offer> FindAllOffers(int hotelId)
        {
            return offerRepository.FindAll(hotelId).ToList();
        }

        public void AddOffer(int hotelId, DateOnly date, int noNights)
        {
            Hotel hotel = hotelRepository.findOne(hotelId);
            Offer offer = new Offer(hotel, date, noNights);
            offerRepository.Save(offer);
        }

        public void UpdateOffer(int id, int hotelId, DateOnly date, int noNights)
        {
            Hotel hotel = hotelRepository.findOne(hotelId);
            Offer offer = new Offer(hotel, date, noNights);
            offer.Id = id;
            offerRepository.Update(offer);
        }

        public void DeleteOffer(int id, int hotelId, DateOnly date, int noNights)
        {
            Hotel hotel = hotelRepository.findOne(hotelId);
            Offer offer = new Offer(hotel, date, noNights);
            offer.Id = id;
            offerRepository.Delete(offer);
        }

    }
}
