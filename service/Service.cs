using HotelBooking.model;
using HotelBooking.repository;
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
        public Service(UserRepository userRepository)
        {
            this.userRepository = userRepository;
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
    }
}
